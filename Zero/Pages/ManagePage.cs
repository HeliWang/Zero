using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Pages
{
    public class ManagePage : System.Web.UI.Page
    {
        public StringBuilder ErrorMsg = new StringBuilder();

        public string GetClientScript(string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type=\"text/javascript\">");
            sb.Append("$(function () {");
            sb.AppendFormat("alert('{0}')", msg);
            sb.Append(" });");
            sb.Append("</script>");
            return sb.ToString();
        }

        public string GetClientScriptByOK(string msg, string url)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type=\"text/javascript\">");
            sb.Append("$(function () {");
            sb.AppendFormat("alert('{0}');", msg);
            sb.AppendFormat("document.location='{0}';", url);
            sb.Append(" });");
            sb.Append("</script>");
            return sb.ToString();
        }

        public void ShowError(string msg)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "sc1", GetClientScript(msg));
        }

        public void ShowOK(string msg, string url)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "sc1", GetClientScriptByOK(msg, url));
        }
    }
}
