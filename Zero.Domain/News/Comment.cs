using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Domain.News
{
    public class Comment
    {
        public int CommentId { get; set; }

        public int UserId { get; set; }

        public int NewsId { get; set; }

        public string Content { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}
