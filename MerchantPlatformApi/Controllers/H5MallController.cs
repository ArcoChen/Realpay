using MerchantModel;
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
    public class H5MallController : ApiController
    {
        #region 配置参数
        //URL请求所需参数
        //static string username = "MerchantPlatform";
        static string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
        static string password = ConfigurationManager.AppSettings[username];
        static string Url = ApiHelper.GetURL("merchant", username);
        #endregion

        /// <summary>
        ///  商家平台_商城主页
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage MallHomepage(UserInfoModel model)
        {
            string Result = string.Empty;

            /////验证登录状态
            //bool ReturnCode = AuthHelper.AuthUserStatus(model);

            try
            {
                //if (ReturnCode)
                //{
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
                //}
                //else
                //{
                //    Result = "{\"RETURNCODE\":\"403\"}";
                //}
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

        /// <summary>
        ///  商家平台_品牌分类
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage BrandClassification(UserInfoModel model)
        {
            string Result = string.Empty;

            /////验证登录状态
            //bool ReturnCode = AuthHelper.AuthUserStatus(model);

            try
            {
                //if (ReturnCode)
                //{
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
                //}
                //else
                //{
                //    Result = "{\"RETURNCODE\":\"403\"}";
                //}

            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

        /// <summary>
        ///  商家平台_品牌商品信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage BrandCommodity(UserInfoModel model)
        {
            string Result = string.Empty;
            //bool ReturnCode = AuthHelper.AuthUserStatus(model);

            try
            {
                //if (ReturnCode)
                //{
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
                //}
                //else
                //{
                //    Result = "{\"RETURNCODE\":\"403\"}";
                //}
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

        /// <summary>
        ///  商城_添加购物车
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddShopping(UserInfoModel model)
        {
            string Result = string.Empty;
            //bool ReturnCode = AuthHelper.AuthUserStatus(model);

            try
            {
                //if (ReturnCode)
                //{
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
                //}
                //else
                //{
                //    Result = "{\"RETURNCODE\":\"403\"}";
                //}
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
