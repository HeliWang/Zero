using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;

using Zero.Data;
using Zero.Domain.Upload;
using Zero.Core.Web;

namespace Zero.Service.Upload
{
    public class PhotoService
    {
        private IRepository<Photo> _photoRepository;

        public PhotoService(IRepository<Photo> photoRepository)
        {
            _photoRepository = photoRepository;
        }

        public ResultInfo Add(HttpFileCollectionBase files)
        {
            PhotoCate cate = new PhotoCate();
            cate.AllowCount = 5;
            cate.AllowExt = "gif,jpg";
            cate.AllowSize = 100;

            string result = CheckFiles(files, cate);

            if (result.Length > 0)
            {
                return new ResultInfo(1, result);
            }

            for (var i = 0; i < files.Count; i++)
            {
                Photo photo = new Photo();
                byte[] input = GetFileByte(files[i], photo, i);

                img.FileUploadService service = new img.FileUploadService();
                result = service.Upload(input, photo.Url);

                if (string.IsNullOrEmpty(result))
                {
                    _photoRepository.Add(photo);
                }
            }
            return new ResultInfo("上传成功");
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        public byte[] GetFileByte(HttpPostedFileBase file, Photo info, int i)
        {
            //生成路径
            DateTime dt = DateTime.Now;
            info.Ext = Path.GetExtension(file.FileName);
            info.Size = file.ContentLength;
            info.FileName = dt.ToString("yyyyMMddHHmmss") + i.ToString() + info.Ext;
            info.Url = string.Format(@"order/{0}/{1}/{2}", dt.Year, dt.Month, info.FileName);

            //获取二进制流数据
            int leng = file.ContentLength;
            byte[] input = new byte[leng];
            Stream inputStream = file.InputStream;
            inputStream.Read(input, 0, leng);
            return input;
        }

        /// <summary>
        /// 将二进制文件保存到指定的目录下
        /// </summary>
        /// <param name="input"></param>
        /// <param name="filePath"></param>
        /// <param name="directoryPath"></param>
        public void SaveFile(byte[] input, string filePath)
        {
            filePath = string.Format("{0}/{1}", AppDomain.CurrentDomain.BaseDirectory, filePath);
            string directoryPath = filePath.Substring(0, filePath.LastIndexOf("/"));

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(input);
            bw.Close();
            fs.Close();
        }

        /// <summary>
        /// 验证文件
        /// </summary>
        /// <param name="files"></param>
        /// <param name="cate"></param>
        /// <returns></returns>
        public string CheckFiles(HttpFileCollectionBase files, PhotoCate cate)
        {
            if (files.Count == 0)
            {
                return "请选择上传文件";
            }

            if (files.Count > cate.AllowCount)
            {
                return string.Format("最多可以上传{}张图片", cate.AllowCount);
            }

            for (var i = 0; i < files.Count; i++)
            {
                //验证文件名是否为空
                if (files[i] == null || files[i].ContentLength == 0)
                {
                    return string.Format("第{0}张图片无数据", i + 1);
                }

                //验证文件大小
                if (files[i].ContentLength > cate.AllowSize * 1024)
                {
                    return string.Format("第{0}张图片超过{1}kb", i + 1, cate.AllowSize);
                }

                //验证扩展名
                if (!CheckFileExt(cate.AllowExt, Path.GetExtension(files[i].FileName)))
                {
                    return string.Format("第{0}张图片格式不正确", i + 1, cate.AllowSize);
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// 检查格式
        /// </summary>
        public static bool CheckFileExt(string allowExt, string fileExt)
        {
            if (string.IsNullOrEmpty(fileExt))
            {
                return false;
            }

            string[] allowExtList = allowExt.ToLower().Split(',');

            for (int i = 0; i < allowExtList.Length; i++)
            {
                if ("." + allowExtList[i] == fileExt.ToLower())
                {
                    return true;
                }
            }

            return false;
        }

        public IPage<Photo> GetList(int pageIndex, int pageSize)
        {
            var query = _photoRepository.Table;
            query = query.OrderByDescending(b => b.FileId);
            return new Page<Photo>(query, pageIndex, pageSize);
        }
    }
}
