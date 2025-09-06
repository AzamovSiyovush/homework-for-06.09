using System;

namespace OnlineStore.Domain.Dtos;

public class GetOrdersByCustomerIdDto
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public string Status { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
}
