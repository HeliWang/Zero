using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zero.Domain.Cates;

namespace Zero.Domain.Upload
{
    public class PhotoCate : BaseCate
    {
        /// <summary>
        /// 允许的格式
        /// </summary>
        public string AllowExt { get; set; }

        /// <summary>
        /// 允许的大小
        /// </summary>
        public int AllowSize { get; set; }

        /// <summary>
        /// 允许的数量
        /// </summary>
        public int AllowCount { get; set; }
    }
}
