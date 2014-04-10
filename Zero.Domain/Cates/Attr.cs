using System;
using System.Collections;
using System.Collections.Generic;

namespace Zero.Domain.Cates
{
    public partial class Attr : BaseEntity
    {
        public int id { get { return AttrId; } }

        /// <summary>
        /// 属性编号
        /// </summary>
        public int AttrId { get; set; }

        /// <summary>
        /// 属性名称
        /// </summary>
        public string AttrName { get; set; }

        /// <summary>
        /// 排列序号
        /// </summary>
        public int Oid { get; set; }
    }
}
