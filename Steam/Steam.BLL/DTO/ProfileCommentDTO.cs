using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.BLL.DTO
{
    public class ProfileCommentDTO
    {
        public int ProfileCommentId { get; set; }

        public int ProfileId { get; set; }

        public int AuthorId { get; set; }

        public DateTime CommentTime { get; set; }

        public string CommentText { get; set; }
    }
}
