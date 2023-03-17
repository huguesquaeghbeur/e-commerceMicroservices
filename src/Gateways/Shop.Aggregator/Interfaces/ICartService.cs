namespace Shop.Aggregator.Interfaces
{
    public interface ICartService
    {
        Task<CartModel> GetCart(string userName);
    }
}
