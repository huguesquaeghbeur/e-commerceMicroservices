namespace Cart.API.Models
{
    public class CartShopping
    {
        public string UserName { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public CartShopping(string userName)
        {
            UserName = userName;
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
