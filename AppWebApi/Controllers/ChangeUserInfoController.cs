using AppModel;
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
using RedisModel;
using ImageModel;

namespace AppWebApi.Controllers
{
    public class ChangeUserInfoController : ApiController
    {
        #region 配置参数
        //URL请求所需参数
        static string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
        //string username = "DataSnapDebugTools";
        static string password = ConfigurationManager.AppSettings[username];
        static string Url = ApiHelper.GetURL("app", username);

        #endregion

        /// <summary>
        /// 修改手机号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ChangePhoneNumber(RedisModel.BaseModel model)
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
                model.DATA = System.Web.HttpUtility.UrlDecode(model.DATA);

                string datatojson = ApiHelper.DATAToJson(model.DATA);
                model.Verification = JObject.Parse(datatojson)["Verification"].ToString();
                model.UserMobile = JObject.Parse(datatojson)["NewPhoneNumber"].ToString();
                model.DATA = System.Web.HttpUtility.UrlEncode(model.DATA);

                #region 注释代码
                #region MyRegion
                //string UserAccount = JObject.Parse(datatojson)["UserAccount"].ToString();
                ////获取上传的DATA参数
                //string postData = System.Web.HttpUtility.UrlDecode(model.DATA);
                //Dictionary<string, string> data = new Dictionary<string, string>();
                //var Object = JToken.Parse(postData);

                ////遍历存入字典
                //for (int i = 0; i < Object.First.Count(); i++)
                //{
                //    data.Add(Object.First[i].ToString(), Object.Last[i].ToString());
                //}

                //model.Verification = data["Verification"].ToString();
                //model.NewPhoneNumber = data["NewPhoneNumber"].ToString();
                #endregion
                #region 判断缓存验证码
                ////判断验证码是否正确
                //if (RuntimeCache.Cache.Get(data["NewPhoneNumber"].ToString()) != null)
                //{

                //    if (RuntimeCache.Cache.Get(data["NewPhoneNumber"].ToString()).ToString() == model.Verification)
                //    {

                //        var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

                //        string Str = JsonConvert.SerializeObject(model, JSetting);

                //        //返回结果
                //        Result = ApiHelper.HttpRequest(username, password, Url, Str);
                //    }
                //    else
                //    {
                //        Result = "{\"DATA\":[{\"result\":\"验证码错误\"}]}";
                //    }
                //}
                //else {
                //    Result = "{\"DATA\":[{\"result\":\"验证码已过时\"}]}";
                //} 
                #endregion
                #region 实例化redis请求参数
                ////实例化Redis请求参数
                //RedisModel.BaseModel redis = new RedisModel.BaseModel();

                //redis.RedisIP = "127.0.0.1";
                //redis.RedisPort = SingleXmlInfo.GetInstance().GetWebApiConfig("redisPort");
                //redis.RedisPassword = "yg50";
                //redis.RedisKey = "AuthCode_" + model.NewPhoneNumber;
                //redis.RedisValue = model.Verification;
                //redis.LifeCycle = "60";
                //redis.RedisFunction = "StringGet";

                ////获取Redis中的验证码
                //string GetRedisAuthCode = ApiHelper.HttpRequest(ApiHelper.GetRedisURL(redis.RedisFunction), redis);

                //if (GetRedisAuthCode == "null")
                //{
                //    Result = "{\"DATA\":[{\"result\":\"验证码已过时\"}]}";
                //}
                //else if (GetRedisAuthCode == model.Verification)
                //{
                //    var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

                //    string Str = JsonConvert.SerializeObject(model, JSetting);

                //    //返回结果
                //    Result = await Task<string>.Run(() => ApiHelper.HttpRequest(username, password, Url, Str));
                //}
                //else
                //{
                //    Result = "{\"DATA\":[{\"result\":\"验证码错误\"}]}";
                //} 
                #endregion
                #endregion

                //获取Redis中的验证码
                string GetRedisAuthCode = ApiHelper.HttpRequest(ApiHelper.GetAuthCodeURL("smsCodeIp", "sms", "VerifyAuthCode"), model);
                JObject json = (JObject)JsonConvert.DeserializeObject(GetRedisAuthCode);

