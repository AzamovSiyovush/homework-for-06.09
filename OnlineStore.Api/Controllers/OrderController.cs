using System;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Domain.Dtos;
using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.ApiResponses;
using OnlineStore.Infrastructure.Interfaces;
using OnlineStore.Infrastructure.Services;

namespace OnlineStore.Api.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController
{
    private readonly IOrderService _orderService = new OrderService();
    [HttpGet]
    public async Task<Response<List<Order>>> GetAll()
    {
        return await _orderService.GetAll();
    }
    [HttpPost("create_an_order{request:Order}")]
    public async Task<Response<string>> Create(Order request)
    {
        return await _orderService.CreateOrder(request);
    }
    [HttpDelete("{id:int}")]
    public async Task<Response<string>> Delete(int id)
    {
        return await _orderService.DeleteOrder(id);
    }
    [HttpGet("{id:int}")]
    public async Task<Response<Order>> GetById(int id)
    {
        return await _orderService.GetById(id);
    }
    [HttpGet("Get_customer_WIth_max_orders")]
    public async Task<Response<GetCustomerWithMaxOrdersDto>> GetItemWithMaxOrders()
    {
        return await _orderService.GetCustomerWithMaxOrders();
    }
    [HttpGet("Get_Order_Count_By_Customer")]
    public async Task<Response<List<GetOrderCountByCustomerDto>>> GetOrderCountByCustomer()
    {
        return await _orderService.GetOrderCountByCustomer();
    }
    public async Task<Response<List<Order>>> GetOrderAboveAverage()
    {
        return await _orderService.GetOrdersAboveAverageTotalPrice();
    }
}
