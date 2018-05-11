using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ReCommon
{
    public class ApiHelper
    {
        #region 配置参数
        private static JsonSerializerSettings JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        #endregion

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

            #region HttpWebRequest
            //try
            //{
            //    #region HttpWebRequest
            //    //CredentialCache 类存储多个 Internet 资源的凭据
            //    CredentialCache mycache = new CredentialCache();
            //    mycache.Add(new Uri(Url), "Basic", new NetworkCredential(userName, Password));

            //    //用于客户端，拼接请求的HTTP报文并发送等（HttpWebRequest这个类非常强大，强大的地方在于它封装了几乎HTTP请求报文里需要用到的东西，以致于能够能够发送任意的HTTP请求并获得服务器响应(Response)信息）
            //    HttpWebRequest Request = WebRequest.Create(new Uri(Url)) as HttpWebRequest;

            //    Request.Credentials = mycache;
            //    //string Code = Convert.ToBase64String(new ASCIIEncoding().GetBytes(str));
            //    Request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(str)));

            //    //设置提交方式为post
            //    Request.Method = "POST";

            //    //设置连接类型
            //    Request.ContentType = "application/x-www-form-urlencoded";

            //    //请求参数
            //    byte[] postData = Encoding.UTF8.GetBytes(PostData);
            //    Request.ContentLength = postData.Length;

            //    //用于将数据写入 Internet 资源的 Stream
            //    Stream RequestStream = Request.GetRequestStream();
            //    RequestStream.Write(postData, 0, postData.Length);
            //    RequestStream.Close();

            //    ////返回请求响应
            //    using (HttpWebResponse Response = (HttpWebResponse)Request.GetResponse())
            //    {
            //        using (Stream receiveStream = Response.GetResponseStream())
            //        {
            //            StreamReader Reader = new StreamReader(receiveStream, Encoding.UTF8);
            //            Result = Reader.ReadToEnd();
            //        }
            //    }

            //    Request.Abort();
            //    #endregion

            //    Result = System.Web.HttpUtility.UrlDecode(Result, System.Text.Encoding.UTF8);

            //    //截取json字符串
            //    Result = Result.Remove(0, 12);
            //    Result = Result.Remove(Result.Length - 3, 3);

            //}
            //catch (Exception ex)
            //{

            //    Console.Write(ex.Message);
            //} 
            #endregion

            #region HttpClient
            HttpContent httpContent = new StringContent(PostData);
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:50.0) Gecko/20100101 Firefox/50.0");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(str)));
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            try
            {
                HttpResponseMessage response = httpClient.PostAsync(Url, httpContent).Result;
                Result = response.Content.ReadAsStringAsync().Result;

                Result = System.Web.HttpUtility.UrlDecode(Result, System.Text.Encoding.UTF8);

                //截取json字符串
                Result = Result.Remove(0, 12);
                Result = Result.Remove(Result.Length - 3, 3);
                response = null;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            httpClient.Dispose();
            #endregion
            return Result;
        }

        /// <summary>
        /// httppost请求（带参数）
        /// </summary>
        /// <param name="Url">URL地址</param>
        /// <param name="model">Model实体类</param>
        /// <returns></returns>
        public static string HttpRequest<T>(string userName, string Password, string Url, T model)
        {

            string str = userName + ":" + Password;
            string Result = string.Empty;

            string Str = JsonConvert.SerializeObject(model, JSetting);

            HttpContent httpContent = new StringContent(Str);
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:50.0) Gecko/20100101 Firefox/50.0");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(str)));
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            try
            {
                HttpResponseMessage response = httpClient.PostAsync(Url, httpContent).Result;
                Result = response.Content.ReadAsStringAsync().Result;
                Result = System.Web.HttpUtility.UrlDecode(Result, System.Text.Encoding.UTF8);

                //截取json字符串
                Result = Result.Remove(0, 12);
                Result = Result.Remove(Result.Length - 3, 3);

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            httpClient.Dispose();
            return Result;
        }

        /// <summary>
        /// httppost请求（带参数）
        /// </summary>
        /// <param name="Url">URL地址</param>
        /// <param name="model">Model实体类</param>
        /// <returns></returns>
        public static string HttpRequest<T>(string Url, T model)
        {
            string Result = string.Empty;

            string Str = JsonConvert.SerializeObject(model, JSetting);

            HttpContent httpContent = new StringContent(Str);
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:50.0) Gecko/20100101 Firefox/50.0");
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            try
            {
                HttpResponseMessage response = httpClient.PostAsync(Url, httpContent).Result;
                Result = response.Content.ReadAsStringAsync().Result;

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            httpClient.Dispose();
            return Result;
        }
        #endregion

        #region 访问地址
        /// <summary>
        /// 获取访问的URL地址
        /// </summary>
        /// <param name="ClassName">类库名</param>
        /// <returns></returns>
        public static string GetURL(string Application, string ClassName)
        {
            string IP = SingleXmlInfo.GetInstance().GetWebApiConfig("serverIp");
            Application = SingleXmlInfo.GetInstance().GetWebApiConfig(Application);
            string Url = IP + Application + "/" + ClassName + ".dll/TServerMethods/Transaction/";

            #region 原地址
            //string Url = "http://119.23.35.37/App/" + ClassName + ".dll/TServerMethods/Transaction/";
            //string Url = "http://172.18.5.250/App/" + ClassName + ".dll/TServerMethods/Transaction/";
            //string Url = "http://172.18.5.250/OperatingPlatform/" + ClassName + ".dll/TServerMethods/Transaction/";
            //string Url = "http://172.18.5.250/MerchantPlatform/" + ClassName + ".dll/TServerMethods/Transaction/";
            // string Url = "http://119.23.35.37/MerchantPlatform/" + ClassName + ".dll/TServerMethods/Transaction/";
            //string Url = "http://172.18.5.250/PayManagePlatform/" + ClassName + ".dll/TServerMethods/Transaction/";
            //string Url = "http://192.168.1.51:8010/" + ClassName + "/" + ClassName + ".dll/TServerMethods/Transaction/";
            //string Url = "http://192.168.1.181:8080/TServerMethods/Transaction/"; 
            #endregion

            return Url;
        }

        /// <summary>
        /// 验证码地址
        /// </summary>
        /// <param name="FunctionName">方法名</param>
        /// <returns></returns>
        public static string GetAuthCodeURL(string UrlName, string Application, string FunctionName)
        {
            UrlName = SingleXmlInfo.GetInstance().GetWebApiConfig(UrlName);
            Application = SingleXmlInfo.GetInstance().GetWebApiConfig(Application);
            string Url = UrlName + Application + "/api/SMSCodeAPI/" + FunctionName;
            return Url;
        }

        /// <summary>
        /// 图片上传URL地址
        /// </summary>
        /// <returns></returns>
        public static string GetImgUploadURL(string UrlName, string Application)
        {
            UrlName = SingleXmlInfo.GetInstance().GetWebApiConfig(UrlName);
            Application = SingleXmlInfo.GetInstance().GetWebApiConfig(Application);
            string Url = UrlName + Application + "/api/imgUpload/Upload";
            return Url;
        }

        /// <summary>
        /// 获取图片保存URL地址
        /// </summary>
        /// <returns></returns>
        public static string ImgURL()
        {
            string Url = SingleXmlInfo.GetInstance().GetWebApiConfig("imgIp");
            return Url;
        }

        /// <summary>
        /// 获取Redis的URL地址
        /// </summary>
        /// <returns></returns>
        public static string GetRedisURL(string UrlName, string Application, string FuncationName)
        {
            UrlName = SingleXmlInfo.GetInstance().GetWebApiConfig(UrlName);
            Application = SingleXmlInfo.GetInstance().GetWebApiConfig(Application);
            string Url = UrlName + Application + "/api/RedisAPI/" + FuncationName;
            return Url;
        }
        #endregion

        #region json转换
        /// <summary>
        /// DATA转json字符串
        /// </summary>
        /// <param name="DATA"></param>
        /// <returns></returns>
        public static string DATAToJson(string DATA)
        {
            JArray json = JsonConvert.DeserializeObject(DATA) as JArray;

            StringBuilder jsonData = new StringBuilder();
            jsonData.Append("{");
            for (int i = 0; i < json[0].Count(); i++)
            {
                if (i < json[0].Count() - 1)
                {
                    jsonData.Append("\"" + json[0][i].ToString() + "\":\"" + json[1][i].ToString() + "\",");
                }
                else
                {
                    jsonData.Append("\"" + json[0][i].ToString() + "\":\"" + json[1][i].ToString() + "\"");
                }
            }
            jsonData.Append("}");

            return jsonData.ToString();
        }

        /// <summary>
        /// 获取DATA中指定的键值对，并返回为字典
        /// </summary>
        /// <param name="strArray">指定key数组</param>
        /// <param name="jsonData">json数据</param>
        /// <param name="OtherData">DATA外数据</param>
        /// <returns>dic字典</returns>
        public static Dictionary<string, string> SpecificData(string[] strArray, string jsonData)
        {
            ///解析DATA字符串
            JObject json = JObject.Parse(jsonData);

            Dictionary<string, string> dic = new Dictionary<string, string>();

            ///遍历strArray，循环加入键值对
            for (int i = 0; i < strArray.Length; i++)
            {
                dic.Add(strArray[i], json[strArray[i]].ToString());
            }
            return dic;



        }

        /// <summary>
        /// 字典转为字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static string DictionaryToStr<T>(Dictionary<T, T> dic)
        {
            ///反序列化为json字符串
            string jsonStr = JsonConvert.SerializeObject(dic);
            return jsonStr;
        }
        #endregion

    }
}
