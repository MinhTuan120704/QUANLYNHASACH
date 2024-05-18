using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DatabaseAccess;
using DAL.Model;

namespace BLL
{
    public class Login
    {
        AccountAccess? AccountAccess = new AccountAccess();
        public int CheckLoginBLL(string username, string password)
        {

            if (AccountAccess.CheckLogin(username, password) == null)
            {
                return 0;
            }
            else
            {
                Account? a = AccountAccess.CheckLogin(username, password);

                if (a.Position == "QuanLy") return 1;
                else return 2;
            }
        }
    }
}
