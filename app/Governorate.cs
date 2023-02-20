using System;
using System.Collections.Generic;



public partial class Governorate
{
    public int GovId { get; set; }

    public string? GovName { get; set; }

    public  ICollection<Customer> Customers { get; } = new List<Customer>();
}
