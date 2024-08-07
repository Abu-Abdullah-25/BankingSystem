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
    public partial class frmChangePinCode : Form
    {
        private int _ClientID;
        private clsClient _Client;

        public frmChangePinCode(int ClientID)
        {
            InitializeComponent();

            _ClientID = ClientID;
        }

        private void txtCurrentPinCode_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPinCode.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPinCode, "PinCode cannot be blank");
            }
            else if (_Client.PinCode != txtCurrentPinCode.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPinCode, "Current PinCode is wrong!");
            }
            else
            {
                errorProvider1.SetError(txtCurrentPinCode, null);
            }
        }

        private void txtNewPinCode_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPinCode.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPinCode, "New PinCode cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtNewPinCode, null);
            }
        }

        private void txtconfirmPinCode_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtconfirmPinCode.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtconfirmPinCode, "PinCode Confirmation cannot be blank");
            }
            else if (txtconfirmPinCode.Text.Trim() != txtNewPinCode.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtconfirmPinCode, "PinCode Confirmation does not match New PinCode!");
            }
            else
            {
                errorProvider1.SetError(txtconfirmPinCode, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Client.PinCode = txtNewPinCode.Text;

            if (_Client.Save())
            {
                MessageBox.Show("PinCode Changed Successfully.",
                   "Saved.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ResetDefualtValues();
            }
            else
            {
                MessageBox.Show("An Erro Occured, PinCode did not change.",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void _ResetDefualtValues()
        {
            txtCurrentPinCode.Text = "";
            txtNewPinCode.Text = "";
            txtconfirmPinCode.Text = "";
            txtCurrentPinCode.Focus();
        }


        private void frmChangePinCode_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            _Client = clsClient.FindByClientID(_ClientID);

            if (_Client == null)
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Could not Find Client with id = " + _ClientID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;

            }
            ctrlClientCard1.LoadClientInfo(_ClientID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
