using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisModel
{
    public class BaseModel
    {
        public string SOURCE { get; set; }

        public string CREDENTIALS { get; set; }

        public string TERMINAL { get; set; }

        public string INDEX { get; set; }

        public string METHOD { get; set; }

        public string ADDRESS { get; set; }

        public string DATA { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserAccount { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string UserMobile { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string Verification { get; set; }

        /// <summary>
        /// RedisIP
        /// </summary>
        public string RedisIP { get; set; }

        /// <summary>
        /// RedisPort
        /// </summary>
        public string RedisPort { get; set; }

        /// <summary>
        /// RedisPassword
        /// </summary>
        public string RedisPassword { get; set; }

        /// <summary>
        /// RedisKey
        /// </summary>
        public string RedisKey { get; set; }

        /// <summary>
        /// RedisValue
        /// </summary>
        public string RedisValue { get; set; }

        /// <summary>
        /// LifeCycle
        /// </summary>
        public string LifeCycle { get; set; }

        /// <summary>
        /// RedisNewKey
        /// </summary>
        public string RedisNewKey { get; set; }

        /// <summary>
        /// RedisFunction
        /// </summary>
        public string RedisFunction { get; set; }

        /// <summary>
        /// 新手机号
        /// </summary>
        public string NewPhoneNumber { get; set; }
    }
}
