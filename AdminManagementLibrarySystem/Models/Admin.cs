using MySql.Data.MySqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

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
        public void adminDb_add()
        {
            string connect = "server=localhost;user id=root;password=;database=librarysys";
            string queries = "INSERT INTO `admin_acc_db` (`adminid`, `username_admin`, `password_admin`) VALUES (NULL, 'admin1', 'admin1')";
            MySqlConnection newconn = new MySqlConnection(connect);
            MySqlCommand comm = new MySqlCommand(queries, newconn);
            MySqlDataReader read;
            newconn.Open();
            read = comm.ExecuteReader();
        }
    }
}
