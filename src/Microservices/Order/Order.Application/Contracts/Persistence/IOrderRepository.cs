namespace Order.Application.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Ordered>
    {
        Task<IEnumerable<Ordered>> GetOrderByUserName(string userName);
    }
}
