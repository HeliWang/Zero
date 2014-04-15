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
    public class CateAttrSearch
    {
        public int CateId{get;set;}
    }

    public class CateAttrService
    {
        public EfDbContext context;
        public IRepository<Cate> _cateRepository;
        public IRepository<Attr> _attrRepository;
        public IRepository<CateAttr> _cateAttrRepository;

        public CateAttrService()
        {
            context = new EfDbContext();
            _cateRepository = new EfRepository<Cate>(context);
            _attrRepository = new EfRepository<Attr>(context);
            _cateAttrRepository = new EfRepository<CateAttr>(context);
        }

        public ResultInfo Add(CateAttr cateAttr)
        {
            _cateAttrRepository.Add(cateAttr);
            return new ResultInfo("添加成功");
        }

        public ResultInfo Edit(CateAttr cateAttr)
        {
            _cateAttrRepository.Update(cateAttr);
            return new ResultInfo("添加成功");
        }

        public ResultInfo Delete(string ids)
        {
            _cateAttrRepository.Delete(ids);
            return new ResultInfo("删除成功");
        }

        public CateAttr GetById(int productId)
        {
            return _cateAttrRepository.GetById(productId);
        }

        public IPage<CateAttr> GetList(int pageIndex, int pageSize)
        {
            var query =  _cateAttrRepository.Entities.Include("Cate").Include("Attr").AsQueryable();
            //var query = _cateAttrRepository.Table;
            query = query.OrderByDescending(q => q.CateId);
            return new Page<CateAttr>(query, pageIndex, pageSize);
        }

        public IPage<CateAttr> GetExpandList(int pageIndex, int pageSize)
        {
            var query = from a in _cateAttrRepository.Table
                        from c in _cateRepository.Table
                        where a.CateId == c.CateId
                        select new CateAttrExpand
                        {
                            CateId = a.CateId,
                            CateName = c.CateName,
                        };

            query = query.OrderByDescending(q => q.CateId);
            return new Page<CateAttr>(query, pageIndex, pageSize);
        }

        public IPage<CateAttrExpand> GetExpandList(CateAttrSearch search, int pageIndex, int pageSize)
        {
            //if (search.CateId > 0)
            //{
            //    Cate cate = _cateRepository.GetById(search.CateId);
            //}

            //获取类别

            //根据条件检索cateAttr

            //关联Cate

            //关联AttrName

            //进行排序

            //var query = _cateAttrRepository.Table;

           //var query = from ca in _cateAttrRepository.Table
           //         from a in _attrRepository.Table
           //         where ca.AttrId == a.AttrId
           //         select new CateAttrExpand
           //         {
           //             CateId = ca.CateId,
           //             AttrName = a.AttrName,
           //         };

            var query = from ca in _cateAttrRepository.Table
                        join a in _attrRepository.Table on ca.AttrId equals a.AttrId
                        select new CateAttrExpand
                        {
                            CateId = ca.CateId,
                            AttrName = a.AttrName,
                        };
             


           //var query = from ca in _cateAttrRepository.Table
           //         from c in _cateRepository.Table
           //         select new CateAttrExpand
           //         {
           //             CateId = ca.CateId,
           //             CateName = c.CateName,
           //         };

            query = query.OrderByDescending(q => q.CAID);

            int count = query.Count();

            return new Page<CateAttrExpand>(query, pageIndex, pageSize);
        }
    }
}
