using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Domain.News
{
    public class NewsItem : BaseEntity
    {
        public int NewsId { get; set; }

        public string Title { get; set; }

        public string Short { get; set; }

        public string Summary { get; set; }

        public string Author { get; set; }

        public string Source{get;set;}

        public string SourceUrl{get;set;}

        public string Keyword { get; set; }

        public string Tag { get; set; }

        public string Photo { get; set; }

        public string RedirectUrl { get; set; }

        public int AllowComments { get; set; }

        public int CommentCount { get; set; }

        public int ClickCount { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public int DetailId { get; set; }

        public virtual NewsDetail Detail { get; set; }
    }
}
