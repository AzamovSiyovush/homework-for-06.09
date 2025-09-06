using System;
using Dapper;
using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.Data;
using OnlineStore.Infrastructure.Interfaces;

namespace OnlineStore.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly DataContext _context = new();

    public int Create(Product product)
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $@"insert into products(name,description,price,category,stockquantity,manufacturer) values(@Name,@Description,@Price,@Category,@StockQuantity,@Manufacturer)";
        return connection.Execute(cmd, product);
    }

    public int DeleteProduct(int id)
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $@"delete from products
            where id = @id";
        return connection.Execute(cmd, new { id });

    }

    public List<Product> GetAll()
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $@"select * from products";
        return connection.Query<Product>(cmd).ToList();
    }

    public Product? GetProductById(int id)
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $@"select * from products
                where Id = @id";
        return connection.QueryFirstOrDefault<Product>(cmd,new{id});
    }

    public List<Product> GetProductsByCategory(string category)
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $@"select * from products
                where category = @category";
        return connection.Query<Product>(cmd,new{category}).ToList();
    }

    public List<string> GetUniqueManufacturer()
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $@"select distinct(manufacturer) from products";
        return connection.Query<string>(cmd).ToList();
    }

    public int UpdateProduct(Product product)
    {
        using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $@"update products
                    set name = @name,description = @description,price = @price,category=@category,stockquantity = @stockquantity,manufacturer  = @manufacturer";
        return connection.Execute(cmd, product);
    }
}
