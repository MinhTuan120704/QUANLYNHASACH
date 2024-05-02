using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Consumer
    {
        public int ConsumerID { get; set; }

        public string ConsumerName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public int Debt {  get; set; }

        public DateTime Created { get; set; }

        public List<Order> orders { get; set; }
    }
}
