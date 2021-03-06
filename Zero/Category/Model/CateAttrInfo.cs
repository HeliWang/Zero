﻿using System.Collections.Generic;
using PetaPoco;

namespace Zero.Category.Model
{
    [TableName("Cate_Attr")]
    [PrimaryKey("CAID")]
    public class CateAttrInfo
    {
        /// <summary>
        /// 类别属性编号
        /// </summary>
        public int CAID { get; set; }

        /// <summary>
        /// 类别编号
        /// </summary>
        public int CateId { get; set; }

        /// <summary>
        /// 属性编号
        /// </summary>
        public int AttrId { get; set; }

        /// <summary>
        /// 属性值类型。可选值： multiCheck(枚举多选) optional(枚举单选) multiCheckText(枚举可输入多选) optionalText(枚举可输入单选) text(非枚举可输入)
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 是否必填
        /// </summary>
        public int IsMust { get; set; }

        /// <summary>
        /// 是否关键属性
        /// </summary>
        public int IsKey { get; set; }

        /// <summary>
        /// 是否销售属性
        /// </summary>
        public int IsSale { get; set; }

        /// <summary>
        /// 是否允许别名
        /// </summary>
        public int IsAllowAlias { get; set; }

        /// <summary>
        /// 排列序号
        /// </summary>
        public int Oid { get; set; }
    }

    [TableName("Cate_View_Attr")]
    [PrimaryKey("CAID")]
    public class CateAttrExpandInfo : CateAttrInfo
    {
        public string Attr { get; set; }

        public string CateName { get; set; }

        public List<AttrValueInfo> AttrValueList { get; set; }
    }
}
