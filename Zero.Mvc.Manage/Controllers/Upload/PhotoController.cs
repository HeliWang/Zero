using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

using Zero.Core.Web;
using Zero.Core.Pattern;
using Zero.Domain.Upload;
using Zero.Service.Upload;


namespace Zero.Mvc.Manage.Controllers.Upload
{
    public class PhotoController : BaseController
    {
        PhotoService _photoService;

        public PhotoController()
        {
            _photoService = Singleton<PhotoService>.GetInstance();
        }

        public ActionResult PhotoIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PhotoAdd()
        {
            ResultInfo result = _photoService.Add(Request.Files);
            return Json(result);
        }

        public ActionResult PhotoList()
        {
            int pageIndex = RequestHelper.QueryInt("page");
            int pageSize = RequestHelper.QueryInt("rows");

            pageIndex = pageIndex <= 0 ? 0 : pageIndex - 1;
            if (pageSize <= 0) pageSize = 10;

            IPage<Photo> PhotoPage = _photoService.GetList(pageIndex, pageSize);

            foreach (Photo photo in PhotoPage.Items)
            {
                photo.Url = Zero.Service.UrlFactory.GetPhotoUrl(photo.Url, 100, 100);
            }

            return Json(PhotoPage, JsonRequestBehavior.AllowGet);
        }
    }
}
