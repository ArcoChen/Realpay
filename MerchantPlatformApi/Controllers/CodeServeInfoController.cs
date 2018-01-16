using Newtonsoft.Json;
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
using MerchantModel;

namespace MerchantPlatformApi.Controllers
{
    /// <summary>
    /// 赋码管理
    /// </summary>
    public class CodeServeInfoController : ApiController
    {
        #region 配置参数
        //URL请求所需参数
        //static string username = "MerchantPlatform";
        static string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
        static string password = ConfigurationManager.AppSettings[username];
        static string Url = ApiHelper.GetURL(username);

        private JsonSerializerSettings JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        #endregion

        /// <summary>
        ///  商家平台_编码购买历史
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage CodeServeTable(CodeServiceInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                //去除用户参数中包含的特殊字符
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);
                //model.PageNum = ParametersFilter.FilterSqlHtml(model.PageNum, 10);

                string Str = JsonConvert.SerializeObject(model, JSetting);

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

        /// <summary>
        ///  商家平台_编码下单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage CodePurchase(CodeServiceInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                //去除用户参数中包含的特殊字符
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);

                string Str = JsonConvert.SerializeObject(model, JSetting);

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

        /// <summary>
        ///  商家平台_激活比例
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ActivationRatio(CodeServiceInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                //去除用户参数中包含的特殊字符
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);
                //model.PageNum = ParametersFilter.FilterSqlHtml(model.PageNum, 10);

                string Str = JsonConvert.SerializeObject(model, JSetting);

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

        /// <summary>
        ///  商家平台_编码列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ProductCodeTable(ProductCodeInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                //去除用户参数中包含的特殊字符
                //model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);
                //model.ApplyUser = ParametersFilter.FilterSqlHtml(model.ApplyUser, 50);
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);
                //model.PageNum = ParametersFilter.FilterSqlHtml(model.PageNum, 10);

                string Str = JsonConvert.SerializeObject(model, JSetting);

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

        /// <summary>
        ///  商家平台_编码详情
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ProductCodeInfo(ProductCodeInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                //去除用户参数中包含的特殊字符
                //model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);
                //model.CodeStart = ParametersFilter.FilterSqlHtml(model.CodeStart, 30);
                //model.CodeEnd = ParametersFilter.FilterSqlHtml(model.CodeEnd, 30);
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);
                //model.PageNum = ParametersFilter.FilterSqlHtml(model.PageNum, 10);

                string Str = JsonConvert.SerializeObject(model, JSetting);

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


        /// <summary>
        ///  商家平台_编码总数返回
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage CodeSumReturn(UserInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                //去除用户参数中包含的特殊字符
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);

                string Str = JsonConvert.SerializeObject(model, JSetting);

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
    }
}
