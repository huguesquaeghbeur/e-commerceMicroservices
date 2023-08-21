namespace Ordered.API.Models
{
    public class Order : ModelBase
    {
        // Adresse de facturation
        private string firstName;
        private string lastName;

        private string email;
        private string address;
        private string city;
        private string zipCode;
        private string country;

        // Paiement
        private string cardName;
        private string cardNumber;
        private string expiration;
        private string cvv;
        private int paymentMethod;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string ZipCode { get => zipCode; set => zipCode = value; }
        public string Country { get => country; set => country = value; }
        public string CardName { get => cardName; set => cardName = value; }
        public string CardNumber { get => cardNumber; set => cardNumber = value; }
        public string Expiration { get => expiration; set => expiration = value; }
        public string Cvv { get => cvv; set => cvv = value; }
        public int PaymentMethod { get => paymentMethod; set => paymentMethod = value; }
    }
}
