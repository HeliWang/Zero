using System.Collections.Generic;
using System.Text;
using System.Web;
using Zero.Core.Web;
using Zero.Category.Model;
using Zero.Category.Data;

namespace Zero.Category.Bll
{
    public class CateBaseService<T> where T : class,new()
    {
        public CateBaseMapper<T> cateBaseMapper;


        //删除类别
        public ResultInfo Delete(int cateId)
        {
            if (cateBaseMapper.Delete(cateId) > 0)
            {
                return new ResultInfo("删除成功");
            }

            return new ResultInfo("删除失败，请重试或联系技术");
        }

        /// <summary>
        /// 修改所属类别
        /// </summary>
        public void ChangeParent(int cateId, int pid)
        {
            cateBaseMapper.ChangeParent(cateId, pid);
        }

        /// <summary>
        /// 判断是否存在此类别
        /// </summary>
        public bool ExistCateId(int cateId)
        {
            return cateBaseMapper.ExistCateId(cateId);
        }

        /// <summary>
        /// 判断同一父节点并且同级别的类目是否出现同名
        /// </summary>
        public bool ExistCateName(string cateName, int pid, int depth)
        {
            return cateBaseMapper.ExistCateName(cateName, pid, depth);
        }

        /// <summary>
        /// 判断同一父节点并且同级别的类目是否出现同名
        /// </summary>
        public bool ExistCateName(int cateId, string cateName, int pid, int depth)
        {
            return cateBaseMapper.ExistCateName(cateId, cateName, pid, depth);
        }

        /// <summary>
        /// 获取类别信息
        /// </summary>
        public T GetById(int cateId)
        {
            return cateBaseMapper.GetById(cateId);
        }

        /// <summary>
        /// 获取父亲类别 ，倒序 , 第一个为最亲近的父亲节点
        /// </summary>
        public List<T> GetParent(int cateId)
        {
            return cateBaseMapper.GetCateParent(cateId);
        }

        /// <summary>
        /// 获取类别的路径 
        /// </summary>
        public List<T> GetPath(int cateId)
        {
            return cateBaseMapper.GetCatePath(cateId);
        }

        /// <summary>
        /// 获取类别列表 (depth=-1为自身，depth=0 为所有子节点 , depth>0为指定深度的子节点)
        /// </summary>
        public List<T> GetList(int cateId, int depth)
        {
            return cateBaseMapper.GetCateList(cateId, depth);
        }
    }
}
