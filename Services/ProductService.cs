using Dapper.DemoAPI.Models;
using Dapper.DemoAPI.Repositories;

namespace Dapper.DemoAPI.Services;

public class ProductService: IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }
    public Task<IEnumerable<Product>> GetAllProductAsync()
    {
        return _repository.GetAllAsync();
    }

    public Task<Product?> GetProductByIdAsync(int id)
    {
        var product = _repository.GetByIdAsync(id);
        return product ?? throw new Exception("Product not found");
    }

    public Task<int> AddProductAsync(Product product)
    {
        return _repository.AddAsync(product);
    }

    public Task<int> UpdateProductAsync(Product product)
    {
        return _repository.UpdateAsync(product);
    }

    public Task<int> DeleteProductAsync(int id)
    {
        return _repository.DeleteAsync(id);
    }
}