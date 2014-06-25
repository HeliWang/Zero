using System;
using System.Collections;
using System.Collections.Generic;

namespace Zero.Domain
{
    public class BaseCate : BaseEntity
    {
        /// <summary>
        /// 类别Id
        /// </summary>
        public int CateId { get; set; }

        /// <summary>
        /// 类别名称
        /// </summary>
        public string CateName { get; set; }

        /// <summary>
        /// 节点起始位置
        /// </summary>
        public int Lid { get; set; }

        /// <summary>
        /// 节点结束位置
        /// </summary>
        public int Rid { get; set; }

        /// <summary>
        /// 深度
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// 父节点
        /// </summary>
        public int Pid { get; set; }
     
        /// <summary>
        /// 子节点数
        /// </summary>
        public int ChildCount
        {
            get
            {
                return (Rid - Lid - 1) / 2;
            }
        }

        /// <summary>
        /// 移动标志
        /// </summary>
        public int Flag { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
       
    }
}
