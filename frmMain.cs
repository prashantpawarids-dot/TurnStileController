//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.IO;
//using System.Text;
//using System.Windows.Forms;
//using SemacV14;
//using SemacV14.Entity;
//using SemacV14.Service;
//using SomeControls;
//using static SemacV14.Define;

//using System;
//using System.Threading.Tasks;
//using System.Timers;
//using System.Windows.Threading;
//using System.Threading;
//using Timer = System.Threading.Timer;

//namespace Demo_CSharp
//{

//    public partial class frmMain : Form
//    {

//        System.Timers.Timer _timer;
//        // Interval: 1 hour = 3600000 ms
//        DateTime lastAccessUploadOn = DateTime.Now;
//        DateTime lastAccessDownloadOn = DateTime.Now;

//        public delegate void TerminalConnectHandler(SemacV14.Entity.TerminalEntity En);
//        public delegate void ExecuteHandler(SemacV14.Service.ExecuteArgz Ea);
//        public delegate void DoorStatusHandler(SemacV14.Entity.DoorStatusEntity En);

//        //Terminal Table
//        private DataTable TerminalTable = null;
//        private clsDal DBDal;

//        bool isAccessupload = false;
//        bool isAccessTrdownload = false;

//        bool isAccessBlockedupload = false;
//        bool isAccessRevokupload = false;

//        public frmMain()
//        {
//            DBDal = new clsDal();
//            InitializeComponent();
//            ini();

//            // Task 1 every 1 hour
//             Timer task1Timer = new Timer(AccessUpload, null, TimeSpan.Zero, TimeSpan.FromHours(12));

//            // Task 2 every 2 hours
//            Timer task2Timer = new Timer(AccessActionsUpload, null, TimeSpan.Zero, TimeSpan.FromMinutes(30));

//            // Task 3 every 30 minutes
//            Timer task3Timer = new Timer(AccessEmediateActionsUpload, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));

//        }


//        private void AccessUpload (object state )
//        {
//                 btnAccessFileUpload_Click(null, null);


//                 btnAccLogDownload_Click(null, null);



//            btnAccLogDownload_Click (null, null);

//        }

//        private void AccessActionsUpload(object state)
//        {
//            btnAccessBlockUpload_Click(null, null);

//            btnAccessRevokUpload_Click(null, null);
//        }
//        private void AccessEmediateActionsUpload(object state)
//        { 
//            btnNewlyAddedUpload_Click(null, null);
//        }
//        private void frmMain_Load(object sender, EventArgs e)
//        {
//            BeginListen();

//            //TerminalEntity en = new TerminalEntity();
//            //en.Port = "5000"; en.IPAddress = "127.0.0.1";
//            // OnConnected(en);

//        }

//        private void ini()
//        {
//            try
//            {
//                //Terminal List
//                this.TerminalTable = new DataTable();
//                string[] cols = new string[] {
//                "ChannelID",
//                "Status",
//                "TerminalID",
//                "IPAddress",
//                "MacAddress",
//                "SerialNo",
//                "ModelName",
//                "FirmwareVersion"
//            };
//                foreach (string s in cols)
//                {
//                    DataColumn col = new DataColumn();
//                    col.ColumnName = s;
//                    this.TerminalTable.Columns.Add(col);
//                }

//                DataTable dt = DBDal.getControllerList();
//                if (dt != null)
//                {
//                    if (dt.Rows.Count > 0)
//                    {
//                        foreach (DataRow dr in dt.Rows)
//                        {

//                            lock (this.TerminalTable)
//                            {
//                                //code, readerip, readerport,	readermode, readerLocation, readertype, isActive, IsDeleted 
//                                DataRow row = this.TerminalTable.NewRow();
//                                row["ChannelID"] = dr["readerport"].ToString();
//                                row["Status"] = "Disconnected";
//                                row["TerminalID"] = dr["code"].ToString();
//                                row["IPAddress"] = dr["readerip"].ToString();
//                                row["MacAddress"] = "".ToString();
//                                row["SerialNo"] = dr["readertype"].ToString();
//                                row["ModelName"] = dr["readermode"].ToString();
//                                row["FirmwareVersion"] = "";
//                                this.TerminalTable.Rows.Add(row);
//                            }

//                        }
//                    }
//                }

//                this.dgv_Terminal.DataSource = this.TerminalTable;
//            }
//            catch (Exception ex)
//            {
//                var r = ex.Message.ToString();
//            }
//        }


//        private void BeginListen()
//        {
//            //Connected
//            SemacV14.Service.CurrentService.OnConnected += this.OnConnected;
//            //DisConnected
//            SemacV14.Service.CurrentService.OnDisconnected += this.OnDisconnected;
//            //Start TCP Listen
//            SemacV14.Service.CurrentService.StartListen(Convert.ToUInt16(2000));
//            //Realtime Transaction
//            SemacV14.Service.CurrentService.OnRealtimeTransaction += this.HandleRealtime;

//            SemacV14.Service.CurrentService.OffLineLogTransaction += this.HandleRealtime; // same handle with RealtimeTransaction

//        }

//        //OnConnected
//        //private void OnConnected(SemacV14.Entity.TerminalEntity En)
//        //{
//        //    try
//        //    {
//        //        if (this.InvokeRequired == true)
//        //        {
//        //            BeginInvoke(new TerminalConnectHandler(OnConnected), En);
//        //        }
//        //        else
//        //        {
//        //            lock (this.TerminalTable)
//        //            {
//        //                DataRow row = this.TerminalTable.NewRow();
//        //                row["ChannelID"] = En.ChannelID;
//        //                row["Status"] = En.Status;
//        //                row["TerminalID"] = En.TerminalID.ToString();
//        //                row["IPAddress"] = En.IPAddress;
//        //                row["MacAddress"] = En.MacAddress;
//        //                row["SerialNo"] = En.SerialNo;
//        //                row["ModelName"] = En.ModelName;
//        //                row["FirmwareVersion"] = En.FirmwareVersion;
//        //                this.TerminalTable.Rows.Add(row);
//        //            }

//        //            ListViewItem item = new ListViewItem(System.DateTime.Now.ToString("T"));
//        //            item.SubItems.Add("Connected");
//        //            item.SubItems.Add(En.ToMyString);
//        //            AddMessage(item);

//        //            DBDal.UpdateControllerStatus(En.TerminalID.ToString(), En.Status, En.ToMyString.ToString());

//        //        }
//        //    }

//        //    catch (Exception ex)
//        //    {

//        //        var r = ex.Message.ToString();
//        //    }
//        //}
//        //OnConnected
//        private void OnConnected(SemacV14.Entity.TerminalEntity En)
//        {
//            try
//            {
//                if (this.InvokeRequired == true)
//                {
//                    BeginInvoke(new TerminalConnectHandler(OnConnected), En);
//                }
//                else
//                {
//                    // IP se match karke DB wala sahi code nikalo (controller ka apna bheja TerminalID ignore karo, clash rokne ke liye)
//                    string resolvedCode = En.TerminalID.ToString();
//                    lock (this.TerminalTable)
//                    {
//                        foreach (DataRow r in this.TerminalTable.Rows)
//                        {
//                            if (r["IPAddress"].ToString() == En.IPAddress)
//                            {
//                                resolvedCode = r["TerminalID"].ToString();
//                                r["ChannelID"] = En.ChannelID;
//                                r["Status"] = En.Status;
//                                r["MacAddress"] = En.MacAddress;
//                                r["SerialNo"] = En.SerialNo;
//                                r["ModelName"] = En.ModelName;
//                                r["FirmwareVersion"] = En.FirmwareVersion;
//                                goto found;
//                            }
//                        }

//                        // IP DB mein nahi mila to purane tarike se hi add karo (fallback)
//                        DataRow row = this.TerminalTable.NewRow();
//                        row["ChannelID"] = En.ChannelID;
//                        row["Status"] = En.Status;
//                        row["TerminalID"] = En.TerminalID.ToString();
//                        row["IPAddress"] = En.IPAddress;
//                        row["MacAddress"] = En.MacAddress;
//                        row["SerialNo"] = En.SerialNo;
//                        row["ModelName"] = En.ModelName;
//                        row["FirmwareVersion"] = En.FirmwareVersion;
//                        this.TerminalTable.Rows.Add(row);
//                    found:;
//                    }

//                    ListViewItem item = new ListViewItem(System.DateTime.Now.ToString("T"));
//                    item.SubItems.Add("Connected");
//                    item.SubItems.Add("[Code:" + resolvedCode + "] " + En.ToMyString);
//                    AddMessage(item);

//                    DBDal.UpdateControllerStatus(resolvedCode, En.Status, En.ToMyString.ToString());
//                }
//            }
//            catch (Exception ex)
//            {
//                var r = ex.Message.ToString();
//            }
//        }

//        //OnDisconnected
//        private void OnDisconnected(SemacV14.Entity.TerminalEntity En)
//        {
//            try
//            {
//                if (this.InvokeRequired)
//                {
//                    BeginInvoke(new TerminalConnectHandler(OnDisconnected), En);
//                }
//                else
//                {
//                    lock (TerminalTable)
//                    {
//                        foreach (DataRow row in TerminalTable.Rows)
//                        {
//                            if (row["ChannelID"].ToString() == En.ChannelID)
//                            {
//                                TerminalTable.Rows.Remove(row);
//                                break;
//                            }
//                        }
//                    }
//                    //Message
//                    ListViewItem item = new ListViewItem(System.DateTime.Now.ToString("T"));
//                    item.SubItems.Add("DisConnected");
//                    item.SubItems.Add(En.ToMyString);
//                    AddMessage(item);

//                    DBDal.UpdateControllerStatus(En.TerminalID.ToString(), En.Status, En.ToMyString.ToString());
//                }
//            }
//            catch (Exception ex)
//            {
//                var r = ex.Message.ToString();
//            }
//        }


//        //Add Message
//        private void AddMessage(ListViewItem item)
//        {
//            try
//            {
//                lock (this.lsvMessage)
//                {
//                    if (lsvMessage.Items.Count >= 200)
//                    {
//                        lsvMessage.Items.RemoveAt(lsvMessage.Items.Count - 1);
//                    }
//                    lsvMessage.Items.Insert(0, item);
//                }
//            }
//            catch (Exception ex)
//            {
//                var r = ex.Message.ToString();
//            }
//        }

//        //Realtime
//        //private void HandleRealtime(SemacV14.Service.ExecuteArgz Ea)
//        //{
//        //    try
//        //    {
//        //        if (this.InvokeRequired)
//        //        {
//        //            BeginInvoke(new ExecuteHandler(this.HandleRealtime), Ea);
//        //        }
//        //        else
//        //        {
//        //            if (!(Ea.EntityList == null))
//        //            {
//        //                foreach (SemacV14.Entity.DoorLogEntity En in Ea.EntityList)
//        //                {
//        //                    ListViewItem item = new ListViewItem(System.DateTime.Now.ToString("T"));
//        //                    item.SubItems.Add(Ea.CommandType.ToString());
//        //                    item.SubItems.Add(En.ToMyString);
//        //                    this.AddMessage(item);

//        //                    DBDal.UpdateControllerStatus(En.TerminalID.ToString(), En.CardNo, En.ToMyString.ToString());

