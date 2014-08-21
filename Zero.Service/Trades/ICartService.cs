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
    public interface ICartService
    {
        void DeleteCart(User user, Cart cart);

        ResultInfo DeleteCart(User user, string cartIds);

        /// <summary>
        /// 添加或修改购物车项
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cart"></param>
        /// <returns></returns>
        ResultInfo SetCartQuantity(Cart cart);


        /// <summary>
        /// 获取购物车信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        List<Cart> GetCartList(User user);

        /// <summary>
        /// 获取购物车信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        List<Cart> GetCartList(int userId, string cartIds);

        /// <summary>
        /// 获取购物车信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        List<Cart> GetCartList(int userId, string productIds, string skuIds);
    }
}
