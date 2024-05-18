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
    public class ConsumerRepo : IConsumerRepo
    {
        private DatabaseContext _context;
        public ConsumerRepo()
        {
            _context = new DatabaseContext();
        }
        public bool AddConsumer(Consumer consumer)
        {
            _context.Consumers.Add(consumer);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteConsumer(Consumer consumer)
        {
            _context.Consumers.Remove(consumer);
            _context.SaveChanges();
            return true;
        }

        public List<Consumer> GetAllFromDB()
        {
            return _context.Consumers.ToList();
        }

        public bool UpdateConsumer(Consumer consumer)
        {
            _context.Consumers.Update(consumer);
            _context.SaveChanges();
            return true;
        }
    }
}
