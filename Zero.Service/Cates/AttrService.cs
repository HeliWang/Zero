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
    public class AttrService :IAttrService
    {
        public IRepository<Attr> _attrRepository;

        public AttrService(IRepository<Attr> attrRepository)
        {
            _attrRepository = attrRepository;
        }

        public ResultInfo Add(Attr attr)
        {
            _attrRepository.Add(attr);
            return new ResultInfo("添加成功");
        }

        public ResultInfo Edit(Attr attr)
        {
            _attrRepository.Update(attr);
            return new ResultInfo("添加成功");
        }

        public ResultInfo Delete(string ids)
        {
            _attrRepository.Delete(ids);
            return new ResultInfo("删除成功");
        }

        public Attr GetById(int productId)
        {
            return _attrRepository.GetById(productId);
        }

        public IPage<Attr> GetList(int pageIndex, int pageSize)
        {
            var query = _attrRepository.Table;
            query = query.OrderByDescending(q => q.AttrId);
            return new Page<Attr>(query, pageIndex, pageSize);
        }

    }
}
