using Zero.Core.Web;
using Zero.User.Model;
using System.Collections.Generic;

namespace Zero.User.Bll
{
    public class AdminCtrl
    {
        public static PetaPoco.Database db = Zero.Orm.ZeroDataContext.GetInstance();

        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static AdminInfo AddAdminInfo(AdminInfo info)
        {
            return db.Insert(info) as AdminInfo;
        }

        /// <summary>
        /// 更新管理员
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static int UpdateAdminInfo(AdminInfo info)
        {
            return db.Update(info);
        }

        /// <summary>
        /// 更改管理员状态
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="status"></param>
        public static void ChangeAdminStatus(string ids, int status)
        {
            string sql = string.Format("update [Admin] set status={0} where AdminId in ({1})", status, ids);
            db.Execute(sql);
        }

        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="ids"></param>
        public static void DeleteAdminList(string ids)
        {
            string sql = string.Format("delete [Admin] where AdminId in ({0})", ids);
            db.Execute(sql);
        }

        /// <summary>
        /// 获取管理信息
        /// </summary>
        /// <param name="adminName"></param>
        /// <returns></returns>
        public static AdminInfo GetAdminInfo(string adminName)
        {
            return db.SingleOrDefault<AdminInfo>("where AdminName=@0 ", adminName);
        }

        /// <summary>
        /// 获取管理信息
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public static AdminInfo GetAdminInfo(int adminId)
        {
            return db.SingleOrDefault<AdminInfo>("where AdminId=@0 ", adminId);
        }

        /// <summary>
        /// 判断管理员是否存在同名
        /// </summary>
        /// <param name="adminName"></param>
        /// <returns></returns>
        public static bool ExistAdminName(string adminName)
        {
            return db.Exists<AdminInfo>("AdminName=@0 ", adminName);
        }

        /// <summary>
        /// 判断管理员是否存在同名
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="adminName"></param>
        /// <returns></returns>
        public static bool ExistAdminName(int adminId, string adminName)
        {
            return db.Exists<AdminInfo>(" AdminId<>@0 and AdminName=@1 ", adminId, adminName);
        }

        /// <summary>
        /// 获取管理列表
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static List<AdminInfo> GetAdminList(Paging paging, string condition)
        {
            string sql = string.Format("select * from [Admin] {0}", condition);
            var result = db.Page<AdminInfo>(paging.PageIndex, paging.PageSize, sql);
            paging.RecordCount = result.TotalItems;
            return result.Items;
        }
    }
}
