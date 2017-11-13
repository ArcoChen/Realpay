using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OperationPlatformModel;
using ReCommon;
using Newtonsoft.Json;
using System.Text;
using System.Web;

namespace OperationPlatformApi.Controllers
{
    public class ActivityManageController : ApiController
    {
        /// <summary>
        /// 提交广告申请表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddAdvertisementApply(ActivityManageModel model)
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
                model.DATA = FilteParameter.FilteSQLStr(model.DATA);

                ////去除参数中的特殊字符
                //model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 30);
                //model.FilePosition = ParametersFilter.FilterSqlHtml(model.FilePosition, 50);
                //model.LinkPosition = ParametersFilter.FilterSqlHtml(model.LinkPosition, 50);
                //model.StartTime = ParametersFilter.FilterSqlHtml(model.StartTime, 50);
                //model.PushNum = ParametersFilter.FilterSqlHtml(model.PushNum, 10);
                //model.TollAmount = ParametersFilter.FilterSqlHtml(model.TollAmount, 10);
                //model.ApplyTime = ParametersFilter.FilterSqlHtml(model.ApplyTime, 30);
                //model.PushState = ParametersFilter.FilterSqlHtml(model.PushState, 1);
                //model.PositionNumber = ParametersFilter.FilterSqlHtml(model.PositionNumber, 2);
                //model.IndustryName = ParametersFilter.FilterSqlHtml(model.IndustryName, 10);

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
        /// 待支付列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage EnumActivityList(ActivityManageModel model)
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

                model.PushState = ParametersFilter.FilterSqlHtml(model.PushState, 1);

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
        /// 结束列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage EnumEndActivityList(ActivityManageModel model)
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
        /// 修改活动审核状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UpdateState(ActivityManageModel model)
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
            model.DATA = FilteParameter.FilteSQLStr(model.DATA);

            //去除参数中的特殊字符
            //model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 30);
            //model.FilePosition = ParametersFilter.FilterSqlHtml(model.FilePosition, 50);
            //model.LinkPosition = ParametersFilter.FilterSqlHtml(model.LinkPosition, 50);
            //model.StartTime = ParametersFilter.FilterSqlHtml(model.StartTime, 50);
            //model.PushNum = ParametersFilter.FilterSqlHtml(model.PushNum, 10);
            //model.TollAmount = ParametersFilter.FilterSqlHtml(model.TollAmount, 10);
            //model.ApplyTime = ParametersFilter.FilterSqlHtml(model.ApplyTime, 30);
            //model.PushState = ParametersFilter.FilterSqlHtml(model.PushState, 1);
            //model.PositionNumber = ParametersFilter.FilterSqlHtml(model.PositionNumber, 2);
            //model.IndustryName = ParametersFilter.FilterSqlHtml(model.IndustryName, 10);

            //序列化
            var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

            string Str = JsonConvert.SerializeObject(model, JSetting);

            //http请求
            Result = ApiHelper.HttpRequest(username, password, Url, Str);

            //返回请求结果
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }
    }
}
