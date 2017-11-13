﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OperationPlatformModel;
using System.Configuration;
using ReCommon;
using Newtonsoft.Json;
using System.Text;
using System.Web;

namespace OperationPlatformApi.Controllers
{
    public class PlatformReportManageController : ApiController
    {
        /// <summary>
        /// 提交举报信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddReportInfo(PlatformReportModel model)
        {
            string Result = string.Empty;

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
            model.CommodityCode = ParametersFilter.FilterSqlHtml(model.CommodityCode, 50);
            model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 30);
            model.ReportTime = ParametersFilter.FilterSqlHtml(model.ReportTime, 30);
            model.ReportUser = ParametersFilter.FilterSqlHtml(model.ReportUser, 30);
            model.UserAddress = ParametersFilter.FilterSqlHtml(model.UserAddress, 100);
            model.ReportProblem = ParametersFilter.FilterSqlHtml(model.ReportProblem, 500);
            model.ScreenShot = ParametersFilter.FilterSqlHtml(model.ScreenShot, 500);
            model.ReportState = ParametersFilter.FilterSqlHtml(model.ReportState, 1);

            //序列化
            var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

            string Str = JsonConvert.SerializeObject(model, JSetting);

            //http请求
            Result = ApiHelper.HttpRequest(username, password, Url, Str);

            //返回请求结果
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respend;
        }

        /// <summary>
        /// 待处理举报信息列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage EnumPendingReportList(PlatformReportModel model)
        {
            string Result = string.Empty;

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
            model.DATA = ParametersFilter.FilterSqlHtml(model.DATA, 50);

            //序列化
            var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

            string Str = JsonConvert.SerializeObject(model, JSetting);

            //http请求
            Result = ApiHelper.HttpRequest(username, password, Url, Str);

            //返回请求结果
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respend;
        }

        /// <summary>
        /// 提交处理结果
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UpdateCheckState(PlatformReportModel model)
        {
            string Result = string.Empty;

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
            model.CommodityCode = ParametersFilter.FilterSqlHtml(model.CommodityCode, 50);
            model.ReportState = ParametersFilter.FilterSqlHtml(model.ReportState, 1);
            model.CheckIdea = ParametersFilter.FilterSqlHtml(model.CheckIdea, 500);

            //序列化
            var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

            string Str = JsonConvert.SerializeObject(model, JSetting);

            //http请求
            Result = ApiHelper.HttpRequest(username, password, Url, Str);

            //返回请求结果
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respend;
        }

        /// <summary>
        /// 已处理举报信息列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage SolveReportList(PlatformReportModel model)
        {
            string Result = string.Empty;

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
            //model.CommodityCode = ParametersFilter.FilterSqlHtml(model.CommodityCode, 50);
            //model.ReportState = ParametersFilter.FilterSqlHtml(model.ReportState, 1);
            //model.CheckIdea = ParametersFilter.FilterSqlHtml(model.CheckIdea, 500);

            //序列化
            var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

            string Str = JsonConvert.SerializeObject(model, JSetting);

            //http请求
            Result = ApiHelper.HttpRequest(username, password, Url, Str);

            //返回请求结果
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respend;
        }

        /// <summary>
        /// 修改处理结果
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UpDateState(PlatformReportModel model)
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
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);

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
