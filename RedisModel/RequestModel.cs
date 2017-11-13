using System;

namespace RedisModel
{
    public class RequestModel
    {
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
        public int LifeCycle { get; set; }

        /// <summary>
        /// RedisNewKey
        /// </summary>
        public string RedisNewKey { get; set; }
    }
}
