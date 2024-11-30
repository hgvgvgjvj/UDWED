using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class TbComment
{
    public int CommentId { get; set; }

    public string? Idcommentator { get; set; }

    public string? CommentContent { get; set; }

    public int? Idblog { get; set; }

    public DateTime? Date { get; set; }

    public virtual TbBlog? IdblogNavigation { get; set; }
}
