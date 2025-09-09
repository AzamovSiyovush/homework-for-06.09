using System;
using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.ApiResponses;

namespace OnlineStore.Infrastructure.Interfaces;

public interface ICustomerService
{
    Task<Response<List<Customer>>> GetAll();
    Task<Response<Customer>> GetById(int id);
    Task<Response<string>> CreateCustomer(Customer customer);
    Task<Response<string>> UpdateCustomer(Customer customer);
    Task<Response<string>> DeleteCustomer(int customerId);
    Task<Response<List<Customer>>> GetCustomersRegisteredBetween(DateTime startDate, DateTime endDate);
    

}
