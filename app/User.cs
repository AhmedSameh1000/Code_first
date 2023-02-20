using System;
using System.Collections.Generic;



public partial class User
{
    public int UserId { get; set; }

    public string? UserFullName { get; set; }

    public string? UserUserName { get; set; }

    public string? UserPassword { get; set; }

    public string? UserMail { get; set; }

    public bool? UserIsBlocked { get; set; }

    public int? UserRoleId { get; set; }

    public Role? UserRole { get; set; }
}
