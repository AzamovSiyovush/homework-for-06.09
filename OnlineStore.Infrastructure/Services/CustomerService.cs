using System;
using System.Threading.Tasks;
using Dapper;
using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.ApiResponses;
using OnlineStore.Infrastructure.Data;
using OnlineStore.Infrastructure.Interfaces;

namespace OnlineStore.Infrastructure.Services;

public class CustomerService : ICustomerService
{
    private readonly DataContext _context = new();
    public async  Task<Response<string>> CreateCustomer(Customer customer)
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $@"insert into customers(firstname,lastname,email,phone,address,registrationdate) values(@firstname,@lastname,@email,@phone,@address,@registrationdate)";
        var result = await connection.ExecuteAsync(cmd, customer);
        return result == 0
        ? Response<string>.Fail(400, "customer not created")
        : Response<string>.Create(null, "successfull created");
    }

    public async Task<Response<string>> DeleteCustomer(int customerId)
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $@"delete from customers
            where id = @customerId";
        var result = await connection.ExecuteAsync(cmd, new { customerId });
        return result == 0
        ? Response<string>.Fail(400, "Not deleted")
        : Response<string>.Ok(null, "successfully deleted");
    }

    public async Task<Response<List<Customer>>> GetAll()
    {
       await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $@"select * from customers";
        var result = await connection.QueryAsync<Customer>(cmd);
        var list = result.ToList();
        return list == null
        ? Response<List<Customer>>.Fail(400, "Not Found")
        : Response<List<Customer>>.Create(list, "Found");
    }

    public async Task<Response<Customer>> GetById(int id)
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $@"select * from customers
                where id = @id";
        var result = await connection.QueryFirstOrDefaultAsync<Customer>(cmd, new { id });
        return result == null
        ? Response<Customer>.Fail(404, "Not Found")
        : Response<Customer>.Ok(result, "success");
    }

    public async Task<Response<List<Customer>>> GetCustomersRegisteredBetween(DateTime startDate, DateTime endDate)
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $@"select * from customers 
                    where registrationdate>@startDate and registrationdate<endDate";
        var result = await connection.QueryAsync<Customer>(cmd, new { startDate, endDate });
        return result == null
        ? Response<List<Customer>>.Fail(404, "Failed")
        : Response<List<Customer>>.Ok(null, "success");
    }

    public async Task<Response<string>> UpdateCustomer(Customer customer)
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $@"update customers
            set firstname = @firstname,lastname = @lastname,email = @email,phone=@phone,address = @address,registrationdate = @registrationdate";
        var result = await connection.ExecuteAsync(cmd);
        return result == 0
        ? Response<string>.Fail(400, "Failed to update")
        : Response<string>.Ok(null, "Successfully updated");
    }
}
