using ImageModel;
using MerchantModel;
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

namespace MerchantPlatformApi.Controllers
{
    /// <summary>
    /// 商家信息管理（信息完善）
    /// </summary>
    public class MerchantInfoManageController : ApiController
    {
        #region 配置参数
        //URL请求所需参数
        //static string username = "MerchantPlatform";
        static string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
        static string password = ConfigurationManager.AppSettings[username];
        static string Url = ApiHelper.GetURL("merchant",username);
        #endregion

        #region 账号信息完善修改
        /// <summary>
        ///  商家平台_头像更新（0 – 失败 1 – 成功）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage HeadPortraitUpdate(UserInfoModel model)
        {
            #region MyRegion
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
            #endregion
        }

        /// <summary>
        ///  商家平台_品牌logo更新（0 – 失败 1 – 成功）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage BrandLogoUpdate(UserInfoModel model)
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

                string imgString = model.BrandLogo.Split(new char[] { ',' })[1];

                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);

                //图片Model
                ImgModel imgModel = new ImgModel();
                imgModel.ImgIp = ApiHelper.ImgURL();
                imgModel.ImgDisk = SingleXmlInfo.GetInstance().GetWebApiConfig("imgDisk");
                imgModel.ImgRoot = SingleXmlInfo.GetInstance().GetWebApiConfig("imgRoot");
                imgModel.ImgAttribute = "user";
                imgModel.UserAccount = model.UserAccount;
                imgModel.ImgName = "brandlogo";
                imgModel.ImgString = imgString;

                model.BrandLogo = ApiHelper.HttpRequest(ApiHelper.GetImgUploadURL("imgUploadIp", "imgUpload"), imgModel);
                model.BrandLogo = model.BrandLogo.Replace("\"", "");

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
        ///  商家平台_营业执照更新（0 – 失败 1 – 成功）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage BusinessLicenseUpdate(UserInfoModel model)
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

