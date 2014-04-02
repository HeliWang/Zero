using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;

namespace Zero.Service
{
    public class UrlFactory
    {
        public const string PhotoSiteUrl = "http://img.zero.com/";
        //public const string PhotoSiteUrl = "http://localhost:2330/";


        /// <summary>
        /// 获取各种模式的图片地址
        /// </summary>
        /// <param name="path">图片弟子</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns></returns>
        public static string GetPhotoUrl(string path, int width, int height)
        {
            return GetPhotoUrl(path, width, height, 0);
        }

        /// <summary>
        /// 获取各种模式的图片地址
        /// </summary>
        /// <param name="path">图片弟子</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="model">模式（0=按比例进行缩放|1=按比例缩放再按1/2进行裁剪|）</param>
        /// <returns></returns>
        public static string GetPhotoUrl(string path, int width, int height, int model)
        {
            string size = string.Format("_{0}x{1}_{2}", width, height, model);
            string name = path.Substring(path.LastIndexOf("/") + 1);
            string format = name.Substring(name.IndexOf("."));
            path = path.Substring(0, path.Length - name.Length);
            name = name.Substring(0, name.Length - format.Length);
            //return path + Zero.Core.Security.Encrypt.EncodeDES(name + size, "aaaaaaaaaa") + format;
            return PhotoSiteUrl + "tb/" + path + HttpUtility.HtmlEncode(name + size) + format;
        }
    }
}
