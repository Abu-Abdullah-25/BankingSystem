using BankingSystem_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BankingSystem.frmDepostWithdrawAmount;

namespace BankingSystem
{
    public partial class frmMain : Form
    {
        LoginForm _frmLogin;


        public frmMain(LoginForm frm)
        {
            InitializeComponent();
            _frmLogin = frm;

        }


        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!clsGlobal.CurrentUser.CheckAccessPermission(clsUser.enPermissions.pManagePeople))
            {
                MessageBox.Show("Access Denied! Contact your Admin.","Denied Access",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }


            using(frmListPeople frm = new frmListPeople())
            {
                frm.ShowDialog();
                frm.Dispose();
            }
        }

        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUser.enPermissions.pTranactions))
            {
                MessageBox.Show("Access Denied! Contact your Admin.", "Denied Access", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            enMode TransactionType = enMode.eDeposit;

            using (frmDepostWithdrawAmount frm = new frmDepostWithdrawAmount(TransactionType))
            {
                frm.ShowDialog();
                frm.Dispose();
            }
        }

        private void accountSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUser.enPermissions.pManageUsers))
            {
                MessageBox.Show("Access Denied! Contact your Admin.", "Denied Access", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            using (frmListUsers frm = new frmListUsers())
            {
                frm.ShowDialog();
                frm.Dispose();
            }
        }

       

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLogin.Show();
            this.Close();
        }

        private void manageClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUser.enPermissions.pListClients))
            {
                MessageBox.Show("Access Denied! Contact your Admin.", "Denied Access", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            using (frmListClients frm =new frmListClients())
            {
                frm.ShowDialog();
                frm.Dispose();
            }
        }

        private void currentUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmUserInfo frm = new frmUserInfo(clsGlobal.CurrentUser.UserID))
            {
                frm.ShowDialog();
                frm.Dispose();
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.UserID))
            {
                frm.ShowDialog();
                frm.Dispose();
            }
        }

        private void withdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUser.enPermissions.pTranactions))
            {
                MessageBox.Show("Access Denied! Contact your Admin.", "Denied Access", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            enMode TransactionType = enMode.eWithdraw;

            using(frmDepostWithdrawAmount frm = new frmDepostWithdrawAmount(TransactionType))
            {
                frm.ShowDialog();
                frm.Dispose();
            }


        }




        private void transferLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUser.enPermissions.pShowtransferLog))
            {
                MessageBox.Show("Access Denied! Contact your Admin.", "Denied Access", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            using(frmTransferLog frm = new frmTransferLog())
            {
                frm.ShowDialog();
                frm.Dispose();
            }
        }

        private void transferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUser.enPermissions.pTranactions))
            {
                MessageBox.Show("Access Denied! Contact your Admin.", "Denied Access", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (frmTransfer frm = new frmTransfer())
            {
                frm.ShowDialog();
                frm.Dispose();
            }
        }

        private void totalBalancesoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUser.enPermissions.pTranactions))
            {
                MessageBox.Show("Access Denied! Contact your Admin.", "Denied Access", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (frmTotalBalances frm = new frmTotalBalances())
            {
                frm.ShowDialog();
                frm.Dispose();
            }
        }

        private void loginRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUser.enPermissions.pShowLogInRegister))
            {
                MessageBox.Show("Access Denied! Contact your Admin.", "Denied Access", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            using(frmLoginRegister frm = new frmLoginRegister())
            {
                frm.ShowDialog();
                frm.Dispose();
            }
        }
    }
}
