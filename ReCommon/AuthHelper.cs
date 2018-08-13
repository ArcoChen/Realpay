using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RedisModel;
using ObjectModel;

namespace ReCommon
{
    public class AuthHelper
    {
        /// <summary>
        /// 添加凭证
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns>value值</returns>
        public static string AuthUserSet<T>(T model) where T : ObjectBaseModel
        {
            string Result = string.Empty;
            string UserAccount = string.Empty;

            ///实例化redisModel
            RedisModel.BaseModel redisModel = new BaseModel();
            redisModel.RedisIP = "r-wz9c03c34034e434554.redis.rds.aliyuncs.com";
            redisModel.RedisPort = "6379";
            redisModel.RedisPassword = "Yuegang888888";
            redisModel.LifeCycle = "86400";
            redisModel.RedisFunction = "StringSet";

            if (model.UserAccount != null)
            {
                UserAccount = model.UserAccount;
            }
            else
            {
                string objectData = ApiHelper.DATAToJson(model.DATA);
                JObject jsons = (JObject)JsonConvert.DeserializeObject(objectData);
                UserAccount = jsons["UserAccount"].ToString();
            }

            redisModel.RedisKey = "User_Account_Credentials_" + UserAccount;
            redisModel.RedisValue = UserAccount + model.UserMobile;

            ///保存键值对
            Result = (ApiHelper.HttpRequest(ApiHelper.GetRedisURL("redisIp","redis",redisModel.RedisFunction), redisModel));

            return redisModel.RedisValue;
        }

        public static bool AuthUserStatus<T>(T model) where T : ObjectBaseModel
        {
            bool Result;

            ///实例化redisModel
            RedisModel.BaseModel redisModel = new BaseModel();
            redisModel.RedisIP = "r-wz9c03c34034e434554.redis.rds.aliyuncs.com";
            redisModel.RedisPort = "6379";
            redisModel.RedisPassword = "Yuegang888888";
            redisModel.LifeCycle = "86400";
            redisModel.RedisFunction = "StringGet";

            if (model.CREDENTIALS == null)
            {
                return false;
            }
            else if (model.CREDENTIALS.Length > 10)
            {
                string UserAccount = model.CREDENTIALS.Substring(0, model.CREDENTIALS.Length - 10);
                redisModel.RedisKey = "User_Account_Credentials_" + UserAccount;
            }
            ///拼接要请求的redisKey
            else if (model.UserAccount != null)
            {
                redisModel.RedisKey = "User_Account_Credentials_" + model.UserAccount;
            }
            else
            {
                string objectData = ApiHelper.DATAToJson(model.DATA);
                JObject jsons = (JObject)JsonConvert.DeserializeObject(objectData);
                redisModel.RedisKey = "User_Account_Credentials_" + jsons["UserAccount"].ToString();
            }

            ///获取redisKey对应的值
            redisModel.RedisValue = ApiHelper.HttpRequest(ApiHelper.GetRedisURL("redisIp", "redis", redisModel.RedisFunction), redisModel);

            if (model.CREDENTIALS == redisModel.RedisValue)
            {
                Result = true;
            }
            else
            {
                Result = false;
            }

            return Result;
        }
    }
}
