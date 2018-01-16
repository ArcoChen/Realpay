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
        /// <param name="VerifyCode">随机验证码</param>
        public static void MailSend(string addresser, string addressPsswd, string recipient, string VerifyCode)
        {
            try
            {
                MailMessage msg = new MailMessage();

                //服务端邮箱地址
                msg.From = new MailAddress(addresser, "深圳凯华技术有限公司");

                //收件人
                msg.To.Add(new MailAddress(recipient));

                msg.SubjectEncoding = Encoding.UTF8;
                msg.BodyEncoding = Encoding.UTF8;

                //邮件标题
                msg.Subject = "深圳凯华技术有限公司";

                //邮件正文
                StringBuilder Content = new StringBuilder();
                //Content.Append("请进行邮箱验证来完成您注册的最后一步,点击下面的链接激活您的帐号：<br><a target='_blank' rel='nofollow' style='color: #0041D3; text-decoration: underline' href='http://www.****.net/regeditOK.aspx'>激活</a>");
                Content.Append("请进行邮箱验证,点击下面的链接激活您的邮箱：<br><a target='_blank' rel='nofollow' style='color: #0041D3; text-decoration: underline' href=http://192.168.1.198:54152/v/" + VerifyCode + ">http://192.168.1.198:54152/v/" + VerifyCode + "</a>");
                msg.Body = Content.ToString();
                msg.IsBodyHtml = true;

                SmtpClient Smtpclient = new SmtpClient("smtp.mxhichina.com", 25);

                //对发件人进行认证
                Smtpclient.Credentials = new System.Net.NetworkCredential(addresser, addressPsswd);
                object state = msg;
                Smtpclient.SendAsync(msg, state);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
