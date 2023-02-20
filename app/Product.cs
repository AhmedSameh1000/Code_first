using System;
using System.Collections.Generic;


public partial class Product
{
    public int ProId { get; set; }

    public string? ProName { get; set; }

    public int? ProUnitPrice { get; set; }

    public double? ProDiscountPercent { get; set; }

    public string? ProDiscription { get; set; }

    public bool? ProIsValid { get; set; }

    public int? ProQuantityPerUnit { get; set; }

    public bool? ProIsFeatured { get; set; }

    public string? ProPicture { get; set; }

    public DateTime? ProInsertingDate { get; set; }

    public int? ProCatId { get; set; }

    public int? BrandId { get; set; }

    public  Category? ProCat { get; set; }
}
