using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;

namespace Zero.Core.Web
{
    public class ImageHelper
    {
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">
        /// 生成缩略图的方式
        /// HW : 指定高宽缩放（可能变形）
        /// W : 指定宽，高按比例缩放
        /// H : 指定高，宽按比例缩放
        /// Cut : 指定高宽裁剪（不变形）
        /// </param>    
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            if (width > 0 && height > 0 && width < originalImage.Width && height < originalImage.Width)
            {
                switch (mode)
                {
                    case "0":
                        //按HW来缩放，判断高和宽谁最大
                        if (originalImage.Width / originalImage.Height > towidth / toheight)
                        {
                            //按W来缩放
                            toheight = originalImage.Height * width / originalImage.Width;
                        }
                        else
                        {
                            //按H来缩放
                            towidth = originalImage.Width * height / originalImage.Height;
                        }
                        break;

                    case "1":
                        //"Cut"剪切图片，获取中间部分
                        if (originalImage.Width / originalImage.Height > towidth / toheight)
                        {
                            oh = originalImage.Height;
                            ow = originalImage.Height * towidth / toheight;
                            y = 0;
                            x = (originalImage.Width - ow) / 2;
                        }
                        else
                        {
                            ow = originalImage.Width;
                            oh = originalImage.Width * height / towidth;
                            x = 0;
                            y = (originalImage.Height - oh) / 2;
                        }
                        break;
                }
            }
            else if (width > 0 && width < originalImage.Width)
            {
                //按W来缩放
                toheight = originalImage.Height * width / originalImage.Width;
            }
            else if (height > 0 && height < originalImage.Height)
            {
                //按H来缩放
                towidth = originalImage.Width * height / originalImage.Height;
            }
            else
            {
                towidth = originalImage.Width;
                toheight = originalImage.Height;
            }

            //switch (mode)
            //{
            //    case "HW":
            //        break;
            //    case "W":
            //        toheight = originalImage.Height * width / originalImage.Width;
            //        break;
            //    case "H":
            //        towidth = originalImage.Width * height / originalImage.Height;
            //        break;
            //    case "Cut":
            //        if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
            //        {
            //            oh = originalImage.Height;
            //            ow = originalImage.Height * towidth / toheight;
            //            y = 0;
            //            x = (originalImage.Width - ow) / 2;
            //        }
            //        else
            //        {
            //            ow = originalImage.Width;
            //            oh = originalImage.Width * height / towidth;
            //            x = 0;
            //            y = (originalImage.Height - oh) / 2;
            //        }
            //        break;
            //    default:
            //        break;
            //}

            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
                new System.Drawing.Rectangle(x, y, ow, oh),
                System.Drawing.GraphicsUnit.Pixel);
            try
            {
                //先创建目录
                FileHelper.CreateDirectory(thumbnailPath.Substring(0, thumbnailPath.LastIndexOf("\\")));
                //再保存图片
                bitmap.Save(thumbnailPath, GetFormat(thumbnailPath));

                //关键质量控制 设置 原图片 对象的 EncoderParameters 对象
                //EncoderParameters parameters = new EncoderParameters(1);
                //parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, ((long)100));
                //bitmap.Save(thumbnailPath, GetCodecInfo("image/" + GetFormat(thumbnailPath).ToString().ToLower()), parameters);
                //parameters.Dispose();

            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }

