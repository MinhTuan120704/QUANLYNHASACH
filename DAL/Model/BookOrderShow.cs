using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class BookOrderShow
    {
        public int OrderID { get; set; }

        public int BookID { get; set; }

        public int Quantity { get; set; }

        public string? BookName { get; set; }

        public double Total { get; set; }

        public BookOrderShow(int orderID, int bookID, string? bookName, int quantity, double total)
        {
            OrderID = orderID;
            BookID = bookID;
            BookName = bookName;
            Quantity = quantity;
            Total = total;
        }
    }
}
