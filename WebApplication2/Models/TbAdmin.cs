using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class TbAdmin
{
    public int AccountId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? FullName { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public bool IsActive { get; set; }
}
