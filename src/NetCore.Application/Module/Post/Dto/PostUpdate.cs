using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NetCore.Module.Post.Dto
{ 
    [AutoMapTo(typeof(Models.Post))]
    public class PostUpdate
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        [MaxLength(250)]
        public string Slug { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(250)]
        public string FeatureImageUrl { get; set; }

        [StringLength(1000)]
        public string Content { get; set; }

        public int PostCategoryId { get; set; }
    }
}
