using LibraryManagementSystem.Models;
using LibraryManagementSystem.Views;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    /// <summary>
    /// Main form for displaying and managing the book catalog.
    /// </summary>
    public partial class MainBookCatalogForm : Form, IBookCatalogView, IUserNotificationView, ILoadingIndicatorView
    {
        public Book SelectedBook
        {
            get
            {
                if (dataGridView.SelectedRows.Count > 0)
                    return dataGridView.SelectedRows[0].DataBoundItem as Book;
                return null;
            }
        }

        public string SearchTerm => searchTextBox.Text.Trim();

        public MainBookCatalogForm()
        {
            InitializeComponent();
        }

        // Domain events that controllers can subscribe to
        public event EventHandler<Book> BookSelected;
        public event EventHandler<Book> BookDeleted;
        public event EventHandler<Book> BookEditRequested;
        public event EventHandler<string> SearchRequested;
        public event EventHandler AddBookRequested;
        public event EventHandler RefreshRequested;

        // UI event handlers - translate UI events to domain events
        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchRequested?.Invoke(this, SearchTerm);
        }
        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchRequested?.Invoke(this, SearchTerm);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddBookRequested?.Invoke(this, EventArgs.Empty);
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (SelectedBook != null)
                BookDeleted?.Invoke(this, SelectedBook);
        }
        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshRequested?.Invoke(this, EventArgs.Empty);
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            deleteButton.Enabled = SelectedBook != null;

            // Notify the controller about the selection change
            if (SelectedBook != null)
                BookSelected?.Invoke(this, SelectedBook);
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && SelectedBook != null)
            {
                BookEditRequested?.Invoke(this, SelectedBook);
            }
        }

        // Methods for controller to update the view
        public void DisplayBooks(List<Book> books)
        {
            dataGridView.DataSource = books;

            // Hide the ID column - users don't need to see it
            if (dataGridView.Columns["Id"] != null)
                dataGridView.Columns["Id"].Visible = false;

            statusLabel.Text = $"Showing {books.Count} books";
            statusLabel.ForeColor = Color.Black;
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

            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowLoading(bool isLoading)
        {
            progressBar.Visible = isLoading;

            if (isLoading)
            {
                progressBar.Style = ProgressBarStyle.Marquee;
                statusLabel.Text = "Loading...";
                statusLabel.ForeColor = Color.Blue;
            }
            else
            {
                progressBar.Style = ProgressBarStyle.Blocks;
            }

            // Disable buttons during loading to prevent multiple operations
            searchButton.Enabled = !isLoading;
            addButton.Enabled = !isLoading;
            deleteButton.Enabled = !isLoading && SelectedBook != null;
            refreshButton.Enabled = !isLoading;
        }
    }
}
