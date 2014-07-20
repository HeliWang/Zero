using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zero.Data;
using Zero.Domain.News;
using Zero.Core.Web;

namespace Zero.Service.News
{
    public interface INewsService
    {
        ResultInfo Add(NewsItem newsItem);

        ResultInfo Edit(NewsItem newsItem);

        ResultInfo Delete(string ids);

        IPage<NewsItem> GetList(int pageIndex, int pageSize);

        NewsItem GetById(int productId);
    }
}
