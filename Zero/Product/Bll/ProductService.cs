//using System.Collections.Generic;

//using Zero.Core.Web;
//using Zero.Core.Pattern;
//using Zero.Category.Data;
//using Zero.Category.Model;
//using Zero.Product.Data;
//using Zero.Product.Model;
//using Zero.Category.Bll;

//namespace Zero.Product.Bll
//{
//    public class ProductService : Singleton<ProductService>
//    {
//        private AttrService _attrService;

//        private ProductMapper _productMapper;

//        private ProductDescMapper _productDescMapper;

//        private ProductPhotoMapper _productPhotoMapper;


//        private SkuMapper _skuMapper;

//        public ProductService()
//        {
//            _attrService = Singleton.GetInstance<AttrService>();
//            _productMapper = Singleton.GetInstance<ProductMapper>();
//            _productDescMapper = Singleton.GetInstance<ProductDescMapper>();
//            _productPhotoMapper = Singleton.GetInstance<ProductPhotoMapper>();
//            _skuMapper = Singleton.GetInstance<SkuMapper>();
//        }

//        #region 创建商品草稿

//        /// <summary>
//        /// 保存草稿
//        /// </summary>
//        /// <param name="productInfo"></param>
//        /// <param name="productDetailInfo"></param>
//        /// <returns></returns>
//        public ResultInfo<ProductInfo> CreateDraft(ProductInfo productInfo, ProductDescInfo productDetailInfo)
//        {
//            ResultInfo<ProductInfo> resultInfo = new ResultInfo<ProductInfo>();
//            return resultInfo;
//        }

//        #endregion

//        #region 创建商品信息

//        /// <summary>
//        /// 创建商品
//        /// </summary>
//        /// <param name="productInfo"></param>
//        /// <param name="productDetailInfo"></param>
//        /// <returns></returns>
//        public ResultInfo Create(ProductInfo productInfo, ProductDescInfo productDetailInfo,
//            List<ProductPhotoInfo> productPhotoList, List<SkuInfo> skuList)
//        {
//            productInfo = _productMapper.Create(productInfo);

//            if (productInfo != null)
//            {
//                productDetailInfo.ProductId = productInfo.ProductId;
//                _productDescMapper.Create(productDetailInfo);

//                foreach (ProductPhotoInfo photoInfo in productPhotoList)
//                {
//                    photoInfo.ProductId = productInfo.ProductId;
//                    _productPhotoMapper.Create(photoInfo);
//                }

//                foreach (SkuInfo skuInfo in skuList)
//                {
//                    skuInfo.ProductId = productInfo.ProductId;
//                    _skuMapper.Create(skuInfo);
//                }
//            }

//            return new ResultInfo("添加成功");
//        }

//        #endregion


//        #region 修改商品信息
        
//        /// <summary>
//        /// 修改商品信息
//        /// </summary>
//        /// <param name="productInfo"></param>
//        /// <param name="productDetailInfo"></param>
//        /// <param name="productPhotoList"></param>
//        /// <param name="skuList"></param>
//        /// <returns></returns>
//        public ResultInfo<int> Update(ProductInfo productInfo, ProductDescInfo productDetailInfo,
//            List<ProductPhotoInfo> productPhotoList, List<SkuInfo> skuList)
//        {
//            ResultInfo<int> resultInfo = new ResultInfo<int>();

//            if (!_productMapper.Exist(productInfo.ProductId))
//            {
                
//            }

//            _productMapper.Update(productInfo);

//            _productDescMapper.Update(productDetailInfo);

            

//            return resultInfo;
//        }

//        #endregion


//        public int Delete(int productId)
//        {
//            return _productMapper.Delete(productId);
//        }

//        public Page<ProductInfo> GetList(int pageIndex, int pageSize, string condition)
//        {
//            return _productMapper.GetList(pageIndex, pageSize, condition);
//        }
//    }

    
//}
