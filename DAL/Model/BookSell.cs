using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class BookSell
    {
        public int BookID { get; set; }

        public string BookName { get; set; }

        public string BookType { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public int Quantity { get; set; }

        public int UnitPrice { get; set; }

        public int Price { get; set; }

        public double Amount { get; set; }

        public BookSell(int bookID, string bookName, int quantity, int unitPrice) 
        {
            BookID = bookID;
            BookName = bookName;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Price = UnitPrice * 105 / 100;
            Amount = (double)Price * Quantity;
        }
    }
}
