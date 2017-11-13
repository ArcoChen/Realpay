using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ReCommon;
using System.Configuration;
using System.Web;
using AppModel;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace AppWebApi.Controllers
{
    public class ChangeMobileBindController : ApiController
    {
        /// <summary>
        /// 修改手机号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> ChangePhoneNumber(UserInfoModel model)
        {
            string Result = string.Empty;

            //URL请求所需参数
            string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
            //string username = "DataSnapDebugTools";
            string password = ConfigurationManager.AppSettings[username];
            string Url = ApiHelper.GetURL(username);

            //请求中包含的固定参数
            model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
            model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
            model.ADDRESS = HttpHelper.IPAddress();
            model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
            model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
            model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);
            if (model.TERMINAL == "2")
            {
                model.DATA = System.Web.HttpUtility.UrlEncode(model.DATA);
            }

            ////去除用户参数中包含的特殊字符
            //Dictionary<string, string> data = new Dictionary<string, string>();
            //data.Add("NewPhoneNumber", model.NewPhoneNumber);
            //data.Add("OldPhoneNumber", model.PhoneNumber);

            ////请求数据拼接为JSON格式
            //string Str = JsonTransfrom.SeaRequsetToJson(model.SOURCE, model.CREDENTIALS, HttpHelper.IPAddress(), model.TERMINAL, model.INDEX, model.METHOD, data);

            var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

            string Str = JsonConvert.SerializeObject(model, JSetting);

            //返回结果
            Result = await Task<string>.Run(() => ApiHelper.HttpRequest(username, password, Url, Str));

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

        /// <summary>
        /// 修改手机号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> NewMobileProving(UserInfoModel model)
        {
            string Result = string.Empty;

            //URL请求所需参数
            string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
            //string username = "DataSnapDebugTools";
            string password = ConfigurationManager.AppSettings[username];
            string Url = ApiHelper.GetURL(username);

            //请求中包含的固定参数
            model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
            model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
            model.ADDRESS = HttpHelper.IPAddress();
            model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
            model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
            model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);
            model.NewPhoneNumber = ParametersFilter.FilterSqlHtml(model.NewPhoneNumber, 11);

            ////去除用户参数中包含的特殊字符
            //Dictionary<string, string> data = new Dictionary<string, string>();
            //data.Add("NewPhoneNumber", model.NewPhoneNumber);
            //data.Add("OldPhoneNumber", model.PhoneNumber);

            ////请求数据拼接为JSON格式
            //string Str = JsonTransfrom.SeaRequsetToJson(model.SOURCE, model.CREDENTIALS, HttpHelper.IPAddress(), model.TERMINAL, model.INDEX, model.METHOD, data);

            var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

            string Str = JsonConvert.SerializeObject(model, JSetting);

            //返回结果
            Result = await Task<string>.Run(() => ApiHelper.HttpRequest(username, password, Url, Str));

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

    }
}
