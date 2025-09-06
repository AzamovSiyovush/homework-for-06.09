using System;

namespace OnlineStore.Domain.Entities;

public class Order
{
public int Id { get; set; }
public int Customerid { get; set; }
public int Productid { get; set; }
public DateTime Orderdate { get; set; }
public int Quantity { get; set; }
public decimal Totalprice { get; set; }
public  string Status { get; set; }

    

}
