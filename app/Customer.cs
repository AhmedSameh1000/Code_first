using System;
using System.Collections.Generic;



public partial class Customer
{
    public int CustId { get; set; }

    public string? CustName { get; set; }

    public string? CustMail { get; set; }

    public string? CustUserName { get; set; }

    public string? CustPassword { get; set; }

    public int? CustGenderId { get; set; }

    public int? CustGovId { get; set; }

    public string? CustCity { get; set; }

    public string? CustFullAddress { get; set; }

    public string? CustTel1 { get; set; }

    public string? CustTel2 { get; set; }

    public string? CustMasterCardId { get; set; }

    public DateTime? CustRegDate { get; set; }

    public string? CustIsBlocked { get; set; }

  

    public  Gender? CustGender { get; set; }

    public  Governorate? CustGov { get; set; }

    public  MasterCard? CustMasterCard { get; set; }

    public  ICollection<Wishlist> Wishlists { get; } = new List<Wishlist>();
}
