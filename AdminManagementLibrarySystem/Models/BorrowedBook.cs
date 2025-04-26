using System;

namespace AdminManagementLibrarySystem.Models
{
    internal class BorrowedBook : Book
    {
        public string UserID { get; private set; }
        public Guid BorrowID { get; private set; } = Guid.NewGuid();
        public string IssueDate { get; set; }
        public string DueDate { get; set; }
        public decimal FineAmount { get; set; }
    }
}
