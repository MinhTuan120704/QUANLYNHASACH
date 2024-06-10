using BLL.IServices;
using DAL.IRepo;
using DAL.Model;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

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
            if (CheckBookExist(book))
            {
                return false;
            }
            else
            {
                _bookRepo.AddBook(book);
                return true;
            }
        }

        public bool AddBook(string bookName, string bookType, string author, string publisher, int quantity, int unitPrice)
        {
            Book book = new Book()
            {
                BookID = _bookRepo.GetBookIDFromDB(bookName,author),
                BookName = bookName,
                BookType = bookType,
                Author = author,
                Publisher = publisher,
                Quantity = quantity,
                UnitPrice = unitPrice
            };
            if(CheckBookExist(book))
            {
                return false;
            }
            else
            {
                _bookRepo.AddBook(book);
                return true;
            }
        }

        public bool CheckBookExist(Book book)
        {
            return _bookRepo.CheckBookExistFromDB(book);
        }

        public bool DeleteBook(Book book)
        {
            _bookRepo.DeleteBook(book);
            return true;
        }

        public List<Book> FilterBook(string? bookType, string? author, string? publisher)
        {
            string BookType = "BookType";
            string Author = "Author";
            string Publisher = "Publisher";
            if (bookType != null && author != null && publisher != null)
            {
                return _bookRepo.FilterBookFromDB(bookType, author, publisher);
                
            }
            else
            {
                if (bookType == null && author != null && publisher != null)
                {
                    return _bookRepo.FilterBookFromDB(Author, author, Publisher, publisher);
                    
                }
                else if (bookType != null && author == null && publisher != null)
                {
                    return _bookRepo.FilterBookFromDB(BookType, bookType, Publisher, publisher);

                }
                else if (bookType != null && author != null && publisher == null)
                {
                    return _bookRepo.FilterBookFromDB(BookType, bookType, Author, author);

                }
                else if(bookType != null && author == null && publisher == null)
                {
                    return _bookRepo.FilterBookFromDB(BookType, bookType);

                }
                else if(bookType == null && author != null && publisher == null)
                {
                    return _bookRepo.FilterBookFromDB(Author, author);

                }
                else if(bookType == null && author == null && publisher != null)
                {
                    return _bookRepo.FilterBookFromDB(Publisher, publisher);

                }
                else 
                {
                    return _bookRepo.GetAllFromDB();
                }
            }
        }

        public List<Book> GetAllBook()
        {
            return _bookRepo.GetAllFromDB();
        }

        public List<string> GetAuthors()
        {
            return _bookRepo.GetAuthorsFromDB();
        }

        public int GetBookID(string bookName, string author)
        {
            return _bookRepo.GetBookIDFromDB(bookName, author);
        }

        public List<string> GetBookTypes()
        {
            return _bookRepo.GetBookTypesFromDB();
        }

        public List<string> GetPublishers()
        {
            return _bookRepo.GetPublishersFromDB();
        }

        public List<Book> SearchBook(string bookName)
        {
            return _bookRepo.SearchBookFromDB(bookName);
        }

        public bool UpdateBook(Book book)
        {
            _bookRepo.UpdateBook(book);
            return true;
        }

        public bool UpdateBook(string bookName, string bookType, string author, string publisher, int quantity, int unitPrice)
        {
            Book book = new Book()
            {
                BookName = bookName,
                BookType = bookType,
                Author = author,
                Publisher = publisher,
                Quantity = quantity,
                UnitPrice = unitPrice
            };

            _bookRepo.UpdateBook(book);
            return true;

        }
    }
}
