using System;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.ApiResponses;
using OnlineStore.Infrastructure.Interfaces;
using OnlineStore.Infrastructure.Services;

namespace OnlineStore.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController
{
    private readonly IProductService _productservice = new ProductService();
    [HttpGet]
    public async Task<Response<List<Product>>> GetProducts()
    {
        var products = _productservice.GetAll();
        return await products;
    }
    [HttpPost]
    public async Task<Response<string>> CreateProduct(Product product)
    {
        var products = _productservice.Create(product);
       
        return await products;
    }
    [HttpPut]
    public async Task<Response<string>> UpdateProduct(Product product)
    {
        var products = _productservice.UpdateProduct(product);
        return await products;
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteProduct(int id)
    {
        var products = _productservice.DeleteProduct(id);
        return await products;
        
    }
    [HttpGet("UniqueManufacturer")]
    public async Task<Response<List<string>>> GetUniqueManufacturer()
    {
        var products = _productservice.GetUniqueManufacturer();
        return await products;
    }

    [HttpGet("{id:int}")]
    public async Task<Response<Product>> GetProductById(int id)
    {
        var products = _productservice.GetProductById(id);
        return await products;
    }

    [HttpGet("{category}")]
    public async Task<Response<List<Product>>> GetProductsByCategory(string category)
    {
       return await  _productservice.GetProductsByCategory(category);
    }
}