using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using ReCommon;
using SMSCode;
using AppModel;
using System.Text;
using System.Configuration;
using Newtonsoft.Json;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using CacheManager.Core;
using CacheManager;
using System.Threading.Tasks;
using RedisModel;

namespace AppWebApi.Controllers
{
    public class UserCheckController : ApiController
    {
        /// <summary>
        /// 验证手机是否注册（未注册发送验证码）
        /// </summary>
        /// <param name="UserMobile">手机号</param>
        /// <returns>验证码</returns>
        [HttpPost]
        public async Task<HttpResponseMessage> AccountProving(RedisModel.BaseModel model)
        {
            string Result = string.Empty;

            try
            {
                //string username = "DataSnapDebugTools";
                string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);


                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                //去除提交的数据中的不安全字符
                model.UserMobile = ParametersFilter.FilterSqlHtml(model.UserMobile, 11);

                var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

                string Str = JsonConvert.SerializeObject(model, JSetting);

                Result = ApiHelper.HttpRequest(username, password, Url, Str);

                JObject json = (JObject)JsonConvert.DeserializeObject(Result);

                if (json["DATA"][0]["result"].ToString() == "false")
                {

                    #region 发送短信
                    ////生成六位随机验证码
                    //model.Verification = SMSCode.SMSCode.GetAuthCode(100000, 999999);

                    //SMSCode.SMSCode AuthCode = new SMSCode.SMSCode();

                    ////发送短信
                    //AuthCode.SendMessage(model.UserMobile, model.Verification);

                    //if (RuntimeCache.Cache.Get(model.UserMobile) != null)
                    //{
                    //    RuntimeCache.Cache.Update(model.UserMobile, v => model.Verification);
                    //}
                    //else
                    //{
                    //    //缓存验证码
                    //    RuntimeCache.Cache.Add(model.UserMobile, model.Verification);
                    //} 
                    #endregion

                    string AuthCode = await Task<string>.Run(() => ApiHelper.HttpRequest(ApiHelper.GetAuthCodeURL(), model));
                }
            }
            catch (Exception ex)
            {

                LogHelper.Error(ex.ToString());
            }
            HttpResponseMessage Respond = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respond;
        }

