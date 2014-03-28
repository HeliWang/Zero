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

        public ActionResult CateList()
        {
            Func<List<Cate>, dynamic> getJson = null;
            getJson = (List) =>
            {
                return List.Select(c => new
                {
                    id = c.CateId,
                    text = c.CateName,
                    ChildCount = c.ChildCount,
                    CreateTiem = c.CreateTime,
                    UpdateTime = c.UpdateTime,
                    children = c.children == null ? null : getJson(c.children)
                });
            };

            List<Cate> cateList = _cateService.GetList(0, 0);
            cateList = _cateService.ConvertCateListToTree(cateList);
            return Json(getJson(cateList), JsonRequestBehavior.AllowGet);
        }

        public ActionResult CateDropList()
        {
            Func<List<Cate>, dynamic> getJson = null;
            getJson = (List) =>
            {
                return List.Select(c => new
                {
                    id = c.CateId,
                    text = c.CateName,
                    ChildCount = c.ChildCount,
                    CreateTiem = c.CreateTime,
                    UpdateTime = c.UpdateTime,
                    children = c.children == null ? null : getJson(c.children)
                });
            };

            List<Cate> cateList = _cateService.GetList(0, 0);
            cateList = _cateService.ConvertCateListToTree(cateList);
            cateList.Insert(0, new Cate() { CateId = 0, CateName = "请选择" });
            return Json(getJson(cateList), JsonRequestBehavior.AllowGet);
        }

        public ActionResult CateAdd()
        {
            int cateId = RequestHelper.QueryInt("cateId");

            if (cateId > 0)
            {
                Cate cate = _cateService.GetById(cateId);
                cateId = cate != null ? cateId : 0;
            }

            ViewBag.Pid = cateId;

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

        [HttpPost]
        public ActionResult CateEdit(Cate cate)
        {
            ResultInfo resultInfo = new ResultInfo(1, "验证不通过");

            if (ModelState.IsValid)
            {
                Cate oldCate = _cateService.GetById(cate.CateId);

                if (oldCate == null)
                {
                    resultInfo = new ResultInfo(1, "该信息已被删除或不存在，请刷新列表！");
                    return Json(resultInfo);
                }

                int oldPid = oldCate.Pid;
                oldCate.CateId = cate.CateId;
                oldCate.CateName = cate.CateName;
                oldCate.Pid = cate.Pid;

                resultInfo = _cateService.Update(oldCate, oldPid);
            }

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
