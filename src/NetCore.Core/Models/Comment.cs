using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NetCore.Models
{
    public class Comment : Entity
    {
        [StringLength(1000), Required]
        public string Content { get; set; }

        public bool Status { get; set; }

        public int PostId { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Posts { get; set; }
    }
}
