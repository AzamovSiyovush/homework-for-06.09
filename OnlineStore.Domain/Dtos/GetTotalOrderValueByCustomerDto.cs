using System;

namespace OnlineStore.Domain.Dtos;

public class GetTotalOrderValueByCustomerDto
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public decimal Sum { get; set; }
}
