using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Mail;

namespace Zero.Core.Message
{
    /// <summary>
    /// 发送邮件
    /// </summary>
    public class Email
    {
        private static string host = "smtp.qq.com";
        private static string sender = "723202874@qq.com";
        private static string password = "buzhongbuyi";

        public static bool SendSingleMail(string title, string body, string receiver)
        {
            return SendSingleMail(host, sender, password, title, body, receiver);
        }

        public static bool SendSingleMail(string host, string sender, string password, string title, string body, string receiver)
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(receiver);
            msg.From = new MailAddress(sender, "带头大哥", System.Text.Encoding.UTF8);
            /* 上面3个参数分别是发件人地址（可以随便写），发件人姓名，编码*/
            msg.Subject = title;//邮件标题 
            msg.SubjectEncoding = System.Text.Encoding.UTF8;//邮件标题编码 
            msg.Body = body;//邮件内容
            msg.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码 
            msg.IsBodyHtml = true;//是否是HTML邮件 
            //msg.Priority = MailPriority.High;//邮件优先级 
            msg.Priority = System.Net.Mail.MailPriority.Normal;

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(sender, password);
            client.Host = host;
            client.Port = 25;
            object userState = msg;

            bool result = false;
            try
            {
                client.Send(msg);
                //简单一点儿可以client.Send(msg); 
                result = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                result = false;
            }

            return result;
        }
    }
}
