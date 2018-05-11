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
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace AppWebApi.Controllers
{
    public class UserLoginController : ApiController
    {
        #region 配置参数
        //URL请求所需参数
        //string username = "DataSnapDebugTools";
        static string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
        static string password = ConfigurationManager.AppSettings[username];
        static string Url = ApiHelper.GetURL("app",username);
        #endregion

        /// <summary>
        /// 账号密码登录
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
                    }
                    else
                    {
                        model.UserAccount = "";
                    }
                }

                //返回结果
                Result = ApiHelper.HttpRequest(username, password, Url, model);

                //解析返回结果
                JObject jsons = (JObject)JsonConvert.DeserializeObject(Result);
                if (jsons["DATA"][0]["result"].ToString() == "登录成功！")
                {
                    model.UserMobile = jsons["DATA"][0]["UserMobile"].ToString();

                    //返回凭证
                    jsons["CREDENTIALS"] = AuthHelper.AuthUserSet(model);
                    Result = JsonConvert.SerializeObject(jsons);
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
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 24);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 24);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 24);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 24);

                model.UserMobile = ParametersFilter.FilterSqlHtml(model.UserMobile, 11);
                model.Verification = ParametersFilter.FilterSqlHtml(model.Verification, 6);

                //获取Redis中的验证码
                string GetRedisAuthCode = ApiHelper.HttpRequest(ApiHelper.GetAuthCodeURL("smsCodeIp", "sms", "VerifyAuthCode"), model);

                JObject jsons = (JObject)JsonConvert.DeserializeObject(GetRedisAuthCode);

                //判断验证返回值
                if (jsons["result"].ToString() == "2")
                {
                    Result = "{\"DATA\":[{\"result\":\"验证码已过时\"}]}";
                }
                else if (jsons["result"].ToString() == "1")
                {

                    Result = ApiHelper.HttpRequest(username, password, Url, model);
                    JObject jsonData = (JObject)JsonConvert.DeserializeObject(Result);
                    if (jsonData["DATA"][0]["result"].ToString() == "登录成功！")
                    {
                        model.UserAccount = jsonData["DATA"][0]["UserAccount"].ToString();

                        //返回凭证
                        jsonData["CREDENTIALS"] = AuthHelper.AuthUserSet(model);
                        Result = JsonConvert.SerializeObject(jsonData);
                    }
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
