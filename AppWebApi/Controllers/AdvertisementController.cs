using AppModel;
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

namespace AppWebAPI.Controllers
{
    public class AdvertisementController : ApiController
    {
        #region 配置参数
        //URL请求所需参数
        static string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
        //static string username = "DataSnapDebugTools";
        static string password = ConfigurationManager.AppSettings[username];
        static string Url = ApiHelper.GetURL("app", username);
        #endregion

        /// <summary>
        /// 广告
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Advertisement(UserInfoModel model)
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

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);

            }
            catch (Exception ex)
            {

                LogHelper.LogError(ex.ToString());
            }
            HttpResponseMessage Respond = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respond;
        }
    }
}
