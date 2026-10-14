using System;
using System.Data;
using SemacV14.Request;
using SemacV14.Service;
using static SemacV14.Define;

namespace Demo_CSharp
{
    public class SemacSyncEngine
    {
        private readonly clsDal _dal;
        public event Action<string> OnLog;

        public SemacSyncEngine(clsDal dal)
        {
            _dal = dal;
        }

        public SyncResult SyncNewUsers(SemacTerminal terminal)
        {
            SyncResult result = new SyncResult { ReaderCode = terminal.ReaderCode };
            if (!terminal.IsConnected)
            {
                result.Error = "Controller not connected";
                return result;
            }

            DataTable pending;
            try { pending = _dal.GetTerminalAccessFile(terminal.ReaderCode); }
            catch (Exception ex) { result.Error = "DB read failed: " + ex.Message; Log(result.Error); return result; }

            if (pending == null) { result.Error = "DB returned null"; return result; }

            foreach (DataRow dr in pending.Rows)
            {
                try
                {
                    RegisterModifyUserDataRequest req = new RegisterModifyUserDataRequest(terminal.TerminalID);
                    req.UserID = (uint)Convert.ToInt32(dr["UserId"]);
                    req.EnabledStatus = true;
                    req.UserName = dr["UserName"].ToString();
                    req.CardNo = dr["CardNo"].ToString();
                    req.EmployeeID = dr["EmployeeID"].ToString();
                    req.UserType = (UserType)0;
                    req.BypassTimeZoneLevel = (BypassTimeZoneLevel)1;
                    req.OverWrite = true;
                    req.Group01 = 0b1;
                    req.Door01TZ = 1;

                    // Yahin, seedha — jaisa original frmMain.cs mein tha, koi wrapper method nahi
                    ExecuteArgz ea = new ExecuteArgz(terminal.ChannelID, req);
                    Actor actor = new Actor(ea);
                    ea = actor.SendAndReceive();

                    if (ea.IsCompleted)
                    {
                        _dal.MarkSynced(Convert.ToInt32(dr["UserId"]), terminal.ReaderCode, "Y");
                        result.SuccessCount++;
                    }
                    else
                    {
                        result.FailCount++;
                        Log("[" + terminal.ReaderCode + "] UserId " + dr["UserId"] + " failed: " + ea.ErrorMessage);
                    }
                }
                catch (Exception ex)
                {
                    result.FailCount++;
                    Log("[" + terminal.ReaderCode + "] UserId " + dr["UserId"] + " exception: " + ex.Message);
                }
            }

            terminal.LastSyncedOn = DateTime.Now;
            return result;
        }

        private void Log(string msg)
        {
            if (OnLog != null) OnLog(DateTime.Now.ToString("HH:mm:ss") + " " + msg);
        }
    }

    public class SyncResult
    {
        public string ReaderCode { get; set; }
        public int SuccessCount { get; set; }
        public int FailCount { get; set; }
        public string Error { get; set; }
    }
}