using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero.Domain.Sys;
using Zero.Service.Sys;
using Zero.Core.Web;

namespace Zero.Mvc.Manage.Controllers.Sys
{
    public class CodeController : Controller
    {
        ICodeService _codeService;

        public CodeController(ICodeService codeService)
        {
            _codeService = codeService;
        }

        public ActionResult CodeIndex()
        {
            return View();
        }

        public ActionResult CodeList()
        {
            int pageIndex = RequestHelper.QueryInt("page");
            int pageSize = RequestHelper.QueryInt("rows");

            pageIndex = pageIndex <= 0 ? 0 : pageIndex - 1;
            if (pageSize <= 0) pageSize = 10;

            IPage<Code> codePage = _codeService.GetList(pageIndex, pageSize);

            return Json(codePage, JsonRequestBehavior.AllowGet);
        }
    }
}