        /// <summary>
        /// 获取图像编码解码器的所有相关信息
        /// </summary>
        /// <param name="mimeType">包含编码解码器的多用途网际邮件扩充协议 (MIME) 类型的字符串</param>
        /// <returns>返回图像编码解码器的所有相关信息</returns>
        public static ImageCodecInfo GetCodecInfo(string mimeType)
        {
            ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo ici in CodecInfo)
            {
                if (ici.MimeType == mimeType) return ici;
            }
            return null;
        }

        /// <summary>
        /// 获取图片的格式
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public static ImageFormat GetFormat(string path)
        {
            string format = path.Substring(path.LastIndexOf(".") + 1);
            switch (format)
            {
                case "jpeg":
                case "jpg":
                    return ImageFormat.Jpeg;
                case "gif":
                    return ImageFormat.Gif;
                case "png":
                    return ImageFormat.Png;
                case "bmp":
                    return ImageFormat.Bmp;
                default:
                    return ImageFormat.Jpeg;
            }
        }

        /// <summary>
        /// 获取图片输出的格式
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string GetContentType(string format)
        {
            switch (format)
            {
                case "jpeg":
                case "jpg":
                    return "image/jpeg";
                case "gif":
                    return "image/gif";
                case "png":
                    return "image/png";
                case "bmp":
                    return "image/bmp";
                default:
                    return "image/jpeg";
            }
        }

        /// <summary>
        /// 在图片上增加文字水印
        /// </summary>
        /// <param name="path">原服务器图片路径</param>
        /// <param name="pathSY">生成的带文字水印的图片路径</param>
        /// <param name="addText">水印文字</param>
        public static void AddWater(string path, string pathSY, string addText)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(path);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
            g.DrawImage(image, 0, 0, image.Width, image.Height);
            System.Drawing.Font f = new System.Drawing.Font("Verdana", 60);
            System.Drawing.Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.Green);

            g.DrawString(addText, f, b, 35, 35);
            g.Dispose();

            image.Save(pathSY);
            image.Dispose();
        }

        /// <summary>
        /// 加图片水印
        /// </summary>
        /// <param name="path">原文件名</param>
        /// <param name="filename">生成文件名</param>
        /// <param name="watermarkFilename">水印文件名</param>
        /// <param name="watermarkStatus">图片水印位置:0=不使用 1=左上 2=中上 3=右上 4=左中 ... 9=右下</param>
        /// <param name="quality">是否是高质量图片 取值范围0--100</param> 
        /// <param name="watermarkTransparency">图片水印透明度 取值范围1--10 (10为不透明)</param>
        public static void AddImageSignPicture(string path, string filename, string watermarkFilename, int watermarkStatus, int quality, int watermarkTransparency)
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(path);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(img);

            System.Drawing.Image watermark = new System.Drawing.Bitmap(watermarkFilename);

            if (watermark.Height >= img.Height || watermark.Width >= img.Width)
            {
                return;
            }

            System.Drawing.Imaging.ImageAttributes imageAttributes = new System.Drawing.Imaging.ImageAttributes();
            System.Drawing.Imaging.ColorMap colorMap = new System.Drawing.Imaging.ColorMap();

            colorMap.OldColor = System.Drawing.Color.FromArgb(255, 0, 255, 0);
            colorMap.NewColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
            System.Drawing.Imaging.ColorMap[] remapTable = { colorMap };

            imageAttributes.SetRemapTable(remapTable, System.Drawing.Imaging.ColorAdjustType.Bitmap);

            float transparency = 0.5F;
            if (watermarkTransparency >= 1 && watermarkTransparency <= 10)
            {
                transparency = (watermarkTransparency / 10.0F);
            }

            float[][] colorMatrixElements = {
                                        new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                                        new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
                                        new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
                                        new float[] {0.0f,  0.0f,  0.0f,  transparency, 0.0f},
                                        new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}
                                    };

            System.Drawing.Imaging.ColorMatrix colorMatrix = new System.Drawing.Imaging.ColorMatrix(colorMatrixElements);

            imageAttributes.SetColorMatrix(colorMatrix, System.Drawing.Imaging.ColorMatrixFlag.Default, System.Drawing.Imaging.ColorAdjustType.Bitmap);

            int xpos = 0;
            int ypos = 0;

            switch (watermarkStatus)
            {
                case 1:
                    xpos = (int)(img.Width * (float).01);
                    ypos = (int)(img.Height * (float).01);
                    break;
                case 2:
                    xpos = (int)((img.Width * (float).50) - (watermark.Width / 2));
                    ypos = (int)(img.Height * (float).01);
                    break;
                case 3:
                    xpos = (int)((img.Width * (float).99) - (watermark.Width));
                    ypos = (int)(img.Height * (float).01);
                    break;
                case 4:
                    xpos = (int)(img.Width * (float).01);
                    ypos = (int)((img.Height * (float).50) - (watermark.Height / 2));
                    break;
                case 5:
                    xpos = (int)((img.Width * (float).50) - (watermark.Width / 2));
                    ypos = (int)((img.Height * (float).50) - (watermark.Height / 2));
                    break;
                case 6:
                    xpos = (int)((img.Width * (float).99) - (watermark.Width));
                    ypos = (int)((img.Height * (float).50) - (watermark.Height / 2));
                    break;
                case 7:
                    xpos = (int)(img.Width * (float).01);
                    ypos = (int)((img.Height * (float).99) - watermark.Height);
                    break;
                case 8:
                    xpos = (int)((img.Width * (float).50) - (watermark.Width / 2));
                    ypos = (int)((img.Height * (float).99) - watermark.Height);
                    break;
                case 9:
                    xpos = (int)((img.Width * (float).99) - (watermark.Width));
                    ypos = (int)((img.Height * (float).99) - watermark.Height);
                    break;
            }

            g.DrawImage(watermark, new System.Drawing.Rectangle(xpos, ypos, watermark.Width, watermark.Height), 0, 0, watermark.Width, watermark.Height, System.Drawing.GraphicsUnit.Pixel, imageAttributes);

            System.Drawing.Imaging.ImageCodecInfo[] codecs = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
            System.Drawing.Imaging.ImageCodecInfo ici = null;
            foreach (System.Drawing.Imaging.ImageCodecInfo codec in codecs)
            {
                if (codec.MimeType.IndexOf("jpeg") > -1)
                {
                    ici = codec;
                }
            }
            System.Drawing.Imaging.EncoderParameters encoderParams = new System.Drawing.Imaging.EncoderParameters();
            long[] qualityParam = new long[1];
            if (quality < 0 || quality > 100)
            {
                quality = 80;
            }
            qualityParam[0] = quality;

            System.Drawing.Imaging.EncoderParameter encoderParam = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qualityParam);
            encoderParams.Param[0] = encoderParam;

            if (ici != null)
            {
                img.Save(filename, ici, encoderParams);
            }
            else
            {
                img.Save(filename);
            }

            g.Dispose();
            img.Dispose();
            watermark.Dispose();
            imageAttributes.Dispose();
        }

        /// <summary>
        /// 在图片上生成图片水印
        /// </summary>
        /// <param name="path">原服务器图片路径</param>
        /// <param name="pathSY">生成的带图片水印的图片路径</param>
        /// <param name="pathSYP">水印图片路径</param>
        public static void AddWaterPicture(string path, string pathSY, string pathSYP)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(path);
            System.Drawing.Image copyImage = System.Drawing.Image.FromFile(pathSYP);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
            g.DrawImage(copyImage, new System.Drawing.Rectangle(image.Width - copyImage.Width, image.Height - copyImage.Height, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width, copyImage.Height, System.Drawing.GraphicsUnit.Pixel);
            g.Dispose();

            image.Save(pathSY);
            image.Dispose();
        }

        /// <summary>
        /// 获取各种模式的图片地址
        /// </summary>
        /// <param name="path">图片弟子</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="model">模式（0=按比例进行缩放|1=按比例缩放再按1/2进行裁剪|）</param>
        /// <returns></returns>
        public static string GetPhotoUrl(string path, int width, int height, int model)
        {

            string size = string.Format("_{0}x{1}_{2}", width, height, model);
            string name = path.Substring(path.LastIndexOf("/") + 1);
            string format = name.Substring(name.IndexOf("."));
            path = path.Substring(0, path.Length - name.Length);
            name = name.Substring(0, name.Length - format.Length);
            //return path + Zero.Core.Security.Encrypt.EncodeDES(name + size, "aaaaaaaaaa") + format;
            return Zero.Core.Config.SiteConfig.PhotoSiteUrl + "tb/" + path + HttpUtility.HtmlEncode(name + size) + format;
        }
    }
}
