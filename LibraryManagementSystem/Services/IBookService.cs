using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services
{
    /// <summary>
    /// Service contract for book operations.
    /// </summary>
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        bool AddBook(Book book);
        bool UpdateBook(Book book);
        bool DeleteBook(int id);
        List<Book> SearchBooks(string searchTerm);
    }
}
