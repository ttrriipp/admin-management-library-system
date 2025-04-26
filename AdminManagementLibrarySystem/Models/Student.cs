namespace AdminManagementLibrarySystem.Models
{
    internal class Student : User
    {
        public string StudentID { get; private set; } 
        public string Department { get; set; }
        public string Course { get; set; }
        internal Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FullName = $"{FirstName} {LastName}";
        }
    }
}
