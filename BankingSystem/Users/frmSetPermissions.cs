using BankingSystem_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingSystem
{
    public partial class frmSetPermissions : Form
    {
        private int _Permissions = 0;
        private clsUser _User;


        public delegate void PermissionEventHandler(object sender, int Obj);
        public event PermissionEventHandler PermissionEvent;

        public frmSetPermissions(clsUser User)
        {
            InitializeComponent();

            _User = User;
            _Permissions = _User.Permissions;
        }

        private void frmSetPermissions_Load(object sender, EventArgs e)
        {
            _RessetPermissions();
        }

        private void _RessetPermissions()
        {
            if (_Permissions == 0)
                return;

            if (_Permissions == -1)
            {
                ckbFullAccess.Checked = true;
                return;
            }

            gbPermissions.Enabled = true;
            

            ckbManagePeople.Checked =_User.CheckAccessPermission(clsUser.enPermissions.pManagePeople);
            ckbManageUsers.Checked = _User.CheckAccessPermission(clsUser.enPermissions.pManageUsers);
            ckbListClients.Checked = _User.CheckAccessPermission(clsUser.enPermissions.pListClients);
            ckbAddClient.Checked = _User.CheckAccessPermission(clsUser.enPermissions.pAddNewClient);
            ckbUpdateClient.Checked = _User.CheckAccessPermission(clsUser.enPermissions.pUpdateClients);
            ckbDeleteClient.Checked = _User.CheckAccessPermission(clsUser.enPermissions.pDeleteClient);
            ckbChangePinCode.Checked = _User.CheckAccessPermission(clsUser.enPermissions.pChangePinCode);
            ckbTransactions.Checked = _User.CheckAccessPermission(clsUser.enPermissions.pTranactions);
            ckbShowTransferLog.Checked = _User.CheckAccessPermission(clsUser.enPermissions.pShowtransferLog);
            ckbShowLogInRegister.Checked = _User.CheckAccessPermission(clsUser.enPermissions.pShowLogInRegister);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Prompt the user to confirm saving
            DialogResult result = MessageBox.Show("Do you want to save?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _Permissions = _PreparePermissions();

                // Raise the event to send permission back to Form1
                OnPermissionEvent(_Permissions);
            }
        }

        private int _PreparePermissions()
        {
            int Permissions = 0;

            if (ckbFullAccess.Checked)
                return -1;

            if (ckbManagePeople.Checked)
                Permissions += (int)clsUser.enPermissions.pManagePeople;

            if (ckbManageUsers.Checked)
                Permissions += (int)clsUser.enPermissions.pManageUsers;

            if (ckbListClients.Checked)
                Permissions += (int)clsUser.enPermissions.pListClients;

            if (ckbAddClient.Checked)
                Permissions += (int)clsUser.enPermissions.pAddNewClient;

            if (ckbUpdateClient.Checked)
                Permissions += (int)clsUser.enPermissions.pUpdateClients;

            if (ckbDeleteClient.Checked)
                Permissions += (int)clsUser.enPermissions.pDeleteClient;

            if (ckbChangePinCode.Checked)
                Permissions += (int)clsUser.enPermissions.pChangePinCode;

            if (ckbTransactions.Checked)
                Permissions += (int)clsUser.enPermissions.pTranactions;

            if (ckbShowTransferLog.Checked)
                Permissions += (int)clsUser.enPermissions.pShowtransferLog;

            if (ckbShowLogInRegister.Checked)
                Permissions += (int)clsUser.enPermissions.pShowLogInRegister;

            return Permissions;
        }

        protected virtual void OnPermissionEvent(int permissions)
        {
            if (PermissionEvent != null)
                PermissionEvent?.Invoke(this, permissions);
        }

        private void ckbFullAccess_CheckedChanged(object sender, EventArgs e)
        {
            gbPermissions.Enabled = !(ckbFullAccess.Checked);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
