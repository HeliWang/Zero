using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zero.Data;
using Zero.Domain.Customs;
using Zero.Core.Web;

namespace Zero.Service.Customs
{
    public class CustomService :ICustomService
    {
        public IRepository<Custom> _customRepository;

        public CustomService(IRepository<Custom> customRepository)
        {
            _customRepository = customRepository;
        }

        public ResultInfo Add(Custom custom)
        {
            _customRepository.Add(custom);
            return new ResultInfo("添加成功");
        }

        public ResultInfo Edit(Custom custom)
        {
            _customRepository.Update(custom);
            return new ResultInfo("修改成功");
        }

        public ResultInfo Delete(string ids)
        {
            _customRepository.Delete(ids);
            return new ResultInfo("删除成功");
        }

        public IPage<Custom> GetList(int pageIndex, int pageSize)
        {
            var query = _customRepository.Table;
            query = query.OrderByDescending(b => b.CustomId);
            return new Page<Custom>(query, pageIndex, pageSize);
        }

        public Custom GetById(int productId)
        {
            return _customRepository.GetById(productId);
        }
    }
}
