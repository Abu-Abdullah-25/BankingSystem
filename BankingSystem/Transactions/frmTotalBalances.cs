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
    public partial class frmTotalBalances : Form
    {


        private static DataTable _dtAllClients = clsClient.GetAllClients();

        private static DataTable _dtClients = _dtAllClients.DefaultView.ToTable(false, "AccountNumber", "FullName",
                                                                                        "AccountBalance");

        private decimal _totalBalance = clsClient.GetTotalBalances();

        private void _RefreshPeoplList()
        {
            _dtAllClients = clsClient.GetAllClients();

            _dtClients = _dtAllClients.DefaultView.ToTable(false, "AccountNumber", "FullName",
                                                                    "AccountBalance");
            _totalBalance = clsClient.GetTotalBalances();


            dgvClients.DataSource = _dtClients;
            lblTotalBalances.Text = _totalBalance.ToString();
            lblTotalBalancesInChars.Text = clsUtil.NumberToText((int)_totalBalance);
        }


        public frmTotalBalances()
        {
            InitializeComponent();
        }

        private void frmTotalBalances_Load(object sender, EventArgs e)
        {
            dgvClients.DataSource = _dtClients;

            lblTotalBalances.Text = _totalBalance.ToString();
            lblTotalBalancesInChars.Text = clsUtil.NumberToText((int)_totalBalance);

            if (dgvClients.Rows.Count > 0)
            {
                dgvClients.Columns[0].HeaderText = "Account Number";
                dgvClients.Columns[0].Width = 160;

                dgvClients.Columns[1].HeaderText = "Client Name";
                dgvClients.Columns[1].Width = 350;

                dgvClients.Columns[2].HeaderText = "Account Balance";
                dgvClients.Columns[2].Width = 120;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
