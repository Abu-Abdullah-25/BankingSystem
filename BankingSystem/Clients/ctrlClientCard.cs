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
    public partial class ctrlClientCard : UserControl
    {

        private clsClient _Client;
        private int _ClientID = -1;

        public int ClientID
        {
            get { return _ClientID; }
        }

        public decimal Balance
        {
            set { lblAccountBalance.Text = value.ToString(); }
            get { return decimal.Parse(lblAccountBalance.Text); }
        }

        public ctrlClientCard()
        {
            InitializeComponent();
        }


        public void LoadClientInfo(int ClientID)
        {
            _Client = clsClient.FindByClientID(ClientID);
            if (_Client == null)
            {
                _ResetClientInfo();
                MessageBox.Show("No Client with ClientID = " + ClientID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillClientInfo();
        }

        private void _FillClientInfo()
        {
            ctrlPersonCard1.LoadPersonInfo(_Client.PersonID);
            lblClientID.Text = _Client.ClientID.ToString();
            lblAccountNumber.Text = _Client.AccountNumber.ToString();
            lblAccountBalance.Text = _Client.AccountBalance.ToString();

            if (_Client.IsActive)
                lblIsActive.Text = "Yes";
            else
                lblIsActive.Text = "No";

        }

        private void _ResetClientInfo()
        {

            ctrlPersonCard1.ResetPersonInfo();
            lblClientID.Text = "[???]";
            lblAccountNumber.Text = "[???]";
            lblAccountBalance.Text = "[???]";
            lblIsActive.Text = "[???]";
        }
    }
}