                JObject jobject = new JObject();
                jobject.Add("RETURNCODE", "200");
                jobject.Add("SOURCE", model.SOURCE);
                jobject.Add("CREDENTIALS", model.CREDENTIALS);
                jobject.Add("ADDRESS", model.ADDRESS);
                jobject.Add("TERMINAL", model.TERMINAL);
                jobject.Add("INDEX", model.INDEX);
                jobject.Add("METHOD", model.METHOD);

                #region 判断验证码
                if (json["result"].ToString() == "2")
                {
                    jobject.Add("result", "2");
                    Result = jobject.ToString();
                }
                else if (json["result"].ToString() == "1")
                {

                    //返回结果
                    Result = ApiHelper.HttpRequest(username, password, Url, model);
                }
                else
                {
                    jobject.Add("result", "3");
                    Result = jobject.ToString();
                }
                #endregion
                //}
                //else
                //{
                //    Result = "{\"RETURNCODE\":\"403\"}";
                //}

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
        /// 更改邮箱
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ChangeUserEmail(UserInfoModel model)
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
                //}
                //else
                //{
                //    Result = "{\"RETURNCODE\":\"403\"}";
                //}

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
        /// 修改用户头像
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ChangeUserAvatar(UserInfoModel model)
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
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 30);
                if (model.TERMINAL == "2")
                {
                    model.DATA = System.Web.HttpUtility.UrlEncode(model.DATA);
                }

                //图片Model
                ImgModel imgModel = new ImgModel();

                imgModel.ImgIp = ApiHelper.ImgURL();
                imgModel.ImgDisk = SingleXmlInfo.GetInstance().GetWebApiConfig("imgDisk");
                imgModel.ImgRoot = SingleXmlInfo.GetInstance().GetWebApiConfig("imgRoot");
                imgModel.ImgAttribute = "user";
                imgModel.UserAccount = model.UserAccount;
                imgModel.ImgName = "useravatar";
                imgModel.ImgString = model.UserAvatar;

                //保存用户头像
                model.UserAvatar = ApiHelper.HttpRequest(ApiHelper.GetImgUploadURL("imgUploadIp", "imgUpload"), imgModel);
                model.UserAvatar = model.UserAvatar.Replace("\"", "");


                //返回结果
                if (model.UserAvatar.Length > 16)
                {
                    Result = "{ \"Result\":\"Success\"}";
                }
                else
                {
                    Result = "{\"Result\":\"Fail\"}";
                }
                //}
                //else
                //{
                //    Result = "{\"RETURNCODE\":\"403\"}";
                //}

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

        #region 地址信息
        /// <summary>
        /// 添加地址信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddAddressInfo(AddressModel model)
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
                if (model.TERMINAL == "2")
                {
                    model.DATA = System.Web.HttpUtility.UrlEncode(model.DATA);
                }

                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);

            }
            catch (Exception ex)
            {

                LogHelper.LogError(ex.ToString());
            }
            HttpResponseMessage Respond = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respond;
        }

        /// <summary>
        /// 删除地址信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage DelAddressInfo(AddressModel model)
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
                model.AddressId = ParametersFilter.FilterSqlHtml(model.AddressId, 10);

                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);

            }
            catch (Exception ex)
            {

                LogHelper.LogError(ex.ToString());
            }
            HttpResponseMessage Respond = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respond;
        }

        /// <summary>
        /// 修改地址信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UpdateAddressInfo(AddressModel model)
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
                if (model.TERMINAL == "2")
                {
                    model.DATA = System.Web.HttpUtility.UrlEncode(model.DATA);
                }

                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);

            }
            catch (Exception ex)
            {

                LogHelper.LogError(ex.ToString());
            }
            HttpResponseMessage Respond = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respond;
        }

        /// <summary>
        /// 更新默认地址信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UpdateDefaultAddress(AddressModel model)
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
                if (model.TERMINAL == "2")
                {
                    model.DATA = System.Web.HttpUtility.UrlEncode(model.DATA);
                }

                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);

            }
            catch (Exception ex)
            {

                LogHelper.LogError(ex.ToString());
            }
            HttpResponseMessage Respond = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respond;
        }

        /// <summary>
        /// 更新默认地址信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage SelectAddressInfo(AddressModel model)
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
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 24);

                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);

            }
            catch (Exception ex)
            {

                LogHelper.LogError(ex.ToString());
            }
            HttpResponseMessage Respond = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respond;
        }
        #endregion

    }
}
