using System;
using System.Collections.Generic;



public partial class Wishlist
{
    public int WishlistId { get; set; }

    public int? CustomerId { get; set; }

    public int? ProductId { get; set; }

    public Customer? Customer { get; set; }
}
