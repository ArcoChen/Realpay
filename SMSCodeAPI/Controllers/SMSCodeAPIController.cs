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

namespace SMSCodeAPI.Controllers
{
    public class SMSCodeAPIController : ApiController
    {
        /// <summary>
        /// 获取手机验证码
        /// </summary>
        /// <param name="UserMobile">手机号</param>
        /// <returns>验证码</returns>
        [HttpPost]
        public HttpResponseMessage GetAuthCode(BaseModel model)
        {
            string Result = string.Empty;
            
            //实例化发送短信类
            SMSCode.SMSCode AuthCode = new SMSCode.SMSCode();

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

                //生成六位随机验证码
                model.Verification = SMSCode.SMSCode.GetAuthCode(100000, 999999);

                BaseModel redis = new BaseModel();

                redis.RedisIP = "r-wz9c03c34034e434554.redis.rds.aliyuncs.com";
                redis.RedisPort = "6379";
                redis.RedisPassword = "Yuegang888888";
                redis.RedisKey = "AuthCode_" + model.UserMobile;
                redis.RedisValue = model.Verification;
                redis.LifeCycle = "60";
                redis.RedisFunction = "StringSet";

                if ((ApiHelper.HttpRequest(ApiHelper.GetRedisURL(redis.RedisFunction), redis)) == "True")
                {
                    //发送短信
                    AuthCode.SendMessage(model.UserMobile, model.Verification);

                    var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

                    Result = JsonConvert.SerializeObject(model, JSetting);
                }
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
        public HttpResponseMessage SMSVerification(BaseModel model)
        {
            string Result = string.Empty;

            //实例化发送短信类
            SMSCode.SMSCode AuthCode = new SMSCode.SMSCode();

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

                //生成六位随机验证码
                model.Verification = SMSCode.SMSCode.GetAuthCode(100000, 999999);

                BaseModel redis = new BaseModel();

                redis.RedisIP = "r-wz9c03c34034e434554.redis.rds.aliyuncs.com";
                redis.RedisPort = "6379";
                redis.RedisPassword = "Yuegang888888";
                redis.RedisKey = "AuthCode_" + model.UserMobile;
                redis.LifeCycle = "60";
                redis.RedisFunction = "StringGet";
                string CacheCode = (ApiHelper.HttpRequest(ApiHelper.GetRedisURL(redis.RedisFunction), redis));
                if (CacheCode == model.Verification)
                {
                    Result = "{\"result\":\"1\"}";
                }
                else if(CacheCode=="null")
                {
                    Result = "{\"result\":\"2\"}";
                }
                else
                {
                    Result = "{\"result\":\"0\"}";
                }

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
