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
    public class BookService : IBookService
    {
        private IBookRepo _bookRepo;

        public BookService()
        {
            _bookRepo = new BookRepo();
        }
        public bool AddBook(Book book)
        {
            _bookRepo.AddBook(book);
            return true;
        }

        public bool DeleteBook(Book book)
        {
            _bookRepo.DeleteBook(book);
            return true;
        }

        public List<Book> GetAllBook()
        {
            return _bookRepo.GetAllFromDB();
        }

        public bool UpdateBook(Book book)
        {
            _bookRepo.UpdateBook(book);
            return true;
        }
    }
}
