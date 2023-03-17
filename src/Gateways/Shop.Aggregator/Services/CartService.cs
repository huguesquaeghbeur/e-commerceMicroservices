namespace Shop.Aggregator.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _client;

        public CartService(HttpClient client)
        {
            _client = client;
        }

        public async Task<CartModel> GetCart(string userName)
        {
            var response = await _client.GetAsync($"/api/v1/cart/{userName}");
            return await response.ReadContentAs<CartModel>();
        }
    }
}
