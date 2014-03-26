using System.Text;
using System.Web.UI;

namespace Zero.Controls
{
    public class Paging : Control
    {
        public long PageIndex { get; set; }

        public long PageSize { get; set; }

        public long RecordCount { get; set; }

        public long ShowPageCount { get; set; }

        public string UrlModel { get; set; }

        public int ShowModel { get; set; }

        /// <summary>
        /// 重写 System.Web.UI.Control.Render 方法
        /// </summary>
        protected override void Render(HtmlTextWriter output)
        {   
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<div id=\"{0}\" class=\"z-paging\"></div>",this.ID);
            sb.Append("<script type=\"text/javascript\">");
            sb.Append("$(function () {");
            sb.Append("    $.zero.paging({");
            sb.AppendFormat("        name: \"{0}\",",this.ID);
            sb.AppendFormat("        renderTo: \"#{0}\",",this.ID);
            sb.AppendFormat("        pageIndex: {0},",this.PageIndex);
            sb.AppendFormat("        pageSize: {0},",this.PageSize);
            sb.AppendFormat("        recordCount: {0},",this.RecordCount);
            sb.AppendFormat("        showPageCount: {0},",this.ShowPageCount);
            sb.AppendFormat("        urlMode: \"{0}\",",this.UrlModel);
            switch (ShowModel)
            { 
                case 1:
                sb.Append("        button:{visible: [false, true } ,");
                sb.Append("        goto: {visible: false },");
                sb.Append("        pageInfo:{ visible: true } ,");
                break;
                case 2:
                sb.Append("        button:{visible: [false, true]} ,");
                sb.Append("        goto: {visible: false]},");
                sb.Append("        pageInfo:{ visible: false]} ,");
                break;
                default:
                sb.Append("        button:{visible: [false, true]} ");
                break;
            }
            sb.Append("    }); ");          
            sb.Append("})");
            sb.Append("</script>");
            output.Write(sb.ToString());
        }
    }
}
