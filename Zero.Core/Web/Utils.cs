using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Zero.Core.Web
{
    public class Utils
    {
        /// <summary>
        /// 获取字母指定的随机数
        /// </summary>
        /// <param name="lenght">长度</param>
        public static string GetRandomEn(int lenght)
        {
            StringBuilder sb = new StringBuilder();
            Random rand = new Random();

            string code = "abcdefghijklmnopqrstuvwxyz";
            char[] codes = code.ToCharArray();

            for (int i = 0; i < lenght; i++)
            {
                sb.Append(codes[rand.Next(0, code.Length)].ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获取数字指定的随机数
        /// </summary>
        /// <param name="lenght">长度</param>
        public static string GetRandomNum(int lenght)
        {
            StringBuilder sb = new StringBuilder();
            Random rand = new Random();

            string code = "0123456789";
            char[] codes = code.ToCharArray();

            for (int i = 0; i < lenght; i++)
            {
                sb.Append(codes[rand.Next(0, code.Length)].ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// 字符串专浮点类型
        /// </summary>
        public static bool StrToFloat(string text)
        {
            bool result = false;
            bool.TryParse(text, out result);
            return result;
        }

        /// <summary>
        /// 字符串转小数类型
        /// </summary>
        public static decimal StrToDecimal(string text)
        {
            decimal result = 0;
            decimal.TryParse(text, out result);
            return result;
        }

        /// <summary>
        /// 字符串转整数类型
        /// </summary>
        public static int StrToInt(string text)
        {
            int result = 0;
            int.TryParse(text, out result);
            return result;
        }

        /// <summary>
        /// 获取绝对路径
        /// </summary>
        /// <param name="path">相对路径</param>
        /// <returns>绝对路径</returns>
        public static string GetMapPath(string path)
        {
            return HttpContext.Current.Server.MapPath(path);
        }

        /// <summary>
        /// 抓取网页
        /// </summary>
        /// <param name="sourcePath">源地址</param>
        /// <param name="savePath">保存位置</param>
        public static void CreatePage(string sourcePath, string savePath)
        {
            string content = RemoteHelper.GetWebResult(sourcePath);
            FileHelper.SaveHtml(savePath, content);
        }

        /// <summary>
        /// 验证是否为整数数组，一般用于判断ID集合是否都为整数
        /// </summary>
        /// <param name="keys">待判断的字符串数组</param>
        /// <returns>返回true或者falsh</returns>
        public static bool IsNumberArray(string[] keys)
        {
            if (keys == null || keys.Length <= 0)
            {
                return false;
            }
            foreach (string key in keys)
            {
                if (!FormValidate.IsNumber(key))
                {
                    return false;
                }
            }
            return true;
        }

        public static string CreateCheckBox(string control, int id, string name)
        {
            return string.Format("<input type=\"checkbox\" id=\"{0}_{1}\" name=\"{0}\" value=\"{1}\"/><label for=\"{0}_{1}\">{2}</label>\n", control, id, name);
        }

        public static string CreateCheckBox(string control, int id, string name, bool check)
        {
            return string.Format("<input type=\"checkbox\" id=\"{0}_{1}\" name=\"{0}\" value=\"{1}\" checked/><label for=\"{0}_{1}\">{2}</label>\n", control, id, name);
        }

        /// <summary>
        /// 过滤注入攻击 [sql,html]
        /// </summary>
        /// <returns></returns>
        public static string Filter(string value)
        {
            return HtmlFilter(SqlFilter(value));
        }

        /// 过滤SQL字符。
        /// </summary>
        /// <param name="str">要过滤SQL字符的字符串。</param>
        /// <returns>已过滤掉SQL字符的字符串。</returns>
        public static string HtmlFilter(string value)
        {
            if (string.IsNullOrEmpty(value)) return String.Empty;

            return HttpUtility.HtmlEncode(value);
        }

        /// 过滤SQL字符。
        /// </summary>
        /// <param name="str">要过滤SQL字符的字符串。</param>
        /// <returns>已过滤掉SQL字符的字符串。</returns>
        public static string SqlFilter(string value)
        {
            if (string.IsNullOrEmpty(value)) return String.Empty;

            value = value.Replace("'", "‘");
            value = value.Replace(";", "；");
            value = value.Replace(",", "，");
            value = value.Replace("?", "？");
            value = value.Replace("<", "＜");
            value = value.Replace(">", "＞");
            value = value.Replace("(", "（");
            value = value.Replace(")", "）");
            value = value.Replace("@", "＠");
            value = value.Replace("=", "＝");
            value = value.Replace("+", "＋");
            value = value.Replace("*", "＊");
            value = value.Replace("&", "＆");
            value = value.Replace("#", "＃");
            value = value.Replace("%", "％");
            value = value.Replace("$", "￥");

            return value;
        }
    }
}
