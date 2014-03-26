using System.Collections.Generic;

using Zero.Core.Web;
using Zero.Core.Pattern;
using Zero.Category.Data;
using Zero.Category.Model;

namespace Zero.Category.Bll
{
    public class AttrService
    {
        private AttrMapper _attrMapper;

        public AttrService()
        {
            _attrMapper = Singleton.GetInstance<AttrMapper>();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public AttrInfo InsertAttr(AttrInfo info)
        {
            return _attrMapper.Create(info) as AttrInfo;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int UpdateAttt(AttrInfo info)
        {
            return _attrMapper.Update(info);
        }

        /// <summary>
        /// 更改状态
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="status"></param>
        public void ChangeAttrStatus(string ids, int status)
        {
            _attrMapper.ChangeStatus(ids, status);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        public void DeleteAttrList(string ids)
        {
            _attrMapper.DeleteList(ids);
        }

        /// <summary>
        /// 判断是否存在属性
        /// </summary>
        /// <param name="AttrName"></param>
        /// <returns></returns>
        public bool ExistAttr(int attrId)
        {
            return _attrMapper.Exist(attrId);
        }

        /// <summary>
        /// 判断是否存在同名
        /// </summary>
        /// <param name="AttrName"></param>
        /// <returns></returns>
        public bool ExistAttr(string attr)
        {
            return _attrMapper.Exist(attr);
        }

        /// <summary>
        /// 判断是否存在同名
        /// </summary>
        /// <param name="AttrId"></param>
        /// <param name="AttrName"></param>
        /// <returns></returns>
        public bool ExistAttr(int attrId, string attr)
        {
            return _attrMapper.Exist(attrId, attr);
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="AttrId"></param>
        /// <returns></returns>
        public AttrInfo GetAtrrById(int attrId)
        {
            return _attrMapper.GetById(attrId);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public Page<AttrInfo> GetList(int pageIndex, int pageSize, string condition)
        {
            return _attrMapper.GetList(pageIndex, pageSize, condition);
        }
    }
}
