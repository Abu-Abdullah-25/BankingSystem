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
    public partial class frmDepostWithdrawAmount : Form
    {
        public enum enMode { eDeposit, eWithdraw }
        public enMode _Mode = enMode.eDeposit;

        private int _ClientID;
        private clsClient _Client;

        public frmDepostWithdrawAmount(enMode Mode)
        {
            InitializeComponent();

            _Mode = Mode;


        }
        public frmDepostWithdrawAmount(int ClientID , enMode Mode)
        {
            InitializeComponent();

            _Mode = Mode;

            ctrlClientCard1.Enabled = true;

            //_Client = clsClient.FindByAccountNumber(txtAccountNumber.Text);
            _Client = clsClient.FindByClientID(ClientID);
            _ClientID = _Client.ClientID;

            ctrlClientCard1.LoadClientInfo(_ClientID);
            txtAccountNumber.Text = _Client.AccountNumber;
           
        }

        private void txtAccountNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAccountNumber.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAccountNumber, "AccountNumber cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtAccountNumber, null);
            };


            if (!clsClient.isClientExist(txtAccountNumber.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAccountNumber, $"Client with accountNumber [{txtAccountNumber.Text}] not Found.");
                return;
            }
            else
            {


                errorProvider1.SetError(txtAccountNumber, null);
            };

            ctrlClientCard1.Enabled = true;

            _Client = clsClient.FindByAccountNumber(txtAccountNumber.Text);
            _ClientID = _Client.ClientID;

            ctrlClientCard1.LoadClientInfo(_ClientID);
        }

        private void PerformDeposit(decimal amount)
        {
            if (_Client.Deposit(amount))
            {
                UpdateBalance(amount);
            }
            else
            {
                ShowErrorMessage("Deposit failed. Please try again.");
            }
        }

        private void PerformWithdrawal(decimal amount)
        {
            if (_Client.Withdraw(amount))
            {
                UpdateBalance(amount);
            }
            else
            {
                ShowErrorMessage("Withdrawal failed. Please try again.");
            }
        }

        private void UpdateBalance(decimal amount)
        {
            decimal newBalance = _Client.AccountBalance;
            ctrlClientCard1.Balance = newBalance;

            MessageBox.Show($"Transaction of {amount} completed successfully!\n\nYour new balance is: {newBalance}",
                "Transaction Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Transaction Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values
            //btnDeposit.Enabled = false;

            if (_Mode == enMode.eDeposit)
            {
                btnDepositAmount.Text = "Deposit";
                lblTitle.Text = "Deposit Screen";
                //this.Text = "Deposit";
            }

            else
            {
                btnDepositAmount.Text = "Withdraw";
                lblTitle.Text = "Withdraw Screen";
               // this.Text = "Withdraw";

            }

            //txtAccountNumber.Clear();
            //txtAmount.Clear();

        }

        private void frmDepostWithdrawAmount_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
        }

        private void btnDepositAmount_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            decimal depositAmount;
            if (!decimal.TryParse(txtAmount.Text, out depositAmount))
            {
                ShowErrorMessage("Please enter a valid amount for the transaction.");
                return;
            }

            DialogResult result = MessageBox.Show($"Are you sure you want to perform the transaction with amount {depositAmount}?",
                "Confirm Transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (_Mode == enMode.eDeposit)
                {
                    PerformDeposit(depositAmount);
                }
                else
                {
                    PerformWithdrawal(depositAmount);
                }
            }
        }
    }
}
