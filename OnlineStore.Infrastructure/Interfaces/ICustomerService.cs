using System;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Infrastructure.Interfaces;

public interface ICustomerService
{
    List<Customer> GetAll();
    Customer GetById(int id);
    int CreateCustomer(Customer product);
    int UpdateCustomer(Customer product);
    int DeleteCustomer(Customer customer);
    List<Customer> GetCustomersRegisteredBetween(DateTime startDate, DateTime endDate);
    

}
