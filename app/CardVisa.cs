using System;
using System.Collections.Generic;



public partial class CardVisa
{
    public string CardNumber { get; set; } = null!;

    public int? CardType { get; set; }

    public string? Month { get; set; }

    public string? Year { get; set; }

    public string? NameInCard { get; set; }

    public string? UserName { get; set; }

    public string? MasterBalance { get; set; }

    public PaymentMethod? CardTypeNavigation { get; set; }
}
