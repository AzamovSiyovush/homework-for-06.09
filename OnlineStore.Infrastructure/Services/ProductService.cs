using System;
using Dapper;
using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.ApiResponses;
using OnlineStore.Infrastructure.Data;
using OnlineStore.Infrastructure.Interfaces;

namespace OnlineStore.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly DataContext _context = new();

    public async Task<Response<string>> Create(Product product)
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $@"insert into products(name,description,price,category,stockquantity,manufacturer) values(@Name,@Description,@Price,@Category,@StockQuantity,@Manufacturer)";
        var result = await connection.ExecuteAsync(cmd, product);
        return result == 0
        ?  Response<string>.Fail(500, "Product is not created")
        : Response<string>.Create(null,"Car created succesfully");
    }

    public async Task<Response<string>> DeleteProduct(int id)
    {
        await  using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $@"delete from products
            where id = @id";
        var result = await connection.ExecuteAsync(cmd, new { id });
        return result == 0
        ? Response<string>.Fail(404, "Delete is failed")
        : Response<string>.Ok(null,"Deleted succesfully");
    }

    public async Task<Response<List<Product>>> GetAll()
    {
         await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $@"select * from products";
        var result = await connection.QueryAsync<Product>(cmd);
        var list = result.ToList();
        return list == null
        ? Response<List<Product>>.Fail(404, "deleted success")
        : Response<List<Product>>.Ok(list, "Success");
    }

    public async Task<Response<Product>> GetProductById(int id)
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = @"select * from products
                where Id = @id";
        var result = await connection.QueryFirstOrDefaultAsync<Product>(cmd, new { id });
        return result == null
        ? Response<Product>.Fail(404, "Not found")
        : Response<Product>.Ok(result, "success");
    }

    public async Task<Response<List<Product>>> GetProductsByCategory(string category)
    {
       await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $@"select * from products
                where lower(category) = lower(@category)";
        var result = await connection.QueryAsync<Product>(cmd, new { category });
        var list = result.ToList();
        return list.Any()
        ? Response<List<Product>>.Ok(list, "Success")
        : Response<List<Product>>.Fail(404, "Not Found");
    }

    public async Task<Response<List<string>>> GetUniqueManufacturer()
    {
       await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $@"select distinct(manufacturer) from products";
        var result = await connection.QueryAsync<string>(cmd);
        var list = result.ToList();
        return list == null
        ? Response<List<string>>.Fail(404, "Not found")
        : Response<List<string>>.Ok(list, "Success");
    }

    public async Task<Response<string>> UpdateProduct(Product product)
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $@"update products
                    set name = @name,description = @description,price = @price,category=@category,stockquantity = @stockquantity,manufacturer  = @manufacturer";
        var result = await connection.ExecuteAsync(cmd, product);
        return result == 0
        ? Response<string>.Fail(404, "Not updated")
        : Response<string>.Ok(null, "Succesfully updated");
    }
    
}
