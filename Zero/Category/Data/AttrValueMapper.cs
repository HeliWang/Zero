using System.Collections.Generic;
using Zero.Core.Web;
using Zero.Category.Model;
using PetaPoco;
using Zero.Orm;


namespace Zero.Category.Data
{
    public class AttrValueMapper : Mapper<AttrValueInfo>
    {

        /// <summary>
        /// 更改状态
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="status"></param>
        public void ChangeStatus(string ids, int status)
        {
            string sql = string.Format("update [Attr_Value] set status={0} where ValueId in ({1})", status, ids);
            db.Execute(sql);
        }

        ///// <summary>
        ///// 更改分类
        ///// </summary>
        ///// <param name="ids"></param>
        ///// <param name="status"></param>
        //public static void ChangeAttrValueCate(string ids, int cateId)
        //{
        //    string sql = string.Format("update [AttrValue] set cateId={0} where ValueId in ({1})", cateId, ids);
        //    db.Execute(sql);
        //}

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        public void Delete(string ids)
        {
            string sql = string.Format("delete [Attr_Value] where ValueId in ({0})", ids);
            db.Execute(sql);
        }

        /// <summary>
        /// 判断是否存在同名
        /// </summary>
        /// <param name="AttrName"></param>
        /// <returns></returns>
        public  bool Exist(string value)
        {
            return db.Exists<AttrValueInfo>("Value=@0", value);
        }

        /// <summary>
        /// 判断是否存在同名
        /// </summary>
        /// <param name="AttrId"></param>
        /// <param name="AttrName"></param>
        /// <returns></returns>
        public  bool Exist(int valueId, string value)
        {
            return db.Exists<AttrValueInfo>("ValueId<>@0 and Value=@1", valueId, value);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public List<AttrValueExpandInfo> GetExpandList(Paging paging, string condition)
        {
            string sql = string.Format("select * from [Attr_View_Value] {0}", condition);
            var result = db.Page<AttrValueExpandInfo>(paging.PageIndex, paging.PageSize, sql);
            paging.RecordCount = result.TotalItems;
            return result.Items;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public List<AttrValueInfo> GetList(string condition)
        {
            string sql = string.Format("select * from [Attr_Value] {0}", condition);
            return db.Fetch<AttrValueInfo>(sql);
        }
    }
}
