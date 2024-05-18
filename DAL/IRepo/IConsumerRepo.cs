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
        List<Consumer> GetAllFromDB();
    }
}
