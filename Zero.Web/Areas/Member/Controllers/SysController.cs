using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Zero.Domain.Sys;
using Zero.Core.Web;
using Zero.Service.Sys;


namespace Zero.Web.Areas.Member.Controllers
{
    public class SysController : Controller
    {
        public ICodeService _codeServices;

        public SysController(ICodeService codeServices)
        {
            _codeServices = codeServices;
        }

        public ActionResult SendCode()
        {
            var codeType = RequestHelper.QueryInt("codeType");
            var sendType = RequestHelper.QueryInt("sendType");
            var sendNo = RequestHelper.Query("sendNo");

            Code code = new Code();
            code.UserId = 1;
            code.Operater = "daitoudage";
            code.CodeType = codeType;
            code.SendType = sendType;
            code.SendNo = sendNo;

            ResultInfo resultInfo = _codeServices.Send(code);

            return Json(resultInfo, JsonRequestBehavior.AllowGet);
        }

    }
}
