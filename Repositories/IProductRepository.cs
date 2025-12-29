using Dapper.DemoAPI.Models;

namespace Dapper.DemoAPI.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    
    Task<Product?> GetByIdAsync(int id);
    
    Task<int> AddAsync(Product product);
    
    Task<int> UpdateAsync(Product product);
    
    Task<int> DeleteAsync(int id);
}