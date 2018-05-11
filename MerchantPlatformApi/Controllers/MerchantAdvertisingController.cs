using ImageModel;
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
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MerchantPlatformApi.Controllers
{
    public class MerchantAdvertisingController : ApiController
    {
        #region 配置参数
        //URL请求所需参数
        //static string username = "MerchantPlatform";
        static string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
        static string password = ConfigurationManager.AppSettings[username];
        static string Url = ApiHelper.GetURL("merchant",username);
        #endregion

        /// <summary>
        ///  商家平台_广告推送申请(0 – 成功 1 – 失败)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AdvertisingApply(AdvertiseMentModel model)
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
                
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);
                string imgString = model.FilePosition.Split(new char[] { ',' })[1];

                //图片Model
                ImgModel imgModel = new ImgModel();

                imgModel.ImgIp = ApiHelper.ImgURL();
                imgModel.ImgDisk = SingleXmlInfo.GetInstance().GetWebApiConfig("imgDisk");
                imgModel.ImgRoot = SingleXmlInfo.GetInstance().GetWebApiConfig("imgRoot");
                imgModel.ImgAttribute = "advertisement";
                imgModel.UserAccount = model.UserAccount;
                imgModel.ImgName = ReDateTime.GetTimeStamp();
                imgModel.ImgString = imgString;

                model.FilePosition = ApiHelper.HttpRequest(ApiHelper.GetImgUploadURL("imgUploadIp", "imgUpload"), imgModel);
                model.FilePosition = model.FilePosition.Replace("\"", "");

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
        ///  商家平台_广告申请取消(0 – 成功 1 – 失败)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AdvertisingRemove(AdvertiseMentModel model)
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
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);
                model.PositionNumber = ParametersFilter.FilterSqlHtml(model.PositionNumber, 3);

                //返回结果
                Result =  ApiHelper.HttpRequest(username, password, Url, model);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

        /// <summary>
        ///  商家平台_返回广告列表(未开始)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AdvertisingNotStart(AdvertiseMentModel model)
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
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);
                //model.PageNum = ParametersFilter.FilterSqlHtml(model.PageNum, 1);

                //返回结果
                Result =  ApiHelper.HttpRequest(username, password, Url, model);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

        /// <summary>
        ///  商家平台_返回广告列表(已开始)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AdvertisingStart(AdvertiseMentModel model)
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
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);
                //model.PageNum = ParametersFilter.FilterSqlHtml(model.PageNum, 1);

                //返回结果
                Result =  ApiHelper.HttpRequest(username, password, Url, model);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

        /// <summary>
        ///  商家平台_返回广告列表(已结束)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AdvertisingComplete(AdvertiseMentModel model)
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
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);
                //model.PageNum = ParametersFilter.FilterSqlHtml(model.PageNum, 1);

                //返回结果
                Result =  ApiHelper.HttpRequest(username, password, Url, model);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;
        }

        /// <summary>
        ///  商家平台_广告信息返回
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AdvertisingCodeReturn(AdvertiseMentModel model)
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
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);

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
        ///  商家平台_返回广告列表(未通过)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AdvertisingNotPass(AdvertiseMentModel model)
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
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 50);
                model.PageNum = ParametersFilter.FilterSqlHtml(model.PageNum, 10);

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
        ///  广告推送修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AdvertisingUpdate(AdvertiseMentModel model)
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
                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 24);
                string imgString = model.FilePosition.Split(new char[] { ',' })[1];

                //图片Model
                ImgModel imgModel = new ImgModel();

                imgModel.ImgIp = ApiHelper.ImgURL();
                imgModel.ImgDisk = SingleXmlInfo.GetInstance().GetWebApiConfig("imgDisk");
                imgModel.ImgRoot = SingleXmlInfo.GetInstance().GetWebApiConfig("imgRoot");
                imgModel.ImgAttribute = "advertisement";
                imgModel.UserAccount = model.UserAccount;
                imgModel.ImgName = ReDateTime.GetTimeStamp();
                imgModel.ImgString = imgString;

                model.FilePosition = ApiHelper.HttpRequest(ApiHelper.GetImgUploadURL("imgUploadIp", "imgUpload"), imgModel);
                model.FilePosition = model.FilePosition.Replace("\"", "");

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
