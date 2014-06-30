using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Domain.News
{
    public class NewsDetail : BaseEntity
    {
        public int DetailId { get; set; }

        public int NewsId { get; set; }

        public string Content { get; set; }
    }
}
