using Abp.Domain.Entities;
using Abp.Timing;
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

        public PostState Status { get; set; } // 0-Published, 1-Draft, 2-Private

        public DateTime PublishedTime { get; set; }

        public int PostCategoryId { get; set; }

        //[ForeignKey("PostCategoryId")]
        //public virtual PostCategory PostCategories { get; set; }

        public List<Comment> Comments { get; set; }

        public Post()
        {
            PublishedTime = Clock.Now;
            //Status = PostState.Published;
        }
    }

    public enum PostState : byte
    {
        Published=0,
        Draft=1,
        Private=2
    }
}
