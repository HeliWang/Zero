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
    /// <summary>
    /// 属性管理
    /// </summary>
    public partial class CateAttrController : BaseController
    {
        CateAttrService _cateAttrService;
        CateService _cateService;

        public CateAttrController()
        {
            _cateAttrService = Singleton<CateAttrService>.GetInstance();
            _cateService = Singleton<CateService>.GetInstance();
        }

        public ActionResult CateAttrList()
        {
            int pageIndex = RequestHelper.QueryInt("page");
            int pageSize = RequestHelper.QueryInt("rows");

            pageIndex = pageIndex <= 0 ? 0 : pageIndex - 1;
            if (pageSize <= 0) pageSize = 10;

            CateAttrSearch search = new CateAttrSearch();
            IPage<CateAttrExpand> productPage = _cateAttrService.GetExpandList(search, pageIndex, pageSize);

            return Json(productPage, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CateAttrIndex()
        {
            return View();
        }

        public ActionResult CateAttrAdd()
        {
            int cateId = RequestHelper.QueryInt("cateId");
            Cate cate = _cateService.GetById(cateId);

            CateAttrExpand cateAttrExpand = new CateAttrExpand();
            if (cate != null)
            {
                cateAttrExpand.CateId = cateId;
                cateAttrExpand.CateName = cate.CateName;
            }
            return View(cateAttrExpand);
        }

        [HttpPost]
        public ActionResult CateAttrAdd(CateAttr cateAttr)
        {
            ResultInfo resultInfo = new ResultInfo(1, "验证不通过");

            if (ModelState.IsValid)
            {
                resultInfo = _cateAttrService.Add(cateAttr);
            }

            return Json(resultInfo);
        }

        public ActionResult CateAttrEdit()
        {
            int cateAttrId = RequestHelper.QueryInt("cateAttrId");
            CateAttr cateAttr = _cateAttrService.GetById(cateAttrId);
            return View(cateAttr);
        }

        [HttpPost]
        public ActionResult CateAttrEdit(CateAttr cateAttr)
        {
            ResultInfo resultInfo = new ResultInfo(1, "验证不通过");

            if (ModelState.IsValid)
            {
                CateAttr oldCateAttr = _cateAttrService.GetById(cateAttr.CateId);
                oldCateAttr.CateId = cateAttr.CateId;
                oldCateAttr.Oid = cateAttr.Oid;
                resultInfo = _cateAttrService.Edit(oldCateAttr);
            }

            return Json(resultInfo);
        }

        [HttpPost]
        public ActionResult CateAttrOperate()
        {
            ResultInfo resultInfo;

            string action = RequestHelper.All("action").ToLower();
            string ids = RequestHelper.All("ids").ToLower();

            if (action == "" || ids == "")
            {
                resultInfo = new ResultInfo((int)ResultStatus.Error, "未选择任何操作或未选择任何操作项！");
                return Json(resultInfo);
            }

            switch (action)
            {
                case "delete":
                    _cateAttrService.Delete(ids);
                    break;
            }

            return Json(new ResultInfo("操作成功"));
        }
    }
}
