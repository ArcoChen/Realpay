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
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MerchantPlatformApi.Controllers
{
    /// <summary>
    /// 账号管理（信息返回）
    /// </summary>
    public class MerchantInfoReturnController : ApiController
    {
        /// <summary>
        ///  商家平台_基本信息返回
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> BasicInfoReturn(UserInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //URL请求所需参数
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

                //去除用户参数中包含的特殊字符
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);

                var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

                string Str = JsonConvert.SerializeObject(model, JSetting);

                //返回结果
                Result = await Task<string>.Run(() => ApiHelper.HttpRequest(username, password, Url, Str));
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
        public async Task<HttpResponseMessage> MerchantInfoReturn(EnterPriseInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //URL请求所需参数
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

                //去除用户参数中包含的特殊字符
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);

                var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

                string Str = JsonConvert.SerializeObject(model, JSetting);

                //返回结果
                Result = await Task<string>.Run(() => ApiHelper.HttpRequest(username, password, Url, Str));
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
        public async Task<HttpResponseMessage> AutonymInfoReturn(EnterPriseInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //URL请求所需参数
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

                //去除用户参数中包含的特殊字符
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);

                var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

                string Str = JsonConvert.SerializeObject(model, JSetting);

                //返回结果
                Result = await Task<string>.Run(() => ApiHelper.HttpRequest(username, password, Url, Str));

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