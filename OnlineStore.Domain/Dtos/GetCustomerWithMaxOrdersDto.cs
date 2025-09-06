using System;

namespace OnlineStore.Domain.Dtos;
public class GetCustomerWithMaxOrdersDto
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public int MaxCount{ get; set; }
}