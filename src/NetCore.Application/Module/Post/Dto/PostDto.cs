using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using NetCore.Models;
using NetCore.Module.Comment.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Module.Post.Dto
{
    [AutoMapFrom(typeof(Models.Post))]
    public class PostDto:EntityDto
    {
        public string Title { get; set; }
        
        public string Slug { get; set; }

        public string Description { get; set; }

        public string FeatureImageUrl { get; set; }

        public string Content { get; set; }

        public string Status { get; set; }

        public DateTime PublishedTime { get; set; }

        public int PostCategoryId { get; set; }

        public List<CommentDto> Comments { get; set; }
    }
}
