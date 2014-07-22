using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using Zero.Core.Web;
using Zero.Core.Pattern;
using Zero.Domain.News;
using Zero.Service.News;


namespace Zero.Mvc.Manage.Controllers.News
{
    public class NewsController : Controller
    {
        public NewsCateService _newsCateService;
        public INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsCateService = Singleton.GetInstance<NewsCateService>();
            _newsService = newsService;
        }

        #region NewsCate
       
        public ActionResult CateIndex()
        {
            return View();
        }

        public ActionResult CateList()
        {
            Func<List<NewsCate>, dynamic> getJson = null;
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

            List<NewsCate> cateList = _newsCateService.GetList(0, 0);
            cateList = _newsCateService.ConvertCateListToTree(cateList);
            return Json(getJson(cateList), JsonRequestBehavior.AllowGet);
        }

        public ActionResult CateDropList()
        {
            Func<List<NewsCate>, dynamic> getJson = null;
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

            List<NewsCate> cateList = _newsCateService.GetList(0, 0);
            cateList = _newsCateService.ConvertCateListToTree(cateList);
            cateList.Insert(0, new NewsCate() { CateId = 0, CateName = "请选择" });
            return Json(getJson(cateList), JsonRequestBehavior.AllowGet);
        }

        public ActionResult CateAdd()
        {
            int cateId = RequestHelper.QueryInt("cateId");

            if (cateId > 0)
            {
                NewsCate cate = _newsCateService.GetById(cateId);
                cateId = cate != null ? cateId : 0;
            }

            ViewBag.Pid = cateId;

            return View();
        }

        [HttpPost]
        public ActionResult CateAdd(NewsCate cate)
        {
            ResultInfo resultInfo = new ResultInfo(1, "验证不通过");

            if (ModelState.IsValid)
            {
                resultInfo = _newsCateService.Add(cate);
            }

            return Json(resultInfo);
        }

        public ActionResult CateEdit()
        {
            int cateId = RequestHelper.QueryInt("cateId");
            NewsCate cate = _newsCateService.GetById(cateId);
            return View(cate);
        }

        [HttpPost]
        public ActionResult CateEdit(NewsCate cate)
        {
            ResultInfo resultInfo = new ResultInfo(1, "验证不通过");

            if (ModelState.IsValid)
            {
                NewsCate oldCate = _newsCateService.GetById(cate.CateId);

                if (oldCate == null)
                {
                    resultInfo = new ResultInfo(1, "该信息已被删除或不存在，请刷新列表！");
                    return Json(resultInfo);
                }

                int oldPid = oldCate.Pid;
                oldCate.CateId = cate.CateId;
                oldCate.CateName = cate.CateName;
                oldCate.Pid = cate.Pid;

                resultInfo = _newsCateService.Update(oldCate, oldPid);
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
                    _newsCateService.Delete(Utils.StrToInt(ids));
                    break;
            }

            return Json(new ResultInfo("操作成功"));
        }

        #endregion


        #region
        
        public ActionResult NewsList()
        {
            int pageIndex = RequestHelper.QueryInt("page");
            int pageSize = RequestHelper.QueryInt("rows");

            pageIndex = pageIndex <= 0 ? 0 : pageIndex - 1;
            if (pageSize <= 0) pageSize = 10;

            IPage<NewsItem> newsItemPage = _newsService.GetList(pageIndex, pageSize);

            return Json(newsItemPage, JsonRequestBehavior.AllowGet);
        }

        public ActionResult NewsIndex()
        {
            return View();
        }

        
        public ActionResult NewsAdd()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewsAdd(NewsItem newsItem)
        {
            ResultInfo resultInfo = new ResultInfo(1, "验证不通过");

            if (ModelState.IsValid)
            {
                resultInfo = _newsService.Add(newsItem);
            }

            return Json(resultInfo);
        }

        public ActionResult NewsEdit()
        {
            int newsId = RequestHelper.QueryInt("newsId");
            NewsItem newsItem = _newsService.GetById(newsId);
            return View(newsItem);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewsEdit(NewsItem newsItem)
        {
            ResultInfo resultInfo = new ResultInfo(1, "验证不通过");

            if (ModelState.IsValid)
            {
                NewsItem oldNewsItem = _newsService.GetById(newsItem.NewsId);

                if (oldNewsItem == null)
                {
                    return Json(new ResultInfo(1, "该信息已被删除或不存在，请刷新列表！"));
                }

                oldNewsItem = newsItem;

                resultInfo = _newsService.Edit(newsItem);
            }

            return Json(resultInfo);
        }

        #endregion
    }
}
