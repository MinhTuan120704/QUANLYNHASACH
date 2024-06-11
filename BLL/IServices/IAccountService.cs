using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IServices
{
    public interface IAccountService
    {
        bool AddAccount(Account account);
        bool UpdateAccount(Account account);
        bool DeleteAccount(Account account);
        List<Account> GetAllAccount();
        string GetAccountPosition(string name);
        bool GetExistAccount(Account account);

        int GetAccountID(string name);

        bool UpdateAccount(string accountName, string password, string position, DateTime created);

    }
}
