namespace AdminManagementLibrarySystem.Models
{
    internal class Admin : User
    {
        public string AdminID { get; private set; } 
        internal Admin(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FullName = $"{FirstName} {LastName}";
        }
    }
}
