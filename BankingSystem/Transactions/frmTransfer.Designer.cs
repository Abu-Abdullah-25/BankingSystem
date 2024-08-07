namespace BankingSystem
{
    partial class frmTransfer
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
            this.components = new System.ComponentModel.Container();
            this.txtSourceAccountNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDestinAccountNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTransfer = new FontAwesome.Sharp.IconButton();
            this.gbSourceClientInfo = new System.Windows.Forms.GroupBox();
            this.lblSourceBalance = new System.Windows.Forms.Label();
            this.lblSourceFullName = new System.Windows.Forms.Label();
            this.lblSourceAccNumber = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbDestinationClientInfo = new System.Windows.Forms.GroupBox();
            this.lblDestiBalance = new System.Windows.Forms.Label();
            this.lblDestiFullName = new System.Windows.Forms.Label();
            this.lblDestiAccNumber = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbSourceClientInfo.SuspendLayout();
            this.gbDestinationClientInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSourceAccountNumber
            // 
            this.txtSourceAccountNumber.Location = new System.Drawing.Point(201, 64);
            this.txtSourceAccountNumber.Name = "txtSourceAccountNumber";
            this.txtSourceAccountNumber.Size = new System.Drawing.Size(213, 20);
            this.txtSourceAccountNumber.TabIndex = 0;
            this.txtSourceAccountNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtSourceAccountNumber_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(22, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sender\'s AccountNumber";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(22, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Reciever\'s AccountNumber";
            // 
            // txtDestinAccountNumber
            // 
            this.txtDestinAccountNumber.Location = new System.Drawing.Point(201, 106);
            this.txtDestinAccountNumber.Name = "txtDestinAccountNumber";
            this.txtDestinAccountNumber.Size = new System.Drawing.Size(213, 20);
            this.txtDestinAccountNumber.TabIndex = 2;
            this.txtDestinAccountNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtDestinAccountNumber_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(22, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Amount";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(201, 149);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(213, 20);
            this.txtAmount.TabIndex = 4;
            this.txtAmount.Validating += new System.ComponentModel.CancelEventHandler(this.txtAmount_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(239, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 27);
            this.label4.TabIndex = 6;
            this.label4.Text = "Transfer Screen";
            // 
            // btnTransfer
            // 
            this.btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransfer.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransfer.IconChar = FontAwesome.Sharp.IconChar.MoneyBillTransfer;
            this.btnTransfer.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnTransfer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTransfer.IconSize = 36;
            this.btnTransfer.Location = new System.Drawing.Point(244, 209);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(127, 42);
            this.btnTransfer.TabIndex = 7;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // gbSourceClientInfo
            // 
            this.gbSourceClientInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(255)))), ((int)(((byte)(251)))));
            this.gbSourceClientInfo.Controls.Add(this.lblSourceBalance);
            this.gbSourceClientInfo.Controls.Add(this.lblSourceFullName);
            this.gbSourceClientInfo.Controls.Add(this.lblSourceAccNumber);
            this.gbSourceClientInfo.Controls.Add(this.label7);
            this.gbSourceClientInfo.Controls.Add(this.label6);
            this.gbSourceClientInfo.Controls.Add(this.label5);
            this.gbSourceClientInfo.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSourceClientInfo.Location = new System.Drawing.Point(12, 275);
            this.gbSourceClientInfo.Name = "gbSourceClientInfo";
            this.gbSourceClientInfo.Size = new System.Drawing.Size(618, 102);
            this.gbSourceClientInfo.TabIndex = 8;
            this.gbSourceClientInfo.TabStop = false;
            this.gbSourceClientInfo.Text = "Sender Client Info";
            // 
            // lblSourceBalance
            // 
            this.lblSourceBalance.AutoSize = true;
            this.lblSourceBalance.Font = new System.Drawing.Font("Trebuchet MS", 8F, System.Drawing.FontStyle.Bold);
            this.lblSourceBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblSourceBalance.Location = new System.Drawing.Point(494, 46);
            this.lblSourceBalance.Name = "lblSourceBalance";
            this.lblSourceBalance.Size = new System.Drawing.Size(30, 16);
            this.lblSourceBalance.TabIndex = 11;
            this.lblSourceBalance.Text = "[???]";
            // 
            // lblSourceFullName
            // 
            this.lblSourceFullName.AutoSize = true;
            this.lblSourceFullName.Font = new System.Drawing.Font("Trebuchet MS", 8F, System.Drawing.FontStyle.Bold);
            this.lblSourceFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblSourceFullName.Location = new System.Drawing.Point(303, 49);
            this.lblSourceFullName.Name = "lblSourceFullName";
            this.lblSourceFullName.Size = new System.Drawing.Size(30, 16);
            this.lblSourceFullName.TabIndex = 10;
            this.lblSourceFullName.Text = "[???]";
            // 
            // lblSourceAccNumber
            // 
            this.lblSourceAccNumber.AutoSize = true;
            this.lblSourceAccNumber.Font = new System.Drawing.Font("Trebuchet MS", 8F, System.Drawing.FontStyle.Bold);
            this.lblSourceAccNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblSourceAccNumber.Location = new System.Drawing.Point(123, 44);
            this.lblSourceAccNumber.Name = "lblSourceAccNumber";
            this.lblSourceAccNumber.Size = new System.Drawing.Size(30, 16);
            this.lblSourceAccNumber.TabIndex = 9;
            this.lblSourceAccNumber.Text = "[???]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(432, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 18);
            this.label7.TabIndex = 8;
            this.label7.Text = "Balance";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(232, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 18);
            this.label6.TabIndex = 7;
            this.label6.Text = "FullName";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(10, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 18);
            this.label5.TabIndex = 6;
            this.label5.Text = "AccountNumber";
            // 
            // gbDestinationClientInfo
            // 
            this.gbDestinationClientInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(255)))), ((int)(((byte)(251)))));
            this.gbDestinationClientInfo.Controls.Add(this.lblDestiBalance);
            this.gbDestinationClientInfo.Controls.Add(this.lblDestiFullName);
            this.gbDestinationClientInfo.Controls.Add(this.lblDestiAccNumber);
            this.gbDestinationClientInfo.Controls.Add(this.label11);
            this.gbDestinationClientInfo.Controls.Add(this.label12);
            this.gbDestinationClientInfo.Controls.Add(this.label13);
            this.gbDestinationClientInfo.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.gbDestinationClientInfo.Location = new System.Drawing.Point(12, 415);
            this.gbDestinationClientInfo.Name = "gbDestinationClientInfo";
            this.gbDestinationClientInfo.Size = new System.Drawing.Size(618, 98);
            this.gbDestinationClientInfo.TabIndex = 9;
            this.gbDestinationClientInfo.TabStop = false;
            this.gbDestinationClientInfo.Text = "Reciever Client Info";
            // 
            // lblDestiBalance
            // 
            this.lblDestiBalance.AutoSize = true;
            this.lblDestiBalance.Font = new System.Drawing.Font("Trebuchet MS", 8F, System.Drawing.FontStyle.Bold);
            this.lblDestiBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblDestiBalance.Location = new System.Drawing.Point(496, 47);
            this.lblDestiBalance.Name = "lblDestiBalance";
            this.lblDestiBalance.Size = new System.Drawing.Size(30, 16);
            this.lblDestiBalance.TabIndex = 17;
            this.lblDestiBalance.Text = "[???]";
            // 
            // lblDestiFullName
            // 
            this.lblDestiFullName.AutoSize = true;
            this.lblDestiFullName.Font = new System.Drawing.Font("Trebuchet MS", 8F, System.Drawing.FontStyle.Bold);
            this.lblDestiFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblDestiFullName.Location = new System.Drawing.Point(305, 49);
            this.lblDestiFullName.Name = "lblDestiFullName";
            this.lblDestiFullName.Size = new System.Drawing.Size(30, 16);
            this.lblDestiFullName.TabIndex = 16;
            this.lblDestiFullName.Text = "[???]";
            // 
            // lblDestiAccNumber
            // 
            this.lblDestiAccNumber.AutoSize = true;
            this.lblDestiAccNumber.Font = new System.Drawing.Font("Trebuchet MS", 8F, System.Drawing.FontStyle.Bold);
            this.lblDestiAccNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblDestiAccNumber.Location = new System.Drawing.Point(125, 44);
            this.lblDestiAccNumber.Name = "lblDestiAccNumber";
            this.lblDestiAccNumber.Size = new System.Drawing.Size(30, 16);
            this.lblDestiAccNumber.TabIndex = 15;
            this.lblDestiAccNumber.Text = "[???]";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(434, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 18);
            this.label11.TabIndex = 14;
            this.label11.Text = "Balance";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(234, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 18);
            this.label12.TabIndex = 13;
            this.label12.Text = "FullName";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(12, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 18);
            this.label13.TabIndex = 12;
            this.label13.Text = "AccountNumber";
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnClose.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 35;
            this.btnClose.Location = new System.Drawing.Point(531, 519);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 39);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 561);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbDestinationClientInfo);
            this.Controls.Add(this.gbSourceClientInfo);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDestinAccountNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSourceAccountNumber);
            this.Name = "frmTransfer";
            this.Text = "frmTransfer";
            this.gbSourceClientInfo.ResumeLayout(false);
            this.gbSourceClientInfo.PerformLayout();
            this.gbDestinationClientInfo.ResumeLayout(false);
            this.gbDestinationClientInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSourceAccountNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDestinAccountNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton btnTransfer;
        private System.Windows.Forms.GroupBox gbSourceClientInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbDestinationClientInfo;
        private System.Windows.Forms.Label lblSourceBalance;
        private System.Windows.Forms.Label lblSourceFullName;
        private System.Windows.Forms.Label lblSourceAccNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDestiBalance;
        private System.Windows.Forms.Label lblDestiFullName;
        private System.Windows.Forms.Label lblDestiAccNumber;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private FontAwesome.Sharp.IconButton btnClose;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}