using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface IAccountRepo
    {
        bool AddAccount(Account account);
        bool UpdateAccount(Account account);
        bool DeleteAccount(Account account);
        List<Account> GetAllFromDB();
    }
}
