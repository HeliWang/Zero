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
    public interface ICateAttrService
    {
        ResultInfo Add(CateAttr cateAttr);

        ResultInfo Edit(CateAttr cateAttr);

        ResultInfo Delete(string ids);

        CateAttr GetById(int productId);

        IPage<CateAttr> GetList(CateAttrSearch search, int pageIndex, int pageSize);

        IPage<CateAttr> GetExpandList(int pageIndex, int pageSize);
    }
}
