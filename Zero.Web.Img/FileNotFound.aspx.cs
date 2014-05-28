using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zero.Core.Web;
using System.Text.RegularExpressions;

namespace Zero.Web.Img
{
    public partial class FileNotFound : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpRequest request = Request;

            //Response.ContentType = "image/jpeg";
            //http://img.zero.com/tb/ad/c1/2012/12/20121204195044_150x150.jpg
            string rawurl = RequestHelper.Query(0);
            string thumbnail = @"(.*)\/tb\/([a-zA-Z0-9_\-\/]+)\/([a-zA-Z0-9]+)_(\d+)x(\d+)_(\d+)\.(jpg|gif|png|bmp)$";

            MatchCollection matches = Regex.Matches(rawurl, thumbnail);
            if (matches.Count > 0)
            {
                string savePath = rawurl.Substring(rawurl.IndexOf("tb"));
                int width = Utils.StrToInt(matches[0].Groups[4].Value);
                int height = Utils.StrToInt(matches[0].Groups[5].Value);
                int type = Utils.StrToInt(matches[0].Groups[6].Value);

                if (type != 0) return;

                //if ((width == 150 && height == 150) || (width == 100 && height == 100))
                //{
                    string filePath = savePath.Replace("tb/", "").Replace(string.Format("_{0}x{1}_{2}", width, height, type), "");
                    ImageHelper.MakeThumbnail(Utils.GetMapPath(filePath), Utils.GetMapPath(savePath), width, height, "HW");
                    switch (matches[0].Groups[7].Value)
                    {
                        case "jpeg":
                        case "jpg":
                            Response.ContentType = "image/jpeg";
                            break;
                        case "gif":
                            Response.ContentType = "image/gif";
                            break;
                        case "png":
                            Response.ContentType = "image/png";
                            break;
                        case "bmp":
                            Response.ContentType = "image/bmp";
                            break;
                    }
                    Response.WriteFile(savePath);
                    Response.End();
                //}
            }
            else
            {
            }
        }
    }
}