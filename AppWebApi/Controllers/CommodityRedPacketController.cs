using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using AppModel;
using ReCommon;
using System.Web;
using System.Configuration;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace AppWebApi.Controllers
{
    public class CommodityRedPacketController : ApiController
    {
        /// <summary>
        ///  提示领取红包-红包活动表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> TipReceivePacket(ProductInfoModel model)
        {
            string Result = string.Empty;

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
            model.CommodityName = ParametersFilter.FilterSqlHtml(model.CommodityName, 50);

            //Dictionary<string, string> data = new Dictionary<string, string>();
            //data.Add("CommodityName", model.CommodityName);

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
        /// 提交领取红包金额进行记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> PacketRecord(RedPacketModel model)
        {
            string Result = string.Empty;

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
            model.DATA = ParametersFilter.StripSQLInjection(model.DATA);
            if(model.TERMINAL=="2")
            {
                model.DATA = System.Web.HttpUtility.UrlEncode(model.DATA);
            }

            //model.DATA = ParametersFilter.FilterSqlHtml(model.DATA, 100);

            //model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 20);
            //Dictionary<string, string> data = new Dictionary<string, string>();
            //data.Add("UserAccount", model.UserAccount);
            //data.Add("DistributeMoney", model.DistributeMoney.ToString());

            //请求数据拼接为JSON格式
            //string Str = JsonTransfrom.InsRequsetToJson(model.SOURCE, model.CREDENTIALS, HttpHelper.IPAddress(), model.TERMINAL, model.INDEX, model.METHOD, data);

            var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

            string Str = JsonConvert.SerializeObject(model, JSetting);

            //返回结果
            Result = await Task<string>.Run(() => ApiHelper.HttpRequest(username, password, Url, Str));

            HttpResponseMessage Respond = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respond;
        }
    }
}
