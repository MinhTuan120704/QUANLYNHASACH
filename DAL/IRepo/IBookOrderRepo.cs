using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface IBookOrderRepo
    {
        bool AddBookOrder(BookOrder bookorder);
        bool UpdateBookOrder(BookOrder bookorder);
        bool DeleteBookOrder(BookOrder bookorder);
        List<BookOrder> GetBookOrderByOrderIDFromDB(int orderID);
        List<BookOrder> GetAllFromDB();
    }
}
