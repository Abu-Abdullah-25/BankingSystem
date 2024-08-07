using System.Configuration;

namespace BankingSystem_DataAccess
{
    static class clsDataAccessSettings
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
        }

    }
}