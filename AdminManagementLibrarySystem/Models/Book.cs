using System;

namespace AdminManagementLibrarySystem.Models
{
    internal class Book
    {
        private static string uuid = Guid.NewGuid().ToString();
        public string BookID { get; } = uuid;
        public string Title { get; set; } 
        public string Author { get; set; } 
        public string Publisher { get; set; } 
        public string YearPublished { get; set; }
        public string ISBN { get; set; } = "N/A"; 
        public string Category { get; set; }
        public bool AvailabilityStatus { get; set; } = true;

				
    }
}
