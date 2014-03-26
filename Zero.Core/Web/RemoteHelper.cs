using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace Zero.Core.Web
{
    public class RemoteHelper
    {
        /// <summary>
        /// 通过WebUrl返回数据
        /// </summary>
        public static string GetWebResult(string url)
        {
            return GetWebResult(url, 5000, "Get", "utf-8");
        }

        /// <summary>
        /// 通过WebUrl返回数据
        /// </summary>
        public static string GetWebResult(string url, int timeout, string menthod, string encoding)
        {
            string result = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = timeout;
            request.Method = menthod;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
            result = reader.ReadToEnd();
            reader.Close();
            response.Close();

            return result;
        }

        /// <summary>
        /// 通过Socket返回数据
        /// </summary>
        public static string SocketResult()
        {
            return string.Empty;
        }
    }
}
