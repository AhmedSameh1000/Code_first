using System;
using System.Collections.Generic;



public partial class Gender
{
    public int GenderId { get; set; }

    public string? GenderName { get; set; }

    public ICollection<Customer> Customers { get; } = new List<Customer>();
}
