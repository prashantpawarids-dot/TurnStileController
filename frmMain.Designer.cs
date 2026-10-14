namespace Demo_CSharp
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_Terminal = new System.Windows.Forms.DataGridView();
            this.ChannelIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TerminalIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MacColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModelNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirmvareVersionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lsvMessage = new System.Windows.Forms.ListView();
            this.colTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCommand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDetail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlUserRegister = new System.Windows.Forms.Panel();
            this.btnRegisterUser = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbDeActivate = new System.Windows.Forms.RadioButton();
            this.btnImportFile = new System.Windows.Forms.Button();
            this.btnGetUser = new System.Windows.Forms.Button();
            this.rdbActivate = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmployeeId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblExcutionStatus = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAccessRevokUpload = new System.Windows.Forms.Button();
            this.btnAccessBlockUpload = new System.Windows.Forms.Button();
            this.btnNewlyAddedUpload = new System.Windows.Forms.Button();
            this.btnAttendanceLog = new System.Windows.Forms.Button();
            this.btnAccLogDownload = new System.Windows.Forms.Button();
            this.btnAccessFileUpload = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Terminal)).BeginInit();
            this.panel3.SuspendLayout();
            this.pnlUserRegister.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv_Terminal);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1121, 64);
            this.panel1.TabIndex = 3;
            // 
            // dgv_Terminal
            // 
            this.dgv_Terminal.AllowUserToAddRows = false;
            this.dgv_Terminal.AllowUserToDeleteRows = false;
            this.dgv_Terminal.AllowUserToResizeRows = false;
            this.dgv_Terminal.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Terminal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_Terminal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Terminal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChannelIDColumn,
            this.StatusColumn,
            this.TerminalIDColumn,
            this.IPColumn,
            this.MacColumn,
            this.SerialNoColumn,
            this.ModelNameColumn,
            this.FirmvareVersionColumn});
            this.dgv_Terminal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Terminal.Location = new System.Drawing.Point(0, 0);
            this.dgv_Terminal.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_Terminal.MultiSelect = false;
            this.dgv_Terminal.Name = "dgv_Terminal";
            this.dgv_Terminal.ReadOnly = true;
            this.dgv_Terminal.RowHeadersVisible = false;
            this.dgv_Terminal.RowHeadersWidth = 11;
            this.dgv_Terminal.RowTemplate.Height = 20;
            this.dgv_Terminal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Terminal.Size = new System.Drawing.Size(1121, 64);
            this.dgv_Terminal.TabIndex = 2;
            this.dgv_Terminal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Terminal_CellContentClick);
            // 
            // ChannelIDColumn
            // 
            this.ChannelIDColumn.DataPropertyName = "ChannelID";
            this.ChannelIDColumn.HeaderText = "ChannelID";
            this.ChannelIDColumn.MinimumWidth = 6;
            this.ChannelIDColumn.Name = "ChannelIDColumn";
            this.ChannelIDColumn.ReadOnly = true;
            this.ChannelIDColumn.Visible = false;
            this.ChannelIDColumn.Width = 125;
            // 
            // StatusColumn
            // 
            this.StatusColumn.DataPropertyName = "Status";
            this.StatusColumn.HeaderText = "Status";
            this.StatusColumn.MinimumWidth = 6;
            this.StatusColumn.Name = "StatusColumn";
            this.StatusColumn.ReadOnly = true;
            this.StatusColumn.Width = 125;
            // 
            // TerminalIDColumn
            // 
            this.TerminalIDColumn.DataPropertyName = "TerminalID";
            this.TerminalIDColumn.HeaderText = "TerminalID";
            this.TerminalIDColumn.MinimumWidth = 6;
            this.TerminalIDColumn.Name = "TerminalIDColumn";
            this.TerminalIDColumn.ReadOnly = true;
            this.TerminalIDColumn.Width = 125;
            // 
            // IPColumn
            // 
            this.IPColumn.DataPropertyName = "IPAddress";
            this.IPColumn.HeaderText = "IP Address";
            this.IPColumn.MinimumWidth = 6;
            this.IPColumn.Name = "IPColumn";
            this.IPColumn.ReadOnly = true;
            this.IPColumn.Width = 200;
            // 
            // MacColumn
            // 
            this.MacColumn.DataPropertyName = "MacAddress";
            this.MacColumn.HeaderText = "Mac Address";
            this.MacColumn.MinimumWidth = 6;
            this.MacColumn.Name = "MacColumn";
            this.MacColumn.ReadOnly = true;
            this.MacColumn.Width = 120;
            // 
            // SerialNoColumn
            // 
            this.SerialNoColumn.DataPropertyName = "SerialNo";
            this.SerialNoColumn.HeaderText = "Serial No";
            this.SerialNoColumn.MinimumWidth = 6;
            this.SerialNoColumn.Name = "SerialNoColumn";
            this.SerialNoColumn.ReadOnly = true;
            this.SerialNoColumn.Width = 150;
            // 
            // ModelNameColumn
            // 
            this.ModelNameColumn.DataPropertyName = "ModelName";
            this.ModelNameColumn.HeaderText = "ModelName";
            this.ModelNameColumn.MinimumWidth = 6;
            this.ModelNameColumn.Name = "ModelNameColumn";
            this.ModelNameColumn.ReadOnly = true;
            this.ModelNameColumn.Width = 120;
            // 
            // FirmvareVersionColumn
            // 
            this.FirmvareVersionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FirmvareVersionColumn.DataPropertyName = "FirmwareVersion";
            this.FirmvareVersionColumn.HeaderText = "FirmwareVersion";
            this.FirmvareVersionColumn.MinimumWidth = 6;
            this.FirmvareVersionColumn.Name = "FirmvareVersionColumn";
            this.FirmvareVersionColumn.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lsvMessage);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(300, 313);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(821, 244);
            this.panel3.TabIndex = 4;
            // 
            // lsvMessage
            // 
            this.lsvMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvMessage.BackColor = System.Drawing.SystemColors.MenuText;
            this.lsvMessage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTime,
            this.colCommand,
            this.colDetail});
            this.lsvMessage.ForeColor = System.Drawing.Color.Chartreuse;
            this.lsvMessage.FullRowSelect = true;
            this.lsvMessage.HideSelection = false;
            this.lsvMessage.Location = new System.Drawing.Point(12, 24);
            this.lsvMessage.Margin = new System.Windows.Forms.Padding(4);
            this.lsvMessage.MultiSelect = false;
            this.lsvMessage.Name = "lsvMessage";
            this.lsvMessage.ShowItemToolTips = true;
            this.lsvMessage.Size = new System.Drawing.Size(796, 212);
            this.lsvMessage.TabIndex = 7;
            this.lsvMessage.UseCompatibleStateImageBehavior = false;
            this.lsvMessage.View = System.Windows.Forms.View.Details;
            this.lsvMessage.SelectedIndexChanged += new System.EventHandler(this.lsvMessage_SelectedIndexChanged_1);
            // 
            // colTime
            // 
            this.colTime.Text = "Time";
            // 
            // colCommand
            // 
            this.colCommand.Text = "Command";
            this.colCommand.Width = 180;
            // 
            // colDetail
            // 
            this.colDetail.Text = "Detail";
            this.colDetail.Width = 500;
            // 
            // pnlUserRegister
            // 
            this.pnlUserRegister.Controls.Add(this.btnRegisterUser);
            this.pnlUserRegister.Controls.Add(this.lblCount);
            this.pnlUserRegister.Controls.Add(this.label1);
            this.pnlUserRegister.Controls.Add(this.rdbDeActivate);
            this.pnlUserRegister.Controls.Add(this.btnImportFile);
            this.pnlUserRegister.Controls.Add(this.btnGetUser);
            this.pnlUserRegister.Controls.Add(this.rdbActivate);
            this.pnlUserRegister.Controls.Add(this.btnSave);
            this.pnlUserRegister.Controls.Add(this.label7);
            this.pnlUserRegister.Controls.Add(this.txtEmployeeId);
            this.pnlUserRegister.Controls.Add(this.label6);
            this.pnlUserRegister.Controls.Add(this.txtCardNo);
            this.pnlUserRegister.Controls.Add(this.label5);
            this.pnlUserRegister.Controls.Add(this.txtUserName);
            this.pnlUserRegister.Controls.Add(this.label4);
            this.pnlUserRegister.Controls.Add(this.txtUserId);
            this.pnlUserRegister.Controls.Add(this.label3);
            this.pnlUserRegister.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlUserRegister.Location = new System.Drawing.Point(0, 64);
            this.pnlUserRegister.Name = "pnlUserRegister";
            this.pnlUserRegister.Size = new System.Drawing.Size(300, 504);
            this.pnlUserRegister.TabIndex = 5;
            this.pnlUserRegister.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlUserRegister_Paint);
            // 
            // btnRegisterUser
            // 
            this.btnRegisterUser.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRegisterUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegisterUser.Location = new System.Drawing.Point(15, 199);
            this.btnRegisterUser.Name = "btnRegisterUser";
            this.btnRegisterUser.Size = new System.Drawing.Size(118, 30);
            this.btnRegisterUser.TabIndex = 11;
            this.btnRegisterUser.Text = "User Register";
            this.btnRegisterUser.UseVisualStyleBackColor = false;
            this.btnRegisterUser.Click += new System.EventHandler(this.btnRegisterUser_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(212, 239);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(20, 20);
            this.lblCount.TabIndex = 10;
            this.lblCount.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Count :";
            // 
            // rdbDeActivate
            // 
            this.rdbDeActivate.AutoSize = true;
            this.rdbDeActivate.Location = new System.Drawing.Point(195, 173);
            this.rdbDeActivate.Name = "rdbDeActivate";
            this.rdbDeActivate.Size = new System.Drawing.Size(123, 24);
            this.rdbDeActivate.TabIndex = 8;
            this.rdbDeActivate.TabStop = true;
            this.rdbDeActivate.Text = "DeActivate";
            this.rdbDeActivate.UseVisualStyleBackColor = true;
            // 
            // btnImportFile
            // 
            this.btnImportFile.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnImportFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportFile.Location = new System.Drawing.Point(143, 10);
            this.btnImportFile.Name = "btnImportFile";
            this.btnImportFile.Size = new System.Drawing.Size(135, 30);
            this.btnImportFile.TabIndex = 0;
            this.btnImportFile.Text = "Bulk Upload";
            this.btnImportFile.UseVisualStyleBackColor = false;
            this.btnImportFile.Click += new System.EventHandler(this.btnImportFile_Click);
            // 
            // btnGetUser
            // 
            this.btnGetUser.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGetUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetUser.Location = new System.Drawing.Point(26, 10);
            this.btnGetUser.Name = "btnGetUser";
            this.btnGetUser.Size = new System.Drawing.Size(111, 30);
            this.btnGetUser.TabIndex = 0;
            this.btnGetUser.Text = "Get User";
            this.btnGetUser.UseVisualStyleBackColor = false;
            this.btnGetUser.Click += new System.EventHandler(this.btnGetUser_Click);
            // 
            // rdbActivate
            // 
            this.rdbActivate.AutoSize = true;
            this.rdbActivate.Location = new System.Drawing.Point(107, 173);
            this.rdbActivate.Name = "rdbActivate";
            this.rdbActivate.Size = new System.Drawing.Size(100, 24);
            this.rdbActivate.TabIndex = 8;
            this.rdbActivate.TabStop = true;
            this.rdbActivate.Text = "Activate";
            this.rdbActivate.UseVisualStyleBackColor = true;
            this.rdbActivate.CheckedChanged += new System.EventHandler(this.rdbActivate_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(160, 199);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Status :";
            // 
            // txtEmployeeId
            // 
            this.txtEmployeeId.Location = new System.Drawing.Point(106, 140);
            this.txtEmployeeId.Name = "txtEmployeeId";
            this.txtEmployeeId.Size = new System.Drawing.Size(132, 27);
            this.txtEmployeeId.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Employee Id :";
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point(106, 110);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(132, 27);
            this.txtCardNo.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Card No :";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(106, 80);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(132, 27);
            this.txtUserName.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "User Name :";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(106, 50);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(132, 27);
            this.txtUserId.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "User Id :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblExcutionStatus);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.btnAccessRevokUpload);
            this.panel2.Controls.Add(this.btnAccessBlockUpload);
            this.panel2.Controls.Add(this.btnNewlyAddedUpload);
            this.panel2.Controls.Add(this.btnAttendanceLog);
            this.panel2.Controls.Add(this.btnAccLogDownload);
            this.panel2.Controls.Add(this.btnAccessFileUpload);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(300, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(821, 249);
            this.panel2.TabIndex = 7;
            // 
            // lblExcutionStatus
            // 
            this.lblExcutionStatus.AutoSize = true;
            this.lblExcutionStatus.Location = new System.Drawing.Point(243, 173);
            this.lblExcutionStatus.Name = "lblExcutionStatus";
            this.lblExcutionStatus.Size = new System.Drawing.Size(20, 20);
            this.lblExcutionStatus.TabIndex = 12;
            this.lblExcutionStatus.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(240, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Current Execution Status :";
            // 
            // btnAccessRevokUpload
            // 
            this.btnAccessRevokUpload.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAccessRevokUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccessRevokUpload.Location = new System.Drawing.Point(387, 121);
            this.btnAccessRevokUpload.Name = "btnAccessRevokUpload";
            this.btnAccessRevokUpload.Size = new System.Drawing.Size(184, 30);
            this.btnAccessRevokUpload.TabIndex = 8;
            this.btnAccessRevokUpload.Text = "Access Revok(allow)";
            this.btnAccessRevokUpload.UseVisualStyleBackColor = false;
            this.btnAccessRevokUpload.Click += new System.EventHandler(this.btnAccessRevokUpload_Click);
            // 
            // btnAccessBlockUpload
            // 
            this.btnAccessBlockUpload.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAccessBlockUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccessBlockUpload.Location = new System.Drawing.Point(387, 76);
            this.btnAccessBlockUpload.Name = "btnAccessBlockUpload";
            this.btnAccessBlockUpload.Size = new System.Drawing.Size(184, 30);
            this.btnAccessBlockUpload.TabIndex = 7;
            this.btnAccessBlockUpload.Text = "Access Blocked Upload";
            this.btnAccessBlockUpload.UseVisualStyleBackColor = false;
            this.btnAccessBlockUpload.Click += new System.EventHandler(this.btnAccessBlockUpload_Click);
            // 
            // btnNewlyAddedUpload
            // 
            this.btnNewlyAddedUpload.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNewlyAddedUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewlyAddedUpload.Location = new System.Drawing.Point(387, 28);
            this.btnNewlyAddedUpload.Name = "btnNewlyAddedUpload";
            this.btnNewlyAddedUpload.Size = new System.Drawing.Size(184, 30);
            this.btnNewlyAddedUpload.TabIndex = 6;
            this.btnNewlyAddedUpload.Text = "New User Upload";
            this.btnNewlyAddedUpload.UseVisualStyleBackColor = false;
            this.btnNewlyAddedUpload.Click += new System.EventHandler(this.btnNewlyAddedUpload_Click);
            // 
            // btnAttendanceLog
            // 
            this.btnAttendanceLog.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAttendanceLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttendanceLog.Location = new System.Drawing.Point(164, 123);
            this.btnAttendanceLog.Name = "btnAttendanceLog";
            this.btnAttendanceLog.Size = new System.Drawing.Size(184, 30);
            this.btnAttendanceLog.TabIndex = 3;
            this.btnAttendanceLog.Text = "Attendance Log";
            this.btnAttendanceLog.UseVisualStyleBackColor = false;
            this.btnAttendanceLog.Visible = false;
            this.btnAttendanceLog.Click += new System.EventHandler(this.btnAttendanceLog_Click);
            // 
            // btnAccLogDownload
            // 
            this.btnAccLogDownload.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAccLogDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccLogDownload.Location = new System.Drawing.Point(164, 76);
            this.btnAccLogDownload.Name = "btnAccLogDownload";
            this.btnAccLogDownload.Size = new System.Drawing.Size(184, 30);
            this.btnAccLogDownload.TabIndex = 5;
            this.btnAccLogDownload.Text = "Access Log Download";
            this.btnAccLogDownload.UseVisualStyleBackColor = false;
            this.btnAccLogDownload.Click += new System.EventHandler(this.btnAccLogDownload_Click);
            // 
            // btnAccessFileUpload
            // 
            this.btnAccessFileUpload.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAccessFileUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccessFileUpload.Location = new System.Drawing.Point(164, 28);
            this.btnAccessFileUpload.Name = "btnAccessFileUpload";
            this.btnAccessFileUpload.Size = new System.Drawing.Size(184, 30);
            this.btnAccessFileUpload.TabIndex = 4;
            this.btnAccessFileUpload.Text = "Access Log Upload";
            this.btnAccessFileUpload.UseVisualStyleBackColor = false;
            this.btnAccessFileUpload.Click += new System.EventHandler(this.btnAccessFileUpload_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 568);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlUserRegister);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "SemacV14 - Demo2.2(C#)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Terminal)).EndInit();
            this.panel3.ResumeLayout(false);
            this.pnlUserRegister.ResumeLayout(false);
            this.pnlUserRegister.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnlUserRegister;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEmployeeId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCardNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdbDeActivate;
        private System.Windows.Forms.RadioButton rdbActivate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnGetUser;
        private System.Windows.Forms.Button btnImportFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCount;
        internal System.Windows.Forms.DataGridView dgv_Terminal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChannelIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TerminalIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MacColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirmvareVersionColumn;
        private System.Windows.Forms.Button btnRegisterUser;
        internal System.Windows.Forms.ListView lsvMessage;
        internal System.Windows.Forms.ColumnHeader colTime;
        internal System.Windows.Forms.ColumnHeader colCommand;
        internal System.Windows.Forms.ColumnHeader colDetail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNewlyAddedUpload;
        private System.Windows.Forms.Button btnAttendanceLog;
        private System.Windows.Forms.Button btnAccLogDownload;
        private System.Windows.Forms.Button btnAccessFileUpload;
        private System.Windows.Forms.Button btnAccessRevokUpload;
        private System.Windows.Forms.Button btnAccessBlockUpload;
        private System.Windows.Forms.Label lblExcutionStatus;
        private System.Windows.Forms.Label label8;
    }
}

