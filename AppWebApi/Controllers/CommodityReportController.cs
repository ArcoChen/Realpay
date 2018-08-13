using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using ReCommon;
using AppModel;
using System.Web;
using System.Configuration;
using System.Text;
using Newtonsoft.Json.Linq;
using ImageModel;
using Newtonsoft.Json;

namespace AppWebApi.Controllers
{
    public class CommodityReportController : ApiController
    {
        #region 配置参数
        //URL请求所需参数
        static string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
        //string username = "DataSnapDebugTools";
        static string password = ConfigurationManager.AppSettings[username];
        static string Url = ApiHelper.GetURL("app", username);
        #endregion

        /// <summary>
        /// 返回商品详情
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetCommodityInfo(ProductInfoModel model)
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
                model.CommodityCode = ParametersFilter.FilterSqlHtml(model.CommodityCode, 50);


                //返回结果
                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex.ToString());
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

        /// <summary>
        /// 返回商品码对应的商家
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetCommodityUserAccount(ProductInfoModel model)
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
                model.CommodityCode = ParametersFilter.FilterSqlHtml(model.CommodityCode, 50);


                //返回结果
                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex.ToString());
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
        public HttpResponseMessage SubmitReportInfo(ProductInfoModel model)
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
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);

                if (!string.IsNullOrEmpty(model.Screenshot))
                {
                    model.DATA = System.Web.HttpUtility.UrlDecode(model.DATA);
                    string datatojson = ApiHelper.DATAToJson(model.DATA);


                    string CommodityCode = JObject.Parse(datatojson)["CommodityCode"].ToString();
                    string ReportUser = JObject.Parse(datatojson)["ReportUser"].ToString();

                    //string UserAccount = 

                    ProductInfoModel InfoModel = new ProductInfoModel();
                    InfoModel.SOURCE = model.SOURCE;
                    InfoModel.CREDENTIALS = model.CREDENTIALS;
                    InfoModel.ADDRESS = model.ADDRESS;
                    InfoModel.TERMINAL = model.TERMINAL;
                    InfoModel.INDEX = model.INDEX;
                    InfoModel.METHOD = "GetCommodityUserAccount";
                    InfoModel.CommodityCode = CommodityCode;

                    string ReturnUserAccount = ApiHelper.HttpRequest(username, password, Url, InfoModel);
                    //解析返回结果
                    JObject jsons = (JObject)JsonConvert.DeserializeObject(ReturnUserAccount);
                    string UserAccount = jsons["UserAccount"].ToString();

                    #region 图片地址
                    //图片Model
                    ImgModel imgModel = new ImgModel();

                    imgModel.ImgIp = ApiHelper.ImgURL();
                    imgModel.ImgDisk = SingleXmlInfo.GetInstance().GetWebApiConfig("imgDisk");
                    imgModel.ImgRoot = SingleXmlInfo.GetInstance().GetWebApiConfig("imgRoot");
                    imgModel.UserAccount = UserAccount;
                    imgModel.ImgAttribute = "report";
                    imgModel.ImgName = ReportUser + ReDateTime.GetTimeStamp();
                    imgModel.ImgString = model.Screenshot;

                    //保存图片
                    model.Screenshot = ApiHelper.HttpRequest(ApiHelper.GetImgUploadURL("imgUploadIp", "imgUpload"), imgModel);
                    model.Screenshot = model.Screenshot.Replace("\"", "");
                    #endregion
                }

                model.DATA = System.Web.HttpUtility.UrlEncode(model.DATA);


                //返回结果
                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);
                //}
                //else
                //{
                //    Result = "{\"RETURNCODE\":\"403\"}";
                //}
            }
            catch (Exception ex)
            {
                LogHelper.LogRequest(ex.ToString());
                LogHelper.LogError(ex.ToString());
                LogHelper.LogResopnse(ex.ToString());
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

        /// <summary>
        /// 返回经纬度
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetWorkAddress(ProductInfoModel model)
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
                model.CommodityCode = ParametersFilter.FilterSqlHtml(model.CommodityCode, 50);


                //返回结果
                Result = ApiHelper.HttpRequest(username, password, Url, model);

                ///写日志
                string RequestAction = "api/" + username + "/" + HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() + "：";
                LogHelper.LogResopnse(RequestAction + Result);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex.ToString());
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }
    }
}
