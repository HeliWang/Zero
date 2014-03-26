using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;

namespace Zero.Core.Web
{
    public class AuthCode
    {
        private string[] FontType = new string[] { "Verdana", "Arial", "宋体", "黑体" };
        private int _imgWidth;
        private int _imgHeight;

        public int ImgWidth
        {
            get { return _imgWidth; }
            set { _imgWidth = value; }
        }

        public int ImgHeight
        {
            get { return _imgHeight; }
            set { _imgHeight = value; }
        }

        /// <summary>
        /// 创建随机验证码
        /// </summary>
        /// <returns></returns>
        public byte[] CreateAuthCode(int authCodeLenght)
        {
            string acode = string.Empty;
            acode = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";
            char[] codes = acode.ToCharArray();
            Random rand = new Random();
            acode = "";
            for (int i = 0; i < authCodeLenght; i++)
            {
                acode += codes[rand.Next(0, codes.Length)].ToString();
            }

            CreateCookie(acode.ToLower());

            byte[] result = DrawAuthCode(acode);

            return result;
        }

        /// <summary>
        /// 保存验证码,Cookie或Session
        /// </summary>
        /// <param name="acode"></param>
        private void CreateCookie(string acode)
        {
            HttpResponse response = HttpContext.Current.Response;
            HttpCookie cookie = new HttpCookie("AuthCode");
            cookie.Value = acode;
            response.Cookies.Add(cookie);
        }

        private void CreateSession(string acode)
        {
            HttpContext.Current.Session["AuthCode"] = acode;
        }

        public static string GetSession()
        {
            return HttpContext.Current.Session["AuthCode"].ToString();
        }

        public static string GetCookie()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["AuthCode"];
            string acode = cookie.Value;
            return acode;
        }

        /// <summary>
        /// 绘制随机验证码
        /// </summary>
        private Byte[] DrawAuthCode(string acode)
        {
            int nRed, nGreen, nBlue;
            int nLines = 2;
            int DrawLineX1, DrawLineY1, DrawLineX2, DrawLineY2;
            int fontIndex, fontSize, PositionY;

            System.Drawing.Bitmap authImg = new System.Drawing.Bitmap(ImgWidth, ImgHeight);
            System.Drawing.Graphics graphic = System.Drawing.Graphics.FromImage(authImg);

            //随机生成器
            Random rand = new Random();

            //随机填充色
            //nRed = rand.Next(255) % 32 + 220;
            //nGreen = rand.Next(255) % 32 + 220;
            //nBlue = rand.Next(255) % 32 + 220;
            nRed = 224;
            nGreen = 224;
            nBlue = 224;

            System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(nRed, nGreen, nBlue));

            //随机背景色
            graphic.FillRectangle(brush, 0, 0, ImgWidth, ImgHeight);

            //随机画笔色
            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(nRed - 32, nGreen - 32, nBlue - 32), 1);
            for (int i = 0; i < nLines; i++)
            {
                DrawLineX1 = rand.Next() % ImgWidth;
                DrawLineY1 = rand.Next() % ImgHeight;
                DrawLineX2 = rand.Next() % ImgWidth;
                DrawLineY2 = rand.Next() % ImgHeight;
                graphic.DrawLine(pen, DrawLineX1, DrawLineY1, DrawLineX2, DrawLineY2);
            }

            //随机文字

            for (int i = 0; i < acode.Length; i++)
            {
                //随机字体
                fontIndex = rand.Next(3);
                //随机字体大小
                fontSize = rand.Next(12, 13);
                //随机字体位置，y轴为参考点
                PositionY = rand.Next(1, 2);

                nRed = rand.Next(255) % 228;
                nGreen = rand.Next(255) % 228;
                nBlue = rand.Next(255) % 228;

                System.Drawing.Font font = new System.Drawing.Font(FontType[fontIndex], fontSize, System.Drawing.FontStyle.Bold);
                brush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(nRed, nGreen, nBlue));
                graphic.DrawString(acode.Substring(i, 1), font, brush, 6 + (i * 16), PositionY);
            }
            graphic.Save();
            MemoryStream ms = new MemoryStream();
            authImg.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
    }
}