//        //Realtime
//        private void HandleRealtime(SemacV14.Service.ExecuteArgz Ea)
//        {
//            try
//            {
//                if (this.InvokeRequired)
//                {
//                    BeginInvoke(new ExecuteHandler(this.HandleRealtime), Ea);
//                }
//                else
//                {
//                    if (!(Ea.EntityList == null))
//                    {
//                        // ChannelID se sahi site-code resolve karo (device apna hardware TerminalID "1" bhejta hai dono ke liye, isliye ChannelID match karna zaroori hai)
//                        string resolvedCode = null;
//                        lock (this.TerminalTable)
//                        {
//                            foreach (DataRow r in this.TerminalTable.Rows)
//                            {
//                                if (r["ChannelID"].ToString() == Ea.ChannelID)
//                                {
//                                    resolvedCode = r["TerminalID"].ToString();
//                                    break;
//                                }
//                            }
//                        }

//                        foreach (SemacV14.Entity.DoorLogEntity En in Ea.EntityList)
//                        {
//                            string codeToUse = resolvedCode ?? En.TerminalID.ToString();

//                            ListViewItem item = new ListViewItem(System.DateTime.Now.ToString("T"));
//                            item.SubItems.Add(Ea.CommandType.ToString());
//                            item.SubItems.Add("[Code:" + codeToUse + "] " + En.ToMyString);
//                            this.AddMessage(item);

//                            DBDal.UpdateControllerStatus(codeToUse, En.CardNo, En.ToMyString.ToString());
//                            ////Only for test here
//                            //ListViewItem item2 = new ListViewItem(System.DateTime.Now.ToString("T"));
//                            //SemacV14.Entity.DoorLogEntity Log = (SemacV14.Entity.DoorLogEntity)En;
//                            //item2.SubItems.Add("Function Key");
//                            //item2.SubItems.Add("FunctionKey:" + Log .FunctionKey  + ",FkeyID:"  +  Log.FunctionKeyInt32 .ToString ());                            
//                            //this.AddMessage(item2);   
//                        }
//                    }
//                }
//            }
//            catch (Exception ee)
//            {
//                MessageBox.Show(ee.Message);
//            }
//        }

//        //Common Callback Function
//        private void HandleEntity(SemacV14.Service.ExecuteArgz Ea)
//        {
//            try
//            {
//                if (this.InvokeRequired)
//                {
//                    BeginInvoke(new ExecuteHandler(this.HandleRealtime), Ea);
//                }
//                else
//                {
//                    if (!(Ea.EntityList == null))
//                    {
//                        foreach (SemacV14.Entity.DoorLogEntity En in Ea.EntityList)
//                        {
//                            ListViewItem item = new ListViewItem(System.DateTime.Now.ToString("T"));
//                            item.SubItems.Add(Ea.CommandType.ToString());
//                            item.SubItems.Add(En.ToMyString);
//                            this.AddMessage(item);


//                            DBDal.UpdateControllerStatus(En.TerminalID.ToString(), En.CardNo, En.ToMyString.ToString());
//                            ////Only for test here
//                            //ListViewItem item2 = new ListViewItem(System.DateTime.Now.ToString("T"));
//                            //SemacV14.Entity.DoorLogEntity Log = (SemacV14.Entity.DoorLogEntity)En;
//                            //item2.SubItems.Add("Function Key");
//                            //item2.SubItems.Add("FunctionKey:" + Log .FunctionKey  + ",FkeyID:"  +  Log.FunctionKeyInt32 .ToString ());                            
//                            //this.AddMessage(item2);   
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//            }
//        }

//        //eg,handler Get All Entrylog
//        private void HandleGetAllEntryLog(SemacV14.Service.ExecuteArgz Ea)
//        {
//            try
//            {
//                if (this.InvokeRequired == true)
//                {
//                    BeginInvoke(new ExecuteHandler(this.HandleEntity), Ea);
//                }
//                else
//                {
//                    switch (Ea.IsCompleted)
//                    {
//                        case true:
//                            int i;
//                            for (i = 0; i < Ea.EntityList.Count; i++)
//                            {
//                                SemacV14.Entity.DoorLogEntity log = (SemacV14.Entity.DoorLogEntity)Ea.EntityList[i];

//                                DBDal.UpdateControllerStatus(log.TerminalID.ToString(), log.CardNo, log.ToMyString.ToString());
//                                //MessageBox.Show(log.EntryDate.ToString());                                
//                                //Do something here
//                            }
//                            break;
//                        case false:
//                            MessageBox.Show(Ea.ErrorMessage);
//                            break;
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//            }
//        }

//        //Clear Message
//        private void btnClearMessage_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                lock (this.lsvMessage)
//                {
//                    this.lsvMessage.Items.Clear();
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//            }
//        }

//        #region  Examples        


//        //eg,get one user from a terminal
//        private void GetOneUser()
//        {
//            try
//            {
//                string ChannelID = this.dgv_Terminal.SelectedRows[0].Cells["ChannelIDColumn"].Value.ToString();
//                int TerminalID = Convert.ToInt32(this.dgv_Terminal.SelectedRows[0].Cells["TerminalIDColumn"].Value);
//                UInt32 UserID = Convert.ToUInt32(txtUserId.Text);
//                SemacV14.Request.GetUserDataRequest Re = new SemacV14.Request.GetUserDataRequest(TerminalID, UserID);
//                SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, Re);

//                //Execute 
//                SemacV14.Service.Actor Wrk = new Actor(Ea);
//                Ea = Wrk.SendAndReceive(); //  'Send command,and return result

//                // check the result
//                if (Ea.IsCompleted == true)
//                {
//                    SemacV14.Entity.GetUserDataEntity En = (SemacV14.Entity.GetUserDataEntity)Ea.CallbackEntity;
//                    txtUserId.Text = En.UserID.ToString();
//                    txtUserName.Text = En.UserName;
//                    txtCardNo.Text = En.CardNo;
//                    txtEmployeeId.Text = En.EmployeeID;
//                    if (En.Status == true)
//                    {
//                        rdbActivate.Checked = true;
//                    }
//                    else
//                    {
//                        rdbDeActivate.Checked = true;
//                    }

//                    //MessageBox.Show(En.UserName);
//                    //MessageBox.Show(En.CardNo );                          
//                }
//                else
//                {
//                    MessageBox.Show(Ea.ErrorMessage);  // Failed
//                }

//            }
//            catch (Exception ex)
//            {

//                var r = ex.Message.ToString();
//            }
//            //Done        
//        }

//        #endregion

//        private void btnSave_Click(object sender, EventArgs e)
//        {
//            AddUser();
//        }

//        #region eg,add one user
//        private void AddUser()
//        {
//            string ChannelID = this.dgv_Terminal.SelectedRows[0].Cells["ChannelIDColumn"].Value.ToString();
//            int TerminalID = Convert.ToInt32(this.dgv_Terminal.SelectedRows[0].Cells["TerminalIDColumn"].Value);
//            SemacV14.Request.RegisterModifyUserDataRequest Re = new SemacV14.Request.RegisterModifyUserDataRequest(TerminalID);
//            Re.UserID = Convert.ToUInt32(txtUserId.Text);
//            if (rdbActivate.Checked)
//            {
//                Re.EnabledStatus = true;
//                Re.UserName = txtUserName.Text;
//                Re.CardNo = txtCardNo.Text;
//                Re.EmployeeID = txtEmployeeId.Text;
//                Re.UserType = (Define.UserType)0;
//                Re.BypassTimeZoneLevel = (Define.BypassTimeZoneLevel)1;
//                Re.OverWrite = true;
//                Re.Group01 = 0b1; ;
//                Re.Door01TZ = 1;
//            }
//            if (rdbDeActivate.Checked)
//            {
//                Re.EnabledStatus = false;
//                Re.UserType = (Define.UserType)0;
//                Re.BypassTimeZoneLevel = (Define.BypassTimeZoneLevel)1;
//                Re.OverWrite = true;
//                Re.Group01 = 0b1; ;
//                Re.Door01TZ = 1;
//            }
//            SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, Re);
//            SemacV14.Service.Actor Wrk = new Actor(Ea);
//            Ea = Wrk.SendAndReceive();
//            if (Ea.IsCompleted == true)
//            {
//                MessageBox.Show("Success");
//            }
//            else
//            {
//                MessageBox.Show(Ea.ErrorMessage);
//            }
//        }

//        #endregion

//        //static async Task RunTaskEveryHourAsync()
//        //{
//        //    while (true)
//        //    {
//        //        await Task.Run(async () =>
//        //        {
//        //            Console.WriteLine($"Task started at {DateTime.Now}");
//        //            // Your task logic here
//        //           await asy();

//        //        });

//        //        await Task.Delay(TimeSpan.FromHours(12)); // Wait for 1 hour
//        //    }
//        //}

//        private void btnGetUser_Click(object sender, EventArgs e)
//        {
//            GetOneUser();
//        }

//        private void btnBulkUpload_Click(object sender, EventArgs e)
//        {

//        }
//        string excelPath = "";
//        DataTable dtInwardExcel;
//        private void btnImportFile_Click(object sender, EventArgs e)
//        {
//            OpenFileDialog objFileDialoag = new OpenFileDialog();
//            objFileDialoag.InitialDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
//            objFileDialoag.Filter = "bak files (*.xls)|*.xlsx";
//            objFileDialoag.FilterIndex = 2;
//            objFileDialoag.RestoreDirectory = true;
//            excelPath = "";
//            if (objFileDialoag.ShowDialog() == DialogResult.OK)
//            {
//                excelPath = objFileDialoag.FileName.ToString();
//            }
//            if (excelPath != "")
//            {
//                string _filePath = excelPath;
//                string _extension = Path.GetExtension(_filePath);
//            }

//            ExcelImport exIm = new ExcelImport();
//            List<clsCommon> dataList = new List<clsCommon>();
//            dataList = exIm.ImportFromExcelFile(excelPath);
//            int UpCount = 0;
//            for (int i = 0; i < dataList.Count; i++)
//            {
//                string ChannelID = this.dgv_Terminal.SelectedRows[0].Cells["ChannelIDColumn"].Value.ToString();
//                int TerminalID = Convert.ToInt32(this.dgv_Terminal.SelectedRows[0].Cells["TerminalIDColumn"].Value);
//                SemacV14.Request.RegisterModifyUserDataRequest Re = new SemacV14.Request.RegisterModifyUserDataRequest(TerminalID);
//                Re.UserID = dataList[i].UserId;
//                Re.EnabledStatus = true;
//                Re.UserName = dataList[i].UserName;
//                Re.CardNo = dataList[i].CardNo;
//                Re.EmployeeID = dataList[i].EmployeeID; ;
//                Re.UserType = (Define.UserType)0;
//                Re.BypassTimeZoneLevel = (Define.BypassTimeZoneLevel)1;
//                Re.OverWrite = true;
//                Re.Group01 = 0b1;
//                Re.Door01TZ = 1;

//                SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, Re);
//                SemacV14.Service.Actor Wrk = new Actor(Ea);
//                Ea = Wrk.SendAndReceive();
//                if (Ea.IsCompleted == true)
//                {
//                    UpCount = UpCount + 1;
//                }
//                else
//                {

//                }
//            }
//            lblCount.Text = UpCount.ToString();
//        }

//        private void btnAttendanceLog_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                string ChannelID = this.dgv_Terminal.SelectedRows[0].Cells["ChannelIDColumn"].Value.ToString();
//                int TerminalID = Convert.ToInt32(this.dgv_Terminal.SelectedRows[0].Cells["TerminalIDColumn"].Value);
//                var re = new SemacV14.Request.CommonRequest(TerminalID, SemacV14.Define.CommandType.RetrievingAllEntryExitLog);
//                SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, re);

//                if (Ea == null) return;
//                SemacV14.Service.Actor act = new Actor(Ea);
//                act.OnEntityDataArrival += this.HandleEntity;
//                act.Send();

//            }
//            catch (Exception ex)
//            {
//                var r = ex.Message.ToString();
//            }

