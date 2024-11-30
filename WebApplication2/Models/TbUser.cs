using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class TbUser
{
    public int UseId { get; set; }

    public string? Name { get; set; }

    public string? Sdt { get; set; }

    public string? UseName { get; set; }

    public string? Password { get; set; }

    public string? Address { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<TbBill> TbBills { get; set; } = new List<TbBill>();
}
