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
    public class Code:BaseEntity
    {
        public int id { get { return CodeId; } }

        /// <summary>
        /// 验证码编号
        /// </summary>
        public int CodeId { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public string Operater { get; set; }

        /// <summary>
        /// 验证码类型
        /// </summary>
        public string CodeType { get; set; }

        /// <summary>
        /// 发送方式
        /// </summary>
        public string SendType { get; set; }

        /// <summary>
        /// 发送号码 
        /// </summary>
        public string SendNo { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string Num { get; set; }

        /// <summary>
        /// 验证码内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 发送返回结果
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
        
    }
}
