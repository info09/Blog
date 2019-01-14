using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Module.Comment.Dto
{
    public class CommentFilter
    {
        public int? pageSize { get; set; } = 10;
        public int? pageNum { get; set; } = 1;
        public int? PostId { get; set; }
        public string Search { get; set; }
    }
}
