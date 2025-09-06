using System;

namespace OnlineStore.Domain.Dtos;

public class GetOrderCountByCustomerDto
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public int Count{get;set;}
}
