using System;
using System.Collections;
using System.Collections.Generic;

namespace Zero.Domain.Users
{
    /// <summary>
    /// 总后台管理员-登入
    /// </summary>
    class AdminLoginInfo
    {
        /// <summary>
        /// 上一次登入Ip - 100个字符
        /// </summary>
        public string LastLoginIp { get; set; }

        /// <summary>
        /// 上一次登入时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 当前登入Ip - 100个字符
        /// </summary>
        public string LoginIp { get; set; }

        /// <summary>
        /// 当前登入时间
        /// </summary>
        public DateTime LoginTime { get; set; }

        /// <summary>
        /// 登入总数
        /// </summary>
        public int LoginCount { get; set; }
    }
}
