using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zero.Data;
using Zero.Domain.News;
using Zero.Core.Web;

namespace Zero.Service.News
{
    public class NewsCateService
    {
        private EfCateRepository<NewsCate> _NewsCateRepository;

        public string TableName { get; set; } 

        public NewsCateService()
        {
            _NewsCateRepository = new EfCateRepository<NewsCate>("[NewsCate]");
        }

        /// <summary>
        /// 添加类别
        /// </summary>
        public ResultInfo Add(NewsCate NewsCate)
        {
            //是否存在父节点
            if (NewsCate.Pid > 0)
            {
                var parentNewsCate = _NewsCateRepository.GetById(NewsCate.Pid);

                if (parentNewsCate == null)
                {
                    return new ResultInfo((int)ResultStatus.Error, "所属类别不存在或者已删除，请选中其他");
                }

                NewsCate.Depth = parentNewsCate.Depth + 1;
            }

            //同一父节点并且同级别的类目不能出现同名
            if (_NewsCateRepository.ExistNameByAdd(NewsCate))
            {
                return new ResultInfo((int)ResultStatus.Error, "已存在该类别名称，请重新填写");
            }

            _NewsCateRepository.Add(NewsCate);

            return new ResultInfo("添加成功");
        }

        /// <summary>
        /// 更新类别信息
        /// </summary>
        public ResultInfo Update(NewsCate NewsCate,int oldPid)
        {
            //是否存在父节点
            if (NewsCate.Pid > 0)
            {
                var parentNewsCate = _NewsCateRepository.GetById(NewsCate.Pid);

                if (parentNewsCate == null)
                {
                    return new ResultInfo(1, "所属类别不存在或者已删除，请选中其他");
                }

                NewsCate.Depth = parentNewsCate.Depth + 1;
            }

            //同一父节点并且同级别的类目不能出现同名
            if (_NewsCateRepository.ExistNameByUpdate(NewsCate))
            {
                return new ResultInfo(1, "所属类别不存在或者已删除，请选中其他");
            }

            //移动类目到指定的父类目下
            if (NewsCate.Pid != oldPid)
            {
                _NewsCateRepository.ChangeParent(NewsCate);
            }

            _NewsCateRepository.Update(NewsCate);

            return new ResultInfo("修改成功");
        }

        /// <summary>
        /// 删除类别
        /// </summary>
        /// <param name="NewsCateId"></param>
        /// <returns></returns>
        public ResultInfo Delete(int NewsCateId)
        {
            _NewsCateRepository.Delete(NewsCateId);
            return new ResultInfo("删除成功");
        }

        /// <summary>
        /// 获取类别信息
        /// </summary>
        public NewsCate GetById(int NewsCateId)
        {
            return _NewsCateRepository.GetById(NewsCateId);
        }

        /// <summary>
        /// 获取父亲类别 ，倒序 , 第一个为最亲近的父亲节点
        /// </summary>
        public List<NewsCate> GetParent(int NewsCateId)
        {
            return _NewsCateRepository.GetParent(NewsCateId);
        }

        /// <summary>
        /// 获取类别的路径 
        /// </summary>
        public List<NewsCate> GetPath(int NewsCateId)
        {
            return _NewsCateRepository.GetPath(NewsCateId);
        }

        /// <summary>
        /// 获取类别列表 (depth=-1为自身，depth=0 为所有子节点 , depth>0为指定深度的子节点)
        /// </summary>
        public List<NewsCate> GetList(int NewsCateId, int depth)
        {
            return _NewsCateRepository.GetList(NewsCateId, depth);
        }

        /// <summary>
        /// 将获取的list转换为tree
        /// </summary>
        public List<NewsCate> ConvertNewsCateListToTree(List<NewsCate> NewsCateList)
        {
            List<NewsCate> resultNewsCateList = new List<NewsCate>();

            if (NewsCateList.Count > 0)
            {
                resultNewsCateList = GetNewsCateList(NewsCateList, NewsCateList[0].Pid);
            }
            return resultNewsCateList;
        }

        /// <summary>
        /// 递归获取子节点
        /// </summary>
        /// <param name="NewsCateList"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        public List<NewsCate> GetNewsCateList(List<NewsCate> newsCateList, int pid)
        {
            var resultNewsCateList = (from c in newsCateList
                                  where c.Pid == pid
                                  select c).ToList();

            foreach (NewsCate newsCateInfo in resultNewsCateList)
            {
                if (newsCateInfo.ChildCount > 0)
                {
                    newsCateInfo.children = GetNewsCateList(newsCateList, newsCateInfo.CateId);
                }
            }

            return resultNewsCateList;
        }
    }
}
