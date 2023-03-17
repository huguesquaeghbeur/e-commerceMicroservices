namespace Shop.Aggregator.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _client;

        public CatalogService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalog()
        {
            var response = await _client.GetAsync("/api/v1/catalog");
            return await response.ReadContentAs<List<CatalogModel>>();
            
        }
        public async Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string category)
        {
            var response = await _client.GetAsync($"/api/v1/catalog/{category}");
            return await response.ReadContentAs<List<CatalogModel>>();
        }
        public async Task<CatalogModel> GetCatalogById(string id)
        {
            var response = await _client.GetAsync($"/api/v1/catalog/{id}");
            return await response.ReadContentAs<CatalogModel>();
        }


    }
}
