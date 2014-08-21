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
    public interface IAttrValueService
    {
        ResultInfo Add(AttrValue attrValue);

        ResultInfo Edit(AttrValue attrValue);

        ResultInfo Delete(string ids);

        AttrValue GetById(int productId);

        List<AttrValue> GetList(int attrId);

        IPage<AttrValue> GetList(int AttrId, int pageIndex, int pageSize);
    }
}
