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
    public interface ICustomService
    {
        ResultInfo Add(Custom custom);

        ResultInfo Edit(Custom custom);

        ResultInfo Delete(string ids);

        IPage<Custom> GetList(int pageIndex, int pageSize);

        Custom GetById(int productId);
    }
}
