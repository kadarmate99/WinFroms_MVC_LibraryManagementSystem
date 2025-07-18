using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Views
{
    /// <summary>
    /// Contract for views that handle book creation and editing.
    /// </summary>
    public interface IBookEditorView
    {
        // Properties that the controller can read from the view
        string BookTitle { get; }
        string BookAuthor { get; }
        string BookISBN { get; }
        bool BookIsAvailable { get; }
        DateTime BookPublishedDate { get; }

        // Events that the controller can subscribe to
        event EventHandler SaveRequested;
        event EventHandler CancelRequested;

        // Methods for the controller to update the view
        void PopulateBookData(Book book);
        void ClearForm();
        void SetDialogResultAndClose(DialogResult result);
        DialogResult ShowDialog();
    }
}
