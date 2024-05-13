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
    public class BookRepo : IBookRepo
    {
        private DatabaseContext _context;
        public BookRepo()
        {
            _context = new DatabaseContext();
        }
        public bool AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteBook(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
            return true;
        }

        public List<Book> GetAllFromDB()
        {
            return _context.Books.ToList();
        }

        public bool UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
            return true;
        }
    }
}
