using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IServices
{
    public interface IBookService
    {
        bool AddBook(Book book);
        bool AddBook(string bookName, string bookType, string author, string publisher, int quantity, int unitPrice);
        bool UpdateBook(Book book);
        bool UpdateBook(string bookName, string bookType, string author, string publisher, int quantity, int unitPrice);
        bool DeleteBook(Book book);
        bool CheckBookExist(Book book);
        int GetBookID(string bookName, string author);
        List<Book> SearchBook(string bookName);
        List<Book> FilterBook(string? bookType, string? author, string? publisher);
        List<string> GetBookTypes();
        List<string> GetAuthors();
        List<string> GetPublishers();
        List<Book> GetAllBook();
    }
}
