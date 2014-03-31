using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Domain.Photos
{
    public class Photo
    {
        public int Id { get { return PhotoId; } }

        public int PhotoId { get; set; }

        public int CateId { get; set; }

        public int Url { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
