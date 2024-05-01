using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class BookOrder
    {
        public int OrderID { get; set; }

        public int BookID { get; set; }

        public int Quantity { get; set; }

        public Book Book { get; set; }

        public Order Order { get; set; }
    }
}
