using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using Zero.Img.Model;
using Zero.Core.Web;

namespace Zero.Img.Bll
{
    public partial class AttachmentCtrl
    {
        public static PetaPoco.Database db = Zero.Orm.ZeroDataContext.GetInstance();

        /// <summary>
        /// 添加附件
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static AttachmentInfo AddAttachmentInfo(AttachmentInfo info)
        {
            return db.Insert(info) as AttachmentInfo;
        }

        /// <summary>
        /// 更新附件
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static int UpdateAttachmentInfo(AttachmentInfo info)
        {
            return db.Update(info);
        }

        /// <summary>
        /// 更改附件状态
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="status"></param>
        public static void ChangeAttachmentStatus(string ids, int status)
        {
            string sql = string.Format("update [Attachment] set status={0} where AttachmentId in ({1})", status, ids);
            db.Execute(sql);
        }

        /// <summary>
        /// 删除附件
        /// </summary>
        /// <param name="ids"></param>
        public static void DeleteAttachmentList(string ids)
        {
            string sql = string.Format("delete [Attachment] where AttachmentId in ({0})", ids);
            db.Execute(sql);
        }

        /// <summary>
        /// 获取附件信息
        /// </summary>
        /// <param name="attachmentName"></param>
        /// <returns></returns>
        public static AttachmentInfo GetAttachmentInfo(string attachmentName)
        {
            return db.SingleOrDefault<AttachmentInfo>("where AttachmentName=@0 ", attachmentName);
        }

        /// <summary>
        /// 获取附件信息
        /// </summary>
        /// <param name="attachmentId"></param>
        /// <returns></returns>
        public static AttachmentInfo GetAttachmentInfo(int attachmentId)
        {
            return db.SingleOrDefault<AttachmentInfo>("where AttachmentId=@0 ", attachmentId);
        }

        /// <summary>
        /// 判断附件是否存在同名
        /// </summary>
        /// <param name="attachmentName"></param>
        /// <returns></returns>
        public static bool ExistAttachmentName(string attachmentName)
        {
            return db.Exists<AttachmentInfo>("AttachmentName=@0 ", attachmentName);
        }

        /// <summary>
        /// 判断附件是否存在同名
        /// </summary>
        /// <param name="attachmentId"></param>
        /// <param name="attachmentName"></param>
        /// <returns></returns>
        public static bool ExistAttachmentName(int attachmentId, string attachmentName)
        {
            return db.Exists<AttachmentInfo>(" AttachmentId<>@0 and AttachmentName=@1 ", attachmentId, attachmentName);
        }

        /// <summary>
        /// 获取附件列表
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static List<AttachmentInfo> GetAttachmentList(Paging paging, string condition)
        {
            string sql = string.Format("select * from [Attachment] {0}", condition);
            var result = db.Page<AttachmentInfo>(paging.PageIndex, paging.PageSize, sql);
            paging.RecordCount = result.TotalItems;
            return result.Items;
        }
    }
}
