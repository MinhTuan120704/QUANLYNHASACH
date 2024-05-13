using DAL.Context;
using DAL.IRepo;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class OrderRepo : IOrderRepo
    {
        private DatabaseContext _context;
        public OrderRepo()
        {
            _context = new DatabaseContext();
        }
        public bool AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteOrder(Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return true;
        }

        public List<Order> GetAllFromDB()
        {
            return _context.Orders.ToList();
        }

        public bool UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
            return true;
        }
    }
}
