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
using ImageModel;

namespace MerchantPlatformApi.Controllers
{
    public class MerchantCheckController : ApiController
    {
        #region 配置参数
        //URL请求所需参数
        //static string username = "MerchantPlatform";
        static string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
        static string password = ConfigurationManager.AppSettings[username];
        static string Url = ApiHelper.GetURL("merchant", username);

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
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 24);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 24);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 24);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 24);

                //去除用户参数中包含的特殊字符
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);

                string imgString = model.UserAvatar.Split(new char[] { ',' })[1];

                //图片Model
                ImgModel imgModel = new ImgModel();

                imgModel.ImgIp = ApiHelper.ImgURL();
                imgModel.ImgDisk = SingleXmlInfo.GetInstance().GetWebApiConfig("imgDisk");
                imgModel.ImgRoot = SingleXmlInfo.GetInstance().GetWebApiConfig("imgRoot");
                imgModel.ImgAttribute = "user";
                imgModel.UserAccount = model.UserAccount;
                imgModel.ImgName = "useravatar";
                imgModel.ImgString = imgString;

                model.UserAvatar = ApiHelper.HttpRequest(ApiHelper.GetImgUploadURL("imgUploadIp", "imgUpload"), imgModel);
                model.UserAvatar = model.UserAvatar.Replace("\"", "");

                //返回结果
                Result = ApiHelper.HttpRequest(username, password, Url, model);

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
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 24);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 24);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 24);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 24);

                //去除用户参数中包含的特殊字符
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);
                model.UserPasswd = ParametersFilter.FilterSqlHtml(model.UserPasswd, 50);
                model.LoginIP = HttpHelper.IPAddress();

                //返回结果
                Result = ApiHelper.HttpRequest(username, password, Url, model);
                JObject jsons = (JObject)JsonConvert.DeserializeObject(Result);
                if (jsons["DATA"][0].ToString() == "1")
                {
                    model.UserMobile = jsons["UserMobile"].ToString();
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
        ///  商家平台_修改注册地址
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UpdateUseraddress(UserInfoModel model)
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
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);

                //返回结果
                Result = ApiHelper.HttpRequest(username, password, Url, model);
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
                model.LoginIP = HttpHelper.IPAddress();
                model.Verification = ParametersFilter.FilterSqlHtml(model.Verification, 6);

                //获取Redis中的验证码
                string GetRedisAuthCode = ApiHelper.HttpRequest(ApiHelper.GetAuthCodeURL("smsCodeIp", "sms", "VerifyAuthCode"), model);

                JObject jsons = (JObject)JsonConvert.DeserializeObject(GetRedisAuthCode);


                if (jsons["result"].ToString() == "1")
                {

                    Result = ApiHelper.HttpRequest(username, password, Url, model);
                    JObject jsonData = (JObject)JsonConvert.DeserializeObject(Result);
                    if (jsonData["DATA"][0].ToString() == "1")
                    {
                        model.UserAccount = jsonData["UserAccount"].ToString();
                        //返回凭证
                        jsonData["CREDENTIALS"] = AuthHelper.AuthUserSet(model);
                        Result = JsonConvert.SerializeObject(jsonData);
                    }
                }
                else
                {
                    Result = "{\"DATA\":" + GetRedisAuthCode + "}";
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

                if (json["DATA"][0].ToString() == "1")
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

                if (json["DATA"][0].ToString() == "0")
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
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 24);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 24);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 24);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 24);

                //去除提交的数据中的不安全字符
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);


                Result = ApiHelper.HttpRequest(username, password, Url, model);

                JObject json = (JObject)JsonConvert.DeserializeObject(Result);

                if (json["DATA"][0].ToString() == "1")
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
    }
}
