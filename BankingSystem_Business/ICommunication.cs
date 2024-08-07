using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem_Business
{
    public interface ICommunication
    {
        void SendEmail(string title, string body);
        void SendFax(string title, string body);
        void SendSMS(string title, string body);
    }
}
