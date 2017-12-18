using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ReCommon
{
    public class EmailHelper
    {
        /// <summary>
        /// 发送激活邮件
        /// </summary>
        /// <param name="addresser">发件人地址</param>
        /// <param name="addressPsswd">发件人密码</param>
        /// <param name="recipient">收件人地址</param>
        public static void MailSend(string addresser, string addressPsswd, string recipient)
        {
            MailMessage ActivationMail = new MailMessage();

            //服务端邮箱地址
            ActivationMail.From = new MailAddress(addresser);

            //收件人
            ActivationMail.To.Add(new MailAddress(recipient));

            //邮件标题
            ActivationMail.Subject = "激活邮件";

            //邮件正文
            StringBuilder Content = new StringBuilder();
            Content.Append("请单击一下连接完成激活");
            Content.Append("<a href='http://baidu.com'>激活</a>");
            ActivationMail.Body = Content.ToString();
            ActivationMail.IsBodyHtml = false;

            SmtpClient Smtpclient = new SmtpClient("smtp.mxhichina.com", 465);

            //对发件人进行认证
            Smtpclient.Credentials = new System.Net.NetworkCredential(addresser, addressPsswd);
            Smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
            Smtpclient.EnableSsl = true;

            Smtpclient.Send(ActivationMail);
        }
    }
}
