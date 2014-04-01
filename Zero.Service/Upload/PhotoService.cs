using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zero.Data;
using Zero.Domain.Upload;
using Zero.Core.Web;

namespace Zero.Service.Upload
{
    public class PhotoService
    {
        private IRepository<Photo> _photoRepository;

        public PhotoService()
        {
            _photoRepository = new EfRepository<Photo>();
        }

        public ResultInfo Add(Photo photo)
        {
            _photoRepository.Add(photo);
            return new ResultInfo("上传成功");
        }

        public IPage<Photo> GetList(int pageIndex, int pageSize)
        {
            var query = _photoRepository.Table;
            query = query.OrderByDescending(b => b.CreateTime);
            return new Page<Photo>(query, pageIndex, pageSize);
        }
    }
}
