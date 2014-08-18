using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zero.Data;
using Zero.Domain.Cates;
using Zero.Domain.Customs;
using Zero.Domain.Products;
using Zero.Core.Web;

namespace Zero.Service.Customs
{
    public class CustomService : ICustomService
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

        public string GetProductSql(int quantity, ProductSearch productSearch)
        {
            string result = "";
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(productSearch.Keyword))
            {
                sb.AppendFormat(" and ProductName like '%{0}%'", productSearch.Keyword);
            }

            if (productSearch.CateId > 0)
            {
                sb.AppendFormat(" and CateId={0}", productSearch.CateId);
            }

            if (sb.Length > 0)
            {
                result = string.Format("select top {0} * from [Product] where Status={1} {2}", quantity, 1, sb.ToString());
            }

            return result;
        }

        public string GetNewsSql()
        {
            return "";
        }
    }
}
