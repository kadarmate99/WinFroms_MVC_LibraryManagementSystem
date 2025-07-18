using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;
using LibraryManagementSystem.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Controllers
{
    public class BookEditorController : BaseBookController
    {
        private readonly IBookEditorView _view;
        private readonly IUserNotificationView _feedback;
        private readonly IFormValidation _validation;

        private Book _currentBook; // The book being edited (null when adding new book)

        public BookEditorController(IBookEditorView view, IUserNotificationView feedback, IFormValidation validation, IBookService bookService) : base(bookService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _feedback = view as IUserNotificationView ?? throw new ArgumentException("View must implement IUserFeedback");
            _validation = view as IFormValidation ?? throw new ArgumentException("View must implement IFormValidation");

            _view.SaveRequested += OnSaveRequested;
            _view.CancelRequested += OnCancelRequested;
        }

        public void InitializeForAdd()
        {
            _currentBook = null;
            _view.ClearForm();
            _feedback.ShowMessage("Enter book details and click Save");
        }

        public void InitializeForEdit(Book book)
        {
            _currentBook = book ?? throw new ArgumentNullException(nameof(book));
            _view.PopulateBookData(book);
            _feedback.ShowMessage("Modify book details and click Save");
        }

        // Event Handlers
        private void OnSaveRequested(object sender, EventArgs e)
        {
            try
            {
                // Validate form data (the view handles this now, could be moved to a separate validation service)
                if (_view is BookEditorForm form && !form.ValidateForm())
                {
                    return;
                }

                // Create or update the book
                if (_currentBook == null)
                {
                    // Adding a new book
                    var newbook = CreateBookFromView();
                    var success = BookService.AddBook(newbook);
                    if (success)
                    {
                        _feedback.ShowMessage("Book added successfully");
                        // Close the form with delay
                        Task.Delay(500).ContinueWith(t => _view.SetDialogResultAndClose(DialogResult.OK));
                    }
                    else
                    {
                        _feedback.ShowError("Failed to add book");
                    }
                }
                else
                {
                    // Editing an existing book
                    UpdateBookFromView(_currentBook);
                    var success = BookService.UpdateBook(_currentBook);

                    if (success)
                    {
                        _feedback.ShowMessage("Book updated successfully");
                        // Close the form with delay
                        Task.Delay(500).ContinueWith(t => _view.SetDialogResultAndClose(DialogResult.OK));
                    }
                    else
                    {
                        _feedback.ShowError("Failed to update book");
                    }
                }

            }
            catch (Exception ex)
            {
                HandleError(ex, _currentBook == null ? "adding book" : "updating book");
                _feedback.ShowError("An error occurred while saving the book");
            }
        }

        private void OnCancelRequested(object sender, EventArgs e)
        {
            _view.SetDialogResultAndClose(DialogResult.Cancel);
        }

        // Helper Methods
        private Book CreateBookFromView()
        {
            return new Book
            {
                Title = _view.BookTitle,
                Author = _view.BookAuthor,
                ISBN = _view.BookISBN,
                IsAvailable = _view.BookIsAvailable,
                PublishedDate = _view.BookPublishedDate
            };
        }

        private void UpdateBookFromView(Book book)
        {
            book.Title = _view.BookTitle;
            book.Author = _view.BookAuthor;
            book.ISBN = _view.BookISBN;
            book.IsAvailable = _view.BookIsAvailable;
            book.PublishedDate = _view.BookPublishedDate;
        }
    }
}
