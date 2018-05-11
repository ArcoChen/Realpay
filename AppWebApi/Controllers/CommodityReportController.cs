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
        public HttpResponseMessage SubmitReportInfo(ProductInfoModel model)
        {

            string Result = string.Empty;
            bool ReturnCode = AuthHelper.AuthUserStatus(model);

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
                    string datatojson = ApiHelper.DATAToJson(model.DATA);

                    string UserAccount = JObject.Parse(datatojson)["UserAccount"].ToString();
                    string CommodityCode = JObject.Parse(datatojson)["CommodityCode"].ToString();
                    string ReportUser = JObject.Parse(datatojson)["ReportUser"].ToString();

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
                }

                if (model.TERMINAL == "2")
                {
                    model.DATA = System.Web.HttpUtility.UrlEncode(model.DATA);
                }


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
                Result = ex.ToString();
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }
    }
}
