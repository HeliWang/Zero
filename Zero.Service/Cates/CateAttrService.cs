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
            return new ResultInfo("修改成功");
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

        public IPage<CateAttr> GetList(CateAttrSearch search, int pageIndex, int pageSize)
        {
            var query = _cateAttrRepository.Entities.Include("Cate").Include("Attr").AsQueryable();

            if (search.CateId > 0)
            {
                Cate cate = _cateRepository.GetById(search.CateId);

                if (cate != null)
                {
                    query = from a in query
                            join c in _cateRepository.Table on a.CateId equals c.CateId
                            where c.Lid >= cate.Lid && c.Rid <= cate.Rid
                            select a;
                }
            }

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
    }
}
