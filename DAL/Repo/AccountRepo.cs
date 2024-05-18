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
    public class AccountRepo : IAccountRepo
    {
        private DatabaseContext _context;
        public AccountRepo()
        {
            _context = new DatabaseContext();
        }

        public bool AddAccount(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteAccount(Account account)
        {
            _context.Accounts.Remove(account);
            _context.SaveChanges();
            return true;
        }

        public List<Account> GetAllFromDB()
        {
            return _context.Accounts.ToList();
        }

        public bool UpdateAccount(Account account)
        {
            _context.Accounts.Update(account);
            _context.SaveChanges();
            return true;
        }
    }
}
