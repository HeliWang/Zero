using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Zero.Web.Test
{
    public partial class OrderExcel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }

        protected void sub_Click(object sender, EventArgs e)
        {
            string orderids = this.OrderIDs.Text;
            StringBuilder sb=new StringBuilder();
            foreach(string orderid in orderids.Split(" ".ToCharArray()))
            {
                sb.AppendFormat(",'{0}'",orderid);
            }
            Response.Write(sb.ToString());
        }

        protected void sub2_Click(object sender, EventArgs e)
        {
            string orderids = this.OrderIDs.Text;
            StringBuilder sb = new StringBuilder();
            foreach (string orderid in orderids.Split(" ".ToCharArray()))
            {
                sb.AppendFormat(",{0}", orderid);
            }
            Response.Write(sb.ToString());
        }
    }
}