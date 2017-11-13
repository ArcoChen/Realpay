using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using ReCommon;
using AppModel;
using System.Web;
using System.Configuration;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace AppWebApi.Controllers
{
    public class CommodityReportController : ApiController
    {

        /// <summary>
        /// 返回商品详情
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> GetCommodityInfo(ProductInfoModel model)
        {
            string Result = string.Empty;

            try
            {
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

                //去除用户参数中包含的特殊字符
                model.CommodityCode = ParametersFilter.FilterSqlHtml(model.CommodityCode, 100);

                //Dictionary<string, string> data = new Dictionary<string, string>();
                //data.Add("CommodityCode", model.CommodityCode);

                ////请求数据拼接为JSON格式
                //string Str = JsonTransfrom.SeaRequsetToJson(model.SOURCE, model.CREDENTIALS, HttpHelper.IPAddress(), model.TERMINAL, model.INDEX, model.METHOD, data);

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
        /// 提交举报信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> SubmitReportInfo(ProductInfoModel model)
        {

            string Result = string.Empty;
            try
            {

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

                if (!string.IsNullOrEmpty(model.Screenshot))
                {
                    ///截图名称
                    string imgName = System.DateTime.Now.ToString("yyyyMMddHHmmssfff");

                    //保存图片
                    model.Screenshot = CharConversion.SaveImg(model.Screenshot, imgName, "/Screenshot/");
                }

                if (model.TERMINAL == "2")
                {
                    model.DATA = System.Web.HttpUtility.UrlEncode(model.DATA);
                }

                var JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

                string Str = JsonConvert.SerializeObject(model, JSetting);

                //返回结果
                Result = await Task<string>.Run(() => ApiHelper.HttpRequest(username, password, Url, Str));

            }
            catch (Exception ex)
            {

                LogHelper.Error(ex.ToString());
                Result = ex.ToString();
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }
    }
}
