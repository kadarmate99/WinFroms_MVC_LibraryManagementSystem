using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;
using LibraryManagementSystem.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem.Controllers
{
    /// <summary>
    /// Controller for book catalog functionality.
    /// </summary>
    public class BookCatalogController : BaseBookController
    {
        private readonly IBookCatalogView _view;
        private readonly IUserNotificationView _feedback;
        private readonly ILoadingIndicatorView _loading;
        private readonly IFormCreatorService _formCreatorService;

        public BookCatalogController(IBookCatalogView view, IUserNotificationView feedback, ILoadingIndicatorView loading, IBookService bookService, IFormCreatorService formCreatorService) : base(bookService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _feedback = view as IUserNotificationView ?? throw new ArgumentException("View must implement IUserNotificationView");
            _loading = view as ILoadingIndicatorView ?? throw new ArgumentException("View must implement ILoadingIndicatorView");
            
            _formCreatorService = formCreatorService ?? throw new ArgumentNullException(nameof(formCreatorService));

            // Subscribe to view events
            _view.BookSelected += OnBookSelected;
            _view.BookDeleted += OnBookDeleted;
            _view.BookEditRequested += OnBookEditRequested;
            _view.SearchRequested += OnSearchRequested;
            _view.AddBookRequested += OnAddBookRequested;
            _view.RefreshRequested += OnRefreshRequested;
        }

        public void Initialize()
        {
            LoadBooks();
        }

        // Event handlers
        // These methods coordinate between view and service
        private void OnBookSelected(object? sender, Book book)
        {
            _feedback.ShowMessage($"Selected: {book.Title} by {book.Author}");
        }

        private void OnBookDeleted(object? sender, Book book)
        {
            // Confirm destructive actions with the user
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete '{book.Title}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _loading.ShowLoading(true);

                    // Delegate the actual deletion to the service layer
                    var isDeleted = BookService.DeleteBook(book.Id);

                    if (isDeleted)
                    {
                        _feedback.ShowMessage($"Book '{book.Title}' deleted successfully");
                        LoadBooks();
                    }
                    else
                    {
                        _feedback.ShowError("Failed to delete book");
                    }
                }
                catch (Exception ex)
                {
                    HandleError(ex, "deleting book");
                    _feedback.ShowError("An error occurred while deleting the book");
                }
                finally
                {
                    _loading.ShowLoading(false);
                }

            }
        }

        private void OnBookEditRequested(object? sender, Book book)
        {
            try
            {
                _loading.ShowLoading(true);

                var result = _formCreatorService.ShowBookEditForm(book);

                // If the user saved the book, refresh the main list
                if (result == DialogResult.OK)
                {
                    LoadBooks();
                    _feedback.ShowMessage("Book list refreshed");
                }
            }
            catch (Exception ex)
            {
                HandleError(ex, "opening edit book form");
                _feedback.ShowError("An error occurred while opening the edit book form");
            }
            finally
            {
                _loading.ShowLoading(false);
            }
        }

        private void OnSearchRequested(object? sender, string searchTerm)
        {
            try
            {
                _loading.ShowLoading(true);

                // Delegate the search logic to the service layer
                var books = BookService.SearchBooks(searchTerm);

                _view.DisplayBooks(books);

                // Provide feedback
                if (books.Count == 0)
                {
                    _feedback.ShowMessage("No books found matching your search");
                }
                else if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    _feedback.ShowMessage($"Found {books.Count} books matching '{searchTerm}'");
                }
            }
            catch (Exception ex)
            {
                HandleError(ex, "searching books");
                _feedback.ShowError("An error occurred while searching for books");
            }
            finally
            {
                _loading.ShowLoading(false);
            }
        }

        private void OnAddBookRequested(object? sender, EventArgs e)
        {
            try
            {
                _loading.ShowLoading(true);

                var result = _formCreatorService.ShowBookAddForm();

                // If the user saved the book, refresh the catalog list
                if (result == DialogResult.OK)
                {
                    LoadBooks();
                    _feedback.ShowMessage("Book list refreshed");
                }
            }
            catch (Exception ex)
            {
                HandleError(ex, "opening add book form");
                _feedback.ShowError("An error occurred while opening the add book form");
            }
            finally
            {
                _loading.ShowLoading(false);
            }
        }

        private void OnRefreshRequested(object? sender, EventArgs e)
        {
            LoadBooks();
        }

        //  Helper methods
        private void LoadBooks()
        {
            try
            {
                _loading.ShowLoading(true);

                // Get all books from the service
                var books = BookService.GetAllBooks();

                // Display them in the view
                _view.DisplayBooks(books);
            }
            catch (Exception ex)
            {
                HandleError(ex, "loading books");
                _feedback.ShowError("An error occurred" +
                    " while loading books");
            }
            finally
            {
                _loading.ShowLoading(false);
            }
        }
    }
}