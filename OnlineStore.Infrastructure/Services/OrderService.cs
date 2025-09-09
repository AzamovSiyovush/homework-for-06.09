using System;
using Dapper;
using OnlineStore.Domain.Dtos;
using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.ApiResponses;
using OnlineStore.Infrastructure.Data;
using OnlineStore.Infrastructure.Interfaces;

namespace OnlineStore.Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly DataContext _context = new();
    public async Task<Response<string>> CreateOrder(Order order)
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $@"insert into orders(customerid,productid,orderdate,quantity,totalprice,status)values(customerid,productid,orderdate,quantity,totalprice,status)";
        var result = await connection.ExecuteAsync(cmd);
        return result == 0
        ? Response<string>.Fail(404, "Not Found")
        : Response<string>.Create(null, "Successfull created"); 
    }

    public async Task<Response<string>> DeleteOrder(int id)
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $@"delete from orders
                    where id = @id";
        var result = await connection.ExecuteAsync(cmd);
        return result == 0
        ? Response<string>.Fail(400, "Bad request")
        : Response<string>.Ok(null, "success");

    }

    public async Task<Response<List<Order>>> GetAll()
    {
            await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $@"select * from orders";
        var result = await connection.QueryAsync<Order>(cmd);
        var list = result.ToList();
        return list == null
        ? Response<List<Order>>.Fail(404, "deleted success")
        : Response<List<Order>>.Ok(list, "Success");
    }

    public async Task<Response<Order>> GetById(int id)
    {
              await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = @"select * from orders
                where Id = @id";
        var result = await connection.QueryFirstOrDefaultAsync<Order>(cmd, new { id });
        return result == null
        ? Response<Order>.Fail(404, "Not found")
        : Response<Order>.Ok(result, "success");
    }

    public async Task<Response<GetCustomerWithMaxOrdersDto>> GetCustomerWithMaxOrders()
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $@"select c.id,c.firstname,c.lastname,Count(o.id)
                from orders o
                    join customers c on c.id = o.customerid
                group by c.id,c.firstname,c.lastname
                    order by Count(o.id) desc
                limit 1";
        var result = await connection.QueryFirstOrDefaultAsync(cmd);
        return result == 0
        ? Response<GetCustomerWithMaxOrdersDto>.Fail(400, "Bad request")
        : Response<GetCustomerWithMaxOrdersDto>.Ok(result, "Success");
    }

    public async Task<Response<List<GetOrderCountByCustomerDto>>> GetOrderCountByCustomer()
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $@"select Count(o.id), c.firstname,c.lastname from customers c 
join orders o on o.customerid = c.id
group by c.firstname,c.lastname";
        var result = await connection.QueryAsync<GetOrderCountByCustomerDto>(cmd);
        var list = result.ToList();
        return list.Any()
        ? Response<List<GetOrderCountByCustomerDto>>.Ok(list, "Bad request")
        : Response<List<GetOrderCountByCustomerDto>>.Fail(400, "bad request");
    }

    public async Task<Response<List<Order>>> GetOrdersAboveAverageTotalPrice()
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $@"select id,quantity,totalprice,status from orders
group by id,quantity,totalprice,status
having totalprice>avg(totalprice)";
        var result = await connection.QueryAsync<Order>(cmd);
        var list = result.ToList();
        return list.Any()
        ? Response<List<Order>>.Ok(list, "Success")
        : Response<List<Order>>.Fail(400, "Bad request");
    }

    public async Task<Response<GetOrdersByCustomerIdDto>> GetOrdersByCustomerId(int customerId)
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $@"select o.id,o.orderdate,o.quantity,o.totalprice,o.status, c.firstname,c.lastname from orders o 
join customers c on c.id = o.customerid
where c.id = @customerId";
        var result = await connection.QueryFirstOrDefaultAsync(cmd, new { customerId });
        return result == 0
        ? Response<GetOrdersByCustomerIdDto>.Fail(400, "Bad request")
        : Response<GetOrdersByCustomerIdDto>.Ok(result, "Success");
    }

    public async Task<Response<List<Order>>> GetOrdersSortedByDate()
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $@"select * from orders
where status = 'новый'
order by orderdate desc";
        var result = await connection.QueryAsync<Order>(cmd);
        var list = result.ToList();
        return list.Any()
        ? Response<List<Order>>.Ok(list, "Success")
        : Response<List<Order>>.Fail(400, "Bad request");
    }

    public async Task<Response<List<GetTotalOrderValueByCustomerDto>>> GetTotalOrderValueByCustomers()
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $@"select c.firstname,c.lastname,Sum(o.totalprice) from orders o
join customers c on c.id = o.customerid
group by c.firstname,c.lastname";
        var result = await connection.QueryAsync<GetTotalOrderValueByCustomerDto>(cmd);
        var list = result.ToList();
        return list.Any()
        ? Response<List<GetTotalOrderValueByCustomerDto>>.Ok(list, "Success")
        : Response<List<GetTotalOrderValueByCustomerDto>>.Fail(400, "Bad request");
    }

    public async Task<Response<string>> UpdateOrder(Order order)
    {
          await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = $@"update orders
                    set customerid = @customerid,productid = @productid,orderdate = @orderdate,quantity=@quantity,totalprice = @totalprice,status  = @status";
        var result = await connection.ExecuteAsync(cmd, order);
        return result == 0
        ? Response<string>.Fail(404, "Not updated")
        : Response<string>.Ok(null, "Succesfully updated");
    }
}
