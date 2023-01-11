namespace Catalog.API.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(string id);
        Task<IEnumerable<Product>> GetProductByName(string name);
        Task<IEnumerable<Product>> GetProductByCategory(string category);

        Task CreateProduct(Product element);
        Task<bool> UpdateProduct(Product element);
        Task<bool> DeleteProduct(string id);

    }
}
