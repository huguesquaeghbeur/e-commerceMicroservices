namespace User.API.Repositories
{
    public class ClientRepository : IClientRepository<Client>
    {
        private readonly ClientDataContext _clientContext;
        public ClientRepository(ClientDataContext clientContext)
        {
            _clientContext = clientContext;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            return await _clientContext.Clients.ToListAsync();
        }

        public async Task<Client> GetClientByName(string userName)
        {
            return await _clientContext.Clients.FirstOrDefaultAsync(c => c.UserName == userName);
        }

        public Client SearchOne(Expression<Func<Client, bool>> searchMethode)
        {
            return _clientContext.Clients.FirstOrDefault(searchMethode);
        }

        public async Task<bool> CreateClient(Client client)
        {
            await _clientContext.Clients.AddAsync(client);
            return _clientContext.SaveChanges() > 0;
        }

        public async Task<bool> UpdateClient(Client client)
        {
            return await _clientContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteClient(Client client)
        {
            return await _clientContext.SaveChangesAsync() > 0;
        }
    }
}
