using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ReCommon;
using RedisModel;
using CacheManager;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Web;

namespace SMSCodeAPI.Controllers
{
    public class SMSCodeAPIController : ApiController
    {

        private static JsonSerializerSettings JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        /// <summary>
        /// 获取手机验证码
        /// </summary>
        /// <param name="UserMobile">手机号</param>
        /// <returns>验证码</returns>
        [HttpPost]
        public HttpResponseMessage GetAuthCode(BaseModel model)
        {
            string Result = string.Empty;

            try
            {

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 24);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 24);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 24);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 24);

                //去除提交的数据中的不安全字符
                model.UserMobile = ParametersFilter.FilterSqlHtml(model.UserMobile, 11);

                //生成六位随机验证码
                model.Verification = SMSCode.SMSCode.GetAuthCode(100000, 999999);

                BaseModel redis = new BaseModel();

                redis.RedisIP = SingleXmlInfo.GetInstance().GetWebApiConfig("redisAddress");
                redis.RedisPort = SingleXmlInfo.GetInstance().GetWebApiConfig("redisPort");
                redis.RedisPassword = SingleXmlInfo.GetInstance().GetWebApiConfig("redisPassword");
                redis.RedisKey = "User_Account_Auth_" + model.UserMobile;
                redis.RedisValue = model.Verification;
                redis.LifeCycle = "120";
                redis.RedisFunction = "StringSet";

                //发送短信
                string Code = SMSCode.SMSCode.SendMessage(model.UserMobile, model.Verification);
                LogHelper.LogResopnse("Code:" + Code);
                if (Code == "OK")
                {
                    if ((ApiHelper.HttpRequest(ApiHelper.GetRedisURL("redisIp", "redis", redis.RedisFunction), redis)) == "True")
                    {
                        ////发送短信
                        //SMSCode.SMSCode.SendMessage(model.UserMobile, model.Verification);
                        model.Code = "1";
                    }
                }
                else
                {
                    model.Verification = null;
                    model.Code = "0";
                }

                Result = JsonConvert.SerializeObject(model, JSetting);

                ///写日志
                string RequestAction = "api/SMSCodeAPI/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }

            #region 缓存验证码
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

            HttpResponseMessage Responsed = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Responsed;
        }

        /// <summary>
        /// 审核手机验证码(0-失败 1-成功 2-超时)
        /// </summary>
        /// <param name="UserMobile">手机号</param>
        /// <param name="Verification">验证码</param>
        /// <returns>验证码</returns>
        [HttpPost]
        public HttpResponseMessage VerifyAuthCode(BaseModel model)
        {
            string Result = string.Empty;

            //实例化发送短信类
            SMSCode.SMSCode AuthCode = new SMSCode.SMSCode();

            try
            {

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 24);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 24);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 24);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 24);

                //去除提交的数据中的不安全字符
                model.UserMobile = ParametersFilter.FilterSqlHtml(model.UserMobile, 11);
                model.Verification = ParametersFilter.FilterSqlHtml(model.Verification, 6);

                BaseModel redis = new BaseModel();

                redis.RedisIP = SingleXmlInfo.GetInstance().GetWebApiConfig("redisAddress");
                redis.RedisPort = SingleXmlInfo.GetInstance().GetWebApiConfig("redisPort");
                redis.RedisPassword = SingleXmlInfo.GetInstance().GetWebApiConfig("redisPassword");
                redis.RedisKey = "User_Account_Auth_" + model.UserMobile;
                redis.LifeCycle = "120";
                redis.RedisFunction = "StringGet";
                string CacheCode = (ApiHelper.HttpRequest(ApiHelper.GetRedisURL("redisIp", "redis", redis.RedisFunction), redis));
                if (CacheCode == model.Verification)
                {
                    Result = "{\"result\":\"1\"}";
                }
                else if (CacheCode == "null")
                {
                    Result = "{\"result\":\"2\"}";
                }
                else
                {
                    Result = "{\"result\":\"0\"}";
                }

                ///写日志
                string RequestAction = "api/SMSCodeAPI/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);

            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }

            #region 缓存验证码
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

            HttpResponseMessage Responsed = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Responsed;
        }

        /// <summary>
        /// 短信查询
        /// </summary>
        /// <param name="UserMobile">手机号</param>
        /// <returns>验证码</returns>
        [HttpPost]
        public HttpResponseMessage querySendDetails(BaseModel model)
        {
            string Result = string.Empty;

            try
            {

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 24);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 24);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 24);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 24);

                //去除提交的数据中的不安全字符
                model.UserMobile = ParametersFilter.FilterSqlHtml(model.UserMobile, 11);
                Result = SMSCode.SMSCode.querySendDetails(model.UserMobile);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }

            #region 缓存验证码
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

            HttpResponseMessage Responsed = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Responsed;
        }
    }
}
