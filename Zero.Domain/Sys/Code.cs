using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Domain.Sys
{
    /// <summary>
    /// 验证码
    /// </summary>
    public class Code
    {
        public int CodeId { get; set; }

        public int UserId { get; set; }

        public string Operater { get; set; }

        public string CodeType { get; set; }

        public string SendType { get; set; }

        public string SendNo { get; set; }

        public string Content { get; set; }

        public string Result { get; set; }

        public int Status { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }
        
    }
}