//        }
//        private void btnOpenDoor_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                string ChannelID = this.dgv_Terminal.SelectedRows[0].Cells["ChannelIDColumn"].Value.ToString();
//                int TerminalID = Convert.ToInt32(this.dgv_Terminal.SelectedRows[0].Cells["TerminalIDColumn"].Value);

//                var re = new SemacV14.Request.CommonRequest(TerminalID, SemacV14.Define.CommandType.PulseOpenDoor);
//                SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, re);

//                SemacV14.Service.Actor Wrk = new Actor(Ea);
//                Ea = Wrk.SendAndReceive();

//                if (Ea.IsCompleted == true)
//                    MessageBox.Show("Door Opened");
//                else
//                    MessageBox.Show(Ea.ErrorMessage);
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//            }
//        }
//        private void dgv_Terminal_CellContentClick(object sender, DataGridViewCellEventArgs e)
//        {

//        }

//        //private void btnAccessFileUpload_Click(object sender, EventArgs e)
//        //{
//        //    try
//        //    {
//        //        int UpCount = 0;
//        //        //   UserId, UserName, CardNo, EmployeeID, UserType, BypassTimeZoneLevel default send 1,OverWrite( true),Group01= 0b1,Door01TZ =1
//        //        DataTable dt = DBDal.getAccessFileUpload();
//        //        if (dt != null)
//        //        {
//        //            if (dt.Rows.Count > 0)
//        //            {
//        //                foreach (DataRow dr in dt.Rows)
//        //                {
//        //                    string ChannelID = this.dgv_Terminal.SelectedRows[0].Cells["ChannelIDColumn"].Value.ToString();
//        //                    int TerminalID = Convert.ToInt32(this.dgv_Terminal.SelectedRows[0].Cells["TerminalIDColumn"].Value);
//        //                    SemacV14.Request.RegisterModifyUserDataRequest Re = new SemacV14.Request.RegisterModifyUserDataRequest(TerminalID);
//        //                    var UserID = Convert.ToInt64(dr["UserId"].ToString());
//        //                    Re.UserID =(UInt32)UserID;
//        //                    Re.EnabledStatus = true;
//        //                    Re.UserName = dr["UserName"].ToString();
//        //                    Re.CardNo = dr["CardNo"].ToString();
//        //                    Re.EmployeeID = dr["EmployeeID"].ToString();
//        //                    Re.UserType = (Define.UserType)0;
//        //                    Re.BypassTimeZoneLevel = (Define.BypassTimeZoneLevel)1;
//        //                    Re.OverWrite = true;
//        //                    Re.Group01 = 0b1;
//        //                    Re.Door01TZ = 1;

//        //                    SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, Re);
//        //                    SemacV14.Service.Actor Wrk = new Actor(Ea);
//        //                    Ea = Wrk.SendAndReceive();
//        //                    if (Ea.IsCompleted == true)
//        //                    {
//        //                        UpCount = UpCount + 1;
//        //                    }
//        //                    else
//        //                    {
//        //                        lblExcutionStatus.Text += Ea.ErrorMessage.ToString();
//        //                    }
//        //                }
//        //            }
//        //        }

//        //        isAccessupload = true;
//        //        lblCount.Text = UpCount.ToString();
//        //        lblExcutionStatus.Text = "process done!";
//        //        return;
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        var r = ex.Message.ToString();
//        //    }
//        //}



//        private void btnAccessFileUpload_Click(object sender, EventArgs e)
//        {
//            int UpCount = 0;
//            foreach (DataRow termRow in TerminalTable.Rows)
//            {
//                if (termRow["Status"].ToString() != "Connected") continue;

//                string readerCode = termRow["TerminalID"].ToString();   // = tblReader.code
//                string ChannelID = termRow["ChannelID"].ToString();
//                int TerminalID;
//                if (!int.TryParse(readerCode, out TerminalID)) continue;

//                try
//                {
//                    DataTable dt = DBDal.GetTerminalAccessFile(readerCode);
//                    if (dt == null) continue;

//                    foreach (DataRow dr in dt.Rows)
//                    {
//                        try
//                        {
//                            SemacV14.Request.RegisterModifyUserDataRequest Re = new SemacV14.Request.RegisterModifyUserDataRequest(TerminalID);
//                            var UserID = Convert.ToInt64(dr["UserId"].ToString());
//                            Re.UserID = (UInt32)UserID;
//                            Re.EnabledStatus = true;
//                            Re.UserName = dr["UserName"].ToString();
//                            Re.CardNo = dr["CardNo"].ToString();
//                            Re.EmployeeID = dr["EmployeeID"].ToString();
//                            Re.UserType = (Define.UserType)0;
//                            Re.BypassTimeZoneLevel = (Define.BypassTimeZoneLevel)1;
//                            Re.OverWrite = true;
//                            Re.Group01 = 0b1;
//                            Re.Door01TZ = 1;

//                            SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, Re);
//                            SemacV14.Service.Actor Wrk = new Actor(Ea);
//                            Ea = Wrk.SendAndReceive();
//                            if (Ea.IsCompleted == true)
//                            {
//                                DBDal.MarkSynced(Convert.ToInt32(UserID), readerCode, "Y", "");
//                                UpCount = UpCount + 1;
//                            }
//                            else
//                            {
//                                lblExcutionStatus.Text = "[" + readerCode + "] " + Ea.ErrorMessage;
//                            }
//                        }
//                        catch (Exception exUser)
//                        {
//                            lblExcutionStatus.Text = "[" + readerCode + "] " + exUser.Message;
//                        }
//                    }
//                }
//                catch (Exception exTerm)
//                {
//                    lblExcutionStatus.Text = "[" + readerCode + "] " + exTerm.Message;
//                }
//            }

//            isAccessupload = true;
//            lblCount.Text = UpCount.ToString();
//            lblExcutionStatus.Text = "process done!";
//        }

//        private void lsvMessage_SelectedIndexChanged(object sender, EventArgs e)
//        {
//        }

//        private void pnlUserRegister_Paint(object sender, PaintEventArgs e)
//        {

//        }

//        private void btnRegisterUser_Click(object sender, EventArgs e)
//        {

//        }

//        //private void btnAccLogDownload_Click(object sender, EventArgs e)
//        //{
//        //    try
//        //    {
//        //        if (this.dgv_Terminal.SelectedRows.Count <= 0)
//        //            this.dgv_Terminal.Rows[0].Selected=true;
//        //        string ChannelID = this.dgv_Terminal.SelectedRows[0].Cells["ChannelIDColumn"].Value.ToString();
//        //        int TerminalID = Convert.ToInt32(this.dgv_Terminal.SelectedRows[0].Cells["TerminalIDColumn"].Value);
//        //        var re = new SemacV14.Request.CommonRequest(TerminalID, SemacV14.Define.CommandType.RetrievingAllEntryExitLog);
//        //        SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, re);

//        //        HandleGetAllEntryLog(Ea);
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        lblExcutionStatus.Text = ex.Message.ToString();
//        //    } 
//        //}


//        private void btnAccLogDownload_Click(object sender, EventArgs e)
//        {
//            foreach (DataRow termRow in TerminalTable.Rows)
//            {
//                if (termRow["Status"].ToString() != "Connected") continue;

//                string readerCode = termRow["TerminalID"].ToString();
//                string ChannelID = termRow["ChannelID"].ToString();
//                int TerminalID;
//                if (!int.TryParse(readerCode, out TerminalID)) continue;

//                try
//                {
//                    var re = new SemacV14.Request.CommonRequest(TerminalID, SemacV14.Define.CommandType.RetrievingAllEntryExitLog);
//                    SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, re);

//                    HandleGetAllEntryLog(Ea);
//                }
//                catch (Exception ex)
//                {
//                    lblExcutionStatus.Text = "[" + readerCode + "] " + ex.Message;
//                }
//            }
//        }
//        private void AccLogDownload(SemacV14.Service.ExecuteArgz Ea)
//        {
//            try
//            {
//                if (this.InvokeRequired)
//                {
//                    BeginInvoke(new ExecuteHandler(this.HandleRealtime), Ea);
//                }
//                else
//                {
//                    if (!(Ea.EntityList == null))
//                    {
//                        foreach (SemacV14.Entity.DoorLogEntity En in Ea.EntityList)
//                        {
//                            //ListViewItem item = new ListViewItem(System.DateTime.Now.ToString("T"));
//                            //item.SubItems.Add(Ea.CommandType.ToString());
//                            //item.SubItems.Add(En.ToMyString);
//                            //this.AddMessage(item);

//                            ////Only for test here
//                            ListViewItem item2 = new ListViewItem(System.DateTime.Now.ToString("T"));
//                            SemacV14.Entity.DoorLogEntity Log = (SemacV14.Entity.DoorLogEntity)En;
//                            item2.SubItems.Add("Function Key");
//                            item2.SubItems.Add("FunctionKey:" + Log.FunctionKey + ",FkeyID:" + Log.FunctionKeyInt32.ToString());
//                            this.AddMessage(item2);
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//            }

//        }

//        //private void btnAccessFileUpload_Click_1(object sender, EventArgs e)
//        //{
//        //    btnAccessFileUpload_Click(sender, e);
//        //}

//        //private void btnAttendanceLog_Click_1(object sender, EventArgs e)
//        //{

//        //}
//        // getAccessNewUserFile, getAccessNewUserFile, getAccessBlockFile, getAccessFile, getLostDamageFile, getAccessRevokeList
//        //private void btnNewlyAddedUpload_Click(object sender, EventArgs e)
//        //{
//        //    try
//        //    {
//        //        int UpCount = 0;
//        //        //   UserId, UserName, CardNo, EmployeeID, UserType, BypassTimeZoneLevel default send 1,OverWrite( true),Group01= 0b1,Door01TZ =1
//        //        DataTable dt = DBDal.getAccessNewUserFileUpload();
//        //        if (dt != null)
//        //        {
//        //            if (dt.Rows.Count > 0)
//        //            {
//        //                foreach (DataRow dr in dt.Rows)
//        //                {
//        //                    string ChannelID = this.dgv_Terminal.SelectedRows[0].Cells["ChannelIDColumn"].Value.ToString();
//        //                    int TerminalID = Convert.ToInt32(this.dgv_Terminal.SelectedRows[0].Cells["TerminalIDColumn"].Value);
//        //                    SemacV14.Request.RegisterModifyUserDataRequest Re = new SemacV14.Request.RegisterModifyUserDataRequest(TerminalID);
//        //                    int UserID = Convert.ToInt32(dr["UserId"].ToString());
//        //                    Re.UserID = (uint)UserID;
//        //                    Re.EnabledStatus = true;
//        //                    Re.UserName = dr["UserName"].ToString();
//        //                    Re.CardNo = dr["CardNo"].ToString();
//        //                    Re.EmployeeID = dr["EmployeeID"].ToString();
//        //                    Re.UserType = (Define.UserType)0;
//        //                    Re.BypassTimeZoneLevel = (Define.BypassTimeZoneLevel)1;
//        //                    Re.OverWrite = true;
//        //                    Re.Group01 = 0b1;
//        //                    Re.Door01TZ = 1;

//        //                    SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, Re);
//        //                    SemacV14.Service.Actor Wrk = new Actor(Ea);
//        //                    Ea = Wrk.SendAndReceive();
//        //                    if (Ea.IsCompleted == true)
//        //                    {
//        //                        UpCount = UpCount + 1;
//        //                    }
//        //                    else
//        //                    {
//        //                        lblExcutionStatus.Text = Ea.ErrorMessage.ToString();
//        //                    }
//        //                }
//        //            }
//        //        }

