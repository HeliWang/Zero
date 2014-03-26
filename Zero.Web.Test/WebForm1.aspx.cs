using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Zero.Core.Web;

namespace Zero.Test
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.ccc.Text = StringHelper.CutStr("kk小小kk", 5);

            DateTime first = DateTime.Parse("2013-5-10 1:10");
            DateTime last = DateTime.Parse("2013-5-11 1:11");

            int d = (last - first).Days;

            if (first != last)
            {
                d = d + 1;
            }
        }
    }
}