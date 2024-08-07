using BankingSystem_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem_Business
{
    public class clsTransferLog
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int TransferLogID { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransferDate { get; set; }
        public string SourceAccountNumber { get; set; }
        public string DestinationAccountNumber { get; set; }
        public decimal SourceBalance { get; set; }
        public decimal DestinationBalance { get; set; }
        public int CreatedByUserID { get; set; }


        public clsTransferLog()

        {
            this.TransferLogID = -1;
            this.Amount = 0;
            this.TransferDate = DateTime.Now;
            this.SourceAccountNumber = "";
            this.DestinationAccountNumber = "";
            this.SourceBalance = 0;
            this.DestinationBalance = 0;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        public clsTransferLog(int transferLogID, decimal amount, DateTime transferDate, string sourceAccountNumber,
            string destinationAccountNumber, int createdByUserID)
        {
            TransferLogID = transferLogID;
            Amount = amount;
            TransferDate = transferDate;
            SourceAccountNumber = sourceAccountNumber;
            DestinationAccountNumber = destinationAccountNumber;
            CreatedByUserID = createdByUserID;

            Mode = enMode.Update;
        }

        private bool _AddNewTransferLog()
        {
            this.TransferLogID = clsTransferLogData.AddNewTransferLog(this.SourceAccountNumber, this.DestinationAccountNumber,
                this.Amount, this.SourceBalance, this.DestinationBalance, this.TransferDate, this.CreatedByUserID);

            return (this.TransferLogID != -1);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTransferLog())
                        return true;
                    else
                        return false;

                case enMode.Update:
                    break;
            }

            return false;
        }

    }
}
