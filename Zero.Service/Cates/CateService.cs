using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zero.Data;
using Zero.Domain.Cates;
using Zero.Service.Cates;
using Zero.Core.Web;

namespace Zero.Service.Cates
{
    public class CateService : BaseCateService<Cate>,ICateService<Cate>
    {
        public CateService()
            : base("[Cate]")
        {

        }

        /// <summary>
        /// 将获取的list转换为tree
        /// </summary>
        public List<Cate> ConvertCateListToTree(List<Cate> cateList)
        {
            List<Cate> resultCateList = new List<Cate>();

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
        public List<Cate> GetCateList(List<Cate> cateList, int pid)
        {
            var resultCateList = (from c in cateList
                                  where c.Pid == pid
                                  select c).ToList();

            foreach (Cate cate in resultCateList)
            {
                if (cate.ChildCount > 0)
                {
                    cate.children = GetCateList(cateList, cate.CateId);
                }
            }

            return resultCateList;
        }
    }
}
