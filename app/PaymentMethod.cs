using System;
using System.Collections.Generic;



public partial class PaymentMethod
{
    public int MethodId { get; set; }

    public string? MethodName { get; set; }

    public  ICollection<CardVisa> CardVisas { get; } = new List<CardVisa>();

}
