using System;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.Interfaces;
using OnlineStore.Infrastructure.Services;

namespace OnlineStore.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController
{
    private readonly IProductService _productservice = new ProductService();
    [HttpGet]
    public List<Product> GetProducts()
    {
        var products = _productservice.GetAll();
        return products;
    }
    [HttpPost]
    public string CreateProduct(Product product)
    {
        var products = _productservice.Create(product);
        if (products == 0)
        {
            System.Console.WriteLine("Product not creaated");
        }
        return "Product created";
    }
    [HttpPut]
    public string UpdateProduct(Product product)
    {
        var products = _productservice.UpdateProduct(product);
        if (products == 0)
        {
            return "product not updated";
        }
        return "product updated";
    }

    [HttpDelete]
    public string DeleteProduct(int id)
    {
        var products = _productservice.DeleteProduct(id);
        if (products == 0)
        {
            return "not deleted";
        }
        return "deleted successfully";
    }
    [HttpGet("UniqueManufacturer")]
    public List<string> GetUniqueManufacturer()
    {
        var products = _productservice.GetUniqueManufacturer();
        return products;
    }
}

