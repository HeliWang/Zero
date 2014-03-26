using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zero.Core.Web
{
    public enum BaseStatus
    {
        回收站 = -100,

        未通过 = -1,

        待审核 = 0,

        已通过 = 1,

        全部 = 99999,
    }

    public class BaseStatusCtrl
    {
        public static string GetStatus(int status)
        {
            switch (status)
            {
                case -100:
                    return "回收站";

                case -1:
                    return "未通过";

                case 0:
                    return "待审核";

                case 1:
                    return "已通过";

                default:
                    return "未知";
            }
        }

        public static List<string> GetStatusHtml(int selectValue)
        {
            List<string> list = new List<string>();
            StringBuilder searchStatus = new StringBuilder();
            StringBuilder auditingStatus = new StringBuilder();
            StringBuilder selectStatus = new StringBuilder();

            Array arr = Enum.GetValues(typeof(BaseStatus));
            Array.Sort(arr);
            Array.Reverse(arr);

            selectStatus.Append("<select id=\"searchStatus\" name=\"searchStatus\">\n");

            foreach (int value in arr)
            {
                string name = Enum.GetName(typeof(BaseStatus), value);

                if (selectValue == value)
                {
                    searchStatus.AppendFormat(" | <a href=\"?searchStatus={0}\" style=\"color:red;\">{1}</a>\n", value, name);
                    selectStatus.AppendFormat("<option value=\"{0}\" selected>{1}</option>\n", value, name);
                }
                else
                {
                    searchStatus.AppendFormat(" | <a href=\"?searchStatus={0}\">{1}</a>\n", value, name);
                    selectStatus.AppendFormat("<option value=\"{0}\">{1}</option>\n", value, name);
                }

                if (value != 99999)
                {
                    if (value == 0)
                    {
                        auditingStatus.AppendFormat("<input type=\"radio\" name=\"targetStatus\" id=\"targetStatus_{1}\" value=\"{0}\" checked /><label for=\"targetStatus_{1}\">{1}</label> ", value, name);
                    }
                    else
                    {
                        auditingStatus.AppendFormat("<input type=\"radio\" name=\"targetStatus\" id=\"targetStatus_{1}\" value=\"{0}\" /><label for=\"targetStatus_{1}\">{1}</label> ", value, name);
                    }
                }
            }

            selectStatus.Append("</select>");

            searchStatus.Remove(0, 3);
            list.Add(searchStatus.ToString());
            list.Add(selectStatus.ToString());
            list.Add(auditingStatus.ToString());

            return list;
        }

        /// <summary>
        /// 获取select类型的下拉状态控件
        /// </summary>
        public static string GetSelectStatusHtml(int selectValue)
        {
            StringBuilder sb = new StringBuilder();
            Array arr = Enum.GetValues(typeof(BaseStatus));
            Array.Sort(arr);
            Array.Reverse(arr);
            sb.Append("<select id=\"status\" name=\"status\">\n");

            foreach (int value in arr)
            {
                string name = Enum.GetName(typeof(BaseStatus), value);

                if (selectValue == value)
                {
                    sb.AppendFormat("<option value=\"{0}\" selected>{1}</option>\n", value, name);
                }
                else
                {
                    sb.AppendFormat("<option value=\"{0}\">{1}</option>\n", value, name);
                }
            }

            sb.Append("</select>");
            return sb.ToString();
        }


        public static Dictionary<int, string> GetStatusList()
        {
            Dictionary<int, string> sb = new Dictionary<int, string>();
            Array arr = Enum.GetValues(typeof(BaseStatus));
            Array.Sort(arr);
            Array.Reverse(arr);
            foreach (int value in arr)
            {
                if (value != 99999)
                {
                    string name = Enum.GetName(typeof(BaseStatus), value);
                    sb.Add(value, name);
                }
            }
            return sb;
        }
    }
}
