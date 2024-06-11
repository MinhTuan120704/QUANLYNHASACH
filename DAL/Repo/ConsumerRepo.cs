using DAL.Context;
using DAL.IRepo;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
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
            return _context.Consumers.AsNoTracking().ToList();
        }

        public bool UpdateConsumer(Consumer consumer)
        {
            _context.Consumers.Update(consumer);
            _context.SaveChanges();
            return true;
        }

        public bool CheckConsumerExistFromDB(Consumer consumer)
        {
            return _context.Consumers.Any(p => p.ConsumerName.ToLower() == consumer.ConsumerName.ToLower() && consumer.Phone == p.Phone);
        }

        public int GetConsumerIDFromDB(string phone)
        {
            return _context.Consumers.Where(p => p.Phone == phone).Select(p => p.ConsumerID).FirstOrDefault();
        }

        public List<Consumer> SearchConsumerFromDB(string consumername)
        {
            return _context.Consumers.Where(p => p.ConsumerName.ToLower() == consumername.ToLower()).ToList();
        }

        public string GetConsumerNameByIDFromDB(int consumerID)
        {
            return _context.Consumers.Where(c => c.ConsumerID == consumerID).Select(c => c.ConsumerName).FirstOrDefault();
        }

        public string GetConsumerPhoneByIDFromDB(int consumerID)
        {
            return _context.Consumers.Where(c => c.ConsumerID == consumerID).Select(c => c.Phone).FirstOrDefault();
        }
    }
}
