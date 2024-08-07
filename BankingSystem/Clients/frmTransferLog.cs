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

namespace BankingSystem
{
    public partial class frmTransferLog : Form
    {
        private static DataTable _dtAllTransfersLog;

        public frmTransferLog()
        {
            InitializeComponent();
        }



        private void _RefreshPeoplList()
        {
            _dtAllTransfersLog = clsClient.GetTransfersLogList();

            dgvTransfersLog.DataSource = _dtAllTransfersLog;
            lblRecords.Text = dgvTransfersLog.Rows.Count.ToString();

        }

        private void frmTransferLog_Load(object sender, EventArgs e)
        {
            _dtAllTransfersLog = clsClient.GetTransfersLogList();
            dgvTransfersLog.DataSource = _dtAllTransfersLog;
            lblRecords.Text = dgvTransfersLog.Rows.Count.ToString();

            dgvTransfersLog.Columns[0].HeaderText = "Log ID";
            dgvTransfersLog.Columns[0].Width = 70;

            dgvTransfersLog.Columns[1].HeaderText = "S.Acct";
            dgvTransfersLog.Columns[1].Width = 80;

            dgvTransfersLog.Columns[2].HeaderText = "D.Acct";
            dgvTransfersLog.Columns[2].Width = 80;

            dgvTransfersLog.Columns[3].HeaderText = "Amount";
            dgvTransfersLog.Columns[3].Width = 70;

            dgvTransfersLog.Columns[4].HeaderText = "S.Balance";
            dgvTransfersLog.Columns[4].Width = 70;

            dgvTransfersLog.Columns[5].HeaderText = "D.Balance";
            dgvTransfersLog.Columns[5].Width = 70;

            dgvTransfersLog.Columns[6].HeaderText = "DateTime";
            dgvTransfersLog.Columns[6].Width = 120;

            dgvTransfersLog.Columns[7].HeaderText = "UserName";
            dgvTransfersLog.Columns[7].Width = 90;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
