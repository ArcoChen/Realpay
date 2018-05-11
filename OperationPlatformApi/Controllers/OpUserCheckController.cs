using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OperationPlatformModel;
using ReCommon;
using System.Web;
using Newtonsoft.Json;
using System.Text;
using System.Configuration;
using CacheManager;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RedisModel;

namespace OperationPlatformApi.Controllers
{
    public class OpUserCheckController : ApiController
    {
        #region 配置参数
        //static string username = "DataSnapDebugTools";
        static string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
        static string password = ConfigurationManager.AppSettings[username];
        static string Url = ApiHelper.GetURL("operation", username);
        #endregion

        /// <summary>
        /// 获取手机验证码
        /// </summary>
        /// <param name="UserMobile">手机号</param>
        /// <returns>验证码</returns>
        [HttpPost]
        public HttpResponseMessage GetAuthCode(OperationPlatformModel.BaseModel model)
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


                Result = ApiHelper.HttpRequest(username, password, Url, model);

                JObject json = (JObject)JsonConvert.DeserializeObject(Result);

                if (json["DATA"][0]["result"].ToString() == "true")
                {
                    string AuthCode = ApiHelper.HttpRequest(ApiHelper.GetAuthCodeURL("smsCodeIp", "sms", "GetAuthCode"), model);
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
        /// 用户登录
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
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 24);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 24);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 24);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 24);

                //去除参数中的特殊字符
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 30);
                model.UserPasswd = ParametersFilter.FilterSqlHtml(model.UserPasswd, 64);

                //http请求
                Result = ApiHelper.HttpRequest(username, password, Url, model);
                JObject jsons = (JObject)JsonConvert.DeserializeObject(Result);
                if (jsons["DATA"][0]["login_msg"].ToString() == "Login successful")
                {
                    model.UserMobile = jsons["DATA"][0]["UserMobile"].ToString();
                    //返回凭证
                    jsons["CREDENTIALS"] = AuthHelper.AuthUserSet(model);
                    Result = JsonConvert.SerializeObject(jsons);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
            }

            //返回请求结果
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respend;
        }

        ///// <summary>
        ///// 手机号登录
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public HttpResponseMessage MobileLogin(OperationPlatformModel.BaseModel model)
        //{
        //    string Result = string.Empty;

        //    try
        //    {
        //        //请求中包含的固定参数
        //        model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 24);
        //        model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 24);
        //        model.ADDRESS = HttpHelper.IPAddress();
        //        model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
        //        model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 24);
        //        model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 24);

        //        //去除参数中的特殊字符
        //        model.UserMobile = ParametersFilter.FilterSqlHtml(model.UserMobile, 11);
        //        model.Verification = ParametersFilter.FilterSqlHtml(model.Verification, 6);

        //        //获取Redis中的验证码
        //        string GetRedisAuthCode = ApiHelper.HttpRequest(ApiHelper.GetAuthCodeURL("smsCodeIp", "sms", "VerifyAuthCode"), model);

        //        JObject jsons = (JObject)JsonConvert.DeserializeObject(GetRedisAuthCode);

        //        if (jsons["result"].ToString() == "2")
        //        {
        //            Result = "{\"DATA\":[{\"result\":\"验证码已过时\"}]}";
        //        }
        //        else if (jsons["result"].ToString() == "1")
        //        {

        //            Result = ApiHelper.HttpRequest(username, password, Url, model);
        //            JObject jsonData = (JObject)JsonConvert.DeserializeObject(Result);
        //            if (jsonData["DATA"][0].ToString() == "1")
        //            {
        //                model.UserAccount = jsonData["UserAccount"].ToString();
        //                //返回凭证
        //                jsonData["CREDENTIALS"] = AuthHelper.AuthUserSet(model);
        //                Result = JsonConvert.SerializeObject(jsonData);
        //            }
        //        }
        //        else
        //        {
        //            Result = "{\"DATA\":[{\"result\":\"验证码错误\"}]}";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error(ex.Message);
        //    }

        //    //返回请求结果
        //    HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
        //    return Respend;
        //}
    }
}
