using System;
using System.Collections;
using System.Collections.Generic;

namespace Zero.Domain.Users
{
    public class User:BaseEntity
    {
        public int id { get { return UserId; } }

        public int UserId { get; set; }

        /// <summary>
        /// 会员帐号
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 临时账户
        /// </summary>
        public string GuestId { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string Nick { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 性别（男|女|人妖)
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// 腾讯QQ
        /// </summary>
        public string QQ { get; set; }

        /// <summary>
        /// 电话（86-0595-86569092)
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 县/区
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 邮编（根据身份地址，自动获取右边）
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// 信用等级（是根据score生成的），信用等级：会员在本网站的信用度；
        /// 分为20个级别，级别如：level = 1 时，表示一心；level = 2 时，表示二心
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 信用总分数
        /// </summary>
        public int Score { get; set; }

        public int Status { get; set; }

        public DateTime? Birthday { get; set; }

        public DateTime? RegTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public DateTime? LastVisit { get; set; }
    }
}
