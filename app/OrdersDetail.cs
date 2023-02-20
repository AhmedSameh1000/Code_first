using System;
using System.Collections.Generic;



public partial class OrdersDetail
{
    public int Id { get; set; }

    public int? CategoryNumber { get; set; }

    public int? ProductId { get; set; }

    public int? OrderNo { get; set; }

    public int? Quantity { get; set; }

    public double? SalePrice { get; set; }

    public double? Discount { get; set; }
}
