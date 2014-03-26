using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

using Zero.Core.Web;

namespace Zero.Web.Img
{
    public partial class FileNotFound : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //http://img.zero.com/tb/ad/c1/2012/12/20121204195044_150x150.jpg
            string rawurl = RequestHelper.Query(0);
            string thumbnail = @"(.*)\/tb\/([a-zA-Z0-9_\-\/]+)\/([a-zA-Z0-9]+)_(\d+)x(\d+)_(\d+)\.(jpg|gif|png|bmp)$";

            MatchCollection matches = Regex.Matches(rawurl, thumbnail);
            if (matches.Count > 0)
            {
                //生成缩略图
                string savePath = rawurl.Substring(rawurl.IndexOf("tb"));
                int width = Utils.StrToInt(matches[0].Groups[4].Value);
                int height = Utils.StrToInt(matches[0].Groups[5].Value);
                string type = matches[0].Groups[6].Value;
                string filePath = savePath.Replace("tb/", "").Replace(string.Format("_{0}x{1}_{2}", width, height, type), "");
                ImageHelper.MakeThumbnail(Utils.GetMapPath(filePath), Utils.GetMapPath(savePath), width, height, type);
                Response.ContentType = ImageHelper.GetContentType(matches[0].Groups[7].Value);
                Response.WriteFile(savePath);
                Response.End();

                //未判断filePath是否存在图片
            }
            else
            {
                //显示无图
                Response.WriteFile("tb/noFound.jpg");
                Response.ContentType="image/jpeg";
                Response.End();

                //未按尺寸生成缩略图
            }

            //获取请求路径
            //抓取本地源图片
            //按要求生成图片，进行剪裁，压缩，并保存，否则生成无图
            //输出新图片地址
        }
    }
}