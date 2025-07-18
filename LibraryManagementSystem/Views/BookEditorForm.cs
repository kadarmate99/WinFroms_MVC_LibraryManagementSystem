using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem.Views
{
    public partial class BookEditorForm : Form, IBookEditorView, IUserNotificationView, IFormValidation
    {
        // Properties that expose form data to controllers
        public string BookTitle => titleTextBox.Text.Trim();
        public string BookAuthor => authorTextBox.Text.Trim();
        public string BookISBN => isbnTextBox.Text.Trim();
        public bool BookIsAvailable => availableCheckBox.Checked;
        public DateTime BookPublishedDate => publishedDatePicker.Value;

        public BookEditorForm()
        {
            InitializeComponent();

            // Sensible defaults for new books
            publishedDatePicker.Value = DateTime.Now;
            availableCheckBox.Checked = true;
        }

        // Events that notify the controller of user actions
        public event EventHandler SaveRequested;
        public event EventHandler CancelRequested;

        // UI event handlers to raise domain events
        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveRequested?.Invoke(this, EventArgs.Empty);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CancelRequested?.Invoke(this, EventArgs.Empty);
        }

        // Methods for controller to update the view
        public void PopulateBookData(Book book)
        {
            if (book == null)
            {
                ClearForm();
                return;
            }

            titleTextBox.Text = book.Title ?? string.Empty;
            authorTextBox.Text = book.Author ?? string.Empty;
            isbnTextBox.Text = book.ISBN ?? string.Empty;
            availableCheckBox.Checked = book.IsAvailable;
            publishedDatePicker.Value = book.PublishedDate;

            // Change form title to indicate editing mode
            this.Text = "Edit Book - " + book.Title;
        }
        
        public void ClearForm()
        {
            titleTextBox.Clear();
            authorTextBox.Clear();
            isbnTextBox.Clear();
            availableCheckBox.Checked = true;
            publishedDatePicker.Value = DateTime.Now;
            this.Text = "Add New Book";
        }

        public void SetDialogResultAndClose(DialogResult result)
        {
            this.DialogResult = result;
            this.Close();
        }

        public void ShowMessage(string message)
        {
            statusLabel.Text = message;
            statusLabel.ForeColor = Color.Green;
        }

        public void ShowError(string error)
        {
            statusLabel.Text = error;
            statusLabel.ForeColor = Color.Red;
        }

        // IFormValidationView implementation (maybe could be moved to a separate validation service)
        public bool ValidateForm()
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(BookTitle))
                errors.Add("Title is required");

            if (string.IsNullOrWhiteSpace(BookAuthor))
                errors.Add("Author is required");

            if (BookPublishedDate > DateTime.Now)
                errors.Add("Published date cannot be in the future");

            if (errors.Any())
            {
                ShowError(string.Join(", ", errors));
                return false;
            }

            return true;
        }

    }
}
