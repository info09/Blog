using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NetCore.Models
{
    public class Post : Entity
    {
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

        public string Status { get; set; }

        public DateTime PublishedTime { get; set; }

        public int PostCategoryId { get; set; }

        //[ForeignKey("PostCategoryId")]
        //public virtual PostCategory PostCategories { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
