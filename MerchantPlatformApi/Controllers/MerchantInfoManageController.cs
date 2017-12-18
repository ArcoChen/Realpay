﻿using MerchantModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReCommon;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MerchantPlatformApi.Controllers
{
    /// <summary>
    /// 商家信息管理（信息完善）
    /// </summary>
    public class MerchantInfoManageController : ApiController
    {
        #region 账号信息完善
        /// <summary>
        ///  商家平台_头像更新（0 – 失败 1 – 成功）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage HeadPortraitUpdate(UserInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //URL请求所需参数
                string username = "MerchantPlatform";
                //string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                //去除用户参数中包含的特殊字符
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);

                var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

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
        ///  商家平台_邮箱更新（0 – 失败 1 – 成功  2 – 邮箱重复）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UserEmailUpdate(UserInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //URL请求所需参数
                string username = "MerchantPlatform";
                //string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                //去除用户参数中包含的特殊字符
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);

                var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

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
        ///  商家平台_手机更新（0 – 失败 1 – 成功  2 – 手机号码重复）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UserMobileUpdate(UserInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //URL请求所需参数
                string username = "MerchantPlatform";
                //string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                //去除用户参数中包含的特殊字符
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);

                var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

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
        ///  商家平台_密码修改（0 – 成功 1 – 失败 2 – 密码错误）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ModifyOldPasswd(UserInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //URL请求所需参数
                string username = "MerchantPlatform";
                //string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                //去除用户参数中包含的特殊字符
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);

                var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

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
        ///  商家平台_实名认证（0 – 成功 1 – 失败）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UserInfoIdentification(UserInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //URL请求所需参数
                string username = "MerchantPlatform";
                //string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                //去除用户参数中包含的特殊字符
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);

                var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

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
        #endregion

        #region 企业信息认证
        /// <summary>
        ///  商家平台_(商家信息)企业信息认证（0 – 失败 1 –成功）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage EnterpriseInfoUpdate(UserInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //URL请求所需参数
                string username = "MerchantPlatform";
                //string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                //去除用户参数中包含的特殊字符
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);

                var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

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
        ///  商家平台_开通支付（0 – 失败 1 –成功）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage PaymentOpening(UserInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //URL请求所需参数
                string username = "MerchantPlatform";
                //string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                //去除用户参数中包含的特殊字符
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);

                var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

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
        #endregion

        #region 短信信息
        /// <summary>
        /// 验证手机是否注册（注册了发送验证码）
        /// </summary>
        /// <param name="UserMobile">手机号</param>
        /// <returns>验证码</returns>
        [HttpPost]
        public HttpResponseMessage MobileProving(RedisModel.BaseModel model)
        {
            string Result = string.Empty;

            try
            {
                string username = "MerchantPlatform";
                //string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
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
        /// 验证手机是否注册（注册了发送验证码）
        /// </summary>
        /// <param name="UserMobile">手机号</param>
        /// <returns>验证码</returns>
        [HttpPost]
        public HttpResponseMessage ProvingMobile(RedisModel.BaseModel model)
        {
            string Result = string.Empty;

            try
            {
                string username = "MerchantPlatform";
                //string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
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

                #region 判断缓存验证码
                ////判断验证码是否正确
                //if (RuntimeCache.Cache.Get(model.UserMobile) != null)
                //{
                //    if (RuntimeCache.Cache.Get(model.UserMobile).ToString() == model.Verification)
                //    {
                //        Result = "{\"DATA\":[{\"result\":\"true\"}]}";
                //        RuntimeCache.Cache.Remove(model.UserMobile);
                //    }
                //    else
                //    {
                //        Result = "{\"DATA\":[{\"result\":\"验证码错误\"}]}";
                //    }
                //}
                //else
                //{
                //    Result = "{\"DATA\":[{\"result\":\"验证码已过时\"}]}";
                //}
                #endregion

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
                    Result = "{\"DATA\":[{\"result\":\"2\"}]}";
                }
                else if (GetRedisAuthCode == model.Verification)
                {
                    Result = "{\"DATA\":[{\"result\":\"1\"}]}";
                }
                else
                {
                    Result = "{\"DATA\":[{\"result\":\"0\"}]}";
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }
        #endregion

        #region 信息返回
        /// <summary>
        ///  商家平台_基本信息返回
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage BasicInfoReturn(UserInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //URL请求所需参数
                string username = "MerchantPlatform";
                //string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                //去除用户参数中包含的特殊字符
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);

                var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

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
        ///  商家平台_企业信息返回
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage MerchantInfoReturn(EnterPriseInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //URL请求所需参数
                string username = "MerchantPlatform";
                //string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                //去除用户参数中包含的特殊字符
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);

                var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

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
        ///  商家平台_实名信息返回
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AutonymInfoReturn(EnterPriseInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //URL请求所需参数
                string username = "MerchantPlatform";
                //string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                //去除用户参数中包含的特殊字符
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);

                var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

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
        #endregion

        #region 发送验证邮件
        /// <summary>
        ///  商家平台_基本信息返回
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage EmailSend(UserInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //URL请求所需参数
                string username = "MerchantPlatform";
                //string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                //去除用户参数中包含的特殊字符
                model.UserEmail = ParametersFilter.FilterSqlHtml(model.UserEmail, 50);
                if (FilteParameter.CheckEmail(model.UserEmail))
                {
                    ReCommon.EmailHelper.MailSend("kf@zte-yd.com", "YUEgang888888", model.UserEmail);
                    //返回结果
                    Result = "{\"DATA\":[\"1\"]}";
                }
                else
                {
                    Result = "\"邮箱格式错误\"";
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }
        #endregion
    }
}
