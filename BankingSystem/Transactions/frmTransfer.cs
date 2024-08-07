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
    public partial class frmTransfer : Form
    {
        private static DataTable _dtSourceClientInfo;
        private static DataTable _dtDdestinClientInfo;
        private clsClient _sourceClient;
        private clsClient _destinClient;
        public frmTransfer()
        {
            InitializeComponent();
        }


        private void ValidateAccountNumber(System.Windows.Forms.TextBox textBox, CancelEventArgs e)
        {
            string accountNumber = textBox.Text.Trim();

            if (string.IsNullOrEmpty(accountNumber))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox, "AccountNumber cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(textBox, null);
            }

            if (!clsClient.isClientExist(accountNumber))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox, $"Client with accountNumber [{accountNumber}] not Found");
                return;
            }
            else
            {
                errorProvider1.SetError(textBox, null);
            }
        }


        private void DisplayClientInfo(DataTable clientInfo, Label lblAccNum, Label lblFullName, Label lblBalance)
        {
            if (clientInfo != null && clientInfo.Rows.Count > 0)
            {
                lblAccNum.Text = clientInfo.Rows[0]["AccountNumber"].ToString();
                lblFullName.Text = clientInfo.Rows[0]["FullName"].ToString();
                lblBalance.Text = clientInfo.Rows[0]["AccountBalance"].ToString();
            }
            else
            {
                MessageBox.Show("Client information not available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSourceAccountNumber_Validating(object sender, CancelEventArgs e)
        {
            ValidateAccountNumber(txtSourceAccountNumber, e);

            _dtSourceClientInfo = clsClient.GetClientInfoByAccountNumber(txtSourceAccountNumber.Text);
            _sourceClient = clsClient.FindByAccountNumber(txtSourceAccountNumber.Text);

            if (_dtSourceClientInfo != null && _dtSourceClientInfo.Rows.Count > 0)
            {
                gbSourceClientInfo.Enabled = true;
                DisplayClientInfo(_dtSourceClientInfo, lblSourceAccNumber, lblSourceFullName, lblSourceBalance);
            }
        }

        private void txtDestinAccountNumber_Validating(object sender, CancelEventArgs e)
        {
            ValidateAccountNumber(txtDestinAccountNumber, e);

            _dtDdestinClientInfo = clsClient.GetClientInfoByAccountNumber(txtDestinAccountNumber.Text);
            _destinClient = clsClient.FindByAccountNumber(txtDestinAccountNumber.Text);

            if (_dtDdestinClientInfo != null && _dtDdestinClientInfo.Rows.Count > 0)
            {
                gbDestinationClientInfo.Enabled = true;

                if (_dtDdestinClientInfo.Rows[0]["AccountNumber"].ToString() == _dtSourceClientInfo.Rows[0]["AccountNumber"].ToString())
                {
                    MessageBox.Show("This Client matches the Sender Client!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                DisplayClientInfo(_dtDdestinClientInfo, lblDestiAccNumber, lblDestiFullName, lblDestiBalance);
            }
        }


        private bool ValidateInputs()
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid! Put the mouse over the red icon(s) to see the error.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }



        private void txtAmount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAmount.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAmount, "Amount cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtAmount, null);
            }
        }


        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            //Are you sure you want to perform this operation
            DialogResult result = MessageBox.Show("Are you sure you want to perform this operation ?YES/NO ?", "Transfer Process", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.No)
            {
                return;
            }

            decimal amount = Convert.ToDecimal(txtAmount.Text);
            if (amount > _sourceClient.AccountBalance)
            {
                MessageBox.Show("Amount Exceeds the available Balance", "Transfer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtAmount.Focus();
                return;
            }


            bool isSuccess = _sourceClient.Transfer(amount, ref _destinClient, 1);

            if (isSuccess)
            {
                lblSourceBalance.Text = _sourceClient.AccountBalance.ToString();
                lblDestiBalance.Text = _destinClient.AccountBalance.ToString();
                Console.WriteLine($"Amount Saved Successfuly.");
            }

            else
            {
                Console.WriteLine("Process is Failed");
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
