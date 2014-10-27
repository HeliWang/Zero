using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zero.Domain.Products;
using Zero.Domain.News;

namespace Zero.Web.Areas.Site.Models
{
    public class IndexModel
    {
        public List<Product> ProductList { get; set; }

        public List<NewsItem> NewsList { get; set; }
    }
}