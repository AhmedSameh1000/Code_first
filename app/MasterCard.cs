using System;
using System.Collections.Generic;



public partial class MasterCard
{
    public string MasterCardId { get; set; } = null!;

    public DateTime? MasterExpDate { get; set; }

    public int? MasterBalance { get; set; }

    public  ICollection<Customer> Customers { get; } = new List<Customer>();
}
