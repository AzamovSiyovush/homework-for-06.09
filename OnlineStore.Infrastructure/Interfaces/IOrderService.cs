using System;
using OnlineStore.Domain.Dtos;
using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.ApiResponses;

namespace OnlineStore.Infrastructure.Interfaces;

public interface IOrderService
{
    Task<Response<List<Order>>> GetAll();
    Task<Response<Order>> GetById(int id);
    Task<Response<string>> CreateOrder(Order order);
    Task<Response<string>> UpdateOrder(Order order);
    Task<Response<string>> DeleteOrder(int id);
    Task<Response<List<GetOrderCountByCustomerDto>>> GetOrderCountByCustomer();
    Task<Response<GetCustomerWithMaxOrdersDto>> GetCustomerWithMaxOrders();
    Task<Response<List<Order>>> GetOrdersAboveAverageTotalPrice();
    Task<Response<GetOrdersByCustomerIdDto>> GetOrdersByCustomerId(int customerId);
    Task<Response<List<Order>>> GetOrdersSortedByDate();
    Task<Response<List<GetTotalOrderValueByCustomerDto>>> GetTotalOrderValueByCustomers();
    
}
