using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class TbProductType
{
    public int Idtype { get; set; }

    public string? Typename { get; set; }

    public string? Images { get; set; }

    public bool IsHome { get; set; }
}
