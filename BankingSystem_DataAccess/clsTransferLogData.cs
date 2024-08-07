using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem_DataAccess
{
    public class clsTransferLogData
    {
        public static int AddNewTransferLog(string SourceAccountNumber, string DestinationAccountNumber, decimal Amount,
            decimal SourceBalance, decimal DestinationBalance, DateTime TransferDate, int CreatedByUserID)
        {

            //this function will return the new person id if succeeded and -1 if not.
            int TransferLogID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO TransferLog (SourceAccountNumber,DestinationAccountNumber,Amount,SourceBalance,DestinationBalance,TransferDate,CreatedByUserID)
                             VALUES (@SourceAccountNumber,@DestinationAccountNumber,@Amount,@SourceBalance,@DestinationBalance,@TransferDate,@CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@SourceAccountNumber", SourceAccountNumber);
            command.Parameters.AddWithValue("@DestinationAccountNumber", DestinationAccountNumber);
            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@SourceBalance", SourceBalance);
            command.Parameters.AddWithValue("@DestinationBalance", DestinationBalance);
            command.Parameters.AddWithValue("@TransferDate", TransferDate);

            if (CreatedByUserID != -1)
            {
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            }
            else
            {
                command.Parameters.AddWithValue("@CreatedByUserID", DBNull.Value);
            }


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TransferLogID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return TransferLogID;
        }

    }
}
