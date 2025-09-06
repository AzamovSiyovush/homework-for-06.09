using System;
using OnlineStore.Domain.Dtos;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Infrastructure.Interfaces;

public interface IOrderService
{
    List<Order> GetAll();
    Order GetById(int id);
    int CreateOrder(Order order);
    int UpdateOrder(Order order);
    int DeleteOrder(int id);
    List<GetOrderCountByCustomerDto> GetOrderCountByCustomer();
    List<GetCustomerWithMaxOrdersDto> GetCustomerWithMaxOrders();
    List<Order> GetOrdersAboveAverageTotalPrice();
    List<GetOrdersByCustomerIdDto> GetOrdersByCustomerId(int customerId);
    List<Order> GetOrdersSortedByDate();
    List<GetTotalOrderValueByCustomerDto> GetTotalOrderValueByCustomers();
    
}
