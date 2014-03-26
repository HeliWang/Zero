using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zero.Core.Web;
using Zero.Sys.Model;

namespace Zero.Sys.Bll
{
    public partial class ErrorCtrl
    {
        public static PetaPoco.Database db = Zero.Orm.ZeroDataContext.GetInstance();

        /// <summary>
        /// 创建错误信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static void AddErrorInfo(string message, string url)
        {
            ErrorInfo info = new ErrorInfo();
            info.Message = message;
            info.Url = url;
            AddErrorInfo(info);
        }

        /// <summary>
        /// 添加系统错误信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static ErrorInfo AddErrorInfo(ErrorInfo info)
        {
            return db.Insert(info) as ErrorInfo;
        }

        /// <summary>
        /// 更新系统错误信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static int UpdateErrorInfo(ErrorInfo info)
        {
            return db.Update(info);
        }

       
        /// <summary>
        /// 删除系统错误信息
        /// </summary>
        /// <param name="ids"></param>
        public static void DeleteErrorList(string ids)
        {
            string sql = string.Format("delete [Error] where ErrorId in ({0})", ids);
            db.Execute(sql);
        }

        /// <summary>
        /// 获取系统错误信息
        /// </summary>
        /// <param name="attachmentId"></param>
        /// <returns></returns>
        public static ErrorInfo GetErrorInfo(int attachmentId)
        {
            return db.SingleOrDefault<ErrorInfo>("where ErrorId=@0 ", attachmentId);
        }


        /// <summary>
        /// 获取系统错误信息列表
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static List<ErrorInfo> GetErrorList(Paging paging, string condition)
        {
            string sql = string.Format("select * from [Error] {0}", condition);
            var result = db.Page<ErrorInfo>(paging.PageIndex, paging.PageSize, sql);
            paging.RecordCount = result.TotalItems;
            return result.Items;
        }
    }
}
