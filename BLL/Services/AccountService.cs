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
    public class AccountService : IAccountService
    {
        private IAccountRepo _accountRepo;

        public AccountService() 
        {
            _accountRepo = new AccountRepo();
        }
        public bool AddAccount(Account account)
        {
            _accountRepo.AddAccount(account);
            return true;
        }

        public bool DeleteAccount(Account account)
        {
            _accountRepo.DeleteAccount(account);
            return true;
        }

        public List<Account> GetAllAccount()
        {
            return _accountRepo.GetAllFromDB();
        }

        public bool UpdateAccount(Account account)
        {
            _accountRepo.UpdateAccount(account);
            return true;
        }
    }
}
