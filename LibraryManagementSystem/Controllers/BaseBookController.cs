using LibraryManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Controllers
{
    /// <summary>
    /// Base book controller with common functionality for all book controllers.
    /// </summary>
    public abstract class BaseBookController
    {
        // Shared dependency for a BookService.
        protected IBookService BookService { get; }

        protected BaseBookController(IBookService bookService)
        {
            BookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
        }

        protected virtual void HandleError(Exception ex, string action)
        {
            // Dummy error handle
            // In a real app this should be logging
            System.Diagnostics.Debug.WriteLine($"Error during {action}: {ex.Message}");
        }
    }
}
