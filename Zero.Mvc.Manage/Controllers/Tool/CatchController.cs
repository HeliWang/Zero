using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero.Domain.Tool;
using Zero.Core.Web;

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
            //FileHelper.SaveHtml(site.SaveUrl, content);


            return Json(resultInfo);
        }

    }
}
