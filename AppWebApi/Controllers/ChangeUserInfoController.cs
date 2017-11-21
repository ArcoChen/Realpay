using AppModel;
using CacheManager;
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

namespace AppWebApi.Controllers
{
    public class ChangeUserInfoController : ApiController
    {
        /// <summary>
        /// 修改手机号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> ChangePhoneNumber(RedisModel.BaseModel model)
        {
            string Result = string.Empty;

            try
            {
                //URL请求所需参数
                string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                //string username = "DataSnapDebugTools";
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                //获取上传的DATA参数
                string postData = System.Web.HttpUtility.UrlDecode(model.DATA);
                Dictionary<string, string> data = new Dictionary<string, string>();
                var Object = JToken.Parse(postData);

                //遍历存入字典
                for (int i = 0; i < Object.First.Count(); i++)
                {
                    data.Add(Object.First[i].ToString(), Object.Last[i].ToString());
                }

                model.Verification = data["Verification"].ToString();
                model.NewPhoneNumber = data["NewPhoneNumber"].ToString();


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
                //redis.RedisPort = "6379";
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
                //获取Redis中的验证码
                string GetRedisAuthCode = ApiHelper.HttpRequest(ApiHelper.GetAuthCodeURL(), model);
                JObject json = (JObject)JsonConvert.DeserializeObject(GetRedisAuthCode);

                if (json["result"].ToString() == "2")
                {

                    Result = "{\"DATA\":[{\"result\":\"验证码已过时\"}]}";
                }
                else if (json["result"].ToString() == "1")
                {
                    var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

                    string Str = JsonConvert.SerializeObject(model, JSetting);

                    //返回结果
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


        /// <summary>
        /// 更改邮箱
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> ChangeUserEmail(UserInfoModel model)
        {
            string Result = string.Empty;

            //URL请求所需参数
            string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
            //string username = "DataSnapDebugTools";
            string password = ConfigurationManager.AppSettings[username];
            string Url = ApiHelper.GetURL(username);

            //请求中包含的固定参数
            model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
            model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
            model.ADDRESS = HttpHelper.IPAddress();
            model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
            model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
            model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);
            if (model.TERMINAL == "2")
            {
                model.DATA = System.Web.HttpUtility.UrlEncode(model.DATA);
            }

            ////去除用户参数中包含的特殊字符
            //Dictionary<string, string> data = new Dictionary<string, string>();
            //data.Add("NewPhoneNumber", model.NewPhoneNumber);

            ////请求数据拼接为JSON格式
            //string Str = JsonTransfrom.SeaRequsetToJson(model.SOURCE, model.CREDENTIALS, HttpHelper.IPAddress(), model.TERMINAL, model.INDEX, model.METHOD, data);

            var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

            string Str = JsonConvert.SerializeObject(model, JSetting);

            //返回结果
            Result = await Task<string>.Run(() => ApiHelper.HttpRequest(username, password, Url, Str));

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

        /// <summary>
        /// 修改用户头像
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ChangeUserUserAvatar(UserInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //URL请求所需参数
                string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                //string username = "DataSnapDebugTools";
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 30);
                if (model.TERMINAL == "2")
                {
                    model.DATA = System.Web.HttpUtility.UrlEncode(model.DATA);
                }

                //保存用户头像
                model.UserAvatar = CharConversion.SaveImg(model.UserAvatar, model.UserAccount, "/Avatar/");


                //返回结果
                if (model.UserAvatar.Length > 16)
                {
                    Result = "{ \"Result\":\"Success\"}";
                }
                else
                {
                    Result = "{\"Result\":\"Fail\"}";
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
