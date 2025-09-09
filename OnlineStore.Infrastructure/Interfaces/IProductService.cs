using System;
using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.ApiResponses;
namespace OnlineStore.Infrastructure.Interfaces;
public interface IProductService
{
    Task<Response<List<Product>>> GetAll();
     Task<Response<Product>> GetProductById(int id);
     Task<Response<string>> Create(Product product);
     Task<Response<string>> UpdateProduct( Product product);
     Task<Response<string>> DeleteProduct(int id);
    Task<Response<List<Product>>> GetProductsByCategory(string category);
    Task<Response<List<string>>> GetUniqueManufacturer();
}
