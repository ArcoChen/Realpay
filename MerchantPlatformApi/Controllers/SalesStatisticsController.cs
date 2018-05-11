﻿using MerchantModel;
using Newtonsoft.Json;
using ReCommon;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace MerchantPlatformApi.Controllers
{
    public class SalesStatisticsController : ApiController
    {
        #region 配置参数
        //URL请求所需参数
        static string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
        //string username = "DataSnapDebugTools";
        static string password = ConfigurationManager.AppSettings[username];
        static string Url = ApiHelper.GetURL("merchant", username);

        #endregion

        /// <summary>
        /// 销售统计
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage SalesStatistics(UserInfoModel model)
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

            }
            catch (Exception ex)
            {

                LogHelper.Error(ex.ToString());
            }
            HttpResponseMessage Respond = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respond;
        }

        /// <summary>
        /// 销售统计列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage SalesStatisticsTable(UserInfoModel model)
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

            }
            catch (Exception ex)
            {

                LogHelper.Error(ex.ToString());
            }
            HttpResponseMessage Respond = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respond;
        }

        /// <summary>
        /// 用户统计
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UserDistribution(UserInfoModel model)
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

            }
            catch (Exception ex)
            {

                LogHelper.Error(ex.ToString());
            }
            HttpResponseMessage Respond = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respond;
        }

        /// <summary>
        /// 用户统计列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UserDistributionTable(UserInfoModel model)
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

            }
            catch (Exception ex)
            {

                LogHelper.Error(ex.ToString());
            }
            HttpResponseMessage Respond = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respond;
        }

        /// <summary>
        /// 消费行为分析
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ConsumptionBehavior(UserInfoModel model)
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

            }
            catch (Exception ex)
            {

                LogHelper.Error(ex.ToString());
            }
            HttpResponseMessage Respond = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respond;
        }

        /// <summary>
        /// 消费行为分析列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ConsumptionBehaviorTable(UserInfoModel model)
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