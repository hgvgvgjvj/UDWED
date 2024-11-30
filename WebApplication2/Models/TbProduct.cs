using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class TbProduct
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public decimal? Price { get; set; }

    public decimal? PromotionalPrice { get; set; }

    public int? Idtype { get; set; }

    public virtual ICollection<TbDetailedInvoice> TbDetailedInvoices { get; set; } = new List<TbDetailedInvoice>();
}
