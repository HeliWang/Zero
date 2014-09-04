using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zero.Data;
using Zero.Domain.Cates;
using Zero.Service.Cates;

namespace Zero.Service.Cates
{
    public interface ICateService<T>
    {
        /// <summary>
        /// 将获取的list转换为tree
        /// </summary>
        List<Cate> ConvertCateListToTree(List<Cate> cateList);

        /// <summary>
        /// 递归获取子节点
        /// </summary>
        /// <param name="cateList"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        List<Cate> GetCateList(List<Cate> cateList, int pid);

        List<T> GetPath(int cateId);

        List<T> GetList(int cateId, int depth);
    }
}
