using BankingSystem_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem_Business
{
    public class clsClient
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ClientID { set; get; }
        public int PersonID { set; get; }
        public clsPerson PersonInfo;
        public string AccountNumber { set; get; }
        public string PinCode { set; get; }
        public decimal AccountBalance { set; get; }
        public bool IsActive { set; get; }
        public int CreatedByUserID { get; set; }
        public clsUser UserInfo { get; set; }


        public clsClient()

        {
            this.ClientID = -1;
            this.PersonID = -1;
            this.AccountNumber = "";
            this.PinCode = "";
            this.AccountBalance = 0;
            this.IsActive = true;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private clsClient(int ClientID, int PersonID, string AccountNumber, string PinCode, decimal AccountBalance,
            bool IsActive, int CreatedByUserID)

        {
            this.ClientID = ClientID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.AccountNumber = AccountNumber;
            this.PinCode = PinCode;
            this.AccountBalance = AccountBalance;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;
            this.UserInfo = clsUser.FindByUserID(CreatedByUserID);

            Mode = enMode.Update;
        }

        private bool _AddNewClient()
        {
            //call DataAccess Layer 

            this.ClientID = clsClientData.AddNewClient(this.PersonID, this.AccountNumber,
                this.PinCode, this.AccountBalance, this.IsActive, this.CreatedByUserID);

            return (this.ClientID != -1);
        }

        private bool _UpdateClient()
        {
            //call DataAccess Layer 

            return clsClientData.UpdateClient(this.ClientID, this.PersonID, this.AccountNumber,
                this.PinCode, AccountBalance, this.IsActive, this.CreatedByUserID);
        }

        public static clsClient FindByClientID(int ClientID)
        {
            int PersonID = -1, CreatedByUserID = -1;
            string AccountNumber = "", PinCode = "";
            decimal AccountBalance = 0;
            bool IsActive = false;

            bool IsFound = clsClientData.GetClientInfoByClientID
                                (ClientID, ref PersonID, ref AccountNumber, ref PinCode, ref AccountBalance, ref IsActive,
                                ref CreatedByUserID);

            if (IsFound)
                //we return new object of that Client with the right data
                return new clsClient(ClientID, PersonID, AccountNumber, PinCode, AccountBalance, IsActive, CreatedByUserID);
            else
                return null;
        }

        public static clsClient FindByPersonID(int PersonID)
        {
            int ClientID = -1, CreatedByUserID = -1;
            string AccountNumber = "", PinCode = "";
            decimal AccountBalance = 0;
            bool IsActive = false;

            bool IsFound = clsClientData.GetClientInfoByPersonID
                                (PersonID, ref ClientID, ref AccountNumber, ref PinCode, ref AccountBalance,
                                ref IsActive, ref CreatedByUserID);

            if (IsFound)
                //we return new object of that Client with the right data
                return new clsClient(ClientID, PersonID, AccountNumber, PinCode, AccountBalance, IsActive, CreatedByUserID);
            else
                return null;
        }

        public static clsClient FindByAccountNumber(string AccountNumber)
        {
            int ClientID = -1;
            int PersonID = -1;
            string PinCode = "";
            decimal AccountBalance = 0;
            bool IsActive = false;
            int CreatedByUserID = -1;

            bool IsFound = clsClientData.GetClientInfoByAccountNumber
                                (AccountNumber, ref ClientID, ref PersonID, ref PinCode, ref AccountBalance,
                                ref IsActive, ref CreatedByUserID);

            if (IsFound)
                //we return new object of that Client with the right data
                return new clsClient(ClientID, PersonID, AccountNumber, PinCode, AccountBalance, IsActive, CreatedByUserID);
            else
                return null;
        }

        public static clsClient FindByAccountNumberAndPinCode(string AccountNumber, string PinCode)
        {
            int ClientID = -1;
            int PersonID = -1;
            decimal AccountBalance = 0;
            bool IsActive = false;
            int CreatedByUserID = -1;

            bool IsFound = clsClientData.GetClientInfoByAccountNumberAndPinCode
                                (AccountNumber, PinCode, ref ClientID, ref PersonID, ref AccountBalance,
                                ref IsActive, ref CreatedByUserID);

            if (IsFound)
                //we return new object of that Client with the right data
                return new clsClient(ClientID, PersonID, AccountNumber, PinCode, AccountBalance, IsActive, CreatedByUserID);
            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewClient())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateClient();

            }

            return false;
        }

        public static DataTable GetAllClients()
        {
            return clsClientData.GetAllClients();
        }

        public static decimal GetTotalBalances()
        {
            return clsClientData.GetTotalBalances();
        }

        public static bool DeleteClient(int ClientID)
        {
            return clsClientData.DeleteClient(ClientID);
        }

        public static bool isClientExist(int ClientID)
        {
            return clsClientData.IsClientExist(ClientID);
        }

        public static bool isClientExist(string AccountNumber)
        {
            return clsClientData.IsClientExist(AccountNumber);
        }

        public static bool isClientExistForPersonID(int PersonID)
        {
            return clsClientData.IsClientExistForPersonID(PersonID);
        }


        //----Transactions
        //public void Deposit(decimal Amount)
        //{
        //    AccountBalance += Amount;
        //    Save();
        //}

        // Update the Deposit method to return a boolean value indicating the success of the deposit operation

        public bool Deposit(decimal amount)
        {
            return _ProcessDeposit(amount);
        }

        private bool _ProcessDeposit(decimal amount)
        {
            decimal initialBalance = AccountBalance;

            // Attempt to deposit the amount
            AccountBalance += amount;

            // Call a method in the DataAccessLayer to update the account balance
            if (clsClientData.UpdateAccountBalance(ClientID, AccountBalance))
            {
                // Deposit operation successful
                return true;
            }
            else
            {
                // Roll back the balance update if the database update fails
                AccountBalance = initialBalance;

                // Deposit operation failed
                return false;
            }
        }

        public bool Withdraw(decimal amount)
        {
            decimal initialBalance = AccountBalance;

            // Check if the withdrawal amount is valid
            if (amount <= 0 || amount > AccountBalance)
            {
                // Invalid withdrawal amount
                return false;
            }

            return _ProcessDeposit(-amount);
        }

        private clsTransferLog _PrepareTransferLog(decimal Amount, clsClient DestinationClient, int UserID)
        {
            clsTransferLog TransferLog = new clsTransferLog
            {
                Amount = Amount,
                SourceBalance = AccountBalance,
                DestinationBalance = DestinationClient.AccountBalance,
                TransferDate = DateTime.Now,
                SourceAccountNumber = AccountNumber,
                DestinationAccountNumber = DestinationClient.AccountNumber,
                CreatedByUserID = UserID
            };

            return TransferLog;
        }

        private void _RegisterTransferLog(decimal Amount, clsClient DestinationClient, int UserID)
        {
            clsTransferLog TransferLog = _PrepareTransferLog(Amount, DestinationClient, UserID);
            TransferLog.Save();
        }

        public bool Transfer(decimal Amount, ref clsClient DestinationClient, int UserID)
        {
            if (Amount <= 0 || Amount > AccountBalance)
            {
                // Invalid transfer amount
                return false;
            }

            // Deduct the amount from the current client's account
            if (!Withdraw(Amount))
            {
                // Withdrawal failed
                return false;
            }

            // Add the amount to the destination client's account
            DestinationClient.Deposit(Amount);

            _RegisterTransferLog(Amount, DestinationClient, UserID);

            return true;
        }

        public static DataTable GetClientInfoByAccountNumber(string AccountNumber)
        {
            return clsClientData.GetClientInfoByAccountNumber(AccountNumber);
        }

        public static DataTable GetTransfersLogList()
        {
            return clsClientData.GetTransfersLogList();
        }
    }
}
