using System;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Infrastructure.Interfaces;

public interface IProductService
{
    List<Product> GetAll();
    Product GetProductById(int id);
    int Create(Product product);
    int UpdateProduct( Product product);
    int DeleteProduct(int id);
    List<Product> GetProductsByCategory(string category);
    List<string> GetUniqueManufacturer();
}
