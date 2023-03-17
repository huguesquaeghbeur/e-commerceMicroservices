namespace Shop.Aggregator.Models
{
    public class CartModel
    {
        public string UserName { get; set; }
        public List<CartItemExtendModel> Items { get; set; } = new List<CartItemExtendModel>();
        public decimal TotalPrice { get; set; }
    }
}
