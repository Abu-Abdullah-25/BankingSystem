using BankingSystem_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BankingSystem.frmDepostWithdrawAmount;

namespace BankingSystem
{
    public partial class frmListClients : Form
    {
        private static DataTable _dtAllClients;

        public frmListClients()
        {
            InitializeComponent();
        }

        private void frmListClients_Load(object sender, EventArgs e)
        {
            _dtAllClients = clsClient.GetAllClients();
            dgvClients.DataSource = _dtAllClients;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvClients.Rows.Count.ToString();

            dgvClients.Columns[0].HeaderText = "Client ID";
            dgvClients.Columns[0].Width = 110;

            dgvClients.Columns[1].HeaderText = "Person ID";
            dgvClients.Columns[1].Width = 120;

            dgvClients.Columns[2].HeaderText = "Full Name";
            dgvClients.Columns[2].Width = 350;

            dgvClients.Columns[3].HeaderText = "Account Number";
            dgvClients.Columns[3].Width = 120;

            dgvClients.Columns[4].HeaderText = "Account Balance";
            dgvClients.Columns[4].Width = 120;

            dgvClients.Columns[5].HeaderText = "Is Active";
            dgvClients.Columns[5].Width = 120;
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            using (frmAddUpdateClient frm = new frmAddUpdateClient())
            {
                frm.ShowDialog();
                frm.Dispose();


            }
            frmListClients_Load(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Is Active")
            {
                txtFilterValue.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
                cbIsActive.Location = txtFilterValue.Location;
            }

            else

            {

                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbIsActive.Visible = false;

                if (cbFilterBy.Text == "None")
                {
                    txtFilterValue.Enabled = false;
                }
                else
                    txtFilterValue.Enabled = true;

                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }

        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {

            string FilterColumn = "IsActive";
            string FilterValue = cbIsActive.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                _dtAllClients.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtAllClients.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblRecordsCount.Text = _dtAllClients.Rows.Count.ToString();


            int count = dgvClients.Rows.Count; // Use DefaultView for count
            lblRecordsCount.Text = count.ToString();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Client ID":
                    FilterColumn = "ClientID";
                    break;


                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "Account Number":
                    FilterColumn = "AccountNumber";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllClients.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvClients.Rows.Count.ToString();
                return;
            }


            if (FilterColumn != "FullName" && FilterColumn != "AccountNumber")
                //in this case we deal with numbers not string.
                _dtAllClients.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllClients.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = dgvClients.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id is selected.
            if (cbFilterBy.Text == "Client ID" || cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUser.enPermissions.pListClients))
            {
                MessageBox.Show("Access Denied! Contact your Admin.", "Denied Access", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            using (frmClientInfo frm = new frmClientInfo((int)dgvClients.CurrentRow.Cells[0].Value))
            {
                frm.ShowDialog();
                frm.Dispose();
            }
        }

        private void addNewClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUser.enPermissions.pAddNewClient))
            {
                MessageBox.Show("Access Denied! Contact your Admin.", "Denied Access", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            using (frmAddUpdateClient frm = new frmAddUpdateClient())
            {
                frm.ShowDialog();
                frm.Dispose();


            }
            frmListClients_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUser.enPermissions.pUpdateClients))
            {
                MessageBox.Show("Access Denied! Contact your Admin.", "Denied Access", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            using (frmAddUpdateClient frm = new frmAddUpdateClient((int)dgvClients.CurrentRow.Cells[0].Value))
            {
                frm.ShowDialog();
                frm.Dispose();


            }
            frmListClients_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUser.enPermissions.pDeleteClient))
            {
                MessageBox.Show("Access Denied! Contact your Admin.", "Denied Access", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            DialogResult result = MessageBox.Show("Are you sure you want to delete this client?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
            {
                int ClientID = (int)dgvClients.CurrentRow.Cells[0].Value;

                if (clsClient.DeleteClient(ClientID))
                {
                    MessageBox.Show("Client has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmListClients_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Client could not be deleted due to connected data.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void changePinCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUser.enPermissions.pChangePinCode))
            {
                MessageBox.Show("Access Denied! Contact your Admin.", "Denied Access", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            using (frmChangePinCode frm = new frmChangePinCode((int)dgvClients.CurrentRow.Cells[0].Value))
            {
                frm.ShowDialog();
                frm.Dispose();


            }
            frmListClients_Load(null, null);
        }

        private void DepositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUser.enPermissions.pTranactions))
            {
                MessageBox.Show("Access Denied! Contact your Admin.", "Denied Access", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            enMode TransactionType = enMode.eDeposit;
            int ClientID = (int)dgvClients.CurrentRow.Cells[0].Value;
            using (frmDepostWithdrawAmount frm = new frmDepostWithdrawAmount(ClientID,TransactionType))
            {
                frm.ShowDialog();
                frm.Dispose();
            }

            frmListClients_Load(null, null);

        }

        private void withdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUser.enPermissions.pTranactions))
            {
                MessageBox.Show("Access Denied! Contact your Admin.", "Denied Access", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            enMode TransactionType = enMode.eWithdraw;
            int ClientID = (int)dgvClients.CurrentRow.Cells[0].Value;
            using (frmDepostWithdrawAmount frm = new frmDepostWithdrawAmount(ClientID, TransactionType))
            {
                frm.ShowDialog();
                frm.Dispose();
            }

            frmListClients_Load(null, null);
        }

        private void transferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUser.enPermissions.pTranactions))
            {
                MessageBox.Show("Access Denied! Contact your Admin.", "Denied Access", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            using (frmTransfer frm =new frmTransfer())
            {
                frm.ShowDialog();
                frm.Dispose();
            }
            frmListClients_Load(null, null);
        }

        private void totalBalancesToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void transferLogToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.CheckAccessPermission(clsUser.enPermissions.pTranactions))
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
    }
}
