using BLL.IServices;
using DAL.IRepo;
using DAL.Model;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
            if (CheckConsumerExistFromDB(consumer))
            {
                return false;
            }
            else
            {
                _consumerRepo.AddConsumer(consumer);
                return true;
            }
        }

        public bool AddConsumer(string consumerName, string address, string phone, string email, int debt, DateTime created)
        {
            Consumer consumer = new Consumer()
            {
                ConsumerID = _consumerRepo.GetConsumerIDFromDB(phone),
                ConsumerName = consumerName,
                Address = address,
                Phone = phone,
                Email = email,
                Debt = debt,
                Created = created
            };
            if (CheckConsumerExistFromDB(consumer))
            {
                return false;
            }
            else
            {
                _consumerRepo.AddConsumer(consumer);
                return true;
            }
        }

        public bool DeleteConsumer(Consumer consumer)
        {
            consumer.ConsumerID = _consumerRepo.GetConsumerIDFromDB(consumer.Phone);
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
        public bool UpdateConsumer(string consumerName, string address, string phone, string email, int debt, DateTime created)
        {
            Consumer consumer = new Consumer()
            {
                ConsumerID = _consumerRepo.GetConsumerIDFromDB(phone),
                ConsumerName = consumerName,
                Address = address,
                Phone = phone,
                Email = email,
                Debt = debt,
                Created = created
            };
            _consumerRepo.UpdateConsumer(consumer);
            return true;
        }
        public bool CheckConsumerExistFromDB(Consumer consumer)
        {
            return _consumerRepo.CheckConsumerExistFromDB(consumer);

        }
        public int GetConsumerIDFromDB(string phone)
        {
            return _consumerRepo.GetConsumerIDFromDB(phone);

        }
        public List<Consumer> SearchConsumerFromDB(string consumername)
        {
            return _consumerRepo.SearchConsumerFromDB(consumername);
        }

        public string GetConsumerNameByID(int consumerID)
        {
            return _consumerRepo.GetConsumerNameByIDFromDB(consumerID);
        }

        public string GetConsumerPhoneByID(int consumerID)
        {
            return _consumerRepo.GetConsumerPhoneByIDFromDB(consumerID);
        }

        public int GetDebtByPhone(string phone)
        {
            return _consumerRepo.GetDebtByPhoneFromDB(phone);
        }

        public Consumer? GetConsumerByID(int consumerID)
        {
            return _consumerRepo.GetConsumerByIDFromDB(consumerID);
        }
    }
}
