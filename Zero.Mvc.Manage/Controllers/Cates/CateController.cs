using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

using Zero.Core.Web;
using Zero.Core.Pattern;
using Zero.Domain.Cates;
using Zero.Service.Cates;

namespace Zero.Mvc.Manage.Controllers.Cates
{
    public class CateController : BaseController
    {
        CateService _cateService;

        public CateController()
        {
            _cateService = Singleton<CateService>.GetInstance();
        }

        public ActionResult CateIndex()
        {
            return View();
        }

        public ActionResult CateListJson()
        {
            Func<List<Cate>, dynamic> getJson = null;
            getJson = (List) =>
            {
                return List.Select(c => new { id = c.CateId, text = c.CateName
                    ,ChildCount=c.ChildCount,CreateTiem=c.CreateTime,UpdateTime=c.UpdateTime
                    ,children = c.children == null ? null : getJson(c.children) });
            };

            List<Cate> cateList = _cateService.GetList(0, 0);
            cateList = _cateService.ConvertCateListToTree(cateList);
            return Json(getJson(cateList), JsonRequestBehavior.AllowGet);
        }

        public ActionResult CateAdd(int? pid)
        {
            if (pid != null && pid > 0)
            {
                Cate cate = _cateService.GetById(pid.Value);
                ViewBag.Pid = cate != null ? pid.ToString() : "";
            }
            return View();
        }

        [HttpPost]
        public ActionResult CateAdd(Cate cate)
        {
            ResultInfo resultInfo = new ResultInfo(1, "验证不通过");

            if (ModelState.IsValid)
            {
                resultInfo = _cateService.Add(cate);
            }

            return Json(resultInfo);
        }

        public ActionResult CateEdit()
        {
            int cateId = RequestHelper.QueryInt("cateId");
            Cate cate=_cateService.GetById(cateId);
            return View(cate);
        }

        public void GetForm(Cate cate, StringBuilder ms)
        {
        }

        [HttpPost]
        public ActionResult CateEditPost()
        {
            ResultInfo resultInfo;
            StringBuilder errorMsg = new StringBuilder();
            int cateId = RequestHelper.QueryInt("cateId");
            int oldPid = 0;

            Cate cate = null;

            if (cateId > 0)
            {
                cate = _cateService.GetById(cateId);
            }

            if (cateId == 0 || cate == null)
            {
                resultInfo = new ResultInfo((int)ResultStatus.Error, "未找到该类别信息,请选择其他或刷新");
                return Json(resultInfo);
            }

            oldPid = cate.Pid;

            GetForm(cate, errorMsg);

            if (errorMsg.Length > 0)
            {
                resultInfo = new ResultInfo((int)ResultStatus.Error, errorMsg.ToString());
                return Json(resultInfo);
            }

            resultInfo = _cateService.Update(cate, oldPid);

            return Json(resultInfo);
        }

        [HttpPost]
        public ActionResult CateOperate()
        {
            ResultInfo resultInfo;

            string action = RequestHelper.All("action").ToLower();
            string ids = RequestHelper.All("ids").ToLower();

            if (action == "")
            {
                resultInfo = new ResultInfo((int)ResultStatus.Error, "未选择任何操作！");
                return Json(resultInfo);
            }

            if (ids == "")
            {
                resultInfo = new ResultInfo((int)ResultStatus.Error, "未选择任何操作项！");
                return Json(resultInfo);
            }

            switch (action)
            {
                case "delete":
                    _cateService.Delete(Utils.StrToInt(ids));
                    break;
            }

            return Json(new ResultInfo("操作成功"));
        }
    }
}
