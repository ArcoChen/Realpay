using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AppModel;
using ReCommon;
using System.Configuration;
using Newtonsoft.Json;
using System.Text;
using System.Web;
using CacheManager;
using System.Threading.Tasks;

namespace AppWebApi.Controllers
{
    public class UserLoginController : ApiController
    {
        #region 配置参数
        //URL请求所需参数
        static string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
        //string username = "DataSnapDebugTools";
        static string password = ConfigurationManager.AppSettings[username];
        static string Url = ApiHelper.GetURL(username);

        JsonSerializerSettings JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        #endregion

        /// <summary>
        /// 账号密码登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> UserLogin(UserInfoModel model)
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
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 30);
                model.UserPasswd = ParametersFilter.FilterSqlHtml(model.UserPasswd, 30);
                model.UserMobile = ParametersFilter.StripSQLInjection(model.UserMobile);
                //model.UserEmail = ParametersFilter.StripSQLInjection(model.UserEmail);

                if (model.TERMINAL == "2")
                {
                    if (model.UserAccount != null)
                    {
                        model.UserMobile = "";
                        //model.UserEmail = "";
                    }
                    else
                    {
                        model.UserAccount = "";
                        //model.UserEmail = "";
                    }
                }

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
        /// 手机验证码登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> MobileLogin(UserInfoModel model)
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
                model.Verification = ParametersFilter.FilterSqlHtml(model.Verification, 6);

                #region 验证缓存验证码
                //if (RuntimeCache.Cache.Get(model.UserMobile) != null)
                //{
                //    if (RuntimeCache.Cache.Get(model.UserMobile).ToString() == model.Verification)
                //    {
                //        var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

                //        string Str = JsonConvert.SerializeObject(model, JSetting);

                //        Result = ApiHelper.HttpRequest(username, password, Url, Str);
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
                    Result = "{\"DATA\":[{\"result\":\"验证码已过时\"}]}";
                }
                else if (GetRedisAuthCode == model.Verification)
                {
                    string Str = JsonConvert.SerializeObject(model, JSetting);

                    Result = await Task<string>.Run(() => ApiHelper.HttpRequest(username, password, Url, Str));
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
    }
}
