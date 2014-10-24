using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero.Domain.Tool;
using Zero.Core.Web;
using System.Text.RegularExpressions;
using System.Net;

namespace Zero.Mvc.Manage.Controllers.Tool
{
    public class CatchController : Controller
    {
        public ActionResult CatchIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CatchAdd(Site site)
        {
            ResultInfo resultInfo = new ResultInfo(1, "验证不通过");

            site.SaveUrl =string.Format("/Template/{0}",site.Title);

            string content = RemoteHelper.GetWebResult(site.SourceUrl);

            //string content = @"dsfgsdfg:url(../images/category-trangle-bg.png);";
            //string thumbnail = @"(.*)\/tb\/([a-zA-Z0-9_\-\/]+)\/([a-zA-Z0-9]+)_(\d+)x(\d+)_(\d+)\.(jpg|gif|png|bmp)$";

            string regu = @"url\((\.{0,2})\/images\/.{0,}\)";

            MatchCollection matches = Regex.Matches(content, regu);

            foreach (var matche in matches)
            {
                var imgUrl = matche.ToString();
                imgUrl = imgUrl.Replace("url(..", "").Replace(")", "");
                var saveImgUrl = site.SaveUrl + imgUrl;
                imgUrl = string.Format("http://www.ecmoban.com/content/themes/ecmoban2014{0}", imgUrl);

                WebClient client = new WebClient();

                client.DownloadFile(imgUrl, FileHelper.GetMapPath(saveImgUrl));
            }

            //FileHelper.SaveHtml(site.SaveUrl, content);

            return Json(resultInfo);
        }

    }
}
