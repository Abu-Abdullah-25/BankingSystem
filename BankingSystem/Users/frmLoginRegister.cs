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
    public partial class frmLoginRegister : Form
    {
        private static DataTable _dtAllUsersLoginLog;

        public frmLoginRegister()
        {
            InitializeComponent();
        }


        private void _RefreshPeoplList()
        {
            _dtAllUsersLoginLog = clsUser.GetLoginRegisterList();

            dgvLoginRegisters.DataSource = _dtAllUsersLoginLog;
            lblRecordsCount.Text = dgvLoginRegisters.Rows.Count.ToString();

        }

        private void frmLoginRegister_Load(object sender, EventArgs e)
        {
            _dtAllUsersLoginLog = clsUser.GetLoginRegisterList();
            dgvLoginRegisters.DataSource = _dtAllUsersLoginLog;
            //cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvLoginRegisters.Rows.Count.ToString();

            dgvLoginRegisters.Columns[0].HeaderText = "Log ID";
            dgvLoginRegisters.Columns[0].Width = 110;

            dgvLoginRegisters.Columns[1].HeaderText = "DateTime";
            dgvLoginRegisters.Columns[1].Width = 120;

            dgvLoginRegisters.Columns[2].HeaderText = "UserName";
            dgvLoginRegisters.Columns[2].Width = 160;

            dgvLoginRegisters.Columns[3].HeaderText = "Permissions";
            dgvLoginRegisters.Columns[3].Width = 120;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            //GetLoginRegisterList
        }
    }
}
