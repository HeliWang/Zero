using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Zero.Core.Web
{
    public class RequestHelper
    {
        public static string Query(string name)
        {
            if (HttpContext.Current.Request.QueryString[name] != null)
            {
                return HttpContext.Current.Request.QueryString[name].Trim();
            }
            return string.Empty;
        }

        public static string Query(int index)
        {
            if (HttpContext.Current.Request.QueryString.Count > index)
            {
                return HttpContext.Current.Request.QueryString[index].Trim();
            }
            return string.Empty;
        }

        public static int QueryInt(string name)
        {
            string value = Query(name);
            return Utils.StrToInt(value);
        }

        public static string Form(string name)
        {
            if (HttpContext.Current.Request.Form[name] != null)
            {
                return HttpContext.Current.Request.Form[name].Trim();
            }
            return string.Empty;
        }

        public static int FormInt(string name)
        {
            string value = Form(name);
            return Utils.StrToInt(value);
        }

        public static string All(string name)
        {
            if (!string.IsNullOrEmpty(Query(name)))
            {
                return Query(name);
            }
            else
            {
                return Form(name);
            }
        }

        public static Int32 AllInt(string name)
        {
            if (!string.IsNullOrEmpty(Query(name)))
            {
                return QueryInt(name);
            }
            else
            {
                return FormInt(name);
            }
        }

        public static bool IsPost()
        {
            return HttpContext.Current.Request.HttpMethod == "POST" ? true : false;
        }

        public static bool IsGet()
        {
            return HttpContext.Current.Request.HttpMethod == "GET" ? true : false;
        }


        /// <summary>
        /// 获得当前页面客户端的IP
        /// </summary>
        public static string GetIP()
        {
            string result = String.Empty;

            result = HttpContext.Current.Request.Headers["Cdn-Src-Ip"];
            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }

            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }

            if (null == result || result == String.Empty || !FormValidate.IsIP(result))
            {
                result = "0.0.0.0";
            }

            return result;
        }


        ///// <summary>
        ///// 验证字段是否为空
        ///// </summary>
        //private T GetValue(ItemType type)
        //{
        //    //string s = RetriveValue(_name, type);

        //    //if (string.IsNullOrEmpty(s))
        //    //{
        //    //    if (_haveDefaultValue == false)
        //    //    {
        //    //        _errorMsg = 1;
        //    //        return default(T);
        //    //    }

        //    //    return _defaultValue;
        //    //}

        //    //return ObjectToT(s.Trim());
        //}
    }
}
