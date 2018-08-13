using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using AegisImplicitMail;
using CDO;

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
                #region MyRegion
                //MailMessage msg = new MailMessage();

                ////服务端邮箱地址
                //msg.From = new MailAddress(addresser, "深圳凯华技术有限公司");

                ////收件人
                //msg.To.Add(new MailAddress(recipient));

                //msg.SubjectEncoding = Encoding.UTF8;
                //msg.BodyEncoding = Encoding.UTF8;

                ////邮件标题
                //msg.Subject = "深圳凯华技术有限公司";

                ////邮件正文
                //StringBuilder Content = new StringBuilder();
                ////Content.Append("请进行邮箱验证来完成您注册的最后一步,点击下面的链接激活您的帐号：<br><a target='_blank' rel='nofollow' style='color: #0041D3; text-decoration: underline' href='http://www.****.net/regeditOK.aspx'>激活</a>");
                //Content.Append("请进行邮箱验证,点击下面的链接激活您的邮箱，10分钟内有效：<br><a target='_blank' rel='nofollow' style='color: #0041D3; text-decoration: underline' href=http://120.78.49.234/MerchantPlatformApi/v/" + VerifyCode + ">点击这里</a>");
                //msg.Body = Content.ToString();
                //msg.IsBodyHtml = true;

                //SmtpClient Smtpclient = new SmtpClient("smtp.mxhichina.com", 465);
                //Smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
                //Smtpclient.EnableSsl = true;
                ////对发件人进行认证
                //Smtpclient.Credentials = new System.Net.NetworkCredential(addresser, addressPsswd);
                //object state = msg;
                //Smtpclient.SendAsync(msg, state); 
                #endregion

                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                msg.To.Add(recipient);
                /*  
                * msg.To.Add("b@b.com");  
                * msg.To.Add("b@b.com");  
                * msg.To.Add("b@b.com");可以发送给多人  
                */
                //msg.CC.Add(c@c.com);
                /*  
                * msg.CC.Add("c@c.com");  
                * msg.CC.Add("c@c.com");可以抄送给多人  
                */
                msg.From = new MailAddress(addresser, "深圳凯华技术有限公司", System.Text.Encoding.UTF8);
                /* 上面3个参数分别是发件人地址（可以随便写），发件人姓名，编码*/
                msg.Subject = "深圳凯华技术有限公司";//邮件标题   
                msg.SubjectEncoding = System.Text.Encoding.UTF8;//邮件标题编码  

                //邮件正文
                StringBuilder Content = new StringBuilder();
                //Content.Append("请进行邮箱验证来完成您注册的最后一步,点击下面的链接激活您的帐号：<br><a target='_blank' rel='nofollow' style='color: #0041D3; text-decoration: underline' href='http://www.****.net/regeditOK.aspx'>激活</a>");
                Content.Append("请进行邮箱验证,点击下面的链接激活您的邮箱，10分钟内有效：<br><a target='_blank' rel='nofollow' style='color: #0041D3; text-decoration: underline' href=http://120.78.49.234/MerchantPlatformApi/v/" + VerifyCode + ">点击这里</a>");
                msg.Body = Content.ToString();

                msg.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码   
                msg.IsBodyHtml = true;//是否是HTML邮件   
                msg.Priority = MailPriority.High;//邮件优先级   
                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential(addresser, addressPsswd);
                //上述写你的GMail邮箱和密码   
                client.Port = 25;//Gmail使用的端口   
                client.Host = "smtp.mxhichina.com";
                client.EnableSsl = false;//经过ssl加密   
                object userState = msg;
                try
                {
                    client.SendAsync(msg, userState);
                    //简单一点儿可以client.Send(msg);   
                }
                catch (System.Net.Mail.SmtpException ex)
                {
                    Console.WriteLine(ex.Message, "发送邮件出错");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// 发送激活邮件
        /// </summary>
        /// <param name="addresser">发件人地址</param>
        /// <param name="addressPsswd">发件人密码</param>
        /// <param name="recipient">收件人地址</param>
        /// <param name="VerifyCode">随机验证码</param>
        public static void SSLMailSend(string addresser, string addressPsswd, string recipient, string VerifyCode)
        {
            try
            {

                var msg = new MimeMailMessage();
                msg.From = new MimeMailAddress(addresser, "深圳凯华技术有限公司");
                msg.To.Add(recipient);
                msg.Subject = "深圳凯华技术有限公司";

                ////邮件正文
                StringBuilder Content = new StringBuilder();
                Content.Append("请进行邮箱验证,点击下面的链接激活您的邮箱，10分钟内有效：<br><a target='_blank' rel='nofollow' style='color: #0041D3; text-decoration: underline' href=http://120.78.49.234/MerchantPlatformApi/v/" + VerifyCode + ">点击这里</a>");
                msg.Body = Content.ToString();

                var mailer = new MimeMailer("smtp.mxhichina.com", 465);
                mailer.User = "2209278489@qq.com";
                mailer.Password = "caq50994";
                mailer.SslType = SslMode.Ssl;
                mailer.AuthenticationMode = AuthenticationType.Base64;
                mailer.SendCompleted += compEvent;
                // mailer.SendMailAsync(msg);
                mailer.SendMail(msg);
            }
            catch (MissingMethodException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        /// <summary>
        /// 发送激活邮件
        /// </summary>
        /// <param name="addresser">发件人地址</param>
        /// <param name="addressPsswd">发件人密码</param>
        /// <param name="recipient">收件人地址</param>
        /// <param name="VerifyCode">随机验证码</param>
        public static void CDOMessageSend(string addresser, string addressPsswd, string recipient, string VerifyCode)
        {
            try
            {
                CDO.Message objMail = new CDO.Message();
                try
                {
                    objMail.To = recipient;
                    objMail.From = new MimeMailAddress(addresser,"深圳凯华技术有限公司").ToString();
                    objMail.Subject = "激活邮件";//邮件主题string strHTML = @"";

                    ////邮件正文
                    StringBuilder Content = new StringBuilder();
                    Content.Append("请进行邮箱验证,点击下面的链接激活您的邮箱，10分钟内有效：<br><a target='_blank' rel='nofollow' style='color: #0041D3; text-decoration: underline' href=http://120.78.49.234/MerchantPlatformApi/v/" + VerifyCode + ">点击这里</a>");

                    objMail.HTMLBody = Content.ToString();//邮件内容
                    objMail.Configuration.Fields["http://schemas.microsoft.com/cdo/configuration/smtpserverport"].Value = 465;//设置端口
                    objMail.Configuration.Fields["http://schemas.microsoft.com/cdo/configuration/smtpserver"].Value = "smtp.mxhichina.com";
                    objMail.Configuration.Fields["http://schemas.microsoft.com/cdo/configuration/sendemailaddress"].Value = addresser;
                    objMail.Configuration.Fields["http://schemas.microsoft.com/cdo/configuration/smtpuserreplyemailaddress"].Value = addresser;
                    objMail.Configuration.Fields["http://schemas.microsoft.com/cdo/configuration/smtpaccountname"].Value = addresser;
                    objMail.Configuration.Fields["http://schemas.microsoft.com/cdo/configuration/sendusername"].Value = addresser ;
                    objMail.Configuration.Fields["http://schemas.microsoft.com/cdo/configuration/sendpassword"].Value = addressPsswd;
                    objMail.Configuration.Fields["http://schemas.microsoft.com/cdo/configuration/sendusing"].Value = 2;
                    objMail.Configuration.Fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"].Value = 1;
                    objMail.Configuration.Fields["http://schemas.microsoft.com/cdo/configuration/smtpusessl"].Value = "true";//这一句指示是否使用ssl
                    objMail.Configuration.Fields.Update();
                    objMail.Send();
                }
                catch (Exception ex) { throw ex; }
                finally { }
                System.Runtime.InteropServices.Marshal.ReleaseComObject(objMail);
                objMail = null;
            }
            catch (MissingMethodException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        //Call back function
        private static void compEvent(object sender, AsyncCompletedEventArgs e)
        {
            if (e.UserState != null)
                Console.Out.WriteLine(e.UserState.ToString());

            Console.Out.WriteLine("is it canceled? " + e.Cancelled);

            if (e.Error != null)
                Console.Out.WriteLine("Error : " + e.Error.Message);
        }
    }
}
