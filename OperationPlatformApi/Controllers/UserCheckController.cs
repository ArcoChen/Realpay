using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OperationPlatformModel;
using ReCommon;
using SMSCode;
using System.Web;
using Newtonsoft.Json;
using System.Text;
using System.Configuration;
using CacheManager;

namespace OperationPlatformApi.Controllers
{
    public class UserCheckController : ApiController
    {
        /// <summary>
        /// 获取手机验证码
        /// </summary>
        /// <param name="UserMobile">手机号</param>
        /// <returns>验证码</returns>
        [HttpPost]
        public HttpResponseMessage GetAuthCode(UserInfoModel model)
        {

            //请求中包含的固定参数
            model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
            model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
            model.ADDRESS = HttpHelper.IPAddress();
            model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
            model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
            model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

            //去除提交的数据中的不安全字符
            if (FilteParameter.CheckPhoneIsAble(model.UserMobile) == true)
            {
                model.UserMobile = ParametersFilter.FilterSqlHtml(model.UserMobile, 11);
            }

            //生成六位随机验证码
            string Verification = SMSCode.SMSCode.GetAuthCode(100000, 999999);

            model.Verification = Verification;

            SMSCode.SMSCode AuthCode = new SMSCode.SMSCode();

            //缓存验证码
            RuntimeCache.Cache.Add(model.UserMobile, Verification);

            //发送短信
            AuthCode.SendMessage(model.UserMobile, Verification);

            var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

            string Str = JsonConvert.SerializeObject(model, JSetting);

            HttpResponseMessage Result = new HttpResponseMessage { Content = new StringContent(Str, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Result;
        }

        /// <summary>
        /// 验证验证码
        /// </summary>
        /// <param name="UserMobile">手机号</param>
        /// <param name="Verification">验证码</param>
        /// <returns>验证码</returns>
        [HttpPost]
        public HttpResponseMessage CheckAuthCode(UserInfoModel model)
        {

            //请求中包含的固定参数
            model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
            model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
            model.ADDRESS = HttpHelper.IPAddress();
            model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
            model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
            model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

            //去除提交的数据中的不安全字符
            if (FilteParameter.CheckPhoneIsAble(model.UserMobile) == true)
            {
                model.UserMobile = ParametersFilter.FilterSqlHtml(model.UserMobile, 11);
            }

            //读取缓存的验证码
            string Verification = RuntimeCache.Cache.Get(model.UserMobile).ToString();

            if(Verification==model.Verification)
            {

            }

            var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

            string Str = JsonConvert.SerializeObject(model, JSetting);

            HttpResponseMessage Result = new HttpResponseMessage { Content = new StringContent(Str, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Result;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UserRegister(UserInfoModel model)
        {
            string Result = string.Empty;

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

                //去除参数中的特殊字符
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 30);
                model.UserPasswd = ParametersFilter.FilterSqlHtml(model.UserPasswd, 64);
                if (FilteParameter.CheckEmail(model.Email) == true)
                {
                    model.Email = ParametersFilter.FilterSqlHtml(model.Email, 30);
                }
                if (FilteParameter.CheckPhoneIsAble(model.UserMobile) == true)
                {
                    model.UserMobile = ParametersFilter.FilterSqlHtml(model.UserMobile, 11);
                }
                model.UserType = ParametersFilter.FilterSqlHtml(model.UserType, 1);

                //序列化
                var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

                string Str = JsonConvert.SerializeObject(model, JSetting);

                //http请求
                Result = ApiHelper.HttpRequest(username, password, Url, Str);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }

            //返回请求结果
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respend;
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

            //string username = "DataSnapDebugTools";
            string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
            string password = ConfigurationManager.AppSettings[username];
            string Url = ApiHelper.GetURL(username);

            try
            {
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                //去除参数中的特殊字符
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 30);
                model.UserPasswd = ParametersFilter.FilterSqlHtml(model.UserPasswd, 64);

                //序列化
                var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

                string Str = JsonConvert.SerializeObject(model, JSetting);

                //http请求
                Result = ApiHelper.HttpRequest(username, password, Url, Str);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);
            }

            //返回请求结果
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respend;
        }
    }
}
