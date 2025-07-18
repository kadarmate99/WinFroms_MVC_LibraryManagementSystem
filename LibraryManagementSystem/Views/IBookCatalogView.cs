using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Views
{
    /// <summary>
    /// Contract for views that display and manage a catalog of books.
    /// </summary>
    public interface IBookCatalogView
    {
        //Properties that the controller can read from the view
        Book SelectedBook { get; }
        string SearchTerm { get; }

        // Events that the controller can subscribe to
        // These events represent user intentions, not specific UI actions
        event EventHandler<Book> BookSelected;
        event EventHandler<Book> BookDeleted;
        event EventHandler<Book> BookEditRequested;
        event EventHandler<string> SearchRequested;
        event EventHandler AddBookRequested;
        event EventHandler RefreshRequested;

        // Methods for the controller to update the view
        void DisplayBooks(List<Book> books);
    }
}
