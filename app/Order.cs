using System;
using System.Collections.Generic;



public partial class Order
{
    public int OrderNo { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? ShipName { get; set; }

    public string? ShipCity { get; set; }

    public string? ShipArea { get; set; }

    public string? ShipAddress { get; set; }

    public string? MemberName { get; set; }
}
