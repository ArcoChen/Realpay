using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OperationPlatformModel;
using ReCommon;
using System.Configuration;
using Newtonsoft.Json;
using System.Text;
using System.Web;

namespace OperationPlatformApi.Controllers
{
    public class MerchantManageController : ApiController
    {
        #region 配置参数
        //string username = "DataSnapDebugTools";
        static string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
        static string password = ConfigurationManager.AppSettings[username];
        static string Url = ApiHelper.GetURL(username);

        private JsonSerializerSettings JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        #endregion

        /// <summary>
        /// 修改账号状态
        /// </summary>
        [HttpPost]
        public HttpResponseMessage UpdateUserState(UserInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);
                model.DATA = ParametersFilter.StripSQLInjection(model.DATA);

                //model.UserState = ParametersFilter.FilterSqlHtml(model.UserState, 1);
                //model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 30);

                //序列化
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
        /// 修改实名认证状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UpdateRealState(EnterpriseInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);


                //model.Cerification = ParametersFilter.FilterSqlHtml(model.Cerification, 50);
                //model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 30);

                //序列化
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
        ///  修改企业认证状态（营业执照）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UpdateEnterpriseState(EnterpriseInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);


                //model.Cerification = ParametersFilter.FilterSqlHtml(model.Cerification, 50);
                //model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 30);

                //序列化
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
        ///  修改缴费状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UpdatePayState(PlatformServiceModel model)
        {
            string Result = string.Empty;

            try
            {
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);


                //model.ServiceProduct = ParametersFilter.FilterSqlHtml(model.ServiceProduct, 50);
                //model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 30);
                //model.PayState = ParametersFilter.FilterSqlHtml(model.PayState,1);

                //序列化
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
        ///  返回商家信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage EnumBusinessList(UserInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                model.UserType = ParametersFilter.FilterSqlHtml(model.UserType, 1);

                //序列化
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
        ///  返回企业详细信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage BusinessDetailInfo(UserInfoModel model)
        {
            string Result = string.Empty;

            try
            {
                //请求中包含的固定参数
                model.SOURCE = ParametersFilter.FilterSqlHtml(model.SOURCE, 15);
                model.CREDENTIALS = ParametersFilter.FilterSqlHtml(model.CREDENTIALS, 10);
                model.ADDRESS = HttpHelper.IPAddress();
                model.TERMINAL = ParametersFilter.FilterSqlHtml(model.TERMINAL, 1);
                model.INDEX = ParametersFilter.FilterSqlHtml(model.INDEX, 14);
                model.METHOD = ParametersFilter.FilterSqlHtml(model.METHOD, 15);

                model.UserAccount = ParametersFilter.FilterSqlHtml(model.UserAccount, 30);

                //序列化
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
    }
}
