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
    public class NewsService : INewsService
    {
        public IRepository<NewsItem> _newsItemRepository;

        public NewsService(IRepository<NewsItem> newsItemRepository)
        {
            _newsItemRepository = newsItemRepository;
        }

        public ResultInfo Add(NewsItem newsItem)
        {
            _newsItemRepository.Add(newsItem);
            return new ResultInfo("添加成功");
        }

        public ResultInfo Edit(NewsItem newsItem)
        {
            _newsItemRepository.Update(newsItem);
            return new ResultInfo("修改成功");
        }

        public ResultInfo Delete(string ids)
        {
            _newsItemRepository.Delete(ids);
            return new ResultInfo("删除成功");
        }

        public IPage<NewsItem> GetList(int pageIndex, int pageSize)
        {
            var query = _newsItemRepository.Table;
            query = query.OrderByDescending(b => b.CreateTime);
            return new Page<NewsItem>(query, pageIndex, pageSize);
        }

        public NewsItem GetById(int productId)
        {
            return _newsItemRepository.GetById(productId);
        }
    }
}
