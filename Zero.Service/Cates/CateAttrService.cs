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
    public class CateAttrService
    {
        public IRepository<CateAttr> _cateAttrRepository;

        public CateAttrService()
        {
            _cateAttrRepository = new EfRepository<CateAttr>();
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
            var query = _cateAttrRepository.Table;
            query = query.OrderByDescending(q => q.CateId);
            return new Page<CateAttr>(query, pageIndex, pageSize);
        }

    }
}