        /// <summary>
        /// 验证手机是否注册（注册了发送验证码）
        /// </summary>
        /// <param name="UserMobile">手机号</param>
        /// <returns>验证码</returns>
        [HttpPost]
        public async Task<HttpResponseMessage> ProvingAccount(RedisModel.BaseModel model)
        {
            string Result = string.Empty;

            try
            {
                //string username = "DataSnapDebugTools";
                string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);


                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                //去除提交的数据中的不安全字符
                model.UserMobile = ParametersFilter.FilterSqlHtml(model.UserMobile, 11);

                var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

                string Str = JsonConvert.SerializeObject(model, JSetting);

                Result = ApiHelper.HttpRequest(username, password, Url, Str);

                JObject json = (JObject)JsonConvert.DeserializeObject(Result);

                if (json["DATA"][0]["result"].ToString() == "true")
                {

                    #region 发送短信
                    ////生成六位随机验证码
                    //model.Verification = SMSCode.SMSCode.GetAuthCode(100000, 999999);

                    //SMSCode.SMSCode AuthCode = new SMSCode.SMSCode();

                    ////发送短信
                    //AuthCode.SendMessage(model.UserMobile, model.Verification);

                    //if (RuntimeCache.Cache.Get(model.UserMobile) != null)
                    //{
                    //    RuntimeCache.Cache.Update(model.UserMobile, v => model.Verification);
                    //}
                    //else
                    //{
                    //    //缓存验证码
                    //    RuntimeCache.Cache.Add(model.UserMobile, model.Verification);
                    //} 
                    #endregion

                    string AuthCode = await Task<string>.Run(() => ApiHelper.HttpRequest(ApiHelper.GetAuthCodeURL(), model));
                }
            }
            catch (Exception ex)
            {

                LogHelper.Error(ex.ToString());
            }
            HttpResponseMessage Respond = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respond;
        }

        /// <summary>
        /// 获取手机验证码
        /// </summary>
        /// <param name="UserMobile">手机号</param>
        /// <returns>验证码</returns>
        [HttpPost]
        public async Task<HttpResponseMessage> GetAuthCode(RedisModel.BaseModel model)
        {
            string Result = string.Empty;

            //string username = "DataSnapDebugTools";
            string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
            string password = ConfigurationManager.AppSettings[username];
            string Url = ApiHelper.GetURL(username);
            try
            {
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                ////去除提交的数据中的不安全字符
                model.UserMobile = ParametersFilter.FilterSqlHtml(model.UserMobile, 11);

                #region 缓存验证码
                ////生成六位随机验证码
                //model.Verification = SMSCode.SMSCode.GetAuthCode(100000, 999999);


                //SMSCode.SMSCode AuthCode = new SMSCode.SMSCode();

                ////发送短信
                //AuthCode.SendMessage(model.UserMobile, model.Verification);

                //if (RuntimeCache.Cache.Get(model.UserMobile) != null)
                //{
                //    RuntimeCache.Cache.Update(model.UserMobile, v => model.Verification);
                //}
                //else
                //{
                //    //缓存验证码
                //    RuntimeCache.Cache.Add(model.UserMobile, model.Verification);
                //} 
                #endregion
                var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
                string Str = JsonConvert.SerializeObject(model, JSetting);

                //请求验证码
                Result = await Task<string>.Run(() => ApiHelper.HttpRequest(ApiHelper.GetAuthCodeURL(), model));
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }

            HttpResponseMessage Responsed = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Responsed;
        }

        /// <summary>
        /// 验证验证码
        /// </summary>
        /// <param name="UserMobile">手机号</param>
        /// <param name="SMSCode">验证码</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage VerifyAuthCode(RedisModel.BaseModel model)
        {
            string Result = string.Empty;

            //URL请求所需参数
            //string username = "UserCheck";

            try
            {
                //string username = "DataSnapDebugTools";
                string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                model.UserMobile = ParametersFilter.FilterSqlHtml(model.UserMobile, 11);
                model.Verification = ParametersFilter.FilterSqlHtml(model.Verification, 6);

                #region MyRegion
                ////实例化Redis请求参数
                //RedisModel.BaseModel redis = new RedisModel.BaseModel();

                //redis.RedisIP = "r-wz9c03c34034e434554.redis.rds.aliyuncs.com";
                //redis.RedisPort = "6379";
                //redis.RedisPassword = "Yuegang888888";
                //redis.RedisKey = "AuthCode_" + model.UserMobile;
                //redis.RedisValue = model.Verification;
                //redis.LifeCycle = "60";
                //redis.RedisFunction = "StringGet"; 
                #endregion

                //获取Redis中的验证码
                string GetRedisAuthCode = ApiHelper.HttpRequest(ApiHelper.GetAuthCodeURL(),model);
                JObject json = (JObject)JsonConvert.DeserializeObject(GetRedisAuthCode);

                if (json["result"].ToString() == "2")
                {

                    Result = "{\"DATA\":[{\"result\":\"验证码已过时\"}]}";
                }
                else if (json["result"].ToString() == "1")
                {
                    Result = "{\"DATA\":[{\"result\":\"true\"}]}";
                }
                else
                {
                    Result = "{\"DATA\":[{\"result\":\"验证码错误\"}]}";
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

        ///// <summary>
        ///// 验证验证码
        ///// </summary>
        ///// <param name="UserMobile">手机号</param>
        ///// <param name="SMSCode">验证码</param>
        ///// <returns></returns>
        //[HttpPost]
        //public HttpResponseMessage VerifyAuthCode(UserInfoModel model)
        //{
        //    string Result = string.Empty;

        //    //URL请求所需参数
        //    //string username = "UserCheck";

        //    try
        //    {
        //        //string username = "DataSnapDebugTools";
        //        string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
        //        string password = ConfigurationManager.AppSettings[username];
        //        string Url = ApiHelper.GetURL(username);

        //        //请求中包含的固定参数
        //        model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
        //        model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
        //        model.ADDRESS = HttpHelper.IPAddress();
        //        model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
        //        model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
        //        model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

        //        model.UserMobile = ParametersFilter.FilterSqlHtml(model.UserMobile, 11);
        //        model.Verification = ParametersFilter.FilterSqlHtml(model.Verification, 6);

        //        #region 判断缓存验证码
        //        ////判断验证码是否正确
        //        //if (RuntimeCache.Cache.Get(model.UserMobile) != null)
        //        //{
        //        //    if (RuntimeCache.Cache.Get(model.UserMobile).ToString() == model.Verification)
        //        //    {
        //        //        Result = "{\"DATA\":[{\"result\":\"true\"}]}";
        //        //        RuntimeCache.Cache.Remove(model.UserMobile);
        //        //    }
        //        //    else
        //        //    {
        //        //        Result = "{\"DATA\":[{\"result\":\"验证码错误\"}]}";
        //        //    }
        //        //}
        //        //else
        //        //{
        //        //    Result = "{\"DATA\":[{\"result\":\"验证码已过时\"}]}";
        //        //}
        //        #endregion

        //        //实例化Redis请求参数
        //        RedisModel.BaseModel redis = new RedisModel.BaseModel();

        //        redis.RedisIP = "r-wz9c03c34034e434554.redis.rds.aliyuncs.com";
        //        redis.RedisPort = "6379";
        //        redis.RedisPassword = "Yuegang888888";
        //        redis.RedisKey = "AuthCode_" + model.UserMobile;
        //        redis.RedisValue = model.Verification;
        //        redis.LifeCycle = "60";
        //        redis.RedisFunction = "StringGet";

        //        //获取Redis中的验证码
        //        string GetRedisAuthCode = ApiHelper.HttpRequest(ApiHelper.GetRedisURL(redis.RedisFunction), redis);

        //        if (GetRedisAuthCode == "null")
        //        {
        //            Result = "{\"DATA\":[{\"result\":\"验证码已过时\"}]}";
        //        }
        //        else if (GetRedisAuthCode == model.Verification)
        //        {
        //            Result = "{\"DATA\":[{\"result\":\"true\"}]}";
        //        }
        //        else
        //        {
        //            Result = "{\"DATA\":[{\"result\":\"验证码错误\"}]}";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error(ex.ToString());
        //    }

        //    HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

        //    return Respend;
        //}

        /// <summary>
        /// 完善用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> UserInfo(UserInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //URL请求所需参数
                string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                //string username = "DataSnapDebugTools";
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);
                model.DATA = System.Web.HttpUtility.UrlDecode(model.DATA);


                JArray json = (JArray)JsonConvert.DeserializeObject(model.DATA);

                //获取用户账号作为图片名
                string ImgName = json[1][1].ToString();

                //URL编码
                model.DATA = System.Web.HttpUtility.UrlEncode(model.DATA);

                //保存用户头像
                model.UserAvatar = CharConversion.SaveImg(model.UserAvatar, ImgName, "/Avatar/");

                var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

                string Str = JsonConvert.SerializeObject(model, JSetting);

                //返回结果
                Result = await Task<string>.Run(() => ApiHelper.HttpRequest(username, password, Url, Str));
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

        /// <summary>
        /// 提交支付密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> PaymentPassword(UserInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                // URL请求所需参数
                //string username = "DataSnapDebugTools";
                string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);
                if (model.TERMINAL == "2")
                {
                    model.DATA = System.Web.HttpUtility.UrlEncode(model.DATA);
                }

                //去除用户参数中包含的特殊字符
                //model.PaymentPassword = ParametersFilter.FilterSqlHtml(model.PaymentPassword, 50);

                ////键值对
                //Dictionary<string, string> data = new Dictionary<string, string>();
                //data.Add("PaymentPassword", model.PaymentPassword);

                var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

                string Str = JsonConvert.SerializeObject(model, JSetting);

                //返回结果
                Result = await Task<string>.Run(() => ApiHelper.HttpRequest(username, password, Url, Str));
            }
            catch (Exception ex)
            {

                LogHelper.Error(ex.ToString());
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

        /// <summary>
        /// 忘记密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> ForgetPasswd(UserInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                // URL请求所需参数
                //string username = "DataSnapDebugTools";
                string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);
                if (model.TERMINAL == "2")
                {
                    model.DATA = System.Web.HttpUtility.UrlEncode(model.DATA);
                }

                //去除用户参数中包含的特殊字符
                //model.PaymentPassword = ParametersFilter.FilterSqlHtml(model.PaymentPassword, 50);

                ////键值对
                //Dictionary<string, string> data = new Dictionary<string, string>();
                //data.Add("PaymentPassword", model.PaymentPassword);

                var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

                string Str = JsonConvert.SerializeObject(model, JSetting);

                //返回结果
                Result = await Task<string>.Run(() => ApiHelper.HttpRequest(username, password, Url, Str));
            }
            catch (Exception ex)
            {

                LogHelper.Error(ex.ToString());
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> ModifyPasswd(ProductInfoModel model)
        {

            string Result = string.Empty;
            try
            {

                //URL请求所需参数
                string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                //string username = "DataSnapDebugTools";
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                if (model.TERMINAL == "2")
                {
                    model.DATA = System.Web.HttpUtility.UrlEncode(model.DATA);
                }

                var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

                string Str = JsonConvert.SerializeObject(model, JSetting);

                //返回结果
                Result = await Task<string>.Run(() => ApiHelper.HttpRequest(username, password, Url, Str));

            }
            catch (Exception ex)
            {

                LogHelper.Error(ex.ToString());
                Result = ex.ToString();
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

        /// <summary>
        /// 验证密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> PasswdProving(UserInfoModel model)
        {

            string Result = string.Empty;
            try
            {

                //URL请求所需参数
                string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                //string username = "DataSnapDebugTools";
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);


                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 30);
                model.UserPasswd = ParametersFilter.FilterSqlHtml(model.UserPasswd, 32);

                var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

                string Str = JsonConvert.SerializeObject(model, JSetting);

                //返回结果
                Result = await Task<string>.Run(() => ApiHelper.HttpRequest(username, password, Url, Str));

            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
                Result = ex.ToString();
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

    }
}
