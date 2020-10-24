using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBook.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string Text { get; set; }

        [ForeignKey(nameof(Data.Author))]
        public int UserId { get; set; }
        public virtual Author Author { get; set; }

        [ForeignKey(nameof(Data.Post))]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

    }
}
