using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface IBookRepo
    {
        
        bool AddBook(Book book);
        bool UpdateBook(Book book);
        bool DeleteBook(Book book);
        bool CheckBookExistFromDB(Book book);
        int GetBookIDFromDB(string bookName, string author);
        Book? GetBookByIDFromDB(int bookID);
        List<Book> SearchBookFromDB(string bookName);
        List<Book> FilterBookFromDB(string condition1, string value1);
        List<Book> FilterBookFromDB(string condition1, string value1, string condition2, string value2);
        List<Book> FilterBookFromDB(string bookType, string author, string publisher);
        List<string> GetBookTypesFromDB();
        List<string> GetAuthorsFromDB();
        List<string> GetPublishersFromDB();
        List<Book> GetAllFromDB();
    }
}
