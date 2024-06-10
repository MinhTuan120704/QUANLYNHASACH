using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Account
    {
        public int AccountID { get; set; }

        public int EmployeeID { get; set; }

        public string AccountName { get; set; }

        public string Password { get; set; }

        public string Position { get; set; }

        public DateTime Created {  get; set; }

        public Employee Employee { get; set; }
    }
}
