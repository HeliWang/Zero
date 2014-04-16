using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Core.Web
{
    public class EnumHelper
    {
        /// <summary>
        /// 枚举转化字典集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Dictionary<int, string> GetList<T>()
        {
            Dictionary<int, string> sb = new Dictionary<int, string>();
            Array arr = Enum.GetValues(typeof(T));
            Array.Sort(arr);
            Array.Reverse(arr);
            foreach (int value in arr)
            {
                string name = Enum.GetName(typeof(T), value);
                sb.Add(value, name);
            }
            return sb;
        }
    }
}
