using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Domain.News
{
    public class Tag
    {
        public int TagId { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Summary { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}
