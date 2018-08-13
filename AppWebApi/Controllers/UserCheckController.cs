using System;
using System.Net.Http;
using System.Web.Http;
using ReCommon;
using AppModel;
using System.Text;
using System.Configuration;
using Newtonsoft.Json;
using System.Web;
using Newtonsoft.Json.Linq;
using ImageModel;


namespace AppWebApi.Controllers
{
    public class UserCheckController : ApiController
    {
        #region 配置参数
        //URL请求所需参数
        static string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
        //string username = "DataSnapDebugTools";
        static string password = ConfigurationManager.AppSettings[username];
        static string Url = ApiHelper.GetURL("app", username);
        #endregion

        /// <summary>
        /// 验证手机是否注册（未注册发送验证码）
        /// </summary>
        /// <param name="UserMobile">手机号</param>
        /// <returns>验证码</returns>
        [HttpPost]
        public HttpResponseMessage AccountProving(RedisModel.BaseModel model)
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

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);

                if (json["DATA"][0]["result"].ToString() == "false")
                {
                    string AuthCode = ApiHelper.HttpRequest(username, password, ApiHelper.GetAuthCodeURL("smsCodeIp", "sms", "GetAuthCode"), model);
                }
            }
            catch (Exception ex)
            {

                LogHelper.LogError(ex.ToString());
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
        public HttpResponseMessage ProvingAccount(RedisModel.BaseModel model)
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

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);

                JObject json = (JObject)JsonConvert.DeserializeObject(Result);

                if (json["DATA"][0]["result"].ToString() == "true")
                {
                    string AuthCode = ApiHelper.HttpRequest(ApiHelper.GetAuthCodeURL("smsCodeIp", "sms", "GetAuthCode"), model);
                }
            }
            catch (Exception ex)
            {

                LogHelper.LogError(ex.ToString());
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
        public HttpResponseMessage GetAuthCode(RedisModel.BaseModel model)
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

                ////去除提交的数据中的不安全字符
                model.UserMobile = ParametersFilter.FilterSqlHtml(model.UserMobile, 11);

                //请求验证码
                Result = ApiHelper.HttpRequest(ApiHelper.GetAuthCodeURL("smsCodeIp", "sms", "GetAuthCode"), model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex.ToString());
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

                if (jsons["result"].ToString() == "2")
                {
                    Result = "{\"DATA\":[{\"result\":\"验证码已过时\"}]}";
                }
                else if (jsons["result"].ToString() == "1")
                {
                    Result = "{\"DATA\":[{\"result\":\"true\"}]}";
                }
                else
                {
                    Result = "{\"DATA\":[{\"result\":\"验证码错误\"}]}";
                }

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex.ToString());
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

        /// <summary>
        /// 完善用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UserInfo(UserInfoModel model)
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
                model.DATA = System.Web.HttpUtility.UrlDecode(model.DATA);

                #region MyRegion
                //DATA装换为json字符串
                string datatojson = ApiHelper.DATAToJson(model.DATA);

                string UserAccount = JObject.Parse(datatojson)["UserAccount"].ToString();

                //图片Model
                ImgModel imgModel = new ImgModel();

                imgModel.ImgIp = ApiHelper.ImgURL();
                imgModel.ImgDisk = SingleXmlInfo.GetInstance().GetWebApiConfig("imgDisk");
                imgModel.ImgRoot = SingleXmlInfo.GetInstance().GetWebApiConfig("imgRoot");
                imgModel.ImgAttribute = "user";
                imgModel.UserAccount = UserAccount;
                imgModel.ImgName = "userAvatar";
                imgModel.ImgString = model.UserAvatar;

                //URL编码
                model.DATA = System.Web.HttpUtility.UrlEncode(model.DATA);

                //保存的图片名称
                model.UserAvatar = imgModel.ImgIp + imgModel.UserAccount + "/" + imgModel.ImgAttribute + "/" + imgModel.ImgName + ".jpg";

                //返回结果
                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ////解析返回结果
                JObject jsons = (JObject)JsonConvert.DeserializeObject(Result);

                if (jsons["DATA"][0]["Result"].ToString() == "1")
                {
                    ApiHelper.HttpRequest(ApiHelper.GetImgUploadURL("imgUploadIp", "imgUpload"), imgModel);

                    model.UserMobile = jsons["DATA"][0]["UserMobile"].ToString();
                    model.UserAccount = jsons["DATA"][0]["UserAccount"].ToString();

                    //返回凭证
                    jsons["CREDENTIALS"] = AuthHelper.AuthUserSet(model);
                    Result = JsonConvert.SerializeObject(jsons);
                }
                #endregion

                #region Redis_DATA
                //UserCheckBLL B = new UserCheckBLL();
                //Dictionary<string, string> redisData = B.UserInfo_Redis(model.DATA);

                //string imgStr = model.UserAvatar;

                //model.UserAvatar = redisData["UserAvatar"];
                //string Str = JsonConvert.SerializeObject(model, JSetting);

                ////返回结果
                //Result = ApiHelper.HttpRequest(username, password, Url, Str);

                //////解析返回结果
                //JObject jsons = (JObject)JsonConvert.DeserializeObject(Result);

                //if (jsons["DATA"][0]["Result"].ToString() == "1")
                //{
                //    // CharConversion.SaveImg(imgStr, model.UserAvatar, "~/Avatar/");

                //    //实例化Redis请求参数
                //    RedisModel.BaseModel redis = new RedisModel.BaseModel();

                //    redis.RedisIP = SingleXmlInfo.GetInstance().GetWebApiConfig("redisAddress");
                //    redis.RedisPort = SingleXmlInfo.GetInstance().GetWebApiConfig("redisPort");
                //    redis.RedisPassword = SingleXmlInfo.GetInstance().GetWebApiConfig("redisPassword");
                //    redis.RedisKey = "PAY_USER_Info_ " + redisData["UserAccount"];
                //    redis.RedisValue = ApiHelper.DictionaryToStr(redisData);
                //    redis.LifeCycle = "50000";
                //    redis.RedisFunction = "StringSet";

                //    //获取Redis中的验证码
                //    string b = ApiHelper.HttpRequest(ApiHelper.GetRedisURL(redis.RedisFunction), redis);
                //} 
                #endregion

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex.ToString());
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
        public HttpResponseMessage PaymentPassword(UserInfoModel model)
        {
            string Result = string.Empty;
            //bool ReturnCode = AuthHelper.AuthUserStatus(model);

            try
            {
                //if (ReturnCode)
                //{
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 24);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 24);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 24);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 24);
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);
                if (model.TERMINAL == "2")
                {
                    model.DATA = System.Web.HttpUtility.UrlEncode(model.DATA);
                }


                //返回结果
                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);
                //}
                //else
                //{
                //    Result = "{\"RETURNCODE\":\"403\"}";
                //}
            }
            catch (Exception ex)
            {

                LogHelper.LogError(ex.ToString());
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

        #region 登录密码
        /// <summary>
        /// 忘记密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ForgetPasswd(UserInfoModel model)
        {
            string Result = string.Empty;
            //bool ReturnCode = AuthHelper.AuthUserStatus(model);

            try
            {
                //if (ReturnCode)
                //{
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 24);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 24);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 24);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 24);
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);
                if (model.TERMINAL == "2")
                {
                    model.DATA = System.Web.HttpUtility.UrlEncode(model.DATA);
                }


                //返回结果
                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);
                //}
                //else
                //{
                //    Result = "{\"RETURNCODE\":\"403\"}";
                //}
            }
            catch (Exception ex)
            {

                LogHelper.LogError(ex.ToString());
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
        public HttpResponseMessage ModifyPasswd(ProductInfoModel model)
        {

            string Result = string.Empty;
            //bool ReturnCode = AuthHelper.AuthUserStatus(model);

            try
            {
                //if (ReturnCode)
                //{
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 24);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 24);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 24);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 24);

                if (model.TERMINAL == "2")
                {
                    model.DATA = System.Web.HttpUtility.UrlEncode(model.DATA);
                }

                //返回结果
                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);
            }
            //    else
            //    {
            //        Result = "{\"RETURNCODE\":\"403\"}";
            //    }
            //}
            catch (Exception ex)
            {

                LogHelper.LogError(ex.ToString());
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
        public HttpResponseMessage PasswdProving(UserInfoModel model)
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


                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 30);
                model.UserPasswd = ParametersFilter.FilterSqlHtml(model.UserPasswd, 32);

                //返回结果
                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);

            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex.ToString());
                Result = ex.ToString();
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }
        #endregion

        #region 支付密码
        /// <summary>
        /// 忘记支付密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ForgetPayPasswd(UserInfoModel model)
        {
            string Result = string.Empty;
            //bool ReturnCode = AuthHelper.AuthUserStatus(model);

            try
            {
                //if (ReturnCode)
                //{
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 24);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 24);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 24);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 24);
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);
                if (model.TERMINAL == "2")
                {
                    model.DATA = System.Web.HttpUtility.UrlEncode(model.DATA);
                }


                //返回结果
                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);
                //}
                //else
                //{
                //    Result = "{\"RETURNCODE\":\"403\"}";
                //}
            }
            catch (Exception ex)
            {

                LogHelper.LogError(ex.ToString());
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

        /// <summary>
        /// 修改支付密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ModifyPayPasswd(ProductInfoModel model)
        {

            string Result = string.Empty;
            //bool ReturnCode = AuthHelper.AuthUserStatus(model);

            try
            {
                //if (ReturnCode)
                //{
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 24);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 24);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 24);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 24);

                if (model.TERMINAL == "2")
                {
                    model.DATA = System.Web.HttpUtility.UrlEncode(model.DATA);
                }

                //返回结果
                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);
            }
            //    else
            //    {
            //        Result = "{\"RETURNCODE\":\"403\"}";
            //    }
            //}
            catch (Exception ex)
            {

                LogHelper.LogError(ex.ToString());
                Result = ex.ToString();
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

        /// <summary>
        /// 验证支付密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage PayPasswdProving(UserInfoModel model)
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


                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 64);
                model.PayPasswd = ParametersFilter.FilterSqlHtml(model.PayPasswd, 64);

                //返回结果
                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);

            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex.ToString());
                Result = ex.ToString();
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }
        #endregion

    }
}
