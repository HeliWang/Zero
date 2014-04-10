using System;
using System.Collections;
using System.Collections.Generic;

namespace Zero.Domain.Cates
{
    public partial class AttrValue:BaseEntity
    {
        public int id { get { return ValueId; } }

        /// <summary>
        /// 属性值编号
        /// </summary>
        public int ValueId { get; set; }

        /// <summary>
        /// 属性编号
        /// </summary>
        public int AttrId { get; set; }

        /// <summary>
        /// 属性值
        /// </summary>
        public string ValueName { get; set; }

        /// <summary>
        /// 排列序号
        /// </summary>
        public int Oid { get; set; }
    }

    public partial class AttrValueExpand : AttrValue
    {
        public string Attr { get; set; }
    }
}
