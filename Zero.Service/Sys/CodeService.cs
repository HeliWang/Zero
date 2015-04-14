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

        public ResultInfo Send(Code code)
        {
            //判断验证码是否正确
            var oldCode = (from c in _codeRepository.Table
                        where c.UserId == code.UserId && c.CodeType == code.CodeType &&c.SendType==code.SendType
                        select c).OrderByDescending(c => c.CreateTime).FirstOrDefault();

            if (oldCode != null && oldCode.CodeStatus == (int)CodeStatus.发送成功 && (DateTime.Now - oldCode.CreateTime).TotalSeconds < 120)
            {
                return new ResultInfo(1, "120秒才能重新获取，请等待");
            }

            
            code.Num = Utils.GetRandomNum(6);
            code.Content = string.Format("您的验证码为{0},请保管好你的验证码。", code.Num);
            code.Result = "<code>0</code>";
            code.CodeStatus = (int)CodeStatus.发送成功;
            code.CreateTime = DateTime.Now;
            code.UpdateTime = DateTime.Now;

            _codeRepository.Add(code);

            return new ResultInfo("发送成功");
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
