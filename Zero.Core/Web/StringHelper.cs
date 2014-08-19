using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Core.Web
{
    public class StringHelper
    {
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
        /// 从左边0开始截取指定长度的字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string CutStr(string str, int length)
        {
            if (str.Length < length) length = str.Length;
            return str.Substring(0, length);
        }

        /// <summary>
        /// 从左边0开始截取指定长度的字符串,并补上自定义的字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string CutStr(string str, int length, string str2)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            if (str.Length <= length)
            {
                str2 = "";
                length = str.Length;
            }
            return str.Substring(0, length) + str2;
        }

        /// <summary>
        /// 从指定位置开始截取指定长度的字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string CutStr(string str, int startIndex, int length)
        {
            if (str.Length < length - startIndex) length = str.Length - startIndex;
            return str.Substring(startIndex, length);
        }

        /// <summary>
        /// 截取字符串(如果substring把中文当成2个字节的时候，可以使用此方法)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="lenght"></param>
        /// <returns></returns>
        public static string CutStr2(string str, int length)
        {
            int newLength = 0;
            int index = 0;
            foreach (char c in str)
            {
                index++;
                if (index > length) break;
                newLength += (int)c > 128 ? 2 : 1;
            }
            return str.Substring(0, newLength);
           
        }
    }
}
