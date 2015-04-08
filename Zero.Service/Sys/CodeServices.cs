using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zero.Data;
using Zero.Domain.Sys;
using Zero.Core.Web;

namespace Zero.Service.Sys
{
    public class CodeService : ICodeService
    {
        public IRepository<Code> _codeRepository;

        public CodeService(IRepository<Code> codeRepository)
        {
            _codeRepository = codeRepository;
        }

        public ResultInfo Add(Code code)
        {
            _codeRepository.Add(code);
            return new ResultInfo("添加成功");
        }

        public ResultInfo Edit(Code code)
        {
            _codeRepository.Update(code);
            return new ResultInfo("修改成功");
        }

        public ResultInfo Remove(string ids)
        {
            _codeRepository.Delete(ids);
            return new ResultInfo("删除成功");
        }

        public IPage<Code> GetList(int pageIndex, int pageSize)
        {
            var query = _codeRepository.Table;
            query = query.OrderByDescending(c => c.CreateTime);
            return new Page<Code>(query, pageIndex, pageSize);
        }

        public Code GetById(int productId)
        {
            return _codeRepository.GetById(productId);
        }
    }
}
