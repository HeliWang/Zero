using Zero.Core.Web;
using Zero.Category.Model;
using System.Collections.Generic;

namespace Zero.Category.Bll
{
    public class CateAttrValueService
    {
        public static PetaPoco.Database db = Zero.Orm.ZeroDataContext.GetInstance();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static CateAttrValueInfo AddCateAttrValueInfo(CateAttrValueInfo info)
        {
            return db.Insert(info) as CateAttrValueInfo;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static int UpdateCateAttrValueInfo(CateAttrValueInfo info)
        {
            return db.Update(info);
        }

        /// <summary>
        /// 更改状态
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="status"></param>
        public static void ChangeCateAttrValueStatus(string ids, int status)
        {
            string sql = string.Format("update [Attr_Value] set status={0} where ValueId in ({1})", status, ids);
            db.Execute(sql);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        public static void DeleteCateAttrValueList(string ids)
        {
            string sql = string.Format("delete [Attr_Value] where ValueId in ({0})", ids);
            db.Execute(sql);
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="AttrId"></param>
        /// <returns></returns>
        public static CateAttrValueInfo GetCateAttrValueInfo(int valueId)
        {
            return db.SingleOrDefault<CateAttrValueInfo>("where ValueId=@0 ", valueId);
        }

        /// <summary>
        /// 判断是否存在同名
        /// </summary>
        /// <param name="AttrName"></param>
        /// <returns></returns>
        public static bool ExistCateAttrValue(string value)
        {
            return db.Exists<CateAttrValueInfo>("Value=@0", value);
        }

        /// <summary>
        /// 判断是否存在同名
        /// </summary>
        /// <param name="AttrId"></param>
        /// <param name="AttrName"></param>
        /// <returns></returns>
        public static bool ExistCateAttrValue(int valueId, string value)
        {
            return db.Exists<CateAttrValueInfo>("ValueId<>@0 and Value=@1", valueId, value);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static List<CateAttrValueExpandInfo> GetCateAttrValueList(Paging paging, string condition)
        {
            string sql = string.Format("select * from [Cate_View_Attr] {0}", condition);
            var result = db.Page<CateAttrValueExpandInfo>(paging.PageIndex, paging.PageSize, sql);
            paging.RecordCount = result.TotalItems;
            return result.Items;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static List<CateAttrValueInfo> GetCateAttrValueList(string condition)
        {
            string sql = string.Format("select * from [Cate_View_Attr] {0}", condition);
            return db.Fetch<CateAttrValueInfo>(sql);
        }

        /// <summary>
        /// 获取类别对应的属性值
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static List<CateAttrValueExpandInfo> GetCateAttrValueList(int cateId)
        {
            string sql = string.Format("select * from [Cate_View_Attr] cateId={0}", cateId);
            return db.Fetch<CateAttrValueExpandInfo>(sql);
        }
    }
}

