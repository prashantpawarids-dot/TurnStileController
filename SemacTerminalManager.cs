using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Demo_CSharp
{
    public class SemacTerminalManager
    {
        private readonly ConcurrentDictionary<string, SemacTerminal> _terminals = new ConcurrentDictionary<string, SemacTerminal>();
        private readonly clsDal _dal;

        public event Action<SemacTerminal> OnTerminalConnected;

        public SemacTerminalManager(clsDal dal)
        {
            _dal = dal;
        }

        public void LoadKnownReadersFromDb()
        {
            DataTable dt = _dal.getControllerList();
            if (dt == null) return;
            foreach (DataRow r in dt.Rows)
            {
                string code = r["code"].ToString();
                SemacTerminal t = new SemacTerminal
                {
                    ReaderCode = code,
                    IPAddress = r["readerip"].ToString(),
                    Location = r["readerLocation"] != null ? r["readerLocation"].ToString() : "",
                    IsConnected = false
                };
                _terminals.TryAdd(code, t);
            }
        }

        public void HandleConnected(SemacV14.Entity.TerminalEntity en)
        {
            SemacTerminal match = _terminals.Values.FirstOrDefault(t => t.IPAddress == en.IPAddress);
            if (match == null) return; // unknown device, not in tblReader — ignore

            match.ChannelID = en.ChannelID;
            match.TerminalID = en.TerminalID;
            match.IsConnected = true;
            if (OnTerminalConnected != null) OnTerminalConnected(match);
        }

        public void HandleDisconnected(SemacV14.Entity.TerminalEntity en)
        {
            SemacTerminal match = _terminals.Values.FirstOrDefault(t => t.ChannelID == en.ChannelID);
            if (match != null) match.IsConnected = false;
        }

        public IEnumerable<SemacTerminal> ConnectedTerminals
        {
            get { return _terminals.Values.Where(t => t.IsConnected); }
        }

        public IEnumerable<SemacTerminal> AllTerminals
        {
            get { return _terminals.Values; }
        }

        public SemacTerminal Get(string readerCode)
        {
            SemacTerminal result;
            _terminals.TryGetValue(readerCode, out result);
            return result;
        }
    }
}