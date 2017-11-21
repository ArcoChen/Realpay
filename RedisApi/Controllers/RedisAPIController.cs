using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RedisHelper;
using System.Text;
using ReCommon;
using RedisModel;

namespace RedisAPI.Controllers
{
    public class RedisAPIController : ApiController
    {
        /// <summary>
        /// 保存字符串（如果key存在，则覆盖）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage StringSet(BaseModel model)
        {
            string Result = string.Empty;
            try
            {
                string ConnectString = StackExchangeRedis.GetConnectString(model.RedisIP, model.RedisPort, model.RedisPassword);
                Result = StackExchangeRedis.StringSet(ConnectString, model.RedisKey, model.RedisValue, new TimeSpan(0, 0, Convert.ToInt32(model.LifeCycle))).ToString();
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8")) };
            return Respend;
        }

        /// <summary>
        /// 获取key对应的value
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage StringGet(BaseModel model)
        {
            string Result = string.Empty;
            try
            {
                string ConnectString = StackExchangeRedis.GetConnectString(model.RedisIP, model.RedisPort, model.RedisPassword);
                Result = StackExchangeRedis.StringGet(ConnectString, model.RedisKey);
            }
            catch (Exception ex)
            {

                LogHelper.Error(ex.ToString());
            }
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent((Result == null) ? "null" : Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respend;
        }

        /// <summary>
        /// 删除key
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage KeyDelete(BaseModel model)
        {
            string Result = string.Empty;
            try
            {
                string ConnectString = StackExchangeRedis.GetConnectString(model.RedisIP, model.RedisPort, model.RedisPassword);
                Result = StackExchangeRedis.KeyDelete(ConnectString, model.RedisKey).ToString();
            }
            catch (Exception ex)
            {

                LogHelper.Error(ex.ToString());
            }
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respend;
        }

        /// <summary>
        /// 判断key是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage KeyExists(BaseModel model)
        {
            string Result = string.Empty;
            try
            {
                string ConnectString = StackExchangeRedis.GetConnectString(model.RedisIP, model.RedisPort, model.RedisPassword);
                Result = StackExchangeRedis.KeyExists(ConnectString, model.RedisKey).ToString();
            }
            catch (Exception ex)
            {

                LogHelper.Error(ex.ToString());
            }
            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };
            return Respend;
        }

        /// <summary>
        /// 设置key的生命周期
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage KeyExpire(BaseModel model)
        {
            string Result = string.Empty;
            try
            {
                string ConnectString = StackExchangeRedis.GetConnectString(model.RedisIP, model.RedisPort, model.RedisPassword);
                Result = StackExchangeRedis.KeyExpire(ConnectString, model.RedisKey, new TimeSpan(0, 0, Convert.ToInt32(model.LifeCycle))).ToString();
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
