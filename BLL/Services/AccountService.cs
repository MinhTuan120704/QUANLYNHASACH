using BLL.IServices;
using DAL.IRepo;
using DAL.Model;
using DAL.Repo;
using Microsoft.EntityFrameworkCore;
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
            if (GetExistAccount(account))
            {
                return false;
            }
            else
            {
                _accountRepo.AddAccount(account);
                return true;

            }
        }

        public bool AddAccount(string accountName, string password, string position, DateTime created)
        {
            Account account = new Account()
            {
                AccountID = _accountRepo.GetAccountID(accountName),
                AccountName = accountName,
                Password = password,
                Position = position,
                Created = created
            };
            if (GetExistAccount(account))
            {
                return false;
            }
            else
            {
                _accountRepo.AddAccount(account);
                return true;

            }
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

        public bool UpdateAccount(string accountName, string password, string position, DateTime created)
        {
            Account account = new Account()
            {
                AccountID = _accountRepo.GetAccountID(accountName),
                AccountName = accountName,
                Password = password,
                Position = position,
                Created = created
            };
            _accountRepo.UpdateAccount(account);
            return true;


        }

        public string GetAccountPosition(string name)
        {
            return _accountRepo.GetAccountPosition(name);
        }

        public int GetAccountID(string name)
        {
            return _accountRepo.GetAccountID(name);
        }

        public bool GetExistAccount(Account account)
        {
            return _accountRepo.GetExistAccount(account);

        }
    }
}
