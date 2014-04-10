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
    public class AttrValueService
    {
        public IRepository<AttrValue> _attrValueRepository;

        public AttrValueService()
        {
            _attrValueRepository = new EfRepository<AttrValue>();
        }

        public ResultInfo Add(AttrValue attrValue)
        {
            _attrValueRepository.Add(attrValue);
            return new ResultInfo("添加成功");
        }

        public ResultInfo Edit(AttrValue attrValue)
        {
            _attrValueRepository.Update(attrValue);
            return new ResultInfo("添加成功");
        }

        public ResultInfo Delete(string ids)
        {
            _attrValueRepository.Delete(ids);
            return new ResultInfo("删除成功");
        }

        public AttrValue GetById(int productId)
        {
            return _attrValueRepository.GetById(productId);
        }

        public IPage<AttrValue> GetList(int AttrId, int pageIndex, int pageSize)
        {
            var query = _attrValueRepository.Table;
            if (AttrId>0)
                query = query.Where(a => a.AttrId == AttrId);
            query = query.OrderByDescending(q => q.ValueId);
            return new Page<AttrValue>(query, pageIndex, pageSize);
        }

    }
}