//        //        lblCount.Text = UpCount.ToString();
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        var r = ex.Message.ToString();
//        //    }

//        //}



//        private void btnNewlyAddedUpload_Click(object sender, EventArgs e)
//        {
//            int UpCount = 0;
//            foreach (DataRow termRow in TerminalTable.Rows)
//            {
//                if (termRow["Status"].ToString() != "Connected") continue;

//                string readerCode = termRow["TerminalID"].ToString();   // = tblReader.code (Falcon ya Skylark, jo bhi connected ho)
//                string ChannelID = termRow["ChannelID"].ToString();
//                int TerminalID;
//                if (!int.TryParse(readerCode, out TerminalID)) continue;

//                try
//                {
//                    DataTable dt = DBDal.GetTerminalAccessFile(readerCode);
//                    if (dt == null) continue;

//                    foreach (DataRow dr in dt.Rows)
//                    {
//                        try
//                        {
//                            SemacV14.Request.RegisterModifyUserDataRequest Re = new SemacV14.Request.RegisterModifyUserDataRequest(TerminalID);
//                            int UserID = Convert.ToInt32(dr["UserId"].ToString());
//                            Re.UserID = (uint)UserID;
//                            Re.EnabledStatus = true;
//                            Re.UserName = dr["UserName"].ToString();
//                            Re.CardNo = dr["CardNo"].ToString();
//                            Re.EmployeeID = dr["EmployeeID"].ToString();
//                            Re.UserType = (Define.UserType)0;
//                            Re.BypassTimeZoneLevel = (Define.BypassTimeZoneLevel)1;
//                            Re.OverWrite = true;
//                            Re.Group01 = 0b1;
//                            Re.Door01TZ = 1;

//                            SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, Re);
//                            SemacV14.Service.Actor Wrk = new Actor(Ea);
//                            Ea = Wrk.SendAndReceive();
//                            if (Ea.IsCompleted == true)
//                            {
//                                DBDal.MarkSynced(UserID, readerCode, "Y", "");
//                                UpCount = UpCount + 1;
//                            }
//                            else
//                            {
//                                lblExcutionStatus.Text = "[" + readerCode + "] " + Ea.ErrorMessage;
//                            }
//                        }
//                        catch (Exception exUser)
//                        {
//                            lblExcutionStatus.Text = "[" + readerCode + "] " + exUser.Message;
//                        }
//                    }
//                }
//                catch (Exception exTerm)
//                {
//                    lblExcutionStatus.Text = "[" + readerCode + "] " + exTerm.Message;
//                }
//            }

//            lblCount.Text = UpCount.ToString();
//        }

//        //private void btnAccessBlockUpload_Click(object sender, EventArgs e)
//        //{ 
//        //    try
//        //    {
//        //        int UpCount = 0;
//        //        //   UserId, UserName, CardNo, EmployeeID, UserType, BypassTimeZoneLevel default send 1,OverWrite( true),Group01= 0b1,Door01TZ =1
//        //        DataTable dt = DBDal.getAccessBlockListUpload();
//        //        if (dt != null)
//        //        {
//        //            if (dt.Rows.Count > 0)
//        //            {
//        //                foreach (DataRow dr in dt.Rows)
//        //                {
//        //                    string ChannelID = this.dgv_Terminal.SelectedRows[0].Cells["ChannelIDColumn"].Value.ToString();
//        //                    int TerminalID = Convert.ToInt32(this.dgv_Terminal.SelectedRows[0].Cells["TerminalIDColumn"].Value);
//        //                    SemacV14.Request.RegisterModifyUserDataRequest Re = new SemacV14.Request.RegisterModifyUserDataRequest(TerminalID);
//        //                    int UserID = Convert.ToInt32(dr["UserId"].ToString());
//        //                    Re.UserID = (uint)UserID;
//        //                    Re.EnabledStatus = false;
//        //                    Re.UserName = dr["UserName"].ToString();
//        //                    Re.CardNo = dr["CardNo"].ToString();
//        //                    Re.EmployeeID = dr["EmployeeID"].ToString();
//        //                    Re.UserType = (Define.UserType)0;
//        //                    Re.BypassTimeZoneLevel = (Define.BypassTimeZoneLevel)1;
//        //                    Re.OverWrite = true;
//        //                    Re.Group01 = 0b1;
//        //                    Re.Door01TZ = 1;

//        //                    SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, Re);
//        //                    SemacV14.Service.Actor Wrk = new Actor(Ea);
//        //                    Ea = Wrk.SendAndReceive();
//        //                    if (Ea.IsCompleted == true)
//        //                    {
//        //                        UpCount = UpCount + 1;
//        //                    }
//        //                    else
//        //                    {
//        //                        lblExcutionStatus.Text = Ea.ErrorMessage.ToString();
//        //                    }
//        //                }
//        //            }
//        //        }

//        //        lblCount.Text = UpCount.ToString();
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        var r = ex.Message.ToString();
//        //    }

//        //}



//        private void btnAccessBlockUpload_Click(object sender, EventArgs e)
//        {
//            int UpCount = 0;
//            foreach (DataRow termRow in TerminalTable.Rows)
//            {
//                if (termRow["Status"].ToString() != "Connected") continue;

//                string readerCode = termRow["TerminalID"].ToString();
//                string ChannelID = termRow["ChannelID"].ToString();
//                int TerminalID;
//                if (!int.TryParse(readerCode, out TerminalID)) continue;

//                try
//                {
//                    DataTable dt = DBDal.GetTerminalBlockFile(readerCode);
//                    if (dt == null) continue;

//                    foreach (DataRow dr in dt.Rows)
//                    {
//                        try
//                        {
//                            SemacV14.Request.RegisterModifyUserDataRequest Re = new SemacV14.Request.RegisterModifyUserDataRequest(TerminalID);
//                            int UserID = Convert.ToInt32(dr["UserId"].ToString());
//                            Re.UserID = (uint)UserID;
//                            Re.EnabledStatus = false;
//                            Re.UserName = dr["UserName"].ToString();
//                            Re.CardNo = dr["CardNo"].ToString();
//                            Re.EmployeeID = dr["EmployeeID"].ToString();
//                            Re.UserType = (Define.UserType)0;
//                            Re.BypassTimeZoneLevel = (Define.BypassTimeZoneLevel)1;
//                            Re.OverWrite = true;
//                            Re.Group01 = 0b1;
//                            Re.Door01TZ = 1;

//                            SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, Re);
//                            SemacV14.Service.Actor Wrk = new Actor(Ea);
//                            Ea = Wrk.SendAndReceive();
//                            if (Ea.IsCompleted == true)
//                            {
//                                DBDal.MarkSynced(UserID, readerCode, "", "B");
//                                UpCount = UpCount + 1;
//                            }
//                            else
//                            {
//                                lblExcutionStatus.Text = "[" + readerCode + "] " + Ea.ErrorMessage;
//                            }
//                        }
//                        catch (Exception exUser)
//                        {
//                            lblExcutionStatus.Text = "[" + readerCode + "] " + exUser.Message;
//                        }
//                    }
//                }
//                catch (Exception exTerm)
//                {
//                    lblExcutionStatus.Text = "[" + readerCode + "] " + exTerm.Message;
//                }
//            }

//            lblCount.Text = UpCount.ToString();
//        }

//        //private void btnAccessRevokUpload_Click(object sender, EventArgs e)
//        //{
//        //    try
//        //    {
//        //        int UpCount = 0;
//        //        //   UserId, UserName, CardNo, EmployeeID, UserType, BypassTimeZoneLevel default send 1,OverWrite( true),Group01= 0b1,Door01TZ =1
//        //        DataTable dt = DBDal.getAccessRevokeFileUpload();
//        //        if (dt != null)
//        //        {
//        //            if (dt.Rows.Count > 0)
//        //            {
//        //                foreach (DataRow dr in dt.Rows)
//        //                {
//        //                    string ChannelID = this.dgv_Terminal.SelectedRows[0].Cells["ChannelIDColumn"].Value.ToString();
//        //                    int TerminalID = Convert.ToInt32(this.dgv_Terminal.SelectedRows[0].Cells["TerminalIDColumn"].Value);
//        //                    SemacV14.Request.RegisterModifyUserDataRequest Re = new SemacV14.Request.RegisterModifyUserDataRequest(TerminalID);
//        //                    int UserID = Convert.ToInt32(dr["UserId"].ToString());
//        //                    Re.UserID = (uint)UserID;
//        //                    Re.EnabledStatus = true;
//        //                    Re.UserName = dr["UserName"].ToString();
//        //                    Re.CardNo = dr["CardNo"].ToString();
//        //                    Re.EmployeeID = dr["EmployeeID"].ToString();
//        //                    Re.UserType = (Define.UserType)0;
//        //                    Re.BypassTimeZoneLevel = (Define.BypassTimeZoneLevel)1;
//        //                    Re.OverWrite = true;
//        //                    Re.Group01 = 0b1;
//        //                    Re.Door01TZ = 1;

//        //                    SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, Re);
//        //                    SemacV14.Service.Actor Wrk = new Actor(Ea);
//        //                    Ea = Wrk.SendAndReceive();
//        //                    if (Ea.IsCompleted == true)
//        //                    {
//        //                        UpCount = UpCount + 1;
//        //                    }
//        //                    else
//        //                    {
//        //                        lblExcutionStatus.Text = Ea.ErrorMessage.ToString();
//        //                    }
//        //                }
//        //            }
//        //        }

//        //        lblCount.Text = UpCount.ToString();
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        var r = ex.Message.ToString();
//        //    }

//        //}



//        private void btnAccessRevokUpload_Click(object sender, EventArgs e)
//        {
//            int UpCount = 0;
//            foreach (DataRow termRow in TerminalTable.Rows)
//            {
//                if (termRow["Status"].ToString() != "Connected") continue;

//                string readerCode = termRow["TerminalID"].ToString();
//                string ChannelID = termRow["ChannelID"].ToString();
//                int TerminalID;
//                if (!int.TryParse(readerCode, out TerminalID)) continue;

//                try
//                {
//                    DataTable dt = DBDal.GetTerminalRevokeFile(readerCode);
//                    if (dt == null) continue;

//                    foreach (DataRow dr in dt.Rows)
//                    {
//                        try
//                        {
//                            SemacV14.Request.RegisterModifyUserDataRequest Re = new SemacV14.Request.RegisterModifyUserDataRequest(TerminalID);
//                            int UserID = Convert.ToInt32(dr["UserId"].ToString());
//                            Re.UserID = (uint)UserID;
//                            Re.EnabledStatus = true;
//                            Re.UserName = dr["UserName"].ToString();
//                            Re.CardNo = dr["CardNo"].ToString();
//                            Re.EmployeeID = dr["EmployeeID"].ToString();
//                            Re.UserType = (Define.UserType)0;
//                            Re.BypassTimeZoneLevel = (Define.BypassTimeZoneLevel)1;
//                            Re.OverWrite = true;
//                            Re.Group01 = 0b1;
//                            Re.Door01TZ = 1;

//                            SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, Re);
//                            SemacV14.Service.Actor Wrk = new Actor(Ea);
//                            Ea = Wrk.SendAndReceive();
//                            if (Ea.IsCompleted == true)
//                            {
//                                DBDal.MarkSynced(UserID, readerCode, "", "R");
//                                UpCount = UpCount + 1;
//                            }
//                            else
//                            {
//                                lblExcutionStatus.Text = "[" + readerCode + "] " + Ea.ErrorMessage;
//                            }
//                        }
//                        catch (Exception exUser)
//                        {
//                            lblExcutionStatus.Text = "[" + readerCode + "] " + exUser.Message;
//                        }
//                    }
//                }
//                catch (Exception exTerm)
//                {
//                    lblExcutionStatus.Text = "[" + readerCode + "] " + exTerm.Message;
//                }
//            }

