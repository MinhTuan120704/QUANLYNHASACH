using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IServices
{
    public interface IConsumerService
    {
        bool AddConsumer(Consumer consumer);
        bool DeleteConsumer(Consumer consumer);
        bool UpdateConsumer(Consumer consumer);
        string GetConsumerNameByID(int consumerID);
        string GetConsumerPhoneByID(int consumerID);
        List<Consumer> GetAllConsumer();
        bool AddConsumer(string consumerName, string address, string phone, string email, int debt, DateTime created);
        bool UpdateConsumer(string consumerName, string address, string phone, string email, int debt, DateTime created);
        bool CheckConsumerExistFromDB(Consumer consumer);
        int GetConsumerIDFromDB(string phone);
        int GetDebtByPhone(string phone);
        Consumer? GetConsumerByID(int consumerID);
        List<Consumer> SearchConsumerFromDB(string consumername);
    }
}
