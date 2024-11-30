using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class TbBill
{
    public int Idbill { get; set; }

    public string? OrderCode { get; set; }

    public int? UseId { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public bool? Status { get; set; }

    public DateTime? OrderDate { get; set; }

    public virtual TbUser? Use { get; set; }
}
