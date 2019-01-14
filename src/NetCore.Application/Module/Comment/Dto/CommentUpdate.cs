using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NetCore.Module.Comment.Dto
{
    [AutoMapTo(typeof(Models.Comment))]
    public class CommentUpdate
    {
        public int Id { get; set; }

        [StringLength(1000), Required]
        public string Content { get; set; }

        public int PostId { get; set; }
    }
}