//            lblCount.Text = UpCount.ToString();
//        }

//        private void rdbActivate_CheckedChanged(object sender, EventArgs e)
//        {

//        }

//        private void lsvMessage_SelectedIndexChanged_1(object sender, EventArgs e)
//        {

//        }
//    }
//}




using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using SemacV14;
using SemacV14.Entity;
using SemacV14.Service;
using SomeControls;
using static SemacV14.Define;

using System;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Threading;
using System.Threading;
using Timer = System.Threading.Timer;

namespace Demo_CSharp
{

    public partial class frmMain : Form
    {

        System.Timers.Timer _timer;
        // Interval: 1 hour = 3600000 ms
        DateTime lastAccessUploadOn = DateTime.Now;
        DateTime lastAccessDownloadOn = DateTime.Now;

        public delegate void TerminalConnectHandler(SemacV14.Entity.TerminalEntity En);
        public delegate void ExecuteHandler(SemacV14.Service.ExecuteArgz Ea);
        public delegate void DoorStatusHandler(SemacV14.Entity.DoorStatusEntity En);

        //Terminal Table
        private DataTable TerminalTable = null;
        private clsDal DBDal;

        // Simple file logger: writes every caught error/exception to Logs\AppLog_yyyyMMdd.txt
        // next to the exe, with timestamp + which method it happened in. Needed because in
        // Release (no debugger), exceptions were only ever going into a local variable that
        // got thrown away, or a MessageBox that closes and leaves no trace.
        private static readonly object _logLock = new object();
        private static void WriteLog(string context, string message)
        {
            try
            {
                string logDir = System.IO.Path.Combine(
                    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location),
                    "Logs");
                if (!System.IO.Directory.Exists(logDir))
                    System.IO.Directory.CreateDirectory(logDir);

                string logFile = System.IO.Path.Combine(logDir, "AppLog_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
                string line = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " [" + context + "] " + message + Environment.NewLine;

                lock (_logLock)
                {
                    System.IO.File.AppendAllText(logFile, line);
                }
            }
            catch
            {
                // Logging must never itself crash the app.
            }
        }

        bool isAccessupload = false;
        bool isAccessTrdownload = false;

        bool isAccessBlockedupload = false;
        bool isAccessRevokupload = false;

        public frmMain()
        {
            DBDal = new clsDal();
            InitializeComponent();
            ini();

            // Task 1 every 1 hour
            Timer task1Timer = new Timer(AccessUpload, null, TimeSpan.Zero, TimeSpan.FromHours(12));

            // Task 2 every 2 hours
            Timer task2Timer = new Timer(AccessActionsUpload, null, TimeSpan.Zero, TimeSpan.FromMinutes(30));

            // Task 3 every 30 minutes
            Timer task3Timer = new Timer(AccessEmediateActionsUpload, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));

        }


        private void AccessUpload(object state)
        {
            btnAccessFileUpload_Click(null, null);


            btnAccLogDownload_Click(null, null);



            btnAccLogDownload_Click(null, null);

        }

        private void AccessActionsUpload(object state)
        {
            btnAccessBlockUpload_Click(null, null);

            btnAccessRevokUpload_Click(null, null);
        }
        private void AccessEmediateActionsUpload(object state)
        {
            btnNewlyAddedUpload_Click(null, null);
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            BeginListen();

            //TerminalEntity en = new TerminalEntity();
            //en.Port = "5000"; en.IPAddress = "127.0.0.1";
            // OnConnected(en);

        }

        private void ini()
        {
            try
            {
                //Terminal List
                this.TerminalTable = new DataTable();
                string[] cols = new string[] {
                "ChannelID",
                "Status",
                "TerminalID",
                "IPAddress",
                "MacAddress",
                "SerialNo",
                "ModelName",
                "FirmwareVersion"
            };
                foreach (string s in cols)
                {
                    DataColumn col = new DataColumn();
                    col.ColumnName = s;
                    this.TerminalTable.Columns.Add(col);
                }

                DataTable dt = DBDal.getControllerList();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {

                            lock (this.TerminalTable)
                            {
                                //code, readerip, readerport,	readermode, readerLocation, readertype, isActive, IsDeleted 
                                DataRow row = this.TerminalTable.NewRow();
                                row["ChannelID"] = dr["readerport"].ToString();
                                row["Status"] = "Disconnected";
                                row["TerminalID"] = dr["code"].ToString();
                                row["IPAddress"] = dr["readerip"].ToString();
                                row["MacAddress"] = "".ToString();
                                row["SerialNo"] = dr["readertype"].ToString();
                                row["ModelName"] = dr["readermode"].ToString();
                                row["FirmwareVersion"] = "";
                                this.TerminalTable.Rows.Add(row);
                            }

                        }
                    }
                }

