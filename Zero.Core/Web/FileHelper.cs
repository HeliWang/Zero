using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;

namespace Zero.Core.Web
{
    public class FileHelper
    {
        /// <summary>
        /// 获取动态页面生成静态页面
        /// </summary>
        public static void SaveHtml(string path, bool append, string content, string encoding)
        {
            StreamWriter stream = new StreamWriter(GetMapPath(path), append, Encoding.GetEncoding(encoding));
            stream.Write(content);
            stream.Flush();
            stream.Close();
        }

        /// <summary>
        /// 获取动态页面生成静态页面
        /// </summary>
        public static void SaveHtml(string path, string content)
        {
            SaveHtml(path, false, content, "utf-8");
        }

        /// <summary>
        /// 获取站点绝对路径
        /// </summary>
        public static string GetMapPath(string strPath)
        {
            if (strPath.IndexOf(":") == -1)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else
            {
                return strPath;
            }
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        public static void SaveImage(HttpPostedFile file)
        {
            string allow_ext = "jpg,png,gif";
            int max_size = 5;

            //验证文件名是否为空
            if (file == null && file.ContentLength < 1)
            {
                throw new Exception("请上传的图片!");
            }
            string fileExt = Path.GetExtension(file.FileName);
            //验证扩展名
            if (CheckFileExt(allow_ext, file.FileName))
            {
                throw new Exception("请上传正确格式的图片");
            }
            //验证文件大小
            if (file.ContentLength > max_size * 1024 * 1024)
            {
                throw new Exception(string.Format("图片不能超过{0}M", max_size));
            }

            //获取二进制流数据
            int leng = file.ContentLength;
            byte[] input = new byte[leng];
            Stream inputStream = file.InputStream;
            inputStream.Read(input, 0, leng);

            //生成文件
            //if (!Directory.Exists(filePath))
            //{
            //    Directory.CreateDirectory(filePath);
            //}
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + fileExt;
            string filePath = string.Format(@"{0}\uploaded\{1}", AppDomain.CurrentDomain.BaseDirectory, fileName);
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
        /// 保存图片
        /// </summary>
        public static void SaveImages()
        {
            HttpFileCollection files = HttpContext.Current.Request.Files;

            if (files.Count < 1)
            {
                throw new Exception("请上传图片");
            }
            //foreach (HttpPostedFile file in HttpContext.Current.Request.Files)
            //{   
            //}
            for (int i = 0; i < files.Count; i++)
            {
                SaveImage(files[i]);
            }
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        public static void SaveFile()
        {
            //附近上传
            //图片上传
        }
        
        /// <summary>
        /// 创建文件目录
        /// </summary>
        /// <param name="path">路径</param>
        public static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// 检查上传的文件
        /// </summary>
        /// <param name="file">上传的文件流</param>
        /// <param name="allowSize">允许的大小</param>
        /// <param name="allowExt">允许的格式</param>
        /// <returns></returns>
        public static string CheckFile(HttpPostedFile file, int allowSize, string allowExt)
        {
            //验证文件名是否为空
            if (file == null || file.ContentLength < 1)
            {
                return "图片没数据";
            }

            //验证扩展名
            if (!CheckFileExt(allowExt, Path.GetExtension(file.FileName)))
            {
                return "图片格式不正确";
            }

            //验证文件大小
            if (file.ContentLength > allowSize * 1024 * 1024)
            {
                return string.Format("图片不能超过{0}m", allowSize);
            }

            return string.Empty;
        }

        /// <summary>
        /// 文件格式检查格式
        /// </summary>
        /// <param name="allowExt">允许的格式</param>
        /// <param name="fileExt">文件格式</param>
        /// <returns></returns>
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

        /// <summary>
        /// 保存图片
        /// </summary>
        public static byte[] GetFile(HttpPostedFile file)
        {
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
        /// <param name="input">二进制流</param>
        /// <param name="filePath">文件地址</param>
        public static void SaveFile(byte[] input, string filePath)
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
    }
}
