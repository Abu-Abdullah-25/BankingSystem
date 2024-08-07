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
    public partial class frmAddUpdateClient : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _ClientID = -1;
        clsClient _Client;

        public frmAddUpdateClient()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        public frmAddUpdateClient(int ClientID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _ClientID = ClientID;
        }


        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Client";
                this.Text = "Add New Client";
                _Client = new clsClient();

                tpAccountInfo.Enabled = false;

                ctrlPersonCardWithFilter1.FilterFocus();
            }
            else
            {
                lblTitle.Text = "Update Client";
                this.Text = "Update Client";

                tpAccountInfo.Enabled = true;
                btnSave.Enabled = true;


            }

            txtAccountNumber.Clear();
            txtPinCode.Clear();
            txtConfirmPinCode.Clear();
            txtAccountBalance.Clear();
            ckbIsActive.Checked = true;

        }

        private void _LoadData()
        {

            _Client = clsClient.FindByClientID(_ClientID);
            ctrlPersonCardWithFilter1.FilterEnabled = false;

            if (_Client == null)
            {
                MessageBox.Show("No Client with ID = " + _Client, "Client Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            //the following code will not be executed if the person was not found
            lblClientID.Text = _Client.ClientID.ToString();
            txtAccountNumber.Text = _Client.AccountNumber;
            txtPinCode.Text = _Client.PinCode;
            txtConfirmPinCode.Text = _Client.PinCode;
            ckbIsActive.Checked = _Client.IsActive;
            txtAccountBalance.Text = _Client.AccountBalance.ToString();
            ctrlPersonCardWithFilter1.LoadPersonInfo(_Client.PersonID);
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

            _Client.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _Client.AccountNumber = txtAccountNumber.Text.Trim();
            _Client.PinCode = txtPinCode.Text.Trim();
            _Client.AccountBalance = decimal.Parse(txtAccountBalance.Text.Trim());
            _Client.IsActive = ckbIsActive.Checked;
            _Client.CreatedByUserID = clsGlobal.CurrentUser.UserID;


            if (_Client.Save())
            {
                lblClientID.Text = _Client.ClientID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update Client";
                this.Text = "Update Client";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddUpdateClient_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
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


            if (_Mode == enMode.AddNew)
            {

                if (clsClient.isClientExist(txtAccountNumber.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtAccountNumber, "accountNumber is used by another client");
                }
                else
                {
                    errorProvider1.SetError(txtAccountNumber, null);
                };
            }
            else
            {
                //incase update make sure not to use anothers Client name
                if (_Client.AccountNumber != txtAccountNumber.Text.Trim())
                {
                    if (clsClient.isClientExist(txtAccountNumber.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtAccountNumber, "accountNumber is used by another client");
                        return;
                    }
                    else
                    {
                        errorProvider1.SetError(txtAccountNumber, null);
                    };
                }
            }
        }

        private void txtAccountBalance_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAccountBalance.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAccountBalance, "Account Balance cannot be blank");
                return;
            }

            else
            {
                errorProvider1.SetError(txtAccountBalance, null);
            }

            if (decimal.Parse(txtAccountBalance.Text.Trim()) <= 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAccountBalance, "Account Balance should be greater than 0");
                return;
            }
            else
            {
                errorProvider1.SetError(txtAccountBalance, null);
            }
        }

        private void txtPinCode_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPinCode.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPinCode, "PinCode cannot be blank");
            }

            else
            {
                errorProvider1.SetError(txtPinCode, null);
            };
        }

        private void txtConfirmPinCode_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPinCode.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPinCode, "PinCode cannot be blank");
                return;
            }

            else
            {
                errorProvider1.SetError(txtConfirmPinCode, null);
            };


            if (txtConfirmPinCode.Text.Trim() != txtPinCode.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPinCode, "PinCode Confirmation does not match PinCode!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPinCode, null);
            };
        }

        private void btnPersonInfoNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpAccountInfo.Enabled = true;

                tcClientInfo.SelectedTab = tcClientInfo.TabPages["tpAccountInfo"];
                return;
            }

            //incase of add new mode.
            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {

                if (clsClient.isClientExistForPersonID(ctrlPersonCardWithFilter1.PersonID))
                {

                    MessageBox.Show("Selected Person already has a Client, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonCardWithFilter1.FilterFocus();
                }

                else
                {
                    btnSave.Enabled = true;
                    tpAccountInfo.Enabled = true;
                    tcClientInfo.SelectedTab = tcClientInfo.TabPages["tpAccountInfo"];
                }
            }

            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();

            }
        }

        private void frmAddUpdateClient_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FilterFocus();
        }
    }
}
