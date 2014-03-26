using System.Collections.Generic;

using Zero.Core.Web;
using Zero.Core.Pattern;
using Zero.Category.Data;
using Zero.Category.Model;
using Zero.Orm;

namespace Zero.Category.Bll
{
    public class AttrValueService
    {
        private AttrValueMapper _attrValueMapper = Singleton.GetInstance<AttrValueMapper>();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public  AttrValueInfo InsertAttrValueInfo(AttrValueInfo info)
        {
            return _attrValueMapper.Create(info) as AttrValueInfo;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public  int UpdateAttrValueInfo(AttrValueInfo info)
        {
            return _attrValueMapper.Update(info);
        }

        /// <summary>
        /// 更改状态
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="status"></param>
        public  void ChangeAttrValueStatus(string ids, int status)
        {
            _attrValueMapper.ChangeStatus(ids,status);
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
        public  void DeleteAttrValueList(string ids)
        {
            _attrValueMapper.Delete(ids);
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="AttrId"></param>
        /// <returns></returns>
        public  AttrValueInfo GetAttrValueInfo(int valueId)
        {
            return _attrValueMapper.GetById(valueId);
        }

        /// <summary>
        /// 判断是否存在同名
        /// </summary>
        /// <param name="AttrName"></param>
        /// <returns></returns>
        public  bool ExistAttrValue(string value)
        {
            return _attrValueMapper.Exist(value);
        }

        /// <summary>
        /// 判断是否存在同名
        /// </summary>
        /// <param name="AttrId"></param>
        /// <param name="AttrName"></param>
        /// <returns></returns>
        public  bool ExistAttrValue(int valueId, string value)
        {
            return _attrValueMapper.Exist(valueId, value);
        }

        /// <summary>
        /// 获取扩展列表
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public List<AttrValueExpandInfo> GetAttrValueExpandList(Paging paging, string condition)
        {
            return _attrValueMapper.GetExpandList(paging,condition);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public List<AttrValueInfo> GetAttrValueList(string condition)
        {
            return _attrValueMapper.GetList(condition);
        }
    }
}
