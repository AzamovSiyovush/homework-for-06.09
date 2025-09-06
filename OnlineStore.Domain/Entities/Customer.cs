using System;

namespace OnlineStore.Domain.Entities;

public class Customer
{
public int Id { get; set; }
public string Firstname { get; set; }
public string Lastname { get; set; }
public string Email { get; set; }
public string Phone { get; set; }
public string Address { get; set; }
public DateTime Registrationdate { get; set; }
}
