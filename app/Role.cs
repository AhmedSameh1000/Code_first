using System;
using System.Collections.Generic;



public partial class Role
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public string? RoleDescription { get; set; }

    public  ICollection<User> Users { get; } = new List<User>();
}
