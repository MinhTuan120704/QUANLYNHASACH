using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface IOrderRepo
    {
        bool AddOrder(Order order);
        bool DeleteOrder(Order order);
        bool UpdateOrder(Order order);
        List<Order> GetAllFromDB();
    }
}
