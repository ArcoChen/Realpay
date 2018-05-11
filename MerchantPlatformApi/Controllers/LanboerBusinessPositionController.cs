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
    public class LanboerBusinessPositionController : ApiController
    {
        #region 配置参数
        //URL请求所需参数
        static string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
        //string username = "DataSnapDebugTools";
        static string password = ConfigurationManager.AppSettings[username];
        static string Url = ApiHelper.GetURL("merchant", username);
        #endregion

        /// <summary>
        ///  商家平台_商家注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage LanboerBusinessPosition(TerminalModel model)
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

                //去除用户参数中包含的特殊字符
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);

                //返回结果
                Result = ApiHelper.HttpRequest(username, password, Url, model);

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
