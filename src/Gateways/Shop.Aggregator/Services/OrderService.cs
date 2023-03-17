namespace Shop.Aggregator.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;

        public OrderService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrders(string userName)
        {
            var response = await _client.GetAsync($"/api/v1/order/{userName}");
            return await response.ReadContentAs<List<OrderResponseModel>>();
        }
    }
}