                this.dgv_Terminal.DataSource = this.TerminalTable;
            }
            catch (Exception ex)
            {
                WriteLog("ini", ex.Message);
                var r = ex.Message.ToString();
            }
        }


        private void BeginListen()
        {
            //Connected
            SemacV14.Service.CurrentService.OnConnected += this.OnConnected;
            //DisConnected
            SemacV14.Service.CurrentService.OnDisconnected += this.OnDisconnected;
            //Start TCP Listen
            SemacV14.Service.CurrentService.StartListen(Convert.ToUInt16(2000));
            //Realtime Transaction
            SemacV14.Service.CurrentService.OnRealtimeTransaction += this.HandleRealtime;

            SemacV14.Service.CurrentService.OffLineLogTransaction += this.HandleRealtime; // same handle with RealtimeTransaction

        }

        //OnConnected
        //private void OnConnected(SemacV14.Entity.TerminalEntity En)
        //{
        //    try
        //    {
        //        if (this.InvokeRequired == true)
        //        {
        //            BeginInvoke(new TerminalConnectHandler(OnConnected), En);
        //        }
        //        else
        //        {
        //            lock (this.TerminalTable)
        //            {
        //                DataRow row = this.TerminalTable.NewRow();
        //                row["ChannelID"] = En.ChannelID;
        //                row["Status"] = En.Status;
        //                row["TerminalID"] = En.TerminalID.ToString();
        //                row["IPAddress"] = En.IPAddress;
        //                row["MacAddress"] = En.MacAddress;
        //                row["SerialNo"] = En.SerialNo;
        //                row["ModelName"] = En.ModelName;
        //                row["FirmwareVersion"] = En.FirmwareVersion;
        //                this.TerminalTable.Rows.Add(row);
        //            }

        //            ListViewItem item = new ListViewItem(System.DateTime.Now.ToString("T"));
        //            item.SubItems.Add("Connected");
        //            item.SubItems.Add(En.ToMyString);
        //            AddMessage(item);

        //            DBDal.UpdateControllerStatus(En.TerminalID.ToString(), En.Status, En.ToMyString.ToString());

        //        }
        //    }

        //    catch (Exception ex)
        //    {

        //        var r = ex.Message.ToString();
        //    }
        //}
        //OnConnected
        private void OnConnected(SemacV14.Entity.TerminalEntity En)
        {
            try
            {
                if (this.InvokeRequired == true)
                {
                    BeginInvoke(new TerminalConnectHandler(OnConnected), En);
                }
                else
                {
                    // IP se match karke DB wala sahi code nikalo (controller ka apna bheja TerminalID ignore karo, clash rokne ke liye)
                    string resolvedCode = En.TerminalID.ToString();
                    lock (this.TerminalTable)
                    {
                        foreach (DataRow r in this.TerminalTable.Rows)
                        {
                            if (r["IPAddress"].ToString() == En.IPAddress)
                            {
                                resolvedCode = r["TerminalID"].ToString();
                                r["ChannelID"] = En.ChannelID;
                                r["Status"] = En.Status;
                                r["MacAddress"] = En.MacAddress;
                                r["SerialNo"] = En.SerialNo;
                                r["ModelName"] = En.ModelName;
                                r["FirmwareVersion"] = En.FirmwareVersion;
                                goto found;
                            }
                        }

                        // IP DB mein nahi mila to purane tarike se hi add karo (fallback)
                        DataRow row = this.TerminalTable.NewRow();
                        row["ChannelID"] = En.ChannelID;
                        row["Status"] = En.Status;
                        row["TerminalID"] = En.TerminalID.ToString();
                        row["IPAddress"] = En.IPAddress;
                        row["MacAddress"] = En.MacAddress;
                        row["SerialNo"] = En.SerialNo;
                        row["ModelName"] = En.ModelName;
                        row["FirmwareVersion"] = En.FirmwareVersion;
                        this.TerminalTable.Rows.Add(row);
                    found:;
                    }

                    ListViewItem item = new ListViewItem(System.DateTime.Now.ToString("T"));
                    item.SubItems.Add("Connected");
                    item.SubItems.Add("[Code:" + resolvedCode + "] " + En.ToMyString);
                    AddMessage(item);

                    DBDal.UpdateControllerStatus(resolvedCode, En.Status, En.ToMyString.ToString());
                }
            }
            catch (Exception ex)
            {
                WriteLog("OnConnected", ex.Message);
                var r = ex.Message.ToString();
            }
        }

        //OnDisconnected
        private void OnDisconnected(SemacV14.Entity.TerminalEntity En)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    BeginInvoke(new TerminalConnectHandler(OnDisconnected), En);
                }
                else
                {
                    lock (TerminalTable)
                    {
                        foreach (DataRow row in TerminalTable.Rows)
                        {
                            if (row["ChannelID"].ToString() == En.ChannelID)
                            {
                                TerminalTable.Rows.Remove(row);
                                break;
                            }
                        }
                    }
                    //Message
                    ListViewItem item = new ListViewItem(System.DateTime.Now.ToString("T"));
                    item.SubItems.Add("DisConnected");
                    item.SubItems.Add(En.ToMyString);
                    AddMessage(item);

                    DBDal.UpdateControllerStatus(En.TerminalID.ToString(), En.Status, En.ToMyString.ToString());
                }
            }
            catch (Exception ex)
            {
                WriteLog("OnDisconnected", ex.Message);
                var r = ex.Message.ToString();
            }
        }


        //Add Message
        private void AddMessage(ListViewItem item)
        {
            try
            {
                lock (this.lsvMessage)
                {
                    if (lsvMessage.Items.Count >= 200)
                    {
                        lsvMessage.Items.RemoveAt(lsvMessage.Items.Count - 1);
                    }
                    lsvMessage.Items.Insert(0, item);
                }
            }
            catch (Exception ex)
            {
                WriteLog("AddMessage", ex.Message);
                var r = ex.Message.ToString();
            }
        }

        // Which terminal(s) a button action should run against.
        // - Manual click (sender != null) with a row selected in the grid: ONLY that controller.
        // - Automatic/timer call (sender == null) or manual click with nothing selected:
        //   every currently "On Line" controller (keeps the 1-min/30-min/12-hour auto-sync working).
        private List<DataRow> GetTargetTerminals(object sender)
        {
            List<DataRow> result = new List<DataRow>();

            if (sender != null && this.dgv_Terminal.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow gridRow in this.dgv_Terminal.SelectedRows)
                {
                    DataRow dr = ((DataRowView)gridRow.DataBoundItem).Row;
                    if (dr["Status"].ToString() == "On Line")
                    {
                        result.Add(dr);
                    }
                }
                return result;
            }

            foreach (DataRow dr in this.TerminalTable.Rows)
            {
                if (dr["Status"].ToString() == "On Line")
                {
                    result.Add(dr);
                }
            }
            return result;
        }

        // Resolve the DB site-code (tblReader.code, e.g. Falcon=1, Skylark=2) from a ChannelID.
        // Necessary because the physical controller's own hardware TerminalID is always "1"
        // for every unit (Falcon and Skylark both report TerminalID=1), so it can never be
        // trusted to tell the sites apart. ChannelID is unique per live TCP connection and is
        // stored in TerminalTable when the device connects, so it is used instead.
        private string ResolveCodeFromChannel(string channelID)
        {
            lock (this.TerminalTable)
            {
                foreach (DataRow r in this.TerminalTable.Rows)
                {
                    if (r["ChannelID"].ToString() == channelID)
                    {
                        return r["TerminalID"].ToString();
                    }
                }
            }
            return null;
        }

        //Realtime
        private void HandleRealtime(SemacV14.Service.ExecuteArgz Ea)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    BeginInvoke(new ExecuteHandler(this.HandleRealtime), Ea);
                }
                else
                {
                    if (!(Ea.EntityList == null))
                    {
                        string resolvedCode = ResolveCodeFromChannel(Ea.ChannelID);

                        foreach (SemacV14.Entity.DoorLogEntity En in Ea.EntityList)
                        {
                            string codeToUse = resolvedCode ?? En.TerminalID.ToString();

                            ListViewItem item = new ListViewItem(System.DateTime.Now.ToString("T"));
                            item.SubItems.Add(Ea.CommandType.ToString());
                            item.SubItems.Add("[Code:" + codeToUse + "] " + En.ToMyString);
                            this.AddMessage(item);

                            DBDal.UpdateControllerStatus(codeToUse, En.CardNo, En.ToMyString.ToString());
                            ////Only for test here
                            //ListViewItem item2 = new ListViewItem(System.DateTime.Now.ToString("T"));
                            //SemacV14.Entity.DoorLogEntity Log = (SemacV14.Entity.DoorLogEntity)En;
                            //item2.SubItems.Add("Function Key");
                            //item2.SubItems.Add("FunctionKey:" + Log .FunctionKey  + ",FkeyID:"  +  Log.FunctionKeyInt32 .ToString ());                            
                            //this.AddMessage(item2);   
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                WriteLog("HandleRealtime", ee.Message);
                MessageBox.Show(ee.Message);
            }
        }

        //Common Callback Function
        private void HandleEntity(SemacV14.Service.ExecuteArgz Ea)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    BeginInvoke(new ExecuteHandler(this.HandleRealtime), Ea);
                }
                else
                {
                    if (!(Ea.EntityList == null))
                    {
                        string resolvedCode = ResolveCodeFromChannel(Ea.ChannelID);

                        foreach (SemacV14.Entity.DoorLogEntity En in Ea.EntityList)
                        {
                            string codeToUse = resolvedCode ?? En.TerminalID.ToString();

                            ListViewItem item = new ListViewItem(System.DateTime.Now.ToString("T"));
                            item.SubItems.Add(Ea.CommandType.ToString());
                            item.SubItems.Add("[Code:" + codeToUse + "] " + En.ToMyString);
                            this.AddMessage(item);


                            DBDal.UpdateControllerStatus(codeToUse, En.CardNo, En.ToMyString.ToString());
                            ////Only for test here
                            //ListViewItem item2 = new ListViewItem(System.DateTime.Now.ToString("T"));
                            //SemacV14.Entity.DoorLogEntity Log = (SemacV14.Entity.DoorLogEntity)En;
                            //item2.SubItems.Add("Function Key");
                            //item2.SubItems.Add("FunctionKey:" + Log .FunctionKey  + ",FkeyID:"  +  Log.FunctionKeyInt32 .ToString ());                            
                            //this.AddMessage(item2);   
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog("HandleEntity", ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        //eg,handler Get All Entrylog
        private void HandleGetAllEntryLog(SemacV14.Service.ExecuteArgz Ea)
        {
            try
            {
                if (this.InvokeRequired == true)
                {
                    BeginInvoke(new ExecuteHandler(this.HandleEntity), Ea);
                }
                else
                {
                    switch (Ea.IsCompleted)
                    {
                        case true:
                            string resolvedCode = ResolveCodeFromChannel(Ea.ChannelID);
                            int i;
                            for (i = 0; i < Ea.EntityList.Count; i++)
                            {
                                SemacV14.Entity.DoorLogEntity log = (SemacV14.Entity.DoorLogEntity)Ea.EntityList[i];
                                string codeToUse = resolvedCode ?? log.TerminalID.ToString();

                                DBDal.UpdateControllerStatus(codeToUse, log.CardNo, log.ToMyString.ToString());
                                //MessageBox.Show(log.EntryDate.ToString());                                
                                //Do something here
                            }
                            break;
                        case false:
                            MessageBox.Show(Ea.ErrorMessage);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog("HandleGetAllEntryLog", ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        //Clear Message
        private void btnClearMessage_Click(object sender, EventArgs e)
        {
            try
            {
                lock (this.lsvMessage)
                {
                    this.lsvMessage.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                WriteLog("btnClearMessage_Click", ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        #region  Examples        


        //eg,get one user from a terminal
        private void GetOneUser()
        {
            try
            {
                string ChannelID = this.dgv_Terminal.SelectedRows[0].Cells["ChannelIDColumn"].Value.ToString();
                int TerminalID = Convert.ToInt32(this.dgv_Terminal.SelectedRows[0].Cells["TerminalIDColumn"].Value);
                UInt32 UserID = Convert.ToUInt32(txtUserId.Text);
                SemacV14.Request.GetUserDataRequest Re = new SemacV14.Request.GetUserDataRequest(TerminalID, UserID);
                SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, Re);

                //Execute 
                SemacV14.Service.Actor Wrk = new Actor(Ea);
                Ea = Wrk.SendAndReceive(); //  'Send command,and return result

                // check the result
                if (Ea.IsCompleted == true)
                {
                    SemacV14.Entity.GetUserDataEntity En = (SemacV14.Entity.GetUserDataEntity)Ea.CallbackEntity;
                    txtUserId.Text = En.UserID.ToString();
                    txtUserName.Text = En.UserName;
                    txtCardNo.Text = En.CardNo;
                    txtEmployeeId.Text = En.EmployeeID;
                    if (En.Status == true)
                    {
                        rdbActivate.Checked = true;
                    }
                    else
                    {
                        rdbDeActivate.Checked = true;
                    }

                    //MessageBox.Show(En.UserName);
                    //MessageBox.Show(En.CardNo );                          
                }
                else
                {
                    MessageBox.Show(Ea.ErrorMessage);  // Failed
                }

            }
            catch (Exception ex)
            {
                WriteLog("GetOneUser", ex.Message);

                var r = ex.Message.ToString();
            }
            //Done        
        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            AddUser();
        }

        #region eg,add one user
        private void AddUser()
        {
            string ChannelID = this.dgv_Terminal.SelectedRows[0].Cells["ChannelIDColumn"].Value.ToString();
            int TerminalID = Convert.ToInt32(this.dgv_Terminal.SelectedRows[0].Cells["TerminalIDColumn"].Value);
            SemacV14.Request.RegisterModifyUserDataRequest Re = new SemacV14.Request.RegisterModifyUserDataRequest(TerminalID);
            Re.UserID = Convert.ToUInt32(txtUserId.Text);
            if (rdbActivate.Checked)
            {
                Re.EnabledStatus = true;
                Re.UserName = txtUserName.Text;
                Re.CardNo = txtCardNo.Text;
                Re.EmployeeID = txtEmployeeId.Text;
                Re.UserType = (Define.UserType)0;
                Re.BypassTimeZoneLevel = (Define.BypassTimeZoneLevel)1;
                Re.OverWrite = true;
                Re.Group01 = 0b1; ;
                Re.Door01TZ = 1;
            }
            if (rdbDeActivate.Checked)
            {
                Re.EnabledStatus = false;
                Re.UserType = (Define.UserType)0;
                Re.BypassTimeZoneLevel = (Define.BypassTimeZoneLevel)1;
                Re.OverWrite = true;
                Re.Group01 = 0b1; ;
                Re.Door01TZ = 1;
            }
            SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, Re);
            SemacV14.Service.Actor Wrk = new Actor(Ea);
            Ea = Wrk.SendAndReceive();
            if (Ea.IsCompleted == true)
            {
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show(Ea.ErrorMessage);
            }
        }

        #endregion

        //static async Task RunTaskEveryHourAsync()
        //{
        //    while (true)
        //    {
        //        await Task.Run(async () =>
        //        {
        //            Console.WriteLine($"Task started at {DateTime.Now}");
        //            // Your task logic here
        //           await asy();

        //        });

        //        await Task.Delay(TimeSpan.FromHours(12)); // Wait for 1 hour
        //    }
        //}

        private void btnGetUser_Click(object sender, EventArgs e)
        {
            GetOneUser();
        }

        private void btnBulkUpload_Click(object sender, EventArgs e)
        {

        }
        string excelPath = "";
        DataTable dtInwardExcel;
        private void btnImportFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog objFileDialoag = new OpenFileDialog();
            objFileDialoag.InitialDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            objFileDialoag.Filter = "bak files (*.xls)|*.xlsx";
            objFileDialoag.FilterIndex = 2;
            objFileDialoag.RestoreDirectory = true;
            excelPath = "";
            if (objFileDialoag.ShowDialog() == DialogResult.OK)
            {
                excelPath = objFileDialoag.FileName.ToString();
            }
            if (excelPath != "")
            {
                string _filePath = excelPath;
                string _extension = Path.GetExtension(_filePath);
            }

            ExcelImport exIm = new ExcelImport();
            List<clsCommon> dataList = new List<clsCommon>();
            dataList = exIm.ImportFromExcelFile(excelPath);
            int UpCount = 0;
            for (int i = 0; i < dataList.Count; i++)
            {
                string ChannelID = this.dgv_Terminal.SelectedRows[0].Cells["ChannelIDColumn"].Value.ToString();
                int TerminalID = Convert.ToInt32(this.dgv_Terminal.SelectedRows[0].Cells["TerminalIDColumn"].Value);
                SemacV14.Request.RegisterModifyUserDataRequest Re = new SemacV14.Request.RegisterModifyUserDataRequest(TerminalID);
                Re.UserID = dataList[i].UserId;
                Re.EnabledStatus = true;
                Re.UserName = dataList[i].UserName;
                Re.CardNo = dataList[i].CardNo;
                Re.EmployeeID = dataList[i].EmployeeID; ;
                Re.UserType = (Define.UserType)0;
                Re.BypassTimeZoneLevel = (Define.BypassTimeZoneLevel)1;
                Re.OverWrite = true;
                Re.Group01 = 0b1;
                Re.Door01TZ = 1;

                SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, Re);
                SemacV14.Service.Actor Wrk = new Actor(Ea);
                Ea = Wrk.SendAndReceive();
                if (Ea.IsCompleted == true)
                {
                    UpCount = UpCount + 1;
                }
                else
                {

                }
            }
            lblCount.Text = UpCount.ToString();
        }

        private void btnAttendanceLog_Click(object sender, EventArgs e)
        {
            try
            {
                string ChannelID = this.dgv_Terminal.SelectedRows[0].Cells["ChannelIDColumn"].Value.ToString();
                int TerminalID = Convert.ToInt32(this.dgv_Terminal.SelectedRows[0].Cells["TerminalIDColumn"].Value);
                var re = new SemacV14.Request.CommonRequest(TerminalID, SemacV14.Define.CommandType.RetrievingAllEntryExitLog);
                SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, re);

                if (Ea == null) return;
                SemacV14.Service.Actor act = new Actor(Ea);
                act.OnEntityDataArrival += this.HandleEntity;
                act.Send();

            }
            catch (Exception ex)
            {
                WriteLog("btnAttendanceLog_Click", ex.Message);
                var r = ex.Message.ToString();
            }

        }
        private void btnOpenDoor_Click(object sender, EventArgs e)
        {
            try
            {
                string ChannelID = this.dgv_Terminal.SelectedRows[0].Cells["ChannelIDColumn"].Value.ToString();
                int TerminalID = Convert.ToInt32(this.dgv_Terminal.SelectedRows[0].Cells["TerminalIDColumn"].Value);

                var re = new SemacV14.Request.CommonRequest(TerminalID, SemacV14.Define.CommandType.PulseOpenDoor);
                SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, re);

                SemacV14.Service.Actor Wrk = new Actor(Ea);
                Ea = Wrk.SendAndReceive();

                if (Ea.IsCompleted == true)
                    MessageBox.Show("Door Opened");
                else
                    MessageBox.Show(Ea.ErrorMessage);
            }
            catch (Exception ex)
            {
                WriteLog("btnOpenDoor_Click", ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
        private void dgv_Terminal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //private void btnAccessFileUpload_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int UpCount = 0;
        //        //   UserId, UserName, CardNo, EmployeeID, UserType, BypassTimeZoneLevel default send 1,OverWrite( true),Group01= 0b1,Door01TZ =1
        //        DataTable dt = DBDal.getAccessFileUpload();
        //        if (dt != null)
        //        {
        //            if (dt.Rows.Count > 0)
        //            {
        //                foreach (DataRow dr in dt.Rows)
        //                {
        //                    string ChannelID = this.dgv_Terminal.SelectedRows[0].Cells["ChannelIDColumn"].Value.ToString();
        //                    int TerminalID = Convert.ToInt32(this.dgv_Terminal.SelectedRows[0].Cells["TerminalIDColumn"].Value);
        //                    SemacV14.Request.RegisterModifyUserDataRequest Re = new SemacV14.Request.RegisterModifyUserDataRequest(TerminalID);
        //                    var UserID = Convert.ToInt64(dr["UserId"].ToString());
        //                    Re.UserID =(UInt32)UserID;
        //                    Re.EnabledStatus = true;
        //                    Re.UserName = dr["UserName"].ToString();
        //                    Re.CardNo = dr["CardNo"].ToString();
        //                    Re.EmployeeID = dr["EmployeeID"].ToString();
        //                    Re.UserType = (Define.UserType)0;
        //                    Re.BypassTimeZoneLevel = (Define.BypassTimeZoneLevel)1;
        //                    Re.OverWrite = true;
        //                    Re.Group01 = 0b1;
        //                    Re.Door01TZ = 1;

        //                    SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, Re);
        //                    SemacV14.Service.Actor Wrk = new Actor(Ea);
        //                    Ea = Wrk.SendAndReceive();
        //                    if (Ea.IsCompleted == true)
        //                    {
        //                        UpCount = UpCount + 1;
        //                    }
        //                    else
        //                    {
        //                        lblExcutionStatus.Text += Ea.ErrorMessage.ToString();
        //                    }
        //                }
        //            }
        //        }

        //        isAccessupload = true;
        //        lblCount.Text = UpCount.ToString();
        //        lblExcutionStatus.Text = "process done!";
        //        return;
        //    }
        //    catch (Exception ex)
        //    {
        //        var r = ex.Message.ToString();
        //    }
        //}



        private void btnAccessFileUpload_Click(object sender, EventArgs e)
        {
            int UpCount = 0;
            foreach (DataRow termRow in GetTargetTerminals(sender))
            {

                string readerCode = termRow["TerminalID"].ToString();   // = tblReader.code
                string ChannelID = termRow["ChannelID"].ToString();
                int TerminalID;
                if (!int.TryParse(readerCode, out TerminalID)) continue;

                try
                {
                    DataTable dt = DBDal.GetTerminalAccessFile(readerCode);
                    if (dt == null) continue;

                    foreach (DataRow dr in dt.Rows)
                    {
                        try
                        {
                            SemacV14.Request.RegisterModifyUserDataRequest Re = new SemacV14.Request.RegisterModifyUserDataRequest(TerminalID);
                            var UserID = Convert.ToInt64(dr["UserId"].ToString());
                            Re.UserID = (UInt32)UserID;
                            Re.EnabledStatus = true;
                            Re.UserName = dr["UserName"].ToString();
                            Re.CardNo = dr["CardNo"].ToString();
                            Re.EmployeeID = dr["EmployeeID"].ToString();
                            Re.UserType = (Define.UserType)0;
                            Re.BypassTimeZoneLevel = (Define.BypassTimeZoneLevel)1;
                            Re.OverWrite = true;
                            Re.Group01 = 0b1;
                            Re.Door01TZ = 1;

                            SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, Re);
                            SemacV14.Service.Actor Wrk = new Actor(Ea);
                            Ea = Wrk.SendAndReceive();
                            if (Ea.IsCompleted == true)
                            {
                                DBDal.MarkSynced(Convert.ToInt32(UserID), readerCode, "Y", "");
                                UpCount = UpCount + 1;
                            }
                            else
                            {
                                lblExcutionStatus.Text = "[" + readerCode + "] " + Ea.ErrorMessage;
                            }
                        }
                        catch (Exception exUser)
                        {
                            WriteLog("btnAccessFileUpload_Click", exUser.Message);
                            lblExcutionStatus.Text = "[" + readerCode + "] " + exUser.Message;
                        }
                    }
                }
                catch (Exception exTerm)
                {
                    WriteLog("btnAccessFileUpload_Click", exTerm.Message);
                    lblExcutionStatus.Text = "[" + readerCode + "] " + exTerm.Message;
                }
            }

            isAccessupload = true;
            lblCount.Text = UpCount.ToString();
            lblExcutionStatus.Text = "process done!";
        }

        private void lsvMessage_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void pnlUserRegister_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRegisterUser_Click(object sender, EventArgs e)
        {

        }

        //private void btnAccLogDownload_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (this.dgv_Terminal.SelectedRows.Count <= 0)
        //            this.dgv_Terminal.Rows[0].Selected=true;
        //        string ChannelID = this.dgv_Terminal.SelectedRows[0].Cells["ChannelIDColumn"].Value.ToString();
        //        int TerminalID = Convert.ToInt32(this.dgv_Terminal.SelectedRows[0].Cells["TerminalIDColumn"].Value);
        //        var re = new SemacV14.Request.CommonRequest(TerminalID, SemacV14.Define.CommandType.RetrievingAllEntryExitLog);
        //        SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, re);

        //        HandleGetAllEntryLog(Ea);
        //    }
        //    catch (Exception ex)
        //    {
        //        lblExcutionStatus.Text = ex.Message.ToString();
        //    } 
        //}


        private void btnAccLogDownload_Click(object sender, EventArgs e)
        {
            foreach (DataRow termRow in GetTargetTerminals(sender))
            {

                string readerCode = termRow["TerminalID"].ToString();
                string ChannelID = termRow["ChannelID"].ToString();
                int TerminalID;
                if (!int.TryParse(readerCode, out TerminalID)) continue;

                try
                {
                    var re = new SemacV14.Request.CommonRequest(TerminalID, SemacV14.Define.CommandType.RetrievingAllEntryExitLog);
                    SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, re);

                    // The request was built but never actually sent to the device before -
                    // HandleGetAllEntryLog was called immediately on an empty Ea, so it always
                    // silently failed (blank error popup). Actor.Send() is what talks to the
                    // controller; the response arrives via OnEntityDataArrival.
                    SemacV14.Service.Actor act = new Actor(Ea);
                    act.OnEntityDataArrival += this.HandleGetAllEntryLog;
                    act.Send();
                }
                catch (Exception ex)
                {
                    WriteLog("btnAccLogDownload_Click", ex.Message);
                    lblExcutionStatus.Text = "[" + readerCode + "] " + ex.Message;
                }
            }
        }
        private void AccLogDownload(SemacV14.Service.ExecuteArgz Ea)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    BeginInvoke(new ExecuteHandler(this.HandleRealtime), Ea);
                }
                else
                {
                    if (!(Ea.EntityList == null))
                    {
                        foreach (SemacV14.Entity.DoorLogEntity En in Ea.EntityList)
                        {
                            //ListViewItem item = new ListViewItem(System.DateTime.Now.ToString("T"));
                            //item.SubItems.Add(Ea.CommandType.ToString());
                            //item.SubItems.Add(En.ToMyString);
                            //this.AddMessage(item);

                            ////Only for test here
                            ListViewItem item2 = new ListViewItem(System.DateTime.Now.ToString("T"));
                            SemacV14.Entity.DoorLogEntity Log = (SemacV14.Entity.DoorLogEntity)En;
                            item2.SubItems.Add("Function Key");
                            item2.SubItems.Add("FunctionKey:" + Log.FunctionKey + ",FkeyID:" + Log.FunctionKeyInt32.ToString());
                            this.AddMessage(item2);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog("AccLogDownload", ex.Message);
                MessageBox.Show(ex.Message);
            }

        }

        //private void btnAccessFileUpload_Click_1(object sender, EventArgs e)
        //{
        //    btnAccessFileUpload_Click(sender, e);
        //}

        //private void btnAttendanceLog_Click_1(object sender, EventArgs e)
        //{

        //}
        // getAccessNewUserFile, getAccessNewUserFile, getAccessBlockFile, getAccessFile, getLostDamageFile, getAccessRevokeList
        //private void btnNewlyAddedUpload_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int UpCount = 0;
        //        //   UserId, UserName, CardNo, EmployeeID, UserType, BypassTimeZoneLevel default send 1,OverWrite( true),Group01= 0b1,Door01TZ =1
        //        DataTable dt = DBDal.getAccessNewUserFileUpload();
        //        if (dt != null)
        //        {
        //            if (dt.Rows.Count > 0)
        //            {
        //                foreach (DataRow dr in dt.Rows)
        //                {
        //                    string ChannelID = this.dgv_Terminal.SelectedRows[0].Cells["ChannelIDColumn"].Value.ToString();
        //                    int TerminalID = Convert.ToInt32(this.dgv_Terminal.SelectedRows[0].Cells["TerminalIDColumn"].Value);
        //                    SemacV14.Request.RegisterModifyUserDataRequest Re = new SemacV14.Request.RegisterModifyUserDataRequest(TerminalID);
        //                    int UserID = Convert.ToInt32(dr["UserId"].ToString());
        //                    Re.UserID = (uint)UserID;
        //                    Re.EnabledStatus = true;
        //                    Re.UserName = dr["UserName"].ToString();
        //                    Re.CardNo = dr["CardNo"].ToString();
        //                    Re.EmployeeID = dr["EmployeeID"].ToString();
        //                    Re.UserType = (Define.UserType)0;
        //                    Re.BypassTimeZoneLevel = (Define.BypassTimeZoneLevel)1;
        //                    Re.OverWrite = true;
        //                    Re.Group01 = 0b1;
        //                    Re.Door01TZ = 1;

        //                    SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, Re);
        //                    SemacV14.Service.Actor Wrk = new Actor(Ea);
        //                    Ea = Wrk.SendAndReceive();
        //                    if (Ea.IsCompleted == true)
        //                    {
        //                        UpCount = UpCount + 1;
        //                    }
        //                    else
        //                    {
        //                        lblExcutionStatus.Text = Ea.ErrorMessage.ToString();
        //                    }
        //                }
        //            }
        //        }

        //        lblCount.Text = UpCount.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        var r = ex.Message.ToString();
        //    }

        //}



        private void btnNewlyAddedUpload_Click(object sender, EventArgs e)
        {
            int UpCount = 0;
            foreach (DataRow termRow in GetTargetTerminals(sender))
            {

                string readerCode = termRow["TerminalID"].ToString();   // = tblReader.code (Falcon ya Skylark, jo bhi connected ho)
                string ChannelID = termRow["ChannelID"].ToString();
                int TerminalID;
                if (!int.TryParse(readerCode, out TerminalID)) continue;

                try
                {
                    DataTable dt = DBDal.GetTerminalAccessFile(readerCode);
                    if (dt == null) continue;

                    foreach (DataRow dr in dt.Rows)
                    {
                        try
                        {
                            SemacV14.Request.RegisterModifyUserDataRequest Re = new SemacV14.Request.RegisterModifyUserDataRequest(TerminalID);
                            int UserID = Convert.ToInt32(dr["UserId"].ToString());
                            Re.UserID = (uint)UserID;
                            Re.EnabledStatus = true;
                            Re.UserName = dr["UserName"].ToString();
                            Re.CardNo = dr["CardNo"].ToString();
                            Re.EmployeeID = dr["EmployeeID"].ToString();
                            Re.UserType = (Define.UserType)0;
                            Re.BypassTimeZoneLevel = (Define.BypassTimeZoneLevel)1;
                            Re.OverWrite = true;
                            Re.Group01 = 0b1;
                            Re.Door01TZ = 1;

                            SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, Re);
                            SemacV14.Service.Actor Wrk = new Actor(Ea);
                            Ea = Wrk.SendAndReceive();
                            if (Ea.IsCompleted == true)
                            {
                                DBDal.MarkSynced(UserID, readerCode, "Y", "");
                                UpCount = UpCount + 1;
                            }
                            else
                            {
                                lblExcutionStatus.Text = "[" + readerCode + "] " + Ea.ErrorMessage;
                            }
                        }
                        catch (Exception exUser)
                        {
                            WriteLog("btnNewlyAddedUpload_Click", exUser.Message);
                            lblExcutionStatus.Text = "[" + readerCode + "] " + exUser.Message;
                        }
                    }
                }
                catch (Exception exTerm)
                {
                    WriteLog("btnNewlyAddedUpload_Click", exTerm.Message);
                    lblExcutionStatus.Text = "[" + readerCode + "] " + exTerm.Message;
                }
            }

            lblCount.Text = UpCount.ToString();
        }

        //private void btnAccessBlockUpload_Click(object sender, EventArgs e)
        //{ 
        //    try
        //    {
        //        int UpCount = 0;
        //        //   UserId, UserName, CardNo, EmployeeID, UserType, BypassTimeZoneLevel default send 1,OverWrite( true),Group01= 0b1,Door01TZ =1
        //        DataTable dt = DBDal.getAccessBlockListUpload();
        //        if (dt != null)
        //        {
        //            if (dt.Rows.Count > 0)
        //            {
        //                foreach (DataRow dr in dt.Rows)
        //                {
        //                    string ChannelID = this.dgv_Terminal.SelectedRows[0].Cells["ChannelIDColumn"].Value.ToString();
        //                    int TerminalID = Convert.ToInt32(this.dgv_Terminal.SelectedRows[0].Cells["TerminalIDColumn"].Value);
        //                    SemacV14.Request.RegisterModifyUserDataRequest Re = new SemacV14.Request.RegisterModifyUserDataRequest(TerminalID);
        //                    int UserID = Convert.ToInt32(dr["UserId"].ToString());
        //                    Re.UserID = (uint)UserID;
        //                    Re.EnabledStatus = false;
        //                    Re.UserName = dr["UserName"].ToString();
        //                    Re.CardNo = dr["CardNo"].ToString();
        //                    Re.EmployeeID = dr["EmployeeID"].ToString();
        //                    Re.UserType = (Define.UserType)0;
        //                    Re.BypassTimeZoneLevel = (Define.BypassTimeZoneLevel)1;
        //                    Re.OverWrite = true;
        //                    Re.Group01 = 0b1;
        //                    Re.Door01TZ = 1;

        //                    SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, Re);
        //                    SemacV14.Service.Actor Wrk = new Actor(Ea);
        //                    Ea = Wrk.SendAndReceive();
        //                    if (Ea.IsCompleted == true)
        //                    {
        //                        UpCount = UpCount + 1;
        //                    }
        //                    else
        //                    {
        //                        lblExcutionStatus.Text = Ea.ErrorMessage.ToString();
        //                    }
        //                }
        //            }
        //        }

        //        lblCount.Text = UpCount.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        var r = ex.Message.ToString();
        //    }

        //}



        private void btnAccessBlockUpload_Click(object sender, EventArgs e)
        {
            int UpCount = 0;
            foreach (DataRow termRow in GetTargetTerminals(sender))
            {

                string readerCode = termRow["TerminalID"].ToString();
                string ChannelID = termRow["ChannelID"].ToString();
                int TerminalID;
                if (!int.TryParse(readerCode, out TerminalID)) continue;

                try
                {
                    DataTable dt = DBDal.GetTerminalBlockFile(readerCode);
                    if (dt == null) continue;

                    foreach (DataRow dr in dt.Rows)
                    {
                        try
                        {
                            SemacV14.Request.RegisterModifyUserDataRequest Re = new SemacV14.Request.RegisterModifyUserDataRequest(TerminalID);
                            int UserID = Convert.ToInt32(dr["UserId"].ToString());
                            Re.UserID = (uint)UserID;
                            Re.EnabledStatus = false;
                            Re.UserName = dr["UserName"].ToString();
                            Re.CardNo = dr["CardNo"].ToString();
                            Re.EmployeeID = dr["EmployeeID"].ToString();
                            Re.UserType = (Define.UserType)0;
                            Re.BypassTimeZoneLevel = (Define.BypassTimeZoneLevel)1;
                            Re.OverWrite = true;
                            Re.Group01 = 0b1;
                            Re.Door01TZ = 1;

                            SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, Re);
                            SemacV14.Service.Actor Wrk = new Actor(Ea);
                            Ea = Wrk.SendAndReceive();
                            if (Ea.IsCompleted == true)
                            {
                                DBDal.MarkSynced(UserID, readerCode, "", "B");
                                UpCount = UpCount + 1;
                            }
                            else
                            {
                                lblExcutionStatus.Text = "[" + readerCode + "] " + Ea.ErrorMessage;
                            }
                        }
                        catch (Exception exUser)
                        {
                            WriteLog("btnAccessBlockUpload_Click", exUser.Message);
                            lblExcutionStatus.Text = "[" + readerCode + "] " + exUser.Message;
                        }
                    }
                }
                catch (Exception exTerm)
                {
                    WriteLog("btnAccessBlockUpload_Click", exTerm.Message);
                    lblExcutionStatus.Text = "[" + readerCode + "] " + exTerm.Message;
                }
            }

            lblCount.Text = UpCount.ToString();
        }

        //private void btnAccessRevokUpload_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int UpCount = 0;
        //        //   UserId, UserName, CardNo, EmployeeID, UserType, BypassTimeZoneLevel default send 1,OverWrite( true),Group01= 0b1,Door01TZ =1
        //        DataTable dt = DBDal.getAccessRevokeFileUpload();
        //        if (dt != null)
        //        {
        //            if (dt.Rows.Count > 0)
        //            {
        //                foreach (DataRow dr in dt.Rows)
        //                {
        //                    string ChannelID = this.dgv_Terminal.SelectedRows[0].Cells["ChannelIDColumn"].Value.ToString();
        //                    int TerminalID = Convert.ToInt32(this.dgv_Terminal.SelectedRows[0].Cells["TerminalIDColumn"].Value);
        //                    SemacV14.Request.RegisterModifyUserDataRequest Re = new SemacV14.Request.RegisterModifyUserDataRequest(TerminalID);
        //                    int UserID = Convert.ToInt32(dr["UserId"].ToString());
        //                    Re.UserID = (uint)UserID;
        //                    Re.EnabledStatus = true;
        //                    Re.UserName = dr["UserName"].ToString();
        //                    Re.CardNo = dr["CardNo"].ToString();
        //                    Re.EmployeeID = dr["EmployeeID"].ToString();
        //                    Re.UserType = (Define.UserType)0;
        //                    Re.BypassTimeZoneLevel = (Define.BypassTimeZoneLevel)1;
        //                    Re.OverWrite = true;
        //                    Re.Group01 = 0b1;
        //                    Re.Door01TZ = 1;

        //                    SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, Re);
        //                    SemacV14.Service.Actor Wrk = new Actor(Ea);
        //                    Ea = Wrk.SendAndReceive();
        //                    if (Ea.IsCompleted == true)
        //                    {
        //                        UpCount = UpCount + 1;
        //                    }
        //                    else
        //                    {
        //                        lblExcutionStatus.Text = Ea.ErrorMessage.ToString();
        //                    }
        //                }
        //            }
        //        }

        //        lblCount.Text = UpCount.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        var r = ex.Message.ToString();
        //    }

        //}



        private void btnAccessRevokUpload_Click(object sender, EventArgs e)
        {
            int UpCount = 0;
            foreach (DataRow termRow in GetTargetTerminals(sender))
            {

                string readerCode = termRow["TerminalID"].ToString();
                string ChannelID = termRow["ChannelID"].ToString();
                int TerminalID;
                if (!int.TryParse(readerCode, out TerminalID)) continue;

                try
                {
                    DataTable dt = DBDal.GetTerminalRevokeFile(readerCode);
                    if (dt == null) continue;

                    foreach (DataRow dr in dt.Rows)
                    {
                        try
                        {
                            SemacV14.Request.RegisterModifyUserDataRequest Re = new SemacV14.Request.RegisterModifyUserDataRequest(TerminalID);
                            int UserID = Convert.ToInt32(dr["UserId"].ToString());
                            Re.UserID = (uint)UserID;
                            Re.EnabledStatus = true;
                            Re.UserName = dr["UserName"].ToString();
                            Re.CardNo = dr["CardNo"].ToString();
                            Re.EmployeeID = dr["EmployeeID"].ToString();
                            Re.UserType = (Define.UserType)0;
                            Re.BypassTimeZoneLevel = (Define.BypassTimeZoneLevel)1;
                            Re.OverWrite = true;
                            Re.Group01 = 0b1;
                            Re.Door01TZ = 1;

                            SemacV14.Service.ExecuteArgz Ea = new SemacV14.Service.ExecuteArgz(ChannelID, Re);
                            SemacV14.Service.Actor Wrk = new Actor(Ea);
                            Ea = Wrk.SendAndReceive();
                            if (Ea.IsCompleted == true)
                            {
                                DBDal.MarkSynced(UserID, readerCode, "", "R");
                                UpCount = UpCount + 1;
                            }
                            else
                            {
                                lblExcutionStatus.Text = "[" + readerCode + "] " + Ea.ErrorMessage;
                            }
                        }
                        catch (Exception exUser)
                        {
                            WriteLog("btnAccessRevokUpload_Click", exUser.Message);
                            lblExcutionStatus.Text = "[" + readerCode + "] " + exUser.Message;
                        }
                    }
                }
                catch (Exception exTerm)
                {
                    WriteLog("btnAccessRevokUpload_Click", exTerm.Message);
                    lblExcutionStatus.Text = "[" + readerCode + "] " + exTerm.Message;
                }
            }

            lblCount.Text = UpCount.ToString();
        }

        private void rdbActivate_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lsvMessage_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}