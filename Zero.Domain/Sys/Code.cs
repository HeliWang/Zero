using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Domain.Sys
{
    public enum CodeType
    {
        验证手机=0,
    }

    public enum SendType
    {
        手机=0,
        邮件=1,
    }

    public enum CodeStatus
    {
        发送失败 = -1,
        发送成功 = 0,
        已验证 = 1,
    }

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
        public int CodeType { get; set; }

        /// <summary>
        /// 发送方式
        /// </summary>
        public int SendType { get; set; }

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
        public int CodeStatus { get; set; }

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
