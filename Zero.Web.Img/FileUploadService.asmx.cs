using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace Zero.Web.Img
{
    public class CredentialSoapHeader : SoapHeader
    {
        //帐户
        public string UserName { get; set; }
        //加密后的验证密码
        public string Password { get; set; }
    }

    /// <summary>
    /// FileUploadService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class FileUploadService : System.Web.Services.WebService
    {
        public CredentialSoapHeader header = new CredentialSoapHeader();

        public bool CheckUser()
        {
            if (header.UserName == "admin" && header.Password == "admin")
            {
                return true;
            }
            return false;
        }

        [SoapHeader("header")] 
        [WebMethod]
        public string Upload(byte[] image, string path)
        {
            if (!CheckUser())
            {
                return "上传授权账户或密码错误，请检查";
            }

            try
            {
                Zero.Core.Web.FileHelper.SaveFile(image, path);
                return "上传成功";
            }
            catch (Exception ex)
            {
                Zero.Sys.Bll.ErrorCtrl.AddErrorInfo(ex.ToString(), path);
                return "上传失败";
            }
        }
    }
}
