namespace Ordered.API.Repositories
{
    public class OrderedRepository : IOrderedRepository

    {
        private readonly OrderedContext _orderedContext;

        public OrderedRepository(OrderedContext orderedContext)
        {
            _orderedContext = orderedContext;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _orderedContext.Orders.ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrderByEmail(string email)
        {
            return await _orderedContext.Orders.Where(o => o.Email == email).ToListAsync();
        }

        public async Task<bool> CreateOrder(Order order)
        {
            await _orderedContext.Orders.AddAsync(order);
            return _orderedContext.SaveChanges() > 0;
        }

        public async Task<bool> UpdateOrder(Order order)
        {
            return await _orderedContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteOrder(Order order)
        {
            return await _orderedContext.SaveChangesAsync() > 0;
        }
    }
}
