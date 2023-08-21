namespace User.API.Models
{
    public class Client
    {
        
        private int id;
        private string firstName;
        private string lastName;
        private string password;
        private string email;
        private bool isAdmin = false;

        public Client()
        {

        }

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }
    }
}
