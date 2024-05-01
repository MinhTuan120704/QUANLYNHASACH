using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Book
    {
        public int BookID { get; set; }

        public string BookName { get; set; }

        public string BookType { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public int Quantity { get; set; }

        public int UnitPrice { get; set; }

        public int UnitSoldPrice { get; set; }

        public List<BookOrder> bookOrdersB { get; set; }

        public List<ReceiptDetail> receiptDetailsB { get; set; }
    }
}
