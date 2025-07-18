using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services
{
    /// <summary>
    /// In-memory book service implementation. (In a real app, this should talk to a database...)
    /// </summary>
    public class BookService : IBookService
    {
        // Static so data persists across service instances
        private static List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Title = "Clean Code", Author = "Robert Martin", ISBN = "978-0132350884", IsAvailable = true, PublishedDate = new DateTime(2008, 8, 1) },
            new Book { Id = 2, Title = "Design Patterns", Author = "Gang of Four", ISBN = "978-0201633612", IsAvailable = true, PublishedDate = new DateTime(1994, 10, 31) },
            new Book { Id = 3, Title = "Refactoring", Author = "Martin Fowler", ISBN = "978-0201485677", IsAvailable = false, PublishedDate = new DateTime(1999, 7, 8) },
            new Book { Id = 4, Title = "Code Complete", Author = "Steve McConnell", ISBN = "978-0735619678", IsAvailable = true, PublishedDate = new DateTime(2004, 6, 19) },
            new Book { Id = 5, Title = "The Pragmatic Programmer", Author = "Andrew Hunt", ISBN = "978-0201616224", IsAvailable = true, PublishedDate = new DateTime(1999, 10, 30) }
        };

        public List<Book> GetAllBooks()
        {
            return new List<Book>(_books); // Return copy to prevent external modification
        }

        public Book GetBookById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public bool AddBook(Book book)
        {
            if (book == null || string.IsNullOrEmpty(book.Title) || string.IsNullOrEmpty(book.Author))
            {
                return false;
            }

            // Generate a new ID for the book
            book.Id = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
            _books.Add(book);
            return true;
        }

        public bool UpdateBook(Book book)
        {
            if (book == null)
                return false;

            var existingBook = _books.FirstOrDefault(b => b.Id ==  book.Id);
            if (existingBook == null)
                return false;

            // Update all properties of the existing book
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.ISBN = book.ISBN;
            existingBook.IsAvailable = book.IsAvailable;
            existingBook.PublishedDate = book.PublishedDate;
            return true;
        }

        public bool DeleteBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _books.Remove(book);
                return true;
            }
            return false;
        }

        public List<Book> SearchBooks(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return GetAllBooks();
            }

            return _books.Where(b =>
                b.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                b.Author.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
