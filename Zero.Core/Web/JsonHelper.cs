using System.Web.Script.Serialization;

namespace Zero.Core.Web
{
    public class JsonHelper
    {
        /// <summary>
        /// 将对象转为JSON
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string Serialize<T>(T t)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(t);
        }

        /// <summary>
        /// 将JSON转为对象
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string s)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Deserialize<T>(s);
        }
    }
}
