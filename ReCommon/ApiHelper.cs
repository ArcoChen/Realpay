using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using AppModel;
using System.Net.Http;

namespace ReCommon
{
    public class ApiHelper
    {
        #region HTTPPOST请求
        /// <summary>
        /// httppost请求（带参数）
        /// </summary>
        /// <param name="userName">用户名（dll类库名）</param>
        /// <param name="Password">密码</param>
        /// <param name="Url">URL地址</param>
        /// <param name="PostData">参数（json格式）</param>
        /// <returns></returns>
        public static string HttpRequest(string userName, string Password, string Url, string PostData)
        {
            string Result = string.Empty;
            string str = userName + ":" + Password;

            try
            {
                #region HttpWebRequest
                //CredentialCache 类存储多个 Internet 资源的凭据
                CredentialCache mycache = new CredentialCache();
                mycache.Add(new Uri(Url), "Basic", new NetworkCredential(userName, Password));

                //用于客户端，拼接请求的HTTP报文并发送等（HttpWebRequest这个类非常强大，强大的地方在于它封装了几乎HTTP请求报文里需要用到的东西，以致于能够能够发送任意的HTTP请求并获得服务器响应(Response)信息）
                HttpWebRequest Request = WebRequest.Create(new Uri(Url)) as HttpWebRequest;

                Request.Credentials = mycache;
                //string Code = Convert.ToBase64String(new ASCIIEncoding().GetBytes(str));
                Request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(str)));

                //设置提交方式为post
                Request.Method = "POST";

                //设置连接类型
                Request.ContentType = "application/x-www-form-urlencoded";

                //请求参数
                byte[] postData = Encoding.UTF8.GetBytes(PostData);
                Request.ContentLength = postData.Length;

                //用于将数据写入 Internet 资源的 Stream
                Stream RequestStream = Request.GetRequestStream();
                //StreamWriter myStreamWriter = new StreamWriter(RequestStream, Encoding.GetEncoding("gb2312"));
                //myStreamWriter.Write(PostData);
                //myStreamWriter.Close();
                RequestStream.Write(postData, 0, postData.Length);
                RequestStream.Close();

                ////返回请求响应
                using (HttpWebResponse Response = (HttpWebResponse)Request.GetResponse())
                {
                    using (Stream receiveStream = Response.GetResponseStream())
                    {
                        StreamReader Reader = new StreamReader(receiveStream, Encoding.UTF8);
                        Result = Reader.ReadToEnd();
                    }
                }

                Request.Abort();
                #endregion

                Result = System.Web.HttpUtility.UrlDecode(Result, System.Text.Encoding.UTF8);

                //截取json字符串
                Result = Result.Remove(0, 12);
                Result = Result.Remove(Result.Length - 3, 3);

            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
            }
            //Result = Result.Replace("\\","");
            //JObject json = (JObject)JsonConvert.DeserializeObject(Result);
            //Result = json["result"].ToString();

            return Result;
        }

        /// <summary>
        /// httppost请求（带参数）
        /// </summary>
        /// <param name="Url">URL地址</param>
        /// <param name="model">Model实体类</param>
        /// <returns></returns>
        public static string HttpRequest(string Url, BaseModel model)
        {
            string Result = string.Empty;
            var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

            string Str = JsonConvert.SerializeObject(model, JSetting);

            try
            {

                //用于客户端，拼接请求的HTTP报文并发送等（HttpWebRequest这个类非常强大，强大的地方在于它封装了几乎HTTP请求报文里需要用到的东西，以致于能够能够发送任意的HTTP请求并获得服务器响应(Response)信息）
                HttpWebRequest Request = WebRequest.Create(new Uri(Url)) as HttpWebRequest;

                //设置提交方式为post
                Request.Method = "POST";

                //设置连接类型
                Request.ContentType = "application/json";

                //请求参数
                byte[] postData = Encoding.UTF8.GetBytes(Str);
                Request.ContentLength = postData.Length;

                //用于将数据写入 Internet 资源的 Stream
                Stream RequestStream = Request.GetRequestStream();
                //StreamWriter myStreamWriter = new StreamWriter(RequestStream, Encoding.GetEncoding("gb2312"));
                //myStreamWriter.Write(PostData);
                //myStreamWriter.Close();
                RequestStream.Write(postData, 0, postData.Length);
                RequestStream.Close();

                #region 返回请求
                ////返回请求响应
                //HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
                //Stream receiveStream = Response.GetResponseStream();
                //StreamReader Reader = new StreamReader(receiveStream, Encoding.UTF8);
                //Result = Reader.ReadToEnd();
                //Reader.Close();
                //receiveStream.Close();
                //Response.Close();
                //Response = null;
                //Request.Abort(); 
                #endregion

                ////返回请求响应
                using (HttpWebResponse Response = (HttpWebResponse)Request.GetResponse())
                {
                    using (Stream receiveStream = Response.GetResponseStream())
                    {
                        StreamReader Reader = new StreamReader(receiveStream, Encoding.UTF8);
                        Result = Reader.ReadToEnd();
                    }
                }

                Result = System.Web.HttpUtility.UrlDecode(Result, System.Text.Encoding.UTF8);

            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
            }
            //Result = Result.Replace("\\","");
            //JObject json = (JObject)JsonConvert.DeserializeObject(Result);
            //Result = json["result"].ToString();


            return Result;
        }
        #endregion

        #region 访问地址
        /// <summary>
        /// 获取访问的URL地址
        /// </summary>
        /// <param name="ClassName">类库名</param>
        /// <returns></returns>
        public static string GetURL(string ClassName)
        {
            //string Url = "http://192.168.1.51:7090/" + ClassName + "/" + ClassName + ".dll/TServerMethods/Transaction/";
            string Url = "http://192.168.1.195:8080/TServerMethods/Transaction/";
            return Url;
        }

        /// <summary>
        /// 获取验证码的URL地址
        /// </summary>
        /// <returns></returns>
        public static string GetAuthCodeURL()
        {
            string Url = "http://192.168.1.50:8011/api/SMSCodeAPI/GetAuthCode";
            return Url;
        }

        /// <summary>
        /// 获取Redis的URL地址
        /// </summary>
        /// <returns></returns>
        public static string GetRedisURL(String FuncationName)
        {
            string Url = "http://192.168.1.50:8012/api/RedisAPI/" + FuncationName;
            return Url;
        }
        #endregion
    }
}
