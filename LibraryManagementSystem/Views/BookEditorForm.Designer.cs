namespace LibraryManagementSystem.Views
{
    partial class BookEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            titleLabel = new Label();
            titleTextBox = new TextBox();
            authorTextBox = new TextBox();
            authorLabel = new Label();
            isbnTextBox = new TextBox();
            isbnLabel = new Label();
            publishedDateLabel = new Label();
            publishedDatePicker = new DateTimePicker();
            availableCheckBox = new CheckBox();
            saveButton = new Button();
            cancelButton = new Button();
            statusLabel = new Label();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(20, 20);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(32, 15);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Title:";
            // 
            // titleTextBox
            // 
            titleTextBox.Location = new Point(20, 40);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new Size(300, 23);
            titleTextBox.TabIndex = 1;
            // 
            // authorTextBox
            // 
            authorTextBox.Location = new Point(20, 100);
            authorTextBox.Name = "authorTextBox";
            authorTextBox.Size = new Size(300, 23);
            authorTextBox.TabIndex = 3;
            // 
            // authorLabel
            // 
            authorLabel.AutoSize = true;
            authorLabel.Location = new Point(20, 80);
            authorLabel.Name = "authorLabel";
            authorLabel.Size = new Size(47, 15);
            authorLabel.TabIndex = 2;
            authorLabel.Text = "Author:";
            // 
            // isbnTextBox
            // 
            isbnTextBox.Location = new Point(20, 160);
            isbnTextBox.Name = "isbnTextBox";
            isbnTextBox.Size = new Size(300, 23);
            isbnTextBox.TabIndex = 5;
            // 
            // isbnLabel
            // 
            isbnLabel.AutoSize = true;
            isbnLabel.Location = new Point(20, 140);
            isbnLabel.Name = "isbnLabel";
            isbnLabel.Size = new Size(35, 15);
            isbnLabel.TabIndex = 4;
            isbnLabel.Text = "ISBN:";
            // 
            // publishedDateLabel
            // 
            publishedDateLabel.AutoSize = true;
            publishedDateLabel.Location = new Point(20, 200);
            publishedDateLabel.Name = "publishedDateLabel";
            publishedDateLabel.Size = new Size(89, 15);
            publishedDateLabel.TabIndex = 6;
            publishedDateLabel.Text = "Published Date:";
            // 
            // publishedDatePicker
            // 
            publishedDatePicker.Location = new Point(20, 220);
            publishedDatePicker.Name = "publishedDatePicker";
            publishedDatePicker.Size = new Size(300, 23);
            publishedDatePicker.TabIndex = 7;
            // 
            // availableCheckBox
            // 
            availableCheckBox.AutoSize = true;
            availableCheckBox.Location = new Point(20, 260);
            availableCheckBox.Name = "availableCheckBox";
            availableCheckBox.Size = new Size(74, 19);
            availableCheckBox.TabIndex = 10;
            availableCheckBox.Text = "Available";
            availableCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(165, 260);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 30);
            saveButton.TabIndex = 11;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(245, 260);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 30);
            cancelButton.TabIndex = 12;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(20, 307);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(39, 15);
            statusLabel.TabIndex = 13;
            statusLabel.Text = "Ready";
            // 
            // BookEditForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(334, 341);
            Controls.Add(statusLabel);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(availableCheckBox);
            Controls.Add(publishedDatePicker);
            Controls.Add(publishedDateLabel);
            Controls.Add(isbnTextBox);
            Controls.Add(isbnLabel);
            Controls.Add(authorTextBox);
            Controls.Add(authorLabel);
            Controls.Add(titleTextBox);
            Controls.Add(titleLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BookEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add new book";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private TextBox titleTextBox;
        private TextBox authorTextBox;
        private Label authorLabel;
        private TextBox isbnTextBox;
        private Label isbnLabel;
        private Label publishedDateLabel;
        private DateTimePicker publishedDatePicker;
        private CheckBox availableCheckBox;
        private Button saveButton;
        private Button cancelButton;
        private Label statusLabel;
    }
}