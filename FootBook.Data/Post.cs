﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBook.Data
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        //[ForeignKey(nameof(Author))]
        //public int UserId { get; set; }
        //public virtual Author Author { get; set; }
    }
}
