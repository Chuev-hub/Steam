using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.DAL.Context
{
    public class ProfileComment
    {
        public int ProfileCommentId { get; set; }

        [Required]
        public int ProfileId { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public DateTime CommentTime  { get; set; }

        [Required]
        [StringLength(512)]
        public string CommentText { get; set; }

        public virtual Account Author { get; set; } //5
        public virtual Account Profile { get; set; } //4
    }
}
