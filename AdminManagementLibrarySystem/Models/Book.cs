using System;

namespace AdminManagementLibrarySystem.Models
{
    internal class Book
    {
        public Guid BookID { get; private set; } = Guid.NewGuid();
        public string Title { get; set; } 
        public string Author { get; set; } 
        public string Publisher { get; set; } 
        public string YearPublished { get; set; }
        public string ISBN { get; set; } = "N/A"; 
        public string Category { get; set; }
        public int Stock { get; set; }
        public bool IsAvailable => Stock > 0;			
    }
}
