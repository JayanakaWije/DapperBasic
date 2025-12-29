using Dapper.DemoAPI.Models;

namespace Dapper.DemoAPI.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductAsync();
    
    Task<Product?> GetProductByIdAsync(int id);
    
    Task<int> AddProductAsync(Product product);
    
    Task<int> UpdateProductAsync(Product product);
    
    Task<int> DeleteProductAsync(int id);
}