                string imgString = model.BusinessLicense.Split(new char[] { ',' })[1];

                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);
                //图片Model
                ImgModel imgModel = new ImgModel();
                imgModel.ImgIp = ApiHelper.ImgURL();
                imgModel.ImgDisk = SingleXmlInfo.GetInstance().GetWebApiConfig("imgDisk");
                imgModel.ImgRoot = SingleXmlInfo.GetInstance().GetWebApiConfig("imgRoot");
                imgModel.ImgAttribute = "user";
                imgModel.UserAccount = model.UserAccount;
                imgModel.ImgName = "businesslicense";
                imgModel.ImgString = imgString;

                model.BusinessLicense = ApiHelper.HttpRequest(ApiHelper.GetImgUploadURL("imgUploadIp", "imgUpload"), imgModel);
                model.BusinessLicense = model.BusinessLicense.Replace("\"", "");

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
        ///  商家平台_邮箱更新（0 – 失败 1 – 成功）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UserEmailUpdate(UserInfoModel model)
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
        ///  商家平台_手机更新（0 – 失败 1 – 成功  2 – 手机号码重复）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UserMobileUpdate(UserInfoModel model)
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
        ///  商家平台_密码修改（0 – 成功 1 – 失败 2 – 密码错误）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ModifyOldPasswd(UserInfoModel model)
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
        ///  商家平台_实名认证（0 – 成功 1 – 失败）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UserInfoIdentification(UserInfoModel model)
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
        #endregion

        #region 企业信息认证
        /// <summary>
        ///  商家平台_(商家信息)企业信息认证插入（0 – 失败 1 –成功）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage EnterpriseInfoInsert(UserInfoModel model)
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
                string imgString = model.BusinessLicense.Split(new char[] { ',' })[1];
                string logoString = model.BrandLogo.Split(new char[] { ',' })[1];

                #region 保存图片
                //图片Model
                ImgModel imgModel = new ImgModel();
                imgModel.ImgIp = ApiHelper.ImgURL();
                imgModel.ImgDisk = SingleXmlInfo.GetInstance().GetWebApiConfig("imgDisk");
                imgModel.ImgRoot = SingleXmlInfo.GetInstance().GetWebApiConfig("imgRoot");
                imgModel.ImgAttribute = "user";
                imgModel.UserAccount = model.UserAccount;
                imgModel.ImgName = "businesslicense";
                imgModel.ImgString = imgString;

                model.BusinessLicense = ApiHelper.HttpRequest(ApiHelper.GetImgUploadURL("imgUploadIp", "imgUpload"), imgModel);
                model.BusinessLicense = model.BusinessLicense.Replace("\"", "");

                //图片Model
                ImgModel BlogoModel = new ImgModel();
                BlogoModel.ImgIp = ApiHelper.ImgURL();
                BlogoModel.ImgDisk = SingleXmlInfo.GetInstance().GetWebApiConfig("imgDisk");
                BlogoModel.ImgRoot = SingleXmlInfo.GetInstance().GetWebApiConfig("imgRoot");
                BlogoModel.ImgAttribute = "user";
                BlogoModel.UserAccount = model.UserAccount;
                BlogoModel.ImgName = "brandlogo";
                BlogoModel.ImgString = imgString;
                model.BrandLogo = ApiHelper.HttpRequest(ApiHelper.GetImgUploadURL("imgUploadIp", "imgUpload"), BlogoModel);
                model.BrandLogo = model.BrandLogo.Replace("\"", "");
                #endregion

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
        ///  商家平台_(商家信息)修改企业信息（0 – 失败 1 –成功）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage EnterpriseInfoUpdate(UserInfoModel model)
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
        ///  商家平台_开通支付（0 – 失败 1 –成功）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage PaymentOpening(UserInfoModel model)
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
        #endregion

        #region 短信信息
        /// <summary>
        /// 验证手机是否注册（注册了发送验证码）
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

                    string AuthCode = ApiHelper.HttpRequest(ApiHelper.GetAuthCodeURL("smsCodeIp", "sms","GetAuthCode"), model);
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
        /// 验证验证码
        /// </summary>
        /// <param name="UserMobile">手机号</param>
        /// <param name="SMSCode">验证码</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage VerifyAuthCode(RedisModel.BaseModel model)
        {
            string Result = string.Empty;

            //URL请求所需参数
            //string username = "UserCheck";

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


                //实例化Redis请求参数
                RedisModel.BaseModel redis = new RedisModel.BaseModel();

                redis.RedisIP = SingleXmlInfo.GetInstance().GetWebApiConfig("redisAddress");
                redis.RedisPort = SingleXmlInfo.GetInstance().GetWebApiConfig("redisPort");
                redis.RedisPassword = SingleXmlInfo.GetInstance().GetWebApiConfig("redisPassword");
                redis.RedisKey = "AuthCode_" + model.UserMobile;
                redis.RedisValue = model.Verification;
                redis.LifeCycle = "120";
                redis.RedisFunction = "StringGet";

                //获取Redis中的验证码
                string GetRedisAuthCode = ApiHelper.HttpRequest(ApiHelper.GetAuthCodeURL("smsCodeIp", "sms", "VerifyAuthCode"), model);

                JObject jsons = (JObject)JsonConvert.DeserializeObject(GetRedisAuthCode);

                if (jsons["result"].ToString() == "2")
                {
                    Result = "{\"DATA\":[{\"result\":\"2\"}]}";
                }
                else if (jsons["result"].ToString() == "1")
                {
                    Result = "{\"DATA\":[{\"result\":\"1\"}]}";
                }
                else
                {
                    Result = "{\"DATA\":[{\"result\":\"0\"}]}";
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }
        #endregion

        #region 信息返回
        /// <summary>
        ///  商家平台_基本信息返回
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage BasicInfoReturn(UserInfoModel model)
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
        ///  商家平台_企业信息返回
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage MerchantInfoReturn(EnterPriseInfoModel model)
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
        ///  商家平台_实名信息返回
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AutonymInfoReturn(EnterPriseInfoModel model)
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
        ///  商家平台_行业编码返回
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage IndustryInfoReturn(EnterPriseInfoModel model)
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
        #endregion

        #region 验证邮箱
        /// <summary>
        ///  商家平台_发送验证邮件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage EmailSend(UserInfoModel model)
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
                string UrlDecData = HttpUtility.UrlDecode(model.DATA);
                //DATA装换为json字符串
                string datatojson = ApiHelper.DATAToJson(UrlDecData);

                model.UserEmail = JObject.Parse(datatojson)["UserEmail"].ToString();

                var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

                //序列化参数
                string str = JsonConvert.SerializeObject(model, JSetting);

                //生成随机码
                string VerifyCode = CharConversion.GenerateRandomNumber(12);

                if (FilteParameter.CheckEmail(model.UserEmail))
                {
                    //发送邮件
                    ReCommon.EmailHelper.MailSend("kf@zte-yd.com", "YUEgang888888", model.UserEmail, VerifyCode);

                    //实例化Redis请求参数
                    RedisModel.BaseModel redis = new RedisModel.BaseModel();

                    redis.RedisIP = SingleXmlInfo.GetInstance().GetWebApiConfig("redisAddress");
                    redis.RedisPort = SingleXmlInfo.GetInstance().GetWebApiConfig("redisPort");
                    redis.RedisPassword = SingleXmlInfo.GetInstance().GetWebApiConfig("redisPassword");
                    redis.RedisKey = "User_Account_EmailCode_" + VerifyCode;
                    redis.RedisValue = str;
                    redis.LifeCycle = "600";
                    redis.RedisFunction = "StringSet";

                    //保存邮箱信息
                    string GetRedisAuthCode = ApiHelper.HttpRequest(ApiHelper.GetRedisURL("redisIp","redis",redis.RedisFunction), redis);

                    //返回结果
                    Result = "{\"DATA\":[\"1\"]}";
                }
                else
                {
                    Result = "\"邮箱格式错误\"";
                }

                datatojson = null;
                JSetting = null;
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

        /// <summary>
        ///  商家平台_邮箱认证（0 – 失败 1 – 成功）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        [Route("v/{id}")]
        public HttpResponseMessage UserEmailIdent(string id)
        {
            string Result = string.Empty;
            try
            {
                //实例化Redis请求参数
                RedisModel.BaseModel redis = new RedisModel.BaseModel();

                redis.RedisIP = SingleXmlInfo.GetInstance().GetWebApiConfig("redisAddress");
                redis.RedisPort = SingleXmlInfo.GetInstance().GetWebApiConfig("redisPort");
                redis.RedisPassword = SingleXmlInfo.GetInstance().GetWebApiConfig("redisPassword");
                redis.RedisKey = "User_Account_EmailCode_" + id;
                redis.RedisFunction = "StringGet";

                //获取redis中保存的邮箱信息
                string Str = ApiHelper.HttpRequest(ApiHelper.GetRedisURL("redisIp","redis",redis.RedisFunction), redis);

                //返回结果
                Result = ApiHelper.HttpRequest(username, password, Url, Str);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }
        #endregion

        #region 支付信息
        /// <summary>
        ///  商家平台_添加支付信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage PaymentInfoInsert(PaymentModel model)
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
        ///  商家平台_关闭支付
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage PaymentOpen(PaymentModel model)
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
        ///  商家平台_关闭支付
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage PaymentClose(PaymentModel model)
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
        ///  商家平台_支付状态返回
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage PaymentStatu(PaymentModel model)
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
        ///  商家平台_支付账号详情返回
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage PayInfoReturn(PaymentModel model)
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
                model.Status = ParametersFilter.FilterSqlHtml(model.Status, 1);

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
        #endregion
    }
}
