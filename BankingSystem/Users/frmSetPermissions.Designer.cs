namespace BankingSystem
{
    partial class frmSetPermissions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ckbFullAccess = new System.Windows.Forms.CheckBox();
            this.ckbManagePeople = new System.Windows.Forms.CheckBox();
            this.ckbListClients = new System.Windows.Forms.CheckBox();
            this.ckbManageUsers = new System.Windows.Forms.CheckBox();
            this.ckbUpdateClient = new System.Windows.Forms.CheckBox();
            this.ckbAddClient = new System.Windows.Forms.CheckBox();
            this.ckbChangePinCode = new System.Windows.Forms.CheckBox();
            this.ckbDeleteClient = new System.Windows.Forms.CheckBox();
            this.ckbShowTransferLog = new System.Windows.Forms.CheckBox();
            this.ckbTransactions = new System.Windows.Forms.CheckBox();
            this.ckbShowLogInRegister = new System.Windows.Forms.CheckBox();
            this.gbPermissions = new System.Windows.Forms.GroupBox();
            this.btnSave = new FontAwesome.Sharp.IconButton();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.gbPermissions.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(113, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Permissions Screen";
            // 
            // ckbFullAccess
            // 
            this.ckbFullAccess.AutoSize = true;
            this.ckbFullAccess.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbFullAccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ckbFullAccess.Location = new System.Drawing.Point(22, 76);
            this.ckbFullAccess.Name = "ckbFullAccess";
            this.ckbFullAccess.Size = new System.Drawing.Size(97, 24);
            this.ckbFullAccess.TabIndex = 1;
            this.ckbFullAccess.Text = "Full Access";
            this.ckbFullAccess.UseVisualStyleBackColor = true;
            this.ckbFullAccess.CheckedChanged += new System.EventHandler(this.ckbFullAccess_CheckedChanged);
            // 
            // ckbManagePeople
            // 
            this.ckbManagePeople.AutoSize = true;
            this.ckbManagePeople.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbManagePeople.ForeColor = System.Drawing.SystemColors.InfoText;
            this.ckbManagePeople.Location = new System.Drawing.Point(6, 27);
            this.ckbManagePeople.Name = "ckbManagePeople";
            this.ckbManagePeople.Size = new System.Drawing.Size(126, 24);
            this.ckbManagePeople.TabIndex = 2;
            this.ckbManagePeople.Text = "Manage People";
            this.ckbManagePeople.UseVisualStyleBackColor = true;
            // 
            // ckbListClients
            // 
            this.ckbListClients.AutoSize = true;
            this.ckbListClients.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbListClients.ForeColor = System.Drawing.SystemColors.InfoText;
            this.ckbListClients.Location = new System.Drawing.Point(6, 73);
            this.ckbListClients.Name = "ckbListClients";
            this.ckbListClients.Size = new System.Drawing.Size(101, 24);
            this.ckbListClients.TabIndex = 4;
            this.ckbListClients.Text = "List Clients";
            this.ckbListClients.UseVisualStyleBackColor = true;
            // 
            // ckbManageUsers
            // 
            this.ckbManageUsers.AutoSize = true;
            this.ckbManageUsers.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbManageUsers.ForeColor = System.Drawing.SystemColors.InfoText;
            this.ckbManageUsers.Location = new System.Drawing.Point(192, 27);
            this.ckbManageUsers.Name = "ckbManageUsers";
            this.ckbManageUsers.Size = new System.Drawing.Size(120, 24);
            this.ckbManageUsers.TabIndex = 3;
            this.ckbManageUsers.Text = "Manage Users";
            this.ckbManageUsers.UseVisualStyleBackColor = true;
            // 
            // ckbUpdateClient
            // 
            this.ckbUpdateClient.AutoSize = true;
            this.ckbUpdateClient.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbUpdateClient.ForeColor = System.Drawing.SystemColors.InfoText;
            this.ckbUpdateClient.Location = new System.Drawing.Point(6, 121);
            this.ckbUpdateClient.Name = "ckbUpdateClient";
            this.ckbUpdateClient.Size = new System.Drawing.Size(119, 24);
            this.ckbUpdateClient.TabIndex = 6;
            this.ckbUpdateClient.Text = "Update Client";
            this.ckbUpdateClient.UseVisualStyleBackColor = true;
            // 
            // ckbAddClient
            // 
            this.ckbAddClient.AutoSize = true;
            this.ckbAddClient.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbAddClient.ForeColor = System.Drawing.SystemColors.InfoText;
            this.ckbAddClient.Location = new System.Drawing.Point(192, 73);
            this.ckbAddClient.Name = "ckbAddClient";
            this.ckbAddClient.Size = new System.Drawing.Size(130, 24);
            this.ckbAddClient.TabIndex = 5;
            this.ckbAddClient.Text = "Add New Client";
            this.ckbAddClient.UseVisualStyleBackColor = true;
            // 
            // ckbChangePinCode
            // 
            this.ckbChangePinCode.AutoSize = true;
            this.ckbChangePinCode.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbChangePinCode.ForeColor = System.Drawing.SystemColors.InfoText;
            this.ckbChangePinCode.Location = new System.Drawing.Point(6, 176);
            this.ckbChangePinCode.Name = "ckbChangePinCode";
            this.ckbChangePinCode.Size = new System.Drawing.Size(134, 24);
            this.ckbChangePinCode.TabIndex = 8;
            this.ckbChangePinCode.Text = "Change PinCode";
            this.ckbChangePinCode.UseVisualStyleBackColor = true;
            // 
            // ckbDeleteClient
            // 
            this.ckbDeleteClient.AutoSize = true;
            this.ckbDeleteClient.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbDeleteClient.ForeColor = System.Drawing.SystemColors.InfoText;
            this.ckbDeleteClient.Location = new System.Drawing.Point(192, 121);
            this.ckbDeleteClient.Name = "ckbDeleteClient";
            this.ckbDeleteClient.Size = new System.Drawing.Size(113, 24);
            this.ckbDeleteClient.TabIndex = 7;
            this.ckbDeleteClient.Text = "Delete Client";
            this.ckbDeleteClient.UseVisualStyleBackColor = true;
            // 
            // ckbShowTransferLog
            // 
            this.ckbShowTransferLog.AutoSize = true;
            this.ckbShowTransferLog.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbShowTransferLog.ForeColor = System.Drawing.SystemColors.InfoText;
            this.ckbShowTransferLog.Location = new System.Drawing.Point(6, 226);
            this.ckbShowTransferLog.Name = "ckbShowTransferLog";
            this.ckbShowTransferLog.Size = new System.Drawing.Size(151, 24);
            this.ckbShowTransferLog.TabIndex = 10;
            this.ckbShowTransferLog.Text = "Show Transfer Log";
            this.ckbShowTransferLog.UseVisualStyleBackColor = true;
            // 
            // ckbTransactions
            // 
            this.ckbTransactions.AutoSize = true;
            this.ckbTransactions.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbTransactions.ForeColor = System.Drawing.SystemColors.InfoText;
            this.ckbTransactions.Location = new System.Drawing.Point(192, 176);
            this.ckbTransactions.Name = "ckbTransactions";
            this.ckbTransactions.Size = new System.Drawing.Size(110, 24);
            this.ckbTransactions.TabIndex = 9;
            this.ckbTransactions.Text = "Transactions";
            this.ckbTransactions.UseVisualStyleBackColor = true;
            // 
            // ckbShowLogInRegister
            // 
            this.ckbShowLogInRegister.AutoSize = true;
            this.ckbShowLogInRegister.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbShowLogInRegister.ForeColor = System.Drawing.SystemColors.InfoText;
            this.ckbShowLogInRegister.Location = new System.Drawing.Point(192, 226);
            this.ckbShowLogInRegister.Name = "ckbShowLogInRegister";
            this.ckbShowLogInRegister.Size = new System.Drawing.Size(162, 24);
            this.ckbShowLogInRegister.TabIndex = 11;
            this.ckbShowLogInRegister.Text = "Show LogIn Register";
            this.ckbShowLogInRegister.UseVisualStyleBackColor = true;
            // 
            // gbPermissions
            // 
            this.gbPermissions.Controls.Add(this.ckbUpdateClient);
            this.gbPermissions.Controls.Add(this.ckbShowLogInRegister);
            this.gbPermissions.Controls.Add(this.ckbManagePeople);
            this.gbPermissions.Controls.Add(this.ckbShowTransferLog);
            this.gbPermissions.Controls.Add(this.ckbManageUsers);
            this.gbPermissions.Controls.Add(this.ckbTransactions);
            this.gbPermissions.Controls.Add(this.ckbListClients);
            this.gbPermissions.Controls.Add(this.ckbChangePinCode);
            this.gbPermissions.Controls.Add(this.ckbAddClient);
            this.gbPermissions.Controls.Add(this.ckbDeleteClient);
            this.gbPermissions.Enabled = false;
            this.gbPermissions.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gbPermissions.ForeColor = System.Drawing.Color.Black;
            this.gbPermissions.Location = new System.Drawing.Point(18, 123);
            this.gbPermissions.Name = "gbPermissions";
            this.gbPermissions.Size = new System.Drawing.Size(364, 277);
            this.gbPermissions.TabIndex = 12;
            this.gbPermissions.TabStop = false;
            this.gbPermissions.Text = "Permissions";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.IconChar = FontAwesome.Sharp.IconChar.UserLock;
            this.btnSave.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSave.IconSize = 40;
            this.btnSave.Location = new System.Drawing.Point(67, 435);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 47);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnClose.IconColor = System.Drawing.Color.Maroon;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 40;
            this.btnClose.Location = new System.Drawing.Point(224, 435);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 47);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmSetPermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 494);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbPermissions);
            this.Controls.Add(this.ckbFullAccess);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSetPermissions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Permissions";
            this.Load += new System.EventHandler(this.frmSetPermissions_Load);
            this.gbPermissions.ResumeLayout(false);
            this.gbPermissions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckbFullAccess;
        private System.Windows.Forms.CheckBox ckbManagePeople;
        private System.Windows.Forms.CheckBox ckbListClients;
        private System.Windows.Forms.CheckBox ckbManageUsers;
        private System.Windows.Forms.CheckBox ckbUpdateClient;
        private System.Windows.Forms.CheckBox ckbAddClient;
        private System.Windows.Forms.CheckBox ckbChangePinCode;
        private System.Windows.Forms.CheckBox ckbDeleteClient;
        private System.Windows.Forms.CheckBox ckbShowTransferLog;
        private System.Windows.Forms.CheckBox ckbTransactions;
        private System.Windows.Forms.CheckBox ckbShowLogInRegister;
        private System.Windows.Forms.GroupBox gbPermissions;
        private FontAwesome.Sharp.IconButton btnSave;
        private FontAwesome.Sharp.IconButton btnClose;
    }
}