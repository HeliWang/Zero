using System.Collections.Generic;
using Zero.Core.Web;
using Zero.Category.Model;
using PetaPoco;
using Zero.Orm;

namespace Zero.Category.Data
{
    public class CateAttrMapper : Mapper<CateAttrInfo>
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public CateAttrInfo AddCateAttrInfo(CateAttrInfo info)
        {
            return db.Insert(info) as CateAttrInfo;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int UpdateCateAttrInfo(CateAttrInfo info)
        {
            return db.Update(info);
        }

        /// <summary>
        /// 更改状态
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="status"></param>
        public void ChangeCateAttrStatus(string ids, int status)
        {
            string sql = string.Format("update [Cate_Attr] set status={0} where CateAttrId in ({1})", status, ids);
            db.Execute(sql);
        }

        ///// <summary>
        ///// 更改分类
        ///// </summary>
        ///// <param name="ids"></param>
        ///// <param name="status"></param>
        //public static void ChangeCateAttrCate(string ids, int cateId)
        //{
        //    string sql = string.Format("update [Cate_Attr] set cateId={0} where CateAttrId in ({1})", cateId, ids);
        //    db.Execute(sql);
        //}

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        public void DeleteCateAttrList(string ids)
        {
            string sql = string.Format("delete [Cate_Attr] where CAID in ({0})", ids);
            db.Execute(sql);
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="CateAttrId"></param>
        /// <returns></returns>
        public  CateAttrInfo GetCateAttrInfo(int caId)
        {
            return db.SingleOrDefault<CateAttrInfo>("where CAID=@0 ", caId);
        }

        /// <summary>
        /// 判断是否存在同样的属性
        /// </summary>
        /// <param name="CateAttrName"></param>
        /// <returns></returns>
        public bool ExistCateAttr(int cateId, int attrId)
        {
            return db.Exists<CateAttrInfo>("CateId=@0 and AttrId=@1", cateId, attrId);
        }

        /// <summary>
        /// 判断是否存在同名
        /// </summary>
        /// <param name="CateAttrId"></param>
        /// <param name="CateAttrName"></param>
        /// <returns></returns>
        public  bool ExistCateAttr(int CAID, int cateId, int attrId)
        {
            return db.Exists<CateAttrInfo>("CAID<>@0 and CateId=@1 and AttrId=@2", CAID, cateId, attrId);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public  List<CateAttrExpandInfo> GetCateAttrList(Paging paging, string condition)
        {
            string sql = string.Format("select * from [Cate_View_Attr] {0}", condition);
            var result = db.Page<CateAttrExpandInfo>(paging.PageIndex, paging.PageSize, sql);
            paging.RecordCount = result.TotalItems;
            return result.Items;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public  List<CateAttrExpandInfo> GetCateAttrList(string condition)
        {
            string sql=string.Format("select * from [Cate_View_Attr] {0}", condition);
            return db.Fetch<CateAttrExpandInfo>(sql);
        }
    }
}
