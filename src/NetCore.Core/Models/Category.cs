using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NetCore.Models
{
    public class Category : Entity
    {
        [Required, StringLength(250)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Slug { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public int? ParentId { get; set; }

        //public virtual ICollection<PostCategory> PostCategories { get; set; }

    }
}
