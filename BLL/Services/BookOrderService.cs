using BLL.IServices;
using DAL.IRepo;
using DAL.Model;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BookOrderService : IBookOrderService
    {
        private IBookOrderRepo _bookOrderRepo;

        public BookOrderService()
        {
            _bookOrderRepo = new BookOrderRepo();
        }
        public bool AddBookOrder(BookOrder bookorder)
        {
            _bookOrderRepo.AddBookOrder(bookorder);
            return true;
        }

        public bool DeleteBookOrder(BookOrder bookorder)
        {
            _bookOrderRepo.DeleteBookOrder(bookorder);
            return true;
        }

        public List<BookOrder> GetAllBookOrder()
        {
            return _bookOrderRepo.GetAllFromDB();
        }

        public bool UpdateBookOrder(BookOrder bookorder)
        {
            _bookOrderRepo.UpdateBookOrder(bookorder);
            return true;
        }
    }
}
