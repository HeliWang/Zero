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
    public interface IPhotoService
    {
        ResultInfo Add(HttpFileCollectionBase files);

        /// <summary>
        /// 保存图片
        /// </summary>
        byte[] GetFileByte(HttpPostedFileBase file, Photo info, int i);

        /// <summary>
        /// 将二进制文件保存到指定的目录下
        /// </summary>
        /// <param name="input"></param>
        /// <param name="filePath"></param>
        /// <param name="directoryPath"></param>
        void SaveFile(byte[] input, string filePath);

        /// <summary>
        /// 验证文件
        /// </summary>
        /// <param name="files"></param>
        /// <param name="cate"></param>
        /// <returns></returns>
        string CheckFiles(HttpFileCollectionBase files, PhotoCate cate);

        /// <summary>
        /// 检查格式
        /// </summary>
        bool CheckFileExt(string allowExt, string fileExt);

        IPage<Photo> GetList(int pageIndex, int pageSize);
    }
}
