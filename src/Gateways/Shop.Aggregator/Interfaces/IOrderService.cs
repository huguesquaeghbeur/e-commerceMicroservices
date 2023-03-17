namespace Shop.Aggregator.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponseModel>> GetOrders(string userName);
    }
}
