using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MerchantModel;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;
using ReCommon;
using Newtonsoft.Json;
using System.Text;

namespace MerchantPlatformApi.Controllers
{

    /// <summary>
    /// 认证举报
    /// </summary>
    public class CommodityReportIdentController : ApiController
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
        ///  商家平台_返回待处理举报列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UndisposedReportTable(PseudoCodeIdentModel model)
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
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);

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
        ///  商家平台_返回已处理举报列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage DisposedReportTable(CommodityReportIdentModel model)
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
        ///  商家平台_处理举报内容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage DisposedReport(CommodityReportIdentModel model)
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
                //model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);
                //model.CommodityCode = ParametersFilter.FilterSqlHtml(model.CommodityCode, 100);
                //model.ReportState = ParametersFilter.FilterSqlHtml(model.ReportState, 1);
                //model.ReportProblem = ParametersFilter.FilterSqlHtml(model.ReportProblem, 500);

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
        ///  商家平台_举报处理审核
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage DisposedReportAudit(CommodityReportIdentModel model)
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
                //model.CommodityCode = ParametersFilter.FilterSqlHtml(model.CommodityCode, 100);
                //model.ReportState = ParametersFilter.FilterSqlHtml(model.ReportState, 1);
                //model.ReportProblem = ParametersFilter.FilterSqlHtml(model.ReportProblem, 500);
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
    }
}
