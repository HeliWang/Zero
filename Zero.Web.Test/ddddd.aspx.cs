using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zero.Test
{
    public partial class ddddd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //survivalDays = (info.LastLoginTime - info.RegTime).Days;

            Response.Write((DateTime.Parse("2013-7-17 19:01:59") - DateTime.Parse("2011-5-31 15:04:42")).Days);


            //string[] area = { "a", "b", "c" };

            //string[] list = { "apo","pll","boc","dpc"};

            //string sb = "";

            //foreach (string info in list)
            //{
            //    //foreach (string a in area)
            //    //{
            //    //    if (info.Contains(a))
            //    //    {
            //    //        sb += string.Format("{0}<br/>", info);
            //    //    }
            //    //}

            //    string[] b=area.Where(a => info.Contains(a)).ToArray();

            //    if (b.Length > 0)
            //    {
            //        sb += string.Format("{0}<br/>", info);
            //    }
            //}
            //Response.Write(sb);
        }
    }
}