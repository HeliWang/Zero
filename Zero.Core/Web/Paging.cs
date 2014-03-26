using System.Collections.Generic;
using System.Text;

namespace Zero.Core.Web
{
    public class Paging
    {
        public string ID { get; set; }

        public long _pageIndex;

        public long PageIndex
        {
            get
            {
                _pageIndex = RequestHelper.QueryInt("page");
                return _pageIndex == 0 ? 1 : _pageIndex;
            }
            set { _pageIndex = value; }
        }

        public long PageSize { get; set; }

        public long RecordCount { get; set; }

        public long ShowPageCount = 7;

        public string UrlModel { get; set; }

        public int ShowModel { get; set; }

        public Paging()
        {
        }

        public Paging(int pageSize)
        {
            this.PageSize = pageSize > 0 ? pageSize : 10;
        }
        
        public string GetHtml()
        {
            if (string.IsNullOrEmpty(this.ID))
            {
                this.ID = "paging";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<div id=\"{0}\" class=\"z-paging\"></div>", this.ID);
            sb.Append("<script type=\"text/javascript\">");
            sb.Append("$(function () {");
            sb.Append("    $.zero.paging({");
            sb.AppendFormat("        name: \"{0}\",", this.ID);
            sb.AppendFormat("        renderTo: \"#{0}\",", this.ID);
            sb.AppendFormat("        pageIndex: {0},", this.PageIndex);
            sb.AppendFormat("        pageSize: {0},", this.PageSize);
            sb.AppendFormat("        recordCount: {0},", this.RecordCount);
            sb.AppendFormat("        showPageCount: {0},", this.ShowPageCount);
            if (!string.IsNullOrEmpty(this.UrlModel))
            {
                sb.AppendFormat("        urlMode: \"{0}\",", this.UrlModel);
            }
            switch (ShowModel)
            {
                case 1:
                    sb.Append("        button:{visible: [false, true ]} ,");
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
            return sb.ToString();
        }
    }
}
