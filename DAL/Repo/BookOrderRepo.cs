using DAL.Context;
using DAL.IRepo;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class BookOrderRepo : IBookOrderRepo
    {
        private DatabaseContext _context;
        public BookOrderRepo()
        {
            _context = new DatabaseContext();
        }
        public bool AddBookOrder(BookOrder bookorder)
        {
            _context.BookOrders.Add(bookorder);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteBookOrder(BookOrder bookorder)
        {
            _context.BookOrders.Remove(bookorder);
            _context.SaveChanges();
            return true;
        }

        public List<BookOrder> GetAllFromDB()
        {
            return _context.BookOrders.ToList();
        }

        public bool UpdateBookOrder(BookOrder bookorder)
        {
            _context.BookOrders.Update(bookorder);
            _context.SaveChanges();
            return true;
        }
    }
}
