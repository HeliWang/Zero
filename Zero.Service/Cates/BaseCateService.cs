﻿using System;
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
    public class BaseCateService<T> where T : BaseCate
    {
        private EfCateRepository<T> _cateRepository;

        public BaseCateService(string tableName)
        {
            _cateRepository = new EfCateRepository<T>(tableName);
        }

        /// <summary>
        /// 添加类别
        /// </summary>
        public ResultInfo Add(T cate)
        {
            //是否存在父节点
            if (cate.Pid > 0)
            {
                var parentCate = _cateRepository.GetById(cate.Pid);

                if (parentCate == null)
                {
                    return new ResultInfo((int)ResultStatus.Error, "所属类别不存在或者已删除，请选中其他");
                }

                cate.Depth = parentCate.Depth + 1;
            }

            //同一父节点并且同级别的类目不能出现同名
            if (_cateRepository.ExistNameByAdd(cate))
            {
                return new ResultInfo((int)ResultStatus.Error, "已存在该类别名称，请重新填写");
            }

            _cateRepository.Add(cate);

            return new ResultInfo("添加成功");
        }

        /// <summary>
        /// 更新类别信息
        /// </summary>
        public ResultInfo Update(T cate, int oldPid)
        {
            //是否存在父节点
            if (cate.Pid > 0)
            {
                var parentCate = _cateRepository.GetById(cate.Pid);

                if (parentCate == null)
                {
                    return new ResultInfo(1, "所属类别不存在或者已删除，请选中其他");
                }

                cate.Depth = parentCate.Depth + 1;
            }

            //同一父节点并且同级别的类目不能出现同名
            if (_cateRepository.ExistNameByUpdate(cate))
            {
                return new ResultInfo(1, "所属类别不存在或者已删除，请选中其他");
            }

            //移动类目到指定的父类目下
            if (cate.Pid != oldPid)
            {
                _cateRepository.ChangeParent(cate);
            }

            _cateRepository.Update(cate);

            return new ResultInfo("修改成功");
        }

        /// <summary>
        /// 删除类别
        /// </summary>
        /// <param name="cateId"></param>
        /// <returns></returns>
        public ResultInfo Delete(int cateId)
        {
            _cateRepository.Delete(cateId);
            return new ResultInfo("删除成功");
        }

        /// <summary>
        /// 获取类别信息
        /// </summary>
        public T GetById(int cateId)
        {
            return _cateRepository.GetById(cateId);
        }

        /// <summary>
        /// 获取父亲类别 ，倒序 , 第一个为最亲近的父亲节点
        /// </summary>
        public List<T> GetParent(int cateId)
        {
            return _cateRepository.GetParent(cateId);
        }

        /// <summary>
        /// 获取类别的路径 
        /// </summary>
        public List<T> GetPath(int cateId)
        {
            return _cateRepository.GetPath(cateId);
        }

        /// <summary>
        /// 获取类别列表 (depth=-1为自身，depth=0 为所有子节点 , depth>0为指定深度的子节点)
        /// </summary>
        public List<T> GetList(int cateId, int depth)
        {
            return _cateRepository.GetList(cateId, depth);
        }
    }
}
