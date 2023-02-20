using System;
using System.Collections.Generic;



public partial class Category
{
    public int CatId { get; set; }

    public string? CatName { get; set; }

    public string? CatDescription { get; set; }

    public string? CatPicture { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
