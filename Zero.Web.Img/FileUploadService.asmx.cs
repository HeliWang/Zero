using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using Zero.Core.Pattern;
using Zero.Service.Upload;

namespace Zero.Web.Img
{
    public class CredentialSoapHeader : System.Web.Services.Protocols.SoapHeader
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
        public CredentialSoapHeader header;

        public bool CheckUser()
        {
            if (header.UserName == "admin" && header.Password == "panzhongwei")
            {
                return true;
            }
            return false;
        }

        [WebMethod]
        public string HelloWorld()
        {
            if (!CheckUser())
            {
                return "errory";
            }
            return "Hello World";
        }

        [WebMethod]
        public bool Upload(byte[] image, string path)
        {
            if (!CheckUser())
            {
                return false;
            }

            Singleton<PhotoService>.GetInstance().SaveFile(image, path);

            return true;
        }
    }
}
