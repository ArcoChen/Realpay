using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aliyun.MNS;
using Aliyun.MNS.Model;

namespace SMSCode
{
    public class SMSCode
    {

        #region 参数配置
        private const string _endpoint = "https://1018889370025379.mns.cn-shenzhen.aliyuncs.com/";

        private const string _accessKeyId = "LTAIhfoh6Nh7L39T";

        private const string _secretAccessKey = "UYyoKfVAAkr1z1uNmszUWtiDRButWQ";

        private const string _topicName = "sms.topic-cn-shenzhen"; 
        #endregion

        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="phoneNumber">手机号</param>
        /// <param name="SMSCode">验证码</param>
        public void SendMessage(string phoneNumber,string SMSCode)
        {
            IMNS client = new Aliyun.MNS.MNSClient(_accessKeyId, _secretAccessKey, _endpoint);

            Topic topic = client.GetNativeTopic(_topicName);

            MessageAttributes messageAttributes = new MessageAttributes();
            BatchSmsAttributes batchSmsAttributes = new BatchSmsAttributes();

            batchSmsAttributes.FreeSignName = "越港云端";
            batchSmsAttributes.TemplateCode = "SMS_67206006";

            Dictionary<string, string> param = new Dictionary<string, string>();

            param.Add("code", SMSCode);

            batchSmsAttributes.AddReceiver(phoneNumber, param);

            messageAttributes.BatchSmsAttributes = batchSmsAttributes;

            PublishMessageRequest request = new PublishMessageRequest();
            request.MessageAttributes = messageAttributes;

            request.MessageBody = "smsessage";

            try
            {
                PublishMessageResponse resp = topic.PublishMessage(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Publish SMS message failed,exception info:" + ex.Message);
            }
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="minValue">最小取值数</param>
        /// <param name="maxValue">最大取值数</param>
        /// <returns>返回验证码</returns>
        public static string GetAuthCode(int minValue,int maxValue)
        {
            Random random = new Random();
            string authCode = random.Next(minValue, maxValue).ToString();
            return authCode;
        }
    }
}
