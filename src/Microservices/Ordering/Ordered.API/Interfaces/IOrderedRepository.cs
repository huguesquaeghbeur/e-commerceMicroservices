namespace Ordered.API.Interfaces
{
    public interface IOrderedRepository
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<IEnumerable<Order>> GetOrderByEmail(string email);
        Task<bool> CreateOrder(Order order);
        Task<bool> UpdateOrder(Order order);
        Task<bool> DeleteOrder(Order order);
    }
}
