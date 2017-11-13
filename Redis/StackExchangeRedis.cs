using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace RedisHelper
{
    /// <summary>
    /// Redis操作类
    /// </summary>
    public class StackExchangeRedis
    {

        #region 连接字符串
        public static string GetConnectString(string RedisIP, string RedisPort,string RedisPassword)
        {
            return RedisIP + ":" + RedisPort + ",password=" + RedisPassword;
        }
        #endregion
        #region String操作
        #region 获取值
        /// <summary>
        /// 根据key获取值
        /// </summary>
        /// <param name="ConnectString"></param>
        /// <param name="RedisKey"></param>
        /// <returns></returns>
        public static string StringGet(string ConnectString, string RedisKey)
        {
            try
            {
                using (var client = ConnectionMultiplexer.Connect(ConnectString))
                {
                    return client.GetDatabase().StringGet(RedisKey);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// 获取单个值
        /// </summary>
        /// <param name="RedisKey"></param>
        /// <param name="RedisValue"></param>
        /// <param name="Expiry"></param>
        /// <returns></returns>
        public static async Task<string> StringGetAsync(string ConnectString, string RedisKey)
        {
            try
            {
                using (var client = ConnectionMultiplexer.Connect(ConnectString))
                {
                    return await client.GetDatabase().StringGetAsync(RedisKey);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        #endregion

        #region 保存值
        /// <summary>
        /// 设置 key 并保存字符串（如果 key 已存在，则覆盖值）
        /// </summary>
        /// <param name="RedisKey"></param>
        /// <param name="RedisValue"></param>
        /// <param name="Expiry"></param>
        /// <returns></returns>
        public static bool StringSet(string ConnectString, string RedisKey, string RedisValue, TimeSpan? Expiry = null)
        {
            try
            {
                using (var client = ConnectionMultiplexer.Connect(ConnectString))
                {
                    return client.GetDatabase().StringSet(RedisKey, RedisValue, Expiry);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 保存多个 Key-value
        /// </summary>
        /// <param name="keyValuePairs"></param>
        /// <returns></returns>
        public static bool StringSet(string ConnectString, IEnumerable<KeyValuePair<RedisKey, RedisValue>> keyValuePairs)
        {
            try
            {
                keyValuePairs =
            keyValuePairs.Select(x => new KeyValuePair<RedisKey, RedisValue>(x.Key, x.Value));
                using (var client = ConnectionMultiplexer.Connect(ConnectString))
                {
                    return client.GetDatabase().StringSet(keyValuePairs.ToArray());
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 保存一个字符串值
        /// </summary>
        /// <param name="ConnectString">连接字符串</param>
        /// <param name="RedisKey"></param>
        /// <param name="RedisValue"></param>
        /// <param name="Expiry"></param>
        /// <returns></returns>
        public static async Task<bool> StringSetAsync(string ConnectString, string RedisKey, string RedisValue, TimeSpan? Expiry = null)
        {
            try
            {
                using (var client = ConnectionMultiplexer.Connect(ConnectString))
                {
                    return await client.GetDatabase().StringSetAsync(RedisKey, RedisValue, Expiry);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 保存多个 Key-value
        /// </summary>
        /// <param name="keyValuePairs"></param>
        /// <returns></returns>
        public static async Task<bool> StringSetAsync(string ConnectString, IEnumerable<KeyValuePair<RedisKey, RedisValue>> keyValuePairs)
        {
            try
            {
                keyValuePairs =
            keyValuePairs.Select(x => new KeyValuePair<RedisKey, RedisValue>(x.Key, x.Value));
                using (var client = ConnectionMultiplexer.Connect(ConnectString))
                {
                    return await client.GetDatabase().StringSetAsync(keyValuePairs.ToArray());
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        #endregion
        #endregion

        #region Key操作

        /// <summary>
        /// 移除指定 Key
        /// </summary>
        /// <param name="RedisKey"></param>
        /// <returns></returns>
        public static bool KeyDelete(string ConnectString, string RedisKey)
        {
            try
            {
                using (var client = ConnectionMultiplexer.Connect(ConnectString))
                {
                    return client.GetDatabase().KeyDelete(RedisKey);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }


        /// <summary>
        /// 校验 Key 是否存在
        /// </summary>
        /// <param name="RedisKey"></param>
        /// <returns></returns>
        public static bool KeyExists(string ConnectString,string RedisKey)
        {
            try
            {
                using (var client = ConnectionMultiplexer.Connect(ConnectString))
                {
                    return client.GetDatabase().KeyExists(RedisKey);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 重命名 Key
        /// </summary>
        /// <param name="RedisKey"></param>
        /// <param name="redisNewKey"></param>
        /// <returns></returns>
        public bool KeyRename(string ConnectString,string RedisKey, string redisNewKey)
        {
            try
            {
                using (var client = ConnectionMultiplexer.Connect(ConnectString))
                {
                    return client.GetDatabase().KeyRename(RedisKey,redisNewKey);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 设置 Key 的时间
        /// </summary>
        /// <param name="RedisKey"></param>
        /// <param name="Expiry"></param>
        /// <returns></returns>
        public static bool KeyExpire(string ConnectString,string RedisKey, TimeSpan? Expiry)
        {
            try
            {
                using (var client = ConnectionMultiplexer.Connect(ConnectString))
                {
                    return client.GetDatabase().KeyExpire(RedisKey, Expiry);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        #endregion

    }
}
