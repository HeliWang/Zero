using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zero.Data;
using Zero.Domain.Users;
using Zero.Domain.Orders;
using Zero.Domain.Products;
using Zero.Core.Web;

namespace Zero.Service.Orders
{
    //暂时不考虑临时用户
    public class CartService
    {
        private IRepository<Product> _productRepository;
        private IRepository<Sku> _skuRepository;
        private IRepository<Cart> _cartRepository;

        public CartService()
        {
            _productRepository = new EfRepository<Product>();
            _skuRepository = new EfRepository<Sku>();
            _cartRepository = new EfRepository<Cart>();

            //临时用户购物项和会员用户购物项转换
        }

        public ResultInfo DeleteCart(User user, string cartIds)
        {
            //批量删除以后研究
            _cartRepository.Delete(cartIds);
            return new ResultInfo("删除成功");
        }

        /// <summary>
        /// 添加或修改购物车项
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cart"></param>
        /// <returns></returns>
        public ResultInfo SetCartQuantity(Cart cart)
        {
            //保证UserId或GuestId至少有个值
            if (cart.UserId == 0 && cart.GuestId == "")
            {
                return new ResultInfo("无效用户");
            }

            var skuQuery = from s in _skuRepository.Table
                           where s.Attr == cart.Attr && s.ProductId == cart.ProductId
                           select s;
            var sku = skuQuery.FirstOrDefault();

            if (sku == null)
            {
                return new ResultInfo("该商品已下架或者库存不足");
            }

            cart.SkuId = sku.SkuId;

            var cartQuery = from c in  _cartRepository.Table
                            where c.SkuId==cart.SkuId && c.ProductId==cart.ProductId && c.UserId==cart.UserId && c.GuestId==cart.GuestId
                            select c;

            var oldCart = cartQuery.FirstOrDefault();


            if (oldCart == null)
            {
                if (cart.Quantity > sku.Quantity)
                {
                    cart.Quantity = sku.Quantity;
                }
                _cartRepository.Add(cart);
            }
            else
            {
                oldCart.Quantity += cart.Quantity;
                if (cart.Quantity > sku.Quantity)
                {
                    cart.Quantity = sku.Quantity;
                }
                _cartRepository.Update(oldCart);
            }

            return new ResultInfo("添加成功");
        }


        /// <summary>
        /// 获取购物车信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<Cart> GetCartList(User user)
        {
            var query = _cartRepository.Entities.Include("Product").Include("Sku").AsQueryable();

            if (user.UserId > 0)
            {
                query = from c in query
                        where c.UserId == user.UserId
                        select c;
            }
            else if (user.GuestId != string.Empty)
            {
                query = from c in query
                        where c.GuestId == user.GuestId
                        select c;
            }
            else
            {
                return new List<Cart>();
            }

            return query.ToList();
        }

        /// <summary>
        /// 获取购物车信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<Cart> GetCartList(int userId, string productIds, string skuIds)
        {
            var query = _cartRepository.Entities.Include("Product").Include("Sku").AsQueryable();

            if (userId > 0)
            {
                query = from c in query
                        where c.UserId == userId
                        select c;
            }
            return query.ToList();
        }
    }
}
