using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        public string EmployeeName { get; set; }

        public DateTime BirthDay { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public Account account { get; set; }

        public List<Order> Employeeorders { get; set; }

        public List<Receipt> Employeereceipt { get; set; }
    }
}
