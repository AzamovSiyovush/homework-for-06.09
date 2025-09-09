using System;
using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.ApiResponses;
using OnlineStore.Infrastructure.Interfaces;
using OnlineStore.Infrastructure.Services;

namespace OnlineStore.Api.Controllers;

public class CustomerController
{
    private readonly ICustomerService _customerService = new CustomerService();
    public async Task<Response<string>> CreateCustomer(Customer customer)
    {
        return await _customerService.CreateCustomer(customer);
    }
    public async Task<Response<string>> DeleteCustomer(int customerId)
    {
        return await _customerService.DeleteCustomer(customerId);
    }
    public async Task<Response<List<Customer>>> GetAll()
    {
        return await _customerService.GetAll();
    }
    public async Task<Response<Customer>> GetById(int id)
    {
        
    }
}
