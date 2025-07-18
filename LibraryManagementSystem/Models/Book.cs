using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    /// <summary>
    /// Represents a book in the library system.
    /// </summary>
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime PublishedDate { get; set; }

        // read-only methods related to the model
        // If a method changes state, it should be in a service
        public bool CanBeBorrowed() => IsAvailable && !string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(Author);

        public override string ToString() => $"{Title} by {Author}";
    }
}
