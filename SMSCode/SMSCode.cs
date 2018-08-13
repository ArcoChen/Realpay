using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aliyun.MNS;
using Aliyun.MNS.Model;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;

namespace SMSCode
{
    public class SMSCode
    {

        #region MyRegion
        //#region 参数配置
        //private const string _endpoint = "https://1018889370025379.mns.cn-shenzhen.aliyuncs.com/";

        //private const string _accessKeyId = "LTAIhfoh6Nh7L39T";

        //private const string _secretAccessKey = "UYyoKfVAAkr1z1uNmszUWtiDRButWQ";

        //private const string _topicName = "sms.topic-cn-shenzhen"; 
        //#endregion

        ///// <summary>
        ///// 发送验证码
        ///// </summary>
        ///// <param name="phoneNumber">手机号</param>
        ///// <param name="SMSCode">验证码</param>
        //public void SendMessage(string phoneNumber,string SMSCode)
        //{
        //    IMNS client = new Aliyun.MNS.MNSClient(_accessKeyId, _secretAccessKey, _endpoint);

        //    Topic topic = client.GetNativeTopic(_topicName);

        //    MessageAttributes messageAttributes = new MessageAttributes();
        //    BatchSmsAttributes batchSmsAttributes = new BatchSmsAttributes();

        //    batchSmsAttributes.FreeSignName = "越港云端";
        //    batchSmsAttributes.TemplateCode = "SMS_67206006";

        //    Dictionary<string, string> param = new Dictionary<string, string>();

        //    param.Add("code", SMSCode);

        //    batchSmsAttributes.AddReceiver(phoneNumber, param);

        //    messageAttributes.BatchSmsAttributes = batchSmsAttributes;

        //    PublishMessageRequest request = new PublishMessageRequest();
        //    request.MessageAttributes = messageAttributes;

        //    request.MessageBody = "smsessage";

        //    try
        //    {
        //        PublishMessageResponse resp = topic.PublishMessage(request);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Publish SMS message failed,exception info:" + ex.Message);
        //    }
        //} 
        #endregion

        #region 参数配置
        private const string product = "Dysmsapi";//短信API产品名称（短信产品名固定，无需修改）

        private const string domain = "dysmsapi.aliyuncs.com";//短信API产品域名（接口地址固定，无需修改）

        private const string accessKeyId = "LTAIhfoh6Nh7L39T";

        private const string accessKeySeret = "UYyoKfVAAkr1z1uNmszUWtiDRButWQ";
        #endregion

        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="phoneNumber">手机号</param>
        /// <param name="SMSCode">验证码</param>
        public static string SendMessage(string phoneNumber, string SMSCode)
        {
            string Result = string.Empty;
            IClientProfile profile = DefaultProfile.GetProfile("cn-hanghzou", accessKeyId, accessKeySeret);
            DefaultProfile.AddEndpoint("cn-hanghzou", "cn-hanghzou", product, domain);
            IAcsClient acsClient = new DefaultAcsClient(profile);
            SendSmsRequest request = new SendSmsRequest();
            try
            {
                //必填:待发送手机号。支持以逗号分隔的形式进行批量调用，批量上限为1000个手机号码,批量调用相对于单条调用及时性稍有延迟,验证码类型的短信推荐使用单条调用的方式
                request.PhoneNumbers = phoneNumber;
                //必填:短信签名-可在短信控制台中找到
                request.SignName = "正品汇";
                //必填:短信模板-可在短信控制台中找到
                request.TemplateCode = "SMS_67206006";
                //可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为
                request.TemplateParam = "{\"code\":\"" + SMSCode + "\"}";
                //可选:outId为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者
                //request.OutId = "yourOutId";
                //请求失败这里会抛ClientException异常
                SendSmsResponse sendSmsResponse = acsClient.GetAcsResponse(request);
                Result = sendSmsResponse.Code;
            }
            catch (Exception)
            {

                throw;
            }

            return Result;
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="minValue">最小取值数</param>
        /// <param name="maxValue">最大取值数</param>
        /// <returns>返回验证码</returns>
        public static string GetAuthCode(int minValue, int maxValue)
        {
            Random random = new Random();
            string authCode = random.Next(minValue, maxValue).ToString();
            return authCode;
        }

        /// <summary>
        /// 短信查询
        /// </summary>
        /// <param name="phoneNumber">手机号</param>
        /// <param name="SMSCode">验证码</param>
        public static string querySendDetails(string phoneNumber)
        {
            //初始化acsClient,暂不支持region化
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", accessKeyId, accessKeySeret);
            DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", product, domain);
            IAcsClient acsClient = new DefaultAcsClient(profile);
            //组装请求对象
            QuerySendDetailsRequest request = new QuerySendDetailsRequest();
            //必填-号码
            request.PhoneNumber = phoneNumber;
            //可选-流水号
            //request.BizId = bizId;
            //必填-发送日期 支持30天内记录查询，格式yyyyMMdd       
            request.SendDate = DateTime.Now.ToString("yyyyMMdd");
            //必填-页大小
            request.PageSize = 10;
            //必填-当前页码从1开始计数
            request.CurrentPage = 1;
            QuerySendDetailsResponse querySendDetailsResponse = null;
            try
            {
                querySendDetailsResponse = acsClient.GetAcsResponse(request);
            }
            catch (ServerException e)
            {
            }
            catch (ClientException e)
            {
            }
            return querySendDetailsResponse.TotalCount;
        }
    }
}
