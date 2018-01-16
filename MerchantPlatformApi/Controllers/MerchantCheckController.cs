using Newtonsoft.Json;
using ReCommon;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using MerchantModel;
using System.Web;
using Newtonsoft.Json.Linq;

namespace MerchantPlatformApi.Controllers
{
    public class MerchantCheckController : ApiController
    {
        #region 配置参数
        //URL请求所需参数
        //static string username = "MerchantPlatform";
        static string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
        static string password = ConfigurationManager.AppSettings[username];
        static string Url = ApiHelper.GetURL(username);

        private JsonSerializerSettings JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        #endregion

        /// <summary>
        ///  商家平台_商家注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UserRegister(UserInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                //去除用户参数中包含的特殊字符
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);

                string imgString = model.UserAvatar.Split(new char[] { ',' })[1];
                model.UserAvatar = CharConversion.SaveImg(imgString, model.UserAccount, "~/Avatar/");

                string Str = JsonConvert.SerializeObject(model, JSetting);

                //返回结果
                Result =  ApiHelper.HttpRequest(username, password, Url, Str);

            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

        /// <summary>
        ///  商家平台_商家登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UserLogin(UserInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                //去除用户参数中包含的特殊字符
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);
                model.UserPasswd = ParametersFilter.FilterSqlHtml(model.UserPasswd, 50);
                model.LoginIP = HttpHelper.IPAddress();

                string Str = JsonConvert.SerializeObject(model, JSetting);

                //返回结果
                Result = ApiHelper.HttpRequest(username, password, Url, Str);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

        /// <summary>
        /// 手机验证码登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage MobileLogin(UserInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                model.UserMobile = ParametersFilter.FilterSqlHtml(model.UserMobile, 11);
                model.LoginIP = HttpHelper.IPAddress();
                model.Verification = ParametersFilter.FilterSqlHtml(model.Verification, 6);

                //实例化Redis请求参数
                RedisModel.BaseModel redis = new RedisModel.BaseModel();

                redis.RedisIP = "r-wz9c03c34034e434554.redis.rds.aliyuncs.com";
                redis.RedisPort = "6379";
                redis.RedisPassword = "Yuegang888888";
                redis.RedisKey = "AuthCode_" + model.UserMobile;
                redis.RedisValue = model.Verification;
                redis.LifeCycle = "60";
                redis.RedisFunction = "StringGet";

                //获取Redis中的验证码
                string GetRedisAuthCode = ApiHelper.HttpRequest(ApiHelper.GetRedisURL(redis.RedisFunction), redis);

                if (GetRedisAuthCode == "null")
                {
                    Result = "{\"DATA\":[{\"result\":\"验证码已过时\"}]}";
                }
                else if (GetRedisAuthCode == model.Verification)
                {
                    string Str = JsonConvert.SerializeObject(model, JSetting);

                    Result = ApiHelper.HttpRequest(username, password, Url, Str);
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

        /// <summary>
        /// 验证手机是否注册（注册发送验证码）
        /// </summary>
        /// <param name="UserMobile">手机号</param>
        /// <returns>验证码</returns>
        [HttpPost]
        public HttpResponseMessage MobileProving(RedisModel.BaseModel model)
        {
            string Result = string.Empty;

            try
            {
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                //去除提交的数据中的不安全字符
                model.UserMobile = ParametersFilter.FilterSqlHtml(model.UserMobile, 11);

                string Str = JsonConvert.SerializeObject(model, JSetting);

                Result = ApiHelper.HttpRequest(username, password, Url, Str);

                JObject json = (JObject)JsonConvert.DeserializeObject(Result);

                if (json["DATA"][0].ToString() == "1")
                {

                    string AuthCode = ApiHelper.HttpRequest(ApiHelper.GetAuthCodeURL(), model);
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
        /// 验证手机是否注册（未注册发送验证码）
        /// </summary>
        /// <param name="UserMobile">手机号</param>
        /// <returns>验证码</returns>
        [HttpPost]
        public HttpResponseMessage ProvingMobile(RedisModel.BaseModel model)
        {
            string Result = string.Empty;

            try
            {
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                //去除提交的数据中的不安全字符
                model.UserMobile = ParametersFilter.FilterSqlHtml(model.UserMobile, 11);

                string Str = JsonConvert.SerializeObject(model, JSetting);

                Result = ApiHelper.HttpRequest(username, password, Url, Str);

                JObject json = (JObject)JsonConvert.DeserializeObject(Result);

                if (json["DATA"][0].ToString() == "0")
                {

                    string AuthCode = ApiHelper.HttpRequest(ApiHelper.GetAuthCodeURL(), model);
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
        /// 重置密码
        /// </summary>
        /// <param name="UserMobile">手机号</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage MobileUpdatePasswd(RedisModel.BaseModel model)
        {
            string Result = string.Empty;

            try
            {
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                //去除提交的数据中的不安全字符
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);

                string Str = JsonConvert.SerializeObject(model, JSetting);

                Result = ApiHelper.HttpRequest(username, password, Url, Str);

                JObject json = (JObject)JsonConvert.DeserializeObject(Result);

                if (json["DATA"][0].ToString() == "1")
                {

                    string AuthCode = ApiHelper.HttpRequest(ApiHelper.GetAuthCodeURL(), model);
                }
            }
            catch (Exception ex)
            {

                LogHelper.Error(ex.ToString());
            }
            HttpResponseMessage Respond = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respond;
        }
    }
}
