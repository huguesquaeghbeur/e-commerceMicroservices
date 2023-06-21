namespace User.API.Models
{
    public class Client
    {
        private int id;
        private string userName;
        private string password;
        private string email;
        private bool isAdmin = false;

        public Client()
        {

        }

        public int Id { get => id; set => id = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }
    }
}
