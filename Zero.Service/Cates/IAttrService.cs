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
    public interface IAttrService
    {
        ResultInfo Add(Attr attr);

        ResultInfo Edit(Attr attr);

        ResultInfo Delete(string ids);

        Attr GetById(int productId);

        IPage<Attr> GetList(int pageIndex, int pageSize);
    }
}
