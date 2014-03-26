using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Zero.Core.Web
{
    public enum ValidateType
    {
        Number,
        EnCode,
        Email,
        Phone,
        Mobile,
        PostCode,
        IdCard,
        IP,
        Undefine,
    }

    public class FormValidate
    {

        public static bool Validate(string text, ValidateType type)
        {
            switch (type)
            {
                case ValidateType.Number:
                    return IsNumber(text);

                case ValidateType.EnCode:
                    return IsEnCode(text);

                case ValidateType.Email:
                    return IsEmail(text);

                case ValidateType.Phone:
                    return IsPostCode(text);

                case ValidateType.Mobile:
                    return IsMobile(text);

                case ValidateType.PostCode:
                    return IsPostCode(text);

                case ValidateType.IdCard:
                    return IsIdCard(text);

                case ValidateType.IP:
                    return IsIP(text);
            }

            throw new Exception("Not find validate type");
        }

        /// <summary>
        /// 判断该值是否为数字
        /// </summary>
        public static bool IsNumber(string value)
        {
            string regexp = @"^[0-9]*$";

            return Verify(value, regexp);
        }

        /// <summary>
        /// 判断是否为QQ号，腾讯QQ号从10000开始
        /// </summary>
        public static bool IsQQ(string value)
        {
            string regexp = @"[1-9][0-9]{4,}";

            return Verify(value, regexp);
        }

        /// <summary>
        /// 判断是否为Email
        /// </summary>
        public static bool IsEmail(string value)
        {
            string regexp = @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

            return Verify(value, regexp);
        }

        /// <summary>
        /// 判断是否为中国的电话格式；正确格式为：XXXX-XXXXXXX；XXXX-XXXXXXXX；XXX-XXXXXXX；XXX-XXXXXXXX；XXXXXXX；XXXXXXXX。 
        /// </summary>
        public static bool IsChinaPhone(string value)
        {
            string regexp = @"^((d{3,4})|d{3,4}-)?d{7,8}$";

            return Verify(value, regexp);
        }

        /// <summary>
        /// 判断是否为行业的电话；正确格式：区号+座机号码+分机号码。
        /// </summary>
        public static bool IsCompanyPhone(string value)
        {
            string regexp = @"^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$";

            return Verify(value, regexp);
        }

        /// <summary>
        /// 判断是否为手机格式
        /// </summary>
        public static bool IsMobile(string value)
        {
            string regexp = @"^13[0-9]{1}[0-9]{8}|^15[9]{1}[0-9]{8}";

            return Verify(value, regexp);
        }

        /// <summary>
        /// 判断是否为邮政编码
        /// </summary>
        public static bool IsPostCode(string value)
        {
            string regexp = @"[1-9]\d{5}(?!\d)";

            return Verify(value, regexp);
        }

        /// <summary>
        /// 是否为中文
        /// </summary>
        public static bool IsCnCode(string value)
        {
            string regexp = @"[\u4e00-\u9fa5]";

            return Verify(value, regexp);
        }

        public static bool IsEnCode(string value)
        {
            string regexp = @"^[a-zA-Z]+$";

            return Verify(value, regexp);
        }

        /// <summary>
        /// 小写字母
        /// </summary>
        public static bool IsEnLowerCode(string value)
        {
            string regexp = @"^[a-z]+$";


            return Verify(value, regexp);
        }

        /// <summary>
        /// 大写字母
        /// </summary>
        public static bool IsEnUpper(string value)
        {
            string regexp = @"^[A-Z]+$";

            return Verify(value, regexp);
        }

        /// <summary>
        /// 判断是否为网址
        /// </summary>
        public static bool IsHttpUrl(string value)
        {
            string regexp = @"^http:\/\/([\w-]+(\.[\w-]+)+(\/[\w-.\/\?%&=\u4e00-\u9fa5]*)?)?$";

            return Verify(value, regexp);
        }

        /// <summary>
        /// 是否为帐号，(字母开头，允许5-16字节，允许字母数字下划线)；
        /// </summary>
        public static bool IsAccount(string value)
        {
            string regexp = @"^[a-zA-Z][a-zA-Z0-9_]{4,15}$";

            return Verify(value, regexp);
        }

        /// <summary>
        /// 包含15位和18位的身份验证
        /// </summary>
        public static bool IsIdCard(string value)
        {
            if (value.Length == 15)
            {
                return IsIdCard15(value);
            }

            if (value.Length == 18)
            {
                return IsIdCard18(value);
            }

            return false;
        }

        /// <summary>
        /// 15位的身份验证
        /// </summary>>
        public static bool IsIdCard15(string value)
        {
            string regexp = @"^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$";

            return Verify(value, regexp);
        }

        /// <summary>
        /// 18位的身份验证
        /// </summary>
        public static bool IsIdCard18(string value)
        {
            string regexp = @"^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{4}$";

            return Verify(value, regexp);
        }

        /// <summary>
        /// 检测是否有Sql危险字符
        /// </summary>
        public static bool IsSafeSqlString(string value)
        {
            string regexp = @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']";

            return Verify(value, regexp);
        }


        /// <summary>
        /// 域名验证，简单
        /// </summary>
        public static bool IsDomain(string value)
        {
            string regexp = @"^[a-zA-Z0-9]+([a-zA-Z0-9\-\.]+)?\.(com|org|net|cn|com.cn|edu.cn|grv.cn|)$";

            return Verify(value, regexp);
        }


        /// <summary>
        /// 网页色彩验证值,#FF0000
        /// </summary>
        public static bool IsHtmlColor(string value)
        {
            string regexp = @"^#?([a-f]|[A-F]|[0-9]){3}(([a-f]|[A-F]|[0-9]){3})?$";

            return Verify(value, regexp);
        }

        /// <summary>
        /// 是否IP地址
        /// </summary>
        public static bool IsIP(string value)
        {
            //if (value.Length < 7 || value.Length > 15) return false;

            string regexp = @"^\d{1,3}[\.]\d{1,3}[\.]\d{1,3}[\.]\d{1,3}$";

            return Verify(value, regexp);
        }

        /// <summary>
        /// 自定义验证
        /// </summary>
        public static bool Verify(string value, string rule)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            if (Regex.IsMatch(value, rule))
            {
                return true;
            }

            return false;
        }
    }
}