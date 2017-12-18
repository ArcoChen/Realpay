using Newtonsoft.Json;
using PayManageMentModel;
using ReCommon;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace PayMentManageApi.Controllers
{
    public class MerchantSettlementManageController : ApiController
    {
        /// <summary>
        /// 支付管理平台_返回结算报表列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage SettlementReportList(SettlementRermModel model)
        {
            string Result = string.Empty;

            try
            {
                string username = "DataSnapDebugTools";
                //string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                ////去除参数中的特殊字符


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
        /// 支付管理平台_结算报表申报
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage SettlementDeclare(SettlementRermModel model)
        {
            string Result = string.Empty;

            try
            {
                string username = "DataSnapDebugTools";
                //string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);

                ////去除参数中的特殊字符


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
        /// 支付管理平台_结算金额详情(交易记录)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage MerChantSettlementDetail(DealCheckModel model)
        {
            string Result = string.Empty;

            try
            {
                string username = "DataSnapDebugTools";
                //string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                ////去除参数中的特殊字符
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);

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
        /// 支付管理平台_查询结算报表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage SearchSettlementReport(SettlementRermModel model)
        {
            string Result = string.Empty;

            try
            {
                string username = "DataSnapDebugTools";
                //string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                ////去除参数中的特殊字符
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);
                model.StartTime = ParametersFilter.FilterSqlHtml(model.StartTime, 50);
                model.EndTime = ParametersFilter.FilterSqlHtml(model.EndTime, 50);
                model.PageNum = ParametersFilter.FilterSqlHtml(model.PageNum, 5);

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
        /// 支付管理平台_返回结算申报列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage SettlementDeclareList(SettlementRermModel model)
        {
            string Result = string.Empty;

            try
            {
                string username = "DataSnapDebugTools";
                //string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                ////去除参数中的特殊字符

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
        /// 支付管理平台_返回账号平台余额
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage PlatformBalance(DealCheckModel model)
        {
            string Result = string.Empty;

            try
            {
                string username = "DataSnapDebugTools";
                //string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                ////去除参数中的特殊字符

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
        /// 支付管理平台_结算（支付）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage SettleAccounts(DealCheckModel model)
        {
            string Result = string.Empty;

            try
            {
                string username = "DataSnapDebugTools";
                //string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                ////去除参数中的特殊字符
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);

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
        /// 支付管理平台_查询结算申报
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage SearchSettlementDeclare(SettlementRermModel model)
        {
            string Result = string.Empty;

            try
            {
                string username = "DataSnapDebugTools";
                //string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                ////去除参数中的特殊字符
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);
                model.Settlement = ParametersFilter.FilterSqlHtml(model.Settlement, 50);

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
        /// 支付管理平台_返回对账列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UserWithdrawList(DealCheckModel model)
        {
            string Result = string.Empty;

            try
            {
                string username = "DataSnapDebugTools";
                //string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                ////去除参数中的特殊字符

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
        /// 支付管理平台_返回对账列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UpdateExceptionAccount(DealCheckModel model)
        {
            string Result = string.Empty;

            try
            {
                string username = "DataSnapDebugTools";
                //string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);

                ////去除参数中的特殊字符

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
        /// 支付管理平台_查询对账列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage SearchReconciliation(DealCheckModel model)
        {
            string Result = string.Empty;

            try
            {
                string username = "DataSnapDebugTools";
                //string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                ////去除参数中的特殊字符
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);
                model.StartTime = ParametersFilter.FilterSqlHtml(model.StartTime, 50);
                model.EndTime = ParametersFilter.FilterSqlHtml(model.EndTime, 50);

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
        /// 支付管理平台_返回结算周期列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage SettlementCycleList(SettlementRermModel model)
        {
            string Result = string.Empty;

            try
            {
                string username = "DataSnapDebugTools";
                //string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                ////去除参数中的特殊字符

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
        /// 支付管理平台_修改结算周期
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UpdateSettlementCycle(SettlementRermModel model)
        {
            string Result = string.Empty;

            try
            {
                string username = "DataSnapDebugTools";
                //string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

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
        /// 支付管理平台_查询结算周期
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage SearchSettlementCycle(SettlementRermModel model)
        {
            string Result = string.Empty;

            try
            {
                string username = "DataSnapDebugTools";
                //string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                string password = ConfigurationManager.AppSettings[username];
                string Url = ApiHelper.GetURL(username);

                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                ////去除参数中的特殊字符
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);
                model.StartTime = ParametersFilter.FilterSqlHtml(model.StartTime, 50);
                model.EndTime = ParametersFilter.FilterSqlHtml(model.EndTime, 50);

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

    }
}
