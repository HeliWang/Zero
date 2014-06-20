using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zero.Test
{
    public partial class PayPalTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Zero.Payment.PayPayApi api = new Payment.PayPayApi("");
            //api.SetExpressCheckout();

            //string result = HttpUtility.UrlDecode(api.Call(), System.Text.Encoding.Default);

            //string host = "www.sandbox.paypal.com";
            //string ECURL = "https://" + host + "/cgi-bin/webscr?cmd=_express-checkout" + "&token=EC-9U9920034P2316136";

            //Response.Redirect(ECURL);
        }
    }
}