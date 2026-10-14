using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SemacV14.Define;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using CommandType = System.Data.CommandType;

namespace Demo_CSharp
{
    public class clsDal
    {
        string conString = ConfigurationManager.ConnectionStrings["constr"] != null
     ? ConfigurationManager.ConnectionStrings["constr"].ConnectionString
     : throw new Exception("Connection string 'constr' not found in config file. Check App.config / exe.config.");
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;
        int flag = 0;

        public DataTable funInsertUser(clsCommon cm)
        {
            try
            {
                using (con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("uspUser", con))
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        dt = new DataTable();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@intMode", 1);
                        cmd.Parameters.AddWithValue("@ProductSearchKey", cm.UserId);
                        cmd.Parameters.AddWithValue("@ProductName", cm.UserName);
                        cmd.Parameters.AddWithValue("@SerialNumber", cm.CardNo);
                        cmd.Parameters.AddWithValue("@Quantity", cm.EmployeeID);
                        da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                      if (con.State == ConnectionState.Open)
                            con.Close();  
                        return dt; 
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public void UpdateControllerStatus(string code,string  CurrentStatus, string LogMessage="")
        {
            //UpdateReader](@code varchar(10),@CurrentStatus varchar(50)
            try
            {
                using (con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    // UpdateReader](@code varchar(10),@CurrentStatus varchar(50)
                    //using (SqlCommand cmd = new SqlCommand("UpdateReaderStatus", con))
                    //{
                    //    dt = new DataTable();
                    //    cmd.CommandType = CommandType.StoredProcedure;
                    //    cmd.Parameters.AddWithValue("@code", code);
                    //    cmd.Parameters.AddWithValue("@CurrentStatus", CurrentStatus); 
                    //    cmd.Parameters.AddWithValue("@LogMessage", LogMessage);
                    // var r =   cmd.BeginExecuteNonQuery();
                    //}


                    using (SqlCommand cmd = new SqlCommand("UpdateReaderStatus", con))
                    {
                        dt = new DataTable();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@code", code);
                        cmd.Parameters.AddWithValue("@CurrentStatus", CurrentStatus);
                        cmd.Parameters.AddWithValue("@LogMessage", LogMessage);
                        cmd.ExecuteNonQuery();
                    }

                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            } 
        }

        public DataTable getControllerList()
        {
            try
            {
                using (con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("getReader", con))
                    {

                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        dt = new DataTable();
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@intMode", 1);
                        //cmd.Parameters.AddWithValue("@ProductSearchKey", cm.UserId);
                        //cmd.Parameters.AddWithValue("@ProductName", cm.UserName);
                        //cmd.Parameters.AddWithValue("@SerialNumber", cm.CardNo);
                        //cmd.Parameters.AddWithValue("@Quantity", cm.EmployeeID);
                        da = new SqlDataAdapter(cmd);
                        da.Fill(dt);

                        if (con.State == ConnectionState.Open)
                            con.Close();
                        return dt;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DataTable getAccessNewUserFileUpload()
        {
            //UserId, UserName, CardNo, EmployeeID, UserType, BypassTimeZoneLevel default send 1,OverWrite(true),Group01 = 0b1,Door01TZ = 1
            try
            {
                using (con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("getAccessNewUserFile", con))
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        dt = new DataTable();
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@intMode", 1);
                        //cmd.Parameters.AddWithValue("@ProductSearchKey", cm.UserId);
                        //cmd.Parameters.AddWithValue("@ProductName", cm.UserName);
                        //cmd.Parameters.AddWithValue("@SerialNumber", cm.CardNo);
                        //cmd.Parameters.AddWithValue("@Quantity", cm.EmployeeID);
                        da = new SqlDataAdapter(cmd);
                        da.Fill(dt);

                        if (con.State == ConnectionState.Open)
                            con.Close();
                        return dt;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable getAccessBlockListUpload()
         {
            //UserId, UserName, CardNo, EmployeeID, UserType, BypassTimeZoneLevel default send 1,OverWrite(true),Group01 = 0b1,Door01TZ = 1
            try
            {
                using (con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("getAccessBlockFile", con))
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        dt = new DataTable();
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@intMode", 1);
                        //cmd.Parameters.AddWithValue("@ProductSearchKey", cm.UserId);
                        //cmd.Parameters.AddWithValue("@ProductName", cm.UserName);
                        //cmd.Parameters.AddWithValue("@SerialNumber", cm.CardNo);
                        //cmd.Parameters.AddWithValue("@Quantity", cm.EmployeeID);
                        da = new SqlDataAdapter(cmd);
                        da.Fill(dt);

                        if (con.State == ConnectionState.Open)
                            con.Close();
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }   
        public DataTable getAccessFileUpload()
         {
            //UserId, UserName, CardNo, EmployeeID, UserType, BypassTimeZoneLevel default send 1,OverWrite(true),Group01 = 0b1,Door01TZ = 1
            try
            {
                using (con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("getAccessFile", con))
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        dt = new DataTable();
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@intMode", 1);
                        //cmd.Parameters.AddWithValue("@ProductSearchKey", cm.UserId);
                        //cmd.Parameters.AddWithValue("@ProductName", cm.UserName);
                        //cmd.Parameters.AddWithValue("@SerialNumber", cm.CardNo);
                        //cmd.Parameters.AddWithValue("@Quantity", cm.EmployeeID);
                        da = new SqlDataAdapter(cmd);
                        da.Fill(dt);

                        if (con.State == ConnectionState.Open)
                            con.Close();
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                var r = ex.Message.ToString();
                return null;
            }
        }
        public DataTable getCardLostDamageUpload()
        {
            //UserId, UserName, CardNo, EmployeeID, UserType, BypassTimeZoneLevel default send 1,OverWrite(true),Group01 = 0b1,Door01TZ = 1
            try
            {
                using (con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("getLostDamageFile", con))
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        dt = new DataTable();
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@intMode", 1);
                        //cmd.Parameters.AddWithValue("@ProductSearchKey", cm.UserId);
                        //cmd.Parameters.AddWithValue("@ProductName", cm.UserName);
                        //cmd.Parameters.AddWithValue("@SerialNumber", cm.CardNo);
                        //cmd.Parameters.AddWithValue("@Quantity", cm.EmployeeID);
                        da = new SqlDataAdapter(cmd);
                        da.Fill(dt);

                        if (con.State == ConnectionState.Open)
                            con.Close();
                        return dt;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        //public DataTable GetTerminalAccessFile(string rid)
        //{
        //    try
        //    {
        //        using (SqlConnection con2 = new SqlConnection(conString))
        //        using (SqlCommand cmd = new SqlCommand("getTerminalAccessFile", con2))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@RID", rid);
        //            con2.Open();
        //            DataTable dt2 = new DataTable();
        //            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
        //            da2.Fill(dt2);
        //            return dt2;
        //        }
        //    }
        //    catch { return null; }
        //}


        public DataTable GetTerminalAccessFile(string rid)
        {
            try
            {
                using (SqlConnection con2 = new SqlConnection(conString))
                using (SqlCommand cmd = new SqlCommand("getTerminalAccessFile", con2))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RID", rid);
                    con2.Open();
                    DataTable dt2 = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt2);
                    return dt2;
                }
            }
            catch { return null; }
        }

        public DataTable GetTerminalBlockFile(string rid)
        {
            try
            {
                using (SqlConnection con2 = new SqlConnection(conString))
                using (SqlCommand cmd = new SqlCommand("getTerminalBlockFile", con2))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RID", rid);
                    con2.Open();
                    DataTable dt2 = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt2);
                    return dt2;
                }
            }
            catch { return null; }
        }

        public DataTable GetTerminalRevokeFile(string rid)
        {
            try
            {
                using (SqlConnection con2 = new SqlConnection(conString))
                using (SqlCommand cmd = new SqlCommand("getTerminalRevokeFile", con2))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RID", rid);
                    con2.Open();
                    DataTable dt2 = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt2);
                    return dt2;
                }
            }
            catch { return null; }
        }

        public void MarkSynced(int idNumber, string rid, string uploadFlag, string blockRevokeFlag)
        {
            try
            {
                using (SqlConnection con2 = new SqlConnection(conString))
                using (SqlCommand cmd = new SqlCommand("SyncIDs", con2))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Idnumber", idNumber);
                    cmd.Parameters.AddWithValue("@rid", rid);
                    cmd.Parameters.AddWithValue("@syncAccUpload", uploadFlag);
                    cmd.Parameters.AddWithValue("@syncAccBlockRevokUpload", blockRevokeFlag);
                    con2.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch { }
        }
        public void MarkSynced(int idNumber, string rid, string uploadFlag)
        {
            try
            {
                using (SqlConnection con2 = new SqlConnection(conString))
                using (SqlCommand cmd = new SqlCommand("SyncIDs", con2))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Idnumber", idNumber);
                    cmd.Parameters.AddWithValue("@rid", rid);
                    cmd.Parameters.AddWithValue("@syncAccUpload", uploadFlag);
                    cmd.Parameters.AddWithValue("@syncAccBlockRevokUpload", "");
                    con2.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch { }
        }

        public DataTable getAccessRevokeFileUpload()
        {
            //UserId, UserName, CardNo, EmployeeID, UserType, BypassTimeZoneLevel default send 1,OverWrite(true),Group01 = 0b1,Door01TZ = 1
            try
            {
                using (con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("getAccessRevokeList", con))
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        dt = new DataTable();
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@intMode", 1);
                        //cmd.Parameters.AddWithValue("@ProductSearchKey", cm.UserId);
                        //cmd.Parameters.AddWithValue("@ProductName", cm.UserName);
                        //cmd.Parameters.AddWithValue("@SerialNumber", cm.CardNo);
                        //cmd.Parameters.AddWithValue("@Quantity", cm.EmployeeID);
                        da = new SqlDataAdapter(cmd);
                        da.Fill(dt);

                        if (con.State == ConnectionState.Open)
                            con.Close();
                        return dt;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}