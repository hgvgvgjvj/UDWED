using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class TbBlog
{
    public int Idblog { get; set; }

    public string? Image { get; set; }

    public string? Title { get; set; }

    public string? ShortContent { get; set; }

    public string? Contents { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public DateOnly? ModifyDate { get; set; }

    public virtual ICollection<TbComment> TbComments { get; set; } = new List<TbComment>();
}
