namespace Shop.Aggregator.Models
{
    public class ShopModel
    {
        public string UserName { get; set; }
        public CartModel CartWithProducts { get; set; }
        public IEnumerable<OrderResponseModel> Orders { get; set; }
    }
}
