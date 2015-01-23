using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zero.Data;
using Zero.Domain.Products;
using Zero.Core.Web;

namespace Zero.Service.Products
{
    public interface IProductService
    {
        ResultInfo Add(Product product);

        ResultInfo Edit(Product product, ProductDesc productDesc, List<ProductPhoto> productPhotoList, List<Sku> skuList);

        ResultInfo Delete(string ids);

        IPage<Product> GetList(int pageIndex, int pageSize);

        IPage<Product> GetList(ProductSearch search, int pageIndex, int pageSize);

        List<Product> GetList(int quantity);

        Product GetById(int productId);

        ProductDesc GetDescById(int productId);

        List<Sku> GetSkuList(int productId);

        List<ProductPhoto> GetPhotoListById(int productId);
    }
}
