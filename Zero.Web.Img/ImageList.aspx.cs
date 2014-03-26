using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Zero.Core.Web;
using Zero.Img.Bll;
using Zero.Img.Model;

namespace Zero.Web.Img
{
    public partial class ImageList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sbb = new StringBuilder();
            Paging paging = new Paging(30);
            List<AttachmentInfo> list = AttachmentCtrl.GetAttachmentList(paging, "");

            foreach (AttachmentInfo info in list)
            {
                sbb.Append(",{");
                sbb.AppendFormat("  src: '{0}'",info.Url);
                sbb.Append("}");
            }

            if (sbb.Length > 0)
            {
                sbb.Remove(0, 1);
            }

            sb.Append("var data = {");
            sb.AppendFormat("   count: {0}", paging.RecordCount);
            sb.AppendFormat("   ,size: {0}", paging.ShowPageCount);
            sb.AppendFormat("   ,page: {0}", paging.PageIndex);
            sb.AppendFormat("   ,list: [{0}]", sbb.ToString());
            sb.Append("}");
            Response.Write(sb.ToString());
            Response.End();
        }
    }
}