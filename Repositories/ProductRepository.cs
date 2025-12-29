using System.Data;
using Dapper.DemoAPI.Models;

namespace Dapper.DemoAPI.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IDbConnection _dbConnection;

    public ProductRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    
    public Task<IEnumerable<Product>> GetAllAsync()
    {
        var sql = "SELECT * FROM SalesLT.Product";
        return _dbConnection.QueryAsync<Product>(sql);
    }

    public Task<Product?> GetByIdAsync(int id)
    {
        var sql = "SELECT * FROM SalesLT.Product WHERE ProductID = @id";
        return _dbConnection.QueryFirstOrDefaultAsync<Product>(sql, new { id });
    }

    public Task<int> AddAsync(Product product)
    {
        var sql = @"INSERT INTO dbo.SalesLT.Product(
                        ProductID,
                        Name,
                        ProductNumber,
                        Color,
                        StandardCost,
                        ListPrice,
                        Size,
                        Weight,
                        ProductCategoryID,
                        ProductModelID,
                        SellStartDate,
                        SellEndDate,
                        DiscontinuedDate,
                        ThumbnailPhoto,
                        ThumbnailPhotoFileName,
                        rowguid,
                        ModifiedDate
                    )
                    VALUES
                    (
                        @ProductID,
                        @Name,
                        @ProductNumber,
                        @Color,
                        @StandardCost,
                        @ListPrice,
                        @Size,
                        @Weight,
                        @ProductCategoryID,
                        @ProductModelID,
                        @SellStartDate,
                        @SellEndDate,
                        @DiscontinuedDate,
                        @ThumbnailPhoto,
                        @ThumbnailPhotoFileName,
                        @rowguid,
                        @ModifiedDate
                    );";
        
        return _dbConnection.ExecuteAsync(sql, product);
    }

    public Task<int> UpdateAsync(Product product)
    {
        var sql = @"UPDATE dbo.SalesLT.Product
                    SET
                        Name = @Name,
                        ProductNumber = @ProductNumber,
                        Color = @Color,
                        StandardCost = @StandardCost,
                        ListPrice = @ListPrice,
                        Size = @Size,
                        Weight = @Weight,
                        ProductCategoryID = @ProductCategoryID,
                        ProductModelID = @ProductModelID,
                        SellStartDate = @SellStartDate,
                        SellEndDate = @SellEndDate,
                        DiscontinuedDate = @DiscontinuedDate,
                        ThumbnailPhoto = @ThumbnailPhoto,
                        ThumbnailPhotoFileName = @ThumbnailPhotoFileName,
                        ModifiedDate = GETDATE()
                    WHERE ProductID = @ProductID;
                    ";
        
        return _dbConnection.ExecuteAsync(sql, product);
    }

    public Task<int> DeleteAsync(int id)
    {
        var sql = "DELETE FROM SalesLT.Product WHERE ProductID = @id";
        
        return _dbConnection.ExecuteAsync(sql, new { id });
    }
}