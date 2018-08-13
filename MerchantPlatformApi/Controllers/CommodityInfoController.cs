using ImageModel;
using MerchantModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public class CommodityInfoController : ApiController
    {
        #region 配置参数
        //URL请求所需参数
        //static string username = "MerchantPlatform";
        static string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
        static string password = ConfigurationManager.AppSettings[username];
        static string Url = ApiHelper.GetURL("merchant", username);
        #endregion

        /// <summary>
        ///  商家平台_商品信息列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage CommodityTable(UserInfoModel model)
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
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 64);
                model.PageNum = ParametersFilter.FilterSqlHtml(model.PageNum, 16);

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
        ///  商家平台_商品信息详情
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage CommodityInfo(UserInfoModel model)
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
                model.PageNum = ParametersFilter.FilterSqlHtml(model.PageNum, 16);

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
        ///  商家平台_商品添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage CommodityAdd(ProductCodeInfoModel model)
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
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 64);

                #region base64上传
                //string ImgString = model.FilePath.Split(new char[] { ',' })[1];

                ////图片Model
                //ImgModel imgModel = new ImgModel();
                //imgModel.ImgIp = ApiHelper.ImgURL();
                //imgModel.ImgDisk = SingleXmlInfo.GetInstance().GetWebApiConfig("imgDisk");
                //imgModel.ImgRoot = SingleXmlInfo.GetInstance().GetWebApiConfig("imgRoot");
                //imgModel.ImgAttribute = "commodity";
                //imgModel.UserAccount = model.UserAccount;
                //imgModel.ImgName = ReDateTime.GetTimeStamp();
                //imgModel.ImgString = ImgString;

                //model.FilePath = ApiHelper.HttpRequest(ApiHelper.GetImgUploadURL("imgUploadIp", "imgUpload"), imgModel);
                //model.FilePath = model.FilePath.Replace("\"", ""); 
                #endregion

                ///商品轮播图地址
                model.FilePath = ApiHelper.ImgURL() + model.UserAccount + "/Commodity/";

                ///商品详情图地址
                model.CommodityProfile = ApiHelper.ImgURL() + model.UserAccount + "/Commodity/";

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
        ///  商家平台_商品图片修改删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UpdateCommodityFilePath(ProductCodeInfoModel model)
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

                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 64);
                model.Status = ParametersFilter.FilterSqlHtml(model.Status, 1);
                model.CommodityNumber = ParametersFilter.StripSQLInjection(model.CommodityNumber);
                model.ImgStatus = ParametersFilter.FilterSqlHtml(model.ImgStatus,1);

                ///原图片地址
                string ImgPath = model.FilePath;

                if (model.Status == "0")
                {
                    model.FilePath = model.FilePath.Substring(model.FilePath.LastIndexOf("."), model.FilePath.Length - model.FilePath.LastIndexOf("."));
                }

                //返回结果
                Result = ApiHelper.HttpRequest(username, password, Url, model);

                //解析返回结果
                JObject jsons = (JObject)JsonConvert.DeserializeObject(Result);

                ///添加商品
                if (model.Status == "0")
                {
                    ImgModel imgModel = new ImgModel();
                    imgModel.ImgDisk = SingleXmlInfo.GetInstance().GetWebApiConfig("imgDisk");
                    imgModel.ImgRoot = SingleXmlInfo.GetInstance().GetWebApiConfig("imgRoot");
                    imgModel.UserAccount = model.UserAccount;
                    imgModel.ImgAttribute = "commodity";
                    imgModel.SourceFileName = ImgPath;
                    imgModel.ImgName = jsons["FilePath"].ToString();

                    string Return = ApiHelper.HttpRequest(ApiHelper.MoveCommodityImg("imgUploadIp", "imgUpload"), imgModel);

                    if (Return != "1")
                    {
                        jsons["DATA"][0] = 0;
                    }
                    else
                    {
                        jsons["DATA"][0] = 1;
                    }
                    Result = JsonConvert.SerializeObject(jsons);
                }
                else if (model.Status == "1")
                {
                    if (jsons["DATA"][0].ToString() == "1")
                    {
                        ImgModel imgModel = new ImgModel();
                        imgModel.ImgDisk = SingleXmlInfo.GetInstance().GetWebApiConfig("imgDisk");
                        imgModel.ImgRoot = SingleXmlInfo.GetInstance().GetWebApiConfig("imgRoot");
                        imgModel.UserAccount = model.UserAccount;
                        imgModel.ImgAttribute = "commodity";
                        imgModel.SourceFileName = ImgPath;
                        string DeleteImg = ApiHelper.HttpRequest(ApiHelper.DeleteCommodityImg("imgUploadIp", "imgUpload"), imgModel);
                        if (DeleteImg != "1")
                        {
                            jsons["DATA"][0] = 0;
                        }

                        Result = JsonConvert.SerializeObject(jsons);
                    }
                }

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
        ///  商家平台_修改商品信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage CommodityUpdate(ProductCodeInfoModel model)
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
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 64);

                //去除用户参数中包含的特殊字符
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);

                #region MyRegion
                //model.DATA = System.Web.HttpUtility.UrlDecode(model.DATA);
                //string ImgString = string.Empty;
                //if (model.FilePath.Substring(model.FilePath.Length - 3, 3) != "jpg")
                //{
                //    ImgString = model.FilePath.Split(new char[] { ',' })[1];
                //}
                //else
                //{
                //    ImgString = model.FilePath;
                //}

                //string datatojson = ApiHelper.DATAToJson(model.DATA);

                //string CommodityCode = JObject.Parse(datatojson)["CommodityCode"].ToString();

                ////图片Model
                //ImgModel imgModel = new ImgModel();
                //imgModel.ImgIp = ApiHelper.ImgURL();
                //imgModel.ImgDisk = SingleXmlInfo.GetInstance().GetWebApiConfig("imgDisk");
                //imgModel.ImgRoot = SingleXmlInfo.GetInstance().GetWebApiConfig("imgRoot");
                //imgModel.ImgAttribute = "commodity";
                //imgModel.UserAccount = model.UserAccount;
                //imgModel.ImgName = CommodityCode;
                //imgModel.ImgString = ImgString;

                //model.FilePath = ApiHelper.HttpRequest(ApiHelper.GetImgUploadURL("imgUploadIp", "imgUpload"), imgModel);
                //model.FilePath = model.FilePath.Replace("\"", "");

                ////URL编码
                //model.DATA = System.Web.HttpUtility.UrlEncode(model.DATA); 
                #endregion

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
        ///  商家平台_商品勾选信息返回
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage CommodityInfoPlus(UserInfoModel model)
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
                model.PageNum = ParametersFilter.FilterSqlHtml(model.PageNum, 16);

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
        ///  商家平台_商品勾选信息修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage CommodityChoice(UserInfoModel model)
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
                model.PageNum = ParametersFilter.FilterSqlHtml(model.PageNum, 16);

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
