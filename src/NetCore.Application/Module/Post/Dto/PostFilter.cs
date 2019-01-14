using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Module.Post.Dto
{
    public class PostFilter
    {
        public int? pageSize { get; set; } = 10;
        public int? pageNum { get; set; } = 1;
        public int? PostCategoryId { get; set; }
        public string Search { get; set; }
    }
}
