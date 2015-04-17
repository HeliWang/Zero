using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zero.Data;
using Zero.Domain.Users;
using Zero.Domain.Trades;
using Zero.Domain.Products;
using Zero.Core.Web;

namespace Zero.Service.Trades
{
    public interface IOrderService
    {
        ResultInfo Confirm(User user, string cartIds);

        IPage<Order> GetList(int pageIndex, int pageSize);

        List<Snapshot> GetSnapshotList(int orderId);

        List<Snapshot> GetSnapshotList(List<int> orderIds);
    }
}
