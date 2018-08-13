using Newtonsoft.Json;
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
    public class RedpacketManageController : ApiController
    {
        #region 配置参数
        //string username = "DataSnapDebugTools";
        static string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
        static string password = ConfigurationManager.AppSettings[username];
        static string Url = ApiHelper.GetURL("operation", username);
        #endregion

        ///// <summary>
        ///// 提交红包活动数据表
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public HttpResponseMessage AddRedActivity(RedpacketManageModel model)
        //{
        //    string Result = string.Empty;

        //    try
        //    {
        //        //请求中包含的固定参数
        //        model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 24);
        //        model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 24);
        //        model.ADDRESS = HttpHelper.IPAddress();
        //        model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
        //        model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 24);
        //        model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 24);

        //        //去除参数中的特殊字符
        //        //model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 30);
        //        //model.EnterpriseName = ParametersFilter.FilterSqlHtml(model.EnterpriseName, 50);
        //        //model.CommodityName = ParametersFilter.FilterSqlHtml(model.CommodityName, 30);
        //        //model.CommodityCode = ParametersFilter.FilterSqlHtml(model.CommodityCode, 100);
        //        //model.MoneySum = ParametersFilter.FilterSqlHtml(model.MoneySum, 10);
        //        //model.UnitMoney = ParametersFilter.FilterSqlHtml(model.UnitMoney, 5);
        //        //model.StartName = ParametersFilter.FilterSqlHtml(model.StartName, 30);
        //        //model.DistributeState = ParametersFilter.FilterSqlHtml(model.DistributeState, 1);
        //        //model.ApplyTime = ParametersFilter.FilterSqlHtml(model.ApplyTime, 30);
        //        //model.SurplusMoney = ParametersFilter.FilterSqlHtml(model.SurplusMoney, 10);
        //        model.DATA = ParametersFilter.StripSQLInjection(model.DATA);


        //        //http请求
        //        Result = ApiHelper.HttpRequest(username, password, Url, model);

        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.LogError(ex.ToString());
        //    }
        //    //返回请求结果
        //    HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
        //    return Respend;
        //}

        /// <summary>
        /// 红包列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage EnumRedList(RedpacketManageModel model)
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

                ////去除参数中的特殊字符
                model.DistributeState = ParametersFilter.FilterSqlHtml(model.DistributeState, 1);


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
        /// 已结束红包列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage EnumEndRedList(RedpacketManageModel model)
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
        /// 修改推送状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage DistributeState(RedpacketManageModel model)
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

                //去除参数中的特殊字符
                //model.CheckState = ParametersFilter.FilterSqlHtml(model.CheckState, 1);

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
