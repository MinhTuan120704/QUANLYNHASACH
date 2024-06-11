using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Order
    {
        public int OrderID { get; set; }

        public int ConsumerID { get; set; }

        public DateTime Date { get; set; }

        public int TotalValue { get; set; }

        public int PaidValue { get; set; }

        public int RemainingValue { get; set; }

        public List<BookOrder> bookOrdersO { get; set; }

        public Consumer Consumer { get; set; }  
    }
}
