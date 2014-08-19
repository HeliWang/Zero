using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Net;
using System.IO;
using Zero.Web.Models;
using Zero.Service.News;
using Zero.Service.Products;

namespace Zero.Web.Controllers
{
    public class HomeController : Controller
    {
        public IProductService _productService;
        public INewsService _newsService;

        public HomeController(IProductService productService,
           INewsService newsService)
        {
            _productService = productService;
            _newsService = newsService;
        }

        public ActionResult Index()
        {
            IndexModel indexModel = new IndexModel();
            indexModel.ProductList = _productService.GetList(10);
            indexModel.NewsList = _newsService.GetList(10);
            return View(indexModel);
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Vote()
        {
            string message = "";
            int rate = 0;
            GotoURL(out message, "http://www.baidu.com", 100, "http://www.baidu.com", "6", out rate, true);
            ViewBag.message = message;
            return View();
        }

        /*
        Message:返回的信息
        Url:需要访问的地址
        Timeout:超时时间
        Proxyurl:代理的地址
        Keyword:判断投票成功的标志
        Rate:访问url所花费的时间
        Proxyed:是否使用代理
        */
        public int GotoURL(out string message, string url, int timeout, string proxyurl, string keyword, out int rate, bool proxyed)
        {
            byte[] gbyte = new byte[1024];
            string strInput;
            int iret = 3;
            int i, len = 0;
            DateTime dtBegin = DateTime.Now;
            message = "正在访问中。。。";
            //try
            //{

                //url = @"http://pmc.whu.edu.cn/redsky/temp/whu_tp/vote.asp?voted=25& submit=投票";
                WebRequest myWebRequest = WebRequest.Create(url);
                myWebRequest.Timeout = timeout;//设置超时时间=15000毫秒

                if (proxyed)//是否使用代理功能
                {

                    WebProxy myProxy = new WebProxy();//实例化一个WebProxy类，这个类设置WebRequest的Proxy属性，这样可以通过代理来访问url。
                    //myProxy = (WebProxy)myWebRequest.Proxy;
                    string proxyAddress = proxyurl;
                    Uri newUri = new Uri(proxyAddress);
                    myProxy.Address = newUri;
                    myWebRequest.Proxy = myProxy;
                }
                WebResponse myWebResponse = myWebRequest.GetResponse();//实例化一个WebResponse类，用于接收WebRequest的响应内容，依据内容来判断投票是否成功。
                Stream streamResponse = myWebResponse.GetResponseStream();// 实例化一个Stream类，从WebResponse接收数据流。

                i = streamResponse.Read(gbyte, len, 1024);
                len += i;
                while (i != 0)
                {
                    i = streamResponse.Read(gbyte, len, 1024);
                    len += i;
                }

                strInput = System.Text.Encoding.GetEncoding("gb2312").GetString(gbyte);
                i = strInput.IndexOf("成功");
                Console.WriteLine(i);
                if (i == -1)
                    message = "访问成功";
                else
                    message = "访问失败";// 将数据流转换成字符串，并从中判断投票是否成功。
                iret = 0;
                streamResponse.Close();
            //}

            //catch (System.Net.WebException we)
            //{
            //    message = "NetError" + we.Message;
            //}
            //catch (System.IO.IOException ie)
            //{
            //    message = "IOError" + ie.Message;
            //}
            //catch (System.Exception ex)
            //{
            //    message = ex.Message;
            //}

            TimeSpan ts = DateTime.Now - dtBegin;
            rate = (int)ts.TotalMilliseconds; //获取访问的时间。
            return iret;
        }
    }
}
