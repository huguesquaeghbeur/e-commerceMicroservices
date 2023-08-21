namespace User.API.Interfaces
{
    public interface IClientRepository<T>
    {
        Task<IEnumerable<Client>> GetClients();
        Task<Client> GetClientByEmail(string email);
        T SearchOne(Expression<Func<T, bool>> searchMethode);
        Task<bool> CreateClient(Client client);
        Task<bool> UpdateClient(Client client);
        Task<bool> DeleteClient(Client client);
    }
}
