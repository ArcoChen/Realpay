using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OperationPlatformModel;
using System.Configuration;
using ReCommon;
using Newtonsoft.Json;
using System.Text;
using System.Web;

namespace OperationPlatformApi.Controllers
{
    public class SystemMaintainManageController : ApiController
    {
        #region 配置参数
        //string username = "DataSnapDebugTools";
        static string username = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
        static string password = ConfigurationManager.AppSettings[username];
        static string Url = ApiHelper.GetURL(username);

        private JsonSerializerSettings JSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        #endregion

        /// <summary>
        /// 显示行业目录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage EnumIndustryList(SystemMaintainModel model)
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
                model.DATA = ParametersFilter.FilterSqlHtml(model.DATA, 10);

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
        /// 增加行业目录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddIndustry(SystemMaintainModel model)
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
        /// 修改行业目录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UpdateIndustry(SystemMaintainModel model)
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
                model.DATA = ParametersFilter.FilterSqlHtml(model.DATA, 100);

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
        /// 删除行业目录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage DeleteIndustry(SystemMaintainModel model)
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
        /// 修改广告设置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UpdateADSetting(SystemMaintainModel model)
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
        /// 广告设置表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage EnumADSetting(SystemMaintainModel model)
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
                model.DATA = ParametersFilter.FilterSqlHtml(model.DATA, 200);
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
        /// 修改广告状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage UpdateEnableState(SystemMaintainModel model)
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
