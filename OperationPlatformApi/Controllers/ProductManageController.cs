﻿using Newtonsoft.Json;
using OperationPlatformModel;
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

namespace OperationPlatformApi.Controllers
{
    public class ProductManageController : ApiController
    {
        #region 配置参数
        //string username = "DataSnapDebugTools";
        static string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
        static string password = ConfigurationManager.AppSettings[username];
        static string Url = ApiHelper.GetURL("operation", username);
        #endregion

        /// <summary>
        /// 审核商品详情
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AuditinCommodityDetail(ProductCodeModel model)
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

                //去除参数中的特殊字符
                model.CommodityName = ParametersFilter.FilterSqlHtml(model.CommodityName, 30);

                //http请求
                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);
            }
            catch (Exception ex)
            {

                LogHelper.LogError(ex.ToString());
            }

            //返回请求结果
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respend;
        }

        /// <summary>
        /// 品牌列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage BrandInformation(ProductCodeModel model)
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
                model.DATA = ParametersFilter.FilterSqlHtml(model.DATA, 50);

                //http请求
                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);
            }
            catch (Exception ex)
            {

                LogHelper.LogError(ex.ToString());
            }

            //返回请求结果
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respend;
        }

        /// <summary>
        /// 品牌下商品信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage CommodityInformation(ProductCodeModel model)
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

                //去除参数中的特殊字符
                model.BrandName = ParametersFilter.FilterSqlHtml(model.BrandName, 100);

                //http请求
                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);
            }
            catch (Exception ex)
            {

                LogHelper.LogError(ex.ToString());
            }

            //返回请求结果
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respend;
        }

        /// <summary>
        /// 审核商品列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AuditinCommodityList(ProductCodeModel model)
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

                model.AuditingState = ParametersFilter.FilterSqlHtml(model.AuditingState, 1);

                //http请求
                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);
            }
            catch (Exception ex)
            {

                LogHelper.LogError(ex.ToString());
            }

            //返回请求结果
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respend;
        }

        /// <summary>
        /// 终端审核列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AuditTerminalList(ProductCodeModel model)
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

                model.ValidateStatus = ParametersFilter.FilterSqlHtml(model.AuditingState, 1);


                //http请求
                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);
            }
            catch (Exception ex)
            {

                LogHelper.LogError(ex.ToString());
            }

            //返回请求结果
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respend;
        }

        /// <summary>
        /// 修改审核状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UpdateAuditinState(ProductCodeModel model)
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
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);


                //http请求
                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);
            }
            catch (Exception ex)
            {

                LogHelper.LogError(ex.ToString());
            }

            //返回请求结果
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respend;
        }

        /// <summary>
        /// 修改终端审核状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UpdateValidateStatus(ProductCodeModel model)
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
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);


                //http请求
                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);
            }
            catch (Exception ex)
            {

                LogHelper.LogError(ex.ToString());
            }

            //返回请求结果
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respend;
        }
    }
}
