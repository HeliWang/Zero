using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero.Domain.Tool;
using Zero.Core.Web;
using System.Text.RegularExpressions;

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

            string thumbnail = @"*\.(jpg|gif|png|bmp)$";

            //string href = @"href=\["|']http://www.ecmoban.com/content/themes/ecmoban2014/bootstrap/css/bootstrap.min.css\"";

            MatchCollection matches = Regex.Matches(content, thumbnail);

            foreach (var matche in matches)
            {
                var msg = matche;
            }


            //FileHelper.SaveHtml(site.SaveUrl, content);


            return Json(resultInfo);
        }

    }
}
