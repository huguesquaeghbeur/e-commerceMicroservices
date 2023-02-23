namespace Order.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Ordered>, IOrderRepository
    {
        public OrderRepository(OrderContext orderContext) : base(orderContext)
        {

        }

        public async Task<IEnumerable<Ordered>> GetOrderByUserName(string userName)
        {
            var orderList = await _orderContext.Ordereds
                .Where(x => x.UserName == userName)
                .ToListAsync();
            return orderList;
        }
    }
}
