﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zero.Data;
using Zero.Domain.Products;
using Zero.Core.Web;

namespace Zero.Service.Products
{
    public class ProductService : IProductService
    {
        private IRepository<Product> _productRepository;
        private IRepository<Sku> _skuRepository;
        private IRepository<ProductDesc> _productDescRepository;
        private IRepository<ProductPhoto> _productPhotoRepository;

        public ProductService(IRepository<Product> productRepository,
            IRepository<Sku> skuRepository,
            IRepository<ProductDesc> productDescRepository,
            IRepository<ProductPhoto> productPhotoRepository)
        {
            _productRepository = productRepository;
            _skuRepository = skuRepository;
            _productDescRepository = productDescRepository;
            _productPhotoRepository = productPhotoRepository;
        }

        public ResultInfo Add(Product product)
        {
            product.Photo = product.PhotoList[0].Url;
            var productId = _productRepository.Add(product).ProductId;


            foreach (ProductPhoto photo in product.PhotoList)
            {
                photo.ProductId = productId;
                photo.PhotoId = _productPhotoRepository.Add(photo).PhotoId;
            }

            //未测试是否有关联插入
            foreach (Sku sku in product.SkuList)
            {
                sku.ProductId = productId;

                var photo = product.PhotoList.Where(p => sku.Attr.Contains(p.Attr)).ToList();

                if (photo.Count > 0)
                {
                    sku.PhotoId = photo[0].PhotoId;
                }

                _skuRepository.Add(sku);
            }

            product.Desc.ProductId = productId;
            _productDescRepository.Add(product.Desc);

            return new ResultInfo("添加成功");
        }

        public ResultInfo Edit(Product product, ProductDesc productDesc, List<ProductPhoto> productPhotoList, List<Sku> skuList)
        {
            _productRepository.Update(product);
            return new ResultInfo("修改成功");
        }

        public ResultInfo Delete(string ids)
        {
            _productRepository.Delete(ids);
            return new ResultInfo("删除成功");
        }

        public IPage<Product> GetList(int pageIndex, int pageSize)
        {
            var query = _productRepository.Table;
            query = query.OrderByDescending(b => b.CreateTime);
            return new Page<Product>(query, pageIndex, pageSize);
        }

        public IPage<Product> GetList(ProductSearch search, int pageIndex, int pageSize)
        {
            var query = _productRepository.Table;
            query = query.OrderByDescending(b => b.CreateTime);
            return new Page<Product>(query, pageIndex, pageSize);
        }

        public Product GetById(int productId)
        {
            return _productRepository.GetById(productId);
        }

        public List<Sku> GetSkuList(int productId)
        {
            var query = _skuRepository.Table;

            query = from s in query
                    where s.ProductId == productId
                    select s;

            query = query.OrderByDescending(b => b.SkuId);
            return query.ToList();
        }

    }
}
