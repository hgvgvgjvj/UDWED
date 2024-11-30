using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class TbDetailedInvoice
{
    public int AccountId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public decimal? TotalPrice { get; set; }

    public int? Idbill { get; set; }

    public virtual TbProduct? Product { get; set; }
}
