using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using Zero.Core.Web;
using Zero.Img.Bll;
using Zero.Img.Model;


namespace Zero.Web.Manage
{
    public partial class ImageList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RequestHelper.IsPost())
            {
                Add();
            }
            else
            {
                Get();
            }
        }

        private void Get()
        {
            int size = RequestHelper.QueryInt("pageSize");
            StringBuilder sb = new StringBuilder();
            StringBuilder sbb = new StringBuilder();
            Paging paging = new Paging(size);
            List<AttachmentInfo> list = AttachmentCtrl.GetAttachmentList(paging, "order by CreateTime desc");

            foreach (AttachmentInfo info in list)
            {
                sbb.Append(",{");
                sbb.AppendFormat("src: '{0}'", ImageHelper.GetPhotoUrl(info.Url, 100, 100, 0));
                sbb.Append("}");
            }

            if (sbb.Length > 0)
            {
                sbb.Remove(0, 1);
            }

            sb.Append("{");
            sb.AppendFormat("count: {0}", paging.RecordCount);
            sb.AppendFormat(",size: {0}", paging.PageSize);
            sb.AppendFormat(",page: {0}", paging.PageIndex);
            sb.AppendFormat(",list: [{0}]", sbb.ToString());
            sb.Append("}");
            Response.Write(sb.ToString());
            Response.End();
        }

        private void Add()
        {
            string result = string.Empty;
            StringBuilder sb = new StringBuilder();
            StringBuilder item = new StringBuilder();
            StringBuilder error = new StringBuilder();
            HttpFileCollection files = HttpContext.Current.Request.Files;

            AttachmentInfo info = new AttachmentInfo();
            info.CateId = RequestHelper.FormInt("Cate");
            info.AllowExt = "gif,jpg,jpeg,png,bmp";
            info.AllowSize = 5;
            info.Uploader = "系统";

            if (files.Count == 0)
            {
                error.Append("请上传图片|");
            }

            if (files.Count > info.AllowSize)
            {
                error.Append("最多只能上传5个图片|");
            }

            for (int i = 0; i < files.Count; i++)
            {
                //验证文件合法性
                result = FileHelper.CheckFile(files[i], info.AllowSize, info.AllowExt);
                if (result.Length > 0) error.AppendFormat("第{0}{1}|", i + 1, result);
            }

            if (error.Length == 0)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    //生成路径
                    DateTime dt = DateTime.Now;
                    info.Ext = Path.GetExtension(files[i].FileName);
                    info.Size = files[i].ContentLength;
                    info.FileName = dt.ToString("yyyyMMddHHmmss") + info.Ext;
                    info.Url = string.Format(@"ad/g{0}/{1}/{2}/{3}", info.CateId, dt.Year, dt.Month, info.FileName);
                    info.CreateTime = dt;
                    info.UpdateTime = dt;

                    //获取文件的二进制流数据
                    byte[] input = FileHelper.GetFile(files[i]);

                    //调用webservice上传
                    Service.Img.FileUploadServiceSoapClient client = new Service.Img.FileUploadServiceSoapClient();
                    Service.Img.CredentialSoapHeader header = new Service.Img.CredentialSoapHeader();
                    header.UserName = "admin";
                    header.Password = "admin";
                    result = client.Upload(header, input, info.Url);

                    if (result == "上传成功")
                    {
                        //将添加的图片保存到图库中
                        AttachmentCtrl.AddAttachmentInfo(info);
                        item.Append(info.Url + "|");
                    }
                    else
                    {
                        error.AppendFormat("第{0}{1}|", i + 1, result);
                    }
                }
            }

            if (error.Length > 0)
            {
                error.Remove(error.Length - 1, 1);
            }

            if (item.Length > 0)
            {
                item.Remove(item.Length - 1, 1);
            }

            sb.Append("{");
            sb.AppendFormat("error: '{0}'", error.ToString());
            sb.AppendFormat(",item: '{0}'", item.ToString());
            sb.Append("}");

            Response.Write(sb.ToString());
            Response.End();
        }
    }
}