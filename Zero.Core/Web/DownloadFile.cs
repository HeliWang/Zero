using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Core.Web
{
    /// <summary>
    /// 大文件下载
    /// 1. 将数据分成较小的部分，然后将其移动到输出流以供下载，从而获取这些数据。
　　/// 2. 根据下载的文件类型来指定 Response.ContentType 。（参考OSChina的这个网址可以找到大部分文件类型的对照表：http://tool.oschina.net/commons）
　　/// 3. 在每次写完response时记得调用 Response.Flush()
　　/// 4. 在循环下载的过程中使用 Response.IsClientConnected 这个判断可以帮助程序尽早发现连接是否正常。若不正常，可以及早的放弃下载，以释放所占用的服务器资源。
    /// 5. 在下载结束后，需要调用 Response.End() 来保证当前线程可以在最后被终止掉。
    /// </summary>
    public partial class DownloadFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.IO.Stream iStream = null;
            // Buffer to read 10K bytes in chunk:
            byte[] buffer = new Byte[10000];
            // Length of the file:
            int length;
            // Total bytes to read.
            long dataToRead;
            // Identify the file to download including its path.
            string filepath = Server.MapPath("/") + "./Files/TextFile1.txt";
            // Identify the file name.
            string filename = System.IO.Path.GetFileName(filepath);
            try
            {
                // Open the file.
                iStream = new System.IO.FileStream(filepath, System.IO.FileMode.Open,
                            System.IO.FileAccess.Read, System.IO.FileShare.Read);
                // Total bytes to read.
                dataToRead = iStream.Length;
                Response.Clear();
                Response.ClearHeaders();
                Response.ClearContent();
                Response.ContentType = "text/plain"; // Set the file type
                Response.AddHeader("Content-Length", dataToRead.ToString());
                Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                // Read the bytes.
                while (dataToRead > 0)
                {
                    // Verify that the client is connected.
                    if (Response.IsClientConnected)
                    {
                        // Read the data in buffer.
                        length = iStream.Read(buffer, 0, 10000);
                        // Write the data to the current output stream.
                        Response.OutputStream.Write(buffer, 0, length);
                        // Flush the data to the HTML output.
                        Response.Flush();
                        buffer = new Byte[10000];
                        dataToRead = dataToRead - length;
                    }
                    else
                    {
                        // Prevent infinite loop if user disconnects
                        dataToRead = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                // Trap the error, if any.
                Response.Write("Error : " + ex.Message);
            }
            finally
            {
                if (iStream != null)
                {
                    //Close the file.
                    iStream.Close();
                }
                Response.End();
            }
        }
    }
}
