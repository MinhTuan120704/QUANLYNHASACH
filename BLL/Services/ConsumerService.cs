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
    public class ConsumerService : IConsumerService
    {
        private IConsumerRepo _consumerRepo;

        public ConsumerService()
        {
            _consumerRepo = new ConsumerRepo();
        }
        public bool AddConsumer(Consumer consumer)
        {
            _consumerRepo.AddConsumer(consumer);
            return true;
        }

        public bool DeleteConsumer(Consumer consumer)
        {
            _consumerRepo.DeleteConsumer(consumer); 
            return true;
        }

        public List<Consumer> GetAllConsumer()
        {
            return _consumerRepo.GetAllFromDB();
        }

        public bool UpdateConsumer(Consumer consumer)
        {
            _consumerRepo.UpdateConsumer(consumer); 
            return true;
        }
    }
}
