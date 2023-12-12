namespace Cart.API.Models
{
    public class CartShopping
    {
        public string Email { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public CartShopping(string email)
        {
            Email = email;
        }

        public CartShopping()
        {

        }

        public decimal Totalprice
        {
            get
            {
                decimal totalprice = 0;
                foreach (var item in Items )
                    {
                        totalprice += item.Price * item.Quantity;
                    }
                return totalprice;
            }
        }
    }
}
