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
    public interface ICodeService
    {
        ResultInfo Send(Code code);

        ResultInfo Add(Code code);

        ResultInfo Edit(Code code);

        ResultInfo Remove(string ids);

        IPage<Code> GetList(int pageIndex, int pageSize);

        Code GetById(int productId);
    }
}
