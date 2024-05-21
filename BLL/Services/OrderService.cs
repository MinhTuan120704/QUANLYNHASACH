using BLL.IServices;
using DAL.IRepo;
using DAL.Model;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepo _orderRepo;

        public OrderService()
        {
            _orderRepo = new OrderRepo();
        }
        public bool AddOrder(Order order)
        {
            _orderRepo.AddOrder(order);
            return true;
        }

        public bool DeleteOrder(Order order)
        {
            _orderRepo.DeleteOrder(order);  
            return true;
        }

        public List<Order> GetAllOrder()
        {
            return _orderRepo.GetAllFromDB();
        }

        public bool UpdateOrder(Order order)
        {
            _orderRepo.UpdateOrder(order);
            return true;
        }
    }
}
