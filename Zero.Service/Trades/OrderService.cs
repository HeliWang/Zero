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
    public class OrderService :IOrderService
    {
        public ICartService _cartService;
        public IRepository<Order> _orderRepository;
        public IRepository<Snapshot> _snapshotRepository;

        public OrderService(ICartService cartService,
            IRepository<Order> orderRepository,
            IRepository<Snapshot> snapshotRepository)
        {
            _cartService = cartService;
            _orderRepository = orderRepository;
            _snapshotRepository = snapshotRepository;
            
        }
        
        public ResultInfo Confirm(User user,string cartIds)
        {
            List<Cart> cartList = _cartService.GetCartList(user.UserId, cartIds);

            Order order = new Order();
            List<Snapshot> snapshotList = new List<Snapshot>();

            order.BuyerId = user.UserId;
            order.Quantity = cartList.Count;
            order.OrderNo = "123456";
            

            foreach (var cart in cartList)
            {
                Snapshot snapshot = new Snapshot();

                snapshot.UserId = cart.Product.UserId;
                snapshot.CateId = cart.CartId;
                snapshot.ProductName = cart.Product.ProductName;
                snapshot.Attr = cart.Attr;
                snapshot.Photo = cart.ProductPhoto.Url;
                snapshot.Price = cart.Sku.Price;
                snapshot.FinalPrice = cart.Sku.Price;
                snapshot.Quantity = cart.Quantity;
                snapshot.TotalPrice = snapshot.FinalPrice * snapshot.Quantity;

                order.Price += snapshot.TotalPrice;

                snapshotList.Add(snapshot);
                _cartService.DeleteCart(user, cart);
            }

            order.Freight = 0;
            order.RealPay = order.Price;

            int orderId = _orderRepository.Add(order).OrderId;

            foreach (var snapshot in snapshotList)
            {
                snapshot.OrderId = orderId;
                _snapshotRepository.Add(snapshot);
            }

            return new ResultInfo("添加成功");
        }

        public IPage<Order> GetList(int pageIndex, int pageSize)
        {
            var query = _orderRepository.Table;
            query = query.OrderByDescending(o => o.OrderTime);
            return new Page<Order>(query, pageIndex, pageSize);
        }

        public IPage<Order> GetList(OrderSearch search,int pageIndex, int pageSize)
        {
            var query = _orderRepository.Table;
            query = query.OrderByDescending(o => o.OrderTime);
            return new Page<Order>(query, pageIndex, pageSize);
        }

        public List<Snapshot> GetSnapshotList(int orderId)
        {
            var query = _snapshotRepository.Table;

            query = from s in query
                    where s.OrderId == orderId
                    select s;

            query = query.OrderByDescending(s => s.CreateTime);

            return query.ToList();
        }

        public List<Snapshot> GetSnapshotList(List<int> orderIds)
        {
            var query = _snapshotRepository.Table;

            query = from s in query
                    where orderIds.Contains(s.OrderId) 
                    select s;

            query = query.OrderByDescending(s => s.CreateTime);

            return query.ToList();
        }
    }
}
