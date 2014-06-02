using System;
using System.Collections;
using System.Collections.Generic;

namespace Zero.Domain.Users
{
    public class AdminInfo
    {
        public AdminInfo()
        {
            DateTime dt = DateTime.Now;
            CreateTime = dt;
            UpdateTime = dt;
        }

        /// <summary>
        /// 帐户编号
        /// </summary>
        public int AdminId { set; get; }

        /// <summary>
        /// 帐号名称 - 8个字符
        /// </summary>
        public string AdminName { get; set; }

        /// <summary>
        /// 密钥 - 随机3~5个字符
        /// </summary>
        public string Keyt { get; set; }

        /// <summary>
        /// 密码 - (key+用户密码)加密 - 100个字符
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
