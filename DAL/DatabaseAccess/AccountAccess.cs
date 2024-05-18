using Azure.Core;
using DAL.Context;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DatabaseAccess
{
    public class AccountAccess
    {
        public Account? CheckLogin(string username, string password)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                var user = from account in dbContext.Accounts
                           where account.AccountName == username && account.Password == password
                           select account;

                if (user == null) return null;
                else
                {

                    Account? a = user.SingleOrDefault();

                    return a;
                }
            }
        }
    }
}
