using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zero.Core.Web;

namespace Zero.Test
{
    public partial class JsonGet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RequestHelper.IsPost())
            {
                string k = this.kk.Value;

                if (!k.Contains("Data"))
                {
                    ErrorInfo errorInfo = JsonHelper.Deserialize<ErrorInfo>(k);
                }
                else
                {
                    ResponseInfo responseInfo = JsonHelper.Deserialize<ResponseInfo>(k);
                }
            }
        }
    }

    #region 返回的对象

    public class ErrorInfo
    {
        public string Code { get; set; }
        public string Msg { get; set; }
    }

    public class ResponseInfo
    {
        public string Code { get; set; }
        public string Msg { get; set; }
        public DataInfo Data { get; set; }
    }

    public class DataInfo
    {
        public string Pro_Total { get; set; }
        public List<ProductInfo> ProductList { get; set; }
    }

    public class ProductInfo
    {
        public string Pro_Title { get; set; }
        public string Pro_No { get; set; }
        public string Pro_Price { get; set; }
        public string Pro_Weight { get; set; }
        public List<ProductKucInfo> ProductKucList { get; set; }
    }

    public class ProductKucInfo
    {
        public string Pro_Color { get; set; }
        public string Pro_Sizes { get; set; }
        public string Skunk { get; set; }
        public string Pro_Count { get; set; }
    }

    #endregion
}