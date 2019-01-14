using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using NetCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Module.Comment.Dto
{
    [AutoMapFrom(typeof(Models.Comment))]
    public class CommentDto:EntityDto
    {
        public string Content { get; set; }

        public bool Status { get; set; }

        public int PostId { get; set; }

    }
}
