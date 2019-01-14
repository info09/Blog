using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NetCore.Models
{
    public class PostCategory : Entity
    {
        [NotMapped]
        public override int Id { get => base.Id; set => base.Id = value; }

        [Key, Column(Order = 1)]
        public int PostId { get; set; }

        [Key, Column(Order = 2)]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Categories { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Posts { get; set; }
    }
}
