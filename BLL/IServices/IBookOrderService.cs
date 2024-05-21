using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IServices
{
    public interface IBookOrderService
    {
        bool AddBookOrder(BookOrder bookorder);
        bool UpdateBookOrder(BookOrder bookorder);
        bool DeleteBookOrder(BookOrder bookorder);
        List<BookOrder> GetAllBookOrder();
    }
}
