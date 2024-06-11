using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface IConsumerRepo
    {
        bool AddConsumer(Consumer consumer);
        bool DeleteConsumer(Consumer consumer);
        bool UpdateConsumer(Consumer consumer);
        bool CheckConsumerExistFromDB(Consumer consumer);
        int GetConsumerIDFromDB(string phone);
        List<Consumer> SearchConsumerFromDB(string consumername);
        List<Consumer> GetAllFromDB();
    }
}
