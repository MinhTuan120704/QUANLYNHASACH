using DAL.Context;
using DAL.IRepo;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

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

        public bool CheckBookExistFromDB(Book book)
        {
            return _context.Books.Any(p => p.BookName.ToLower() == book.BookName.ToLower() && book.BookType.ToLower() == p.BookType.ToLower() && book.Author.ToLower() == p.Author.ToLower());
        }

        public bool DeleteBook(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
            return true;
        }

        public List<Book> FilterBookFromDB(string condition1, string value1)
        {
            if(condition1 == "BookType")
            {
                return _context.Books.Where(book => book.BookType == value1).ToList();
            }
            else if (condition1 == "Author")
            {
                return _context.Books.Where(book => book.Author == value1).ToList();
            }
            else
            {
                return _context.Books.Where(book => book.Publisher == value1).ToList();
            }
        }

        public List<Book> FilterBookFromDB(string condition1, string value1, string condition2, string value2)
        {
            if (condition1 == "BookType" && condition2 == "Author" || condition2 == "BookType" && condition1 == "Author")
            {
                if (condition1 == "BookType")
                {
                    return _context.Books.Where(book => book.BookType == value1 && book.Author == value2).ToList();
                }
                else
                {
                    return _context.Books.Where(book => book.BookType == value2 && book.Author == value1).ToList();
                }
            }
            else if(condition1 == "BookType" && condition2 == "Publisher" || condition2 == "BookType" && condition1 == "Publisher")
            {
                if (condition1 == "BookType")
                {
                    return _context.Books.Where(book => book.BookType == value1 && book.Publisher == value2).ToList();
                }
                else
                {
                    return _context.Books.Where(book => book.BookType == value2 && book.Publisher == value1).ToList();
                }
            }
            else
            {
                if (condition1 == "Publisher")
                {
                    return _context.Books.Where(book => book.Publisher == value1 && book.Author == value2).ToList();
                }
                else
                {
                    return _context.Books.Where(book => book.Publisher == value2 && book.Author == value1).ToList();
                }
            }
        }

        public List<Book> FilterBookFromDB(string bookType, string author, string publisher)
        {
            return _context.Books.Where(book => book.BookType == bookType && book.Author == author && book.Publisher == publisher).ToList();
        }

        public List<Book> GetAllFromDB()
        {
            return _context.Books.AsNoTracking().ToList();
        }

        public List<string> GetAuthorsFromDB()
        {
            return _context.Books.Select(book => book.Author).Distinct().ToList();
        }

        public Book? GetBookByIDFromDB(int bookID)
        {
            return _context.Books.Where(book => book.BookID == bookID).FirstOrDefault();
        }

        public int GetBookIDFromDB(string bookName, string author)
        {
            return _context.Books.Where(book => book.BookName == bookName && book.Author == author).Select(book => book.BookID).FirstOrDefault();
        }

        public List<string> GetBookTypesFromDB()
        {
            return _context.Books.Select(book => book.BookType).Distinct().ToList();
        }

        public List<string> GetPublishersFromDB()
        {
            return _context.Books.Select(book => book.Publisher).Distinct().ToList();
        }

        public List<Book> SearchBookFromDB(string bookName)
        {
            return _context.Books.Where(book => book.BookName.ToLower() == bookName.ToLower()).ToList();
        }

        public bool UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
            return true;
        }
    }
}
