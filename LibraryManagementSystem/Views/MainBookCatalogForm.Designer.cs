namespace LibraryManagementSystem
{
    partial class MainBookCatalogForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            searchTextBox = new TextBox();
            searchButton = new Button();
            addButton = new Button();
            deleteButton = new Button();
            refreshButton = new Button();
            dataGridView = new DataGridView();
            statusLabel = new Label();
            progressBar = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // searchTextBox
            // 
            searchTextBox.Location = new Point(20, 20);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.PlaceholderText = "Search books...";
            searchTextBox.Size = new Size(200, 23);
            searchTextBox.TabIndex = 0;
            searchTextBox.KeyDown += searchTextBox_KeyDown;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(230, 20);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(75, 25);
            searchButton.TabIndex = 1;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // addButton
            // 
            addButton.Location = new Point(320, 20);
            addButton.Name = "addButton";
            addButton.Size = new Size(75, 25);
            addButton.TabIndex = 2;
            addButton.Text = "Add Book";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Enabled = false;
            deleteButton.Location = new Point(405, 20);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(75, 25);
            deleteButton.TabIndex = 3;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // refreshButton
            // 
            refreshButton.Enabled = false;
            refreshButton.Location = new Point(490, 20);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(75, 25);
            refreshButton.TabIndex = 4;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(20, 60);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(750, 450);
            dataGridView.TabIndex = 5;
            dataGridView.CellDoubleClick += dataGridView_CellDoubleClick;
            dataGridView.SelectionChanged += dataGridView_SelectionChanged;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(20, 520);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(39, 15);
            statusLabel.TabIndex = 6;
            statusLabel.Text = "Ready";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(20, 545);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(750, 10);
            progressBar.TabIndex = 7;
            progressBar.Visible = false;
            // 
            // BookListForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(784, 571);
            Controls.Add(progressBar);
            Controls.Add(statusLabel);
            Controls.Add(dataGridView);
            Controls.Add(refreshButton);
            Controls.Add(deleteButton);
            Controls.Add(addButton);
            Controls.Add(searchButton);
            Controls.Add(searchTextBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "BookListForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Library Management - Books";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox searchTextBox;
        private Button searchButton;
        private Button addButton;
        private Button deleteButton;
        private Button refreshButton;
        private DataGridView dataGridView;
        private Label statusLabel;
        private ProgressBar progressBar;
    }
}
