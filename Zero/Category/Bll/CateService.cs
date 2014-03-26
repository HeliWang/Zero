using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Linq;
using Zero.Core.Web;
using Zero.Category.Data;
using Zero.Category.Model;
using Zero.Core.Pattern;

namespace Zero.Category.Bll
{
    public class CateService : CateBaseService<CateInfo>
    {
        public CateService()
        {
            this.cateBaseMapper = new CateBaseMapper<CateInfo>("[Cate]");
        }

        /// <summary>
        /// 添加类别
        /// </summary>
        public ResultInfo Create(string cateName, int pid)
        {
            int depth = 0;

            //是否存在父节点
            if (pid > 0)
            {
                var parentCateInfo = cateBaseMapper.GetById(pid);

                if (parentCateInfo == null)
                {
                    return new ResultInfo((int)ResultStatus.Error, "所属类别不存在或者已删除，请选中其他");
                }

                depth = parentCateInfo.Depth + 1;
            }

            //同一父节点并且同级别的类目不能出现同名
            if (cateBaseMapper.ExistCateName(cateName, pid, depth))
            {
                return new ResultInfo((int)ResultStatus.Error, "已存在该类别名称，请重新填写");
            }

            cateBaseMapper.Create(cateName, pid);

            return new ResultInfo("添加成功");
        }

        /// <summary>
        /// 更新类别信息
        /// </summary>
        public ResultInfo Update(int cateId, string cateName, int pid)
        {
            ResultInfo resultInfo = new ResultInfo();
            cateBaseMapper.Update(cateId, cateName);

            var cateInfo = cateBaseMapper.GetById(cateId);
            int depth = 0;

            //获取该类别信息
            if (cateInfo == null)
            {
                return new ResultInfo((int)ResultStatus.Error, "该类别不存在或者已删除，请选中其他");
            }

            //是否存在父节点
            if (pid > 0)
            {
                var parentCateInfo = cateBaseMapper.GetById(pid);

                if (parentCateInfo == null)
                {
                    return new ResultInfo((int)ResultStatus.Error, "所属类别不存在或者已删除，请选中其他");
                }

                depth = parentCateInfo.Depth + 1;
            }

            //同一父节点并且同级别的类目不能出现同名
            if (cateBaseMapper.ExistCateName(cateId, cateName, pid, depth))
            {
                return new ResultInfo((int)ResultStatus.Error, "所属类别不存在或者已删除，请选中其他");
            }


            //移动类目到指定的父类目下
            if (pid != cateInfo.Pid)
            {
                cateBaseMapper.ChangeParent(cateId, pid);
            }

            cateBaseMapper.Update(cateId, cateName);

            return resultInfo;
        }

        /// <summary>
        /// 将获取的list转换为tree
        /// </summary>
        public List<CateInfo> ConvertCateListToTree(List<CateInfo> cateList)
        {
            List<CateInfo> resultCateList = new List<CateInfo>();

            if (cateList.Count > 0)
            {
                resultCateList = GetCateList(cateList, cateList[0].Pid);
            }
            return resultCateList;
        }

        /// <summary>
        /// 递归获取子节点
        /// </summary>
        /// <param name="cateList"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        public List<CateInfo> GetCateList(List<CateInfo> cateList, int pid)
        {
            var resultCateList = (from c in cateList
                                  where c.Pid == pid
                                  select c).ToList();
            foreach (CateInfo cateInfo in resultCateList)
            {
                if (cateInfo.ChildCount > 0)
                {
                    cateInfo.children = GetCateList(cateList, cateInfo.CateId);
                }
            }

            return resultCateList;
        }
    }
}
