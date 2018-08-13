using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace ReCommon
{
    public class LogHelper
    {
        /// <summary>
        /// 请求日志
        /// </summary>
        /// <param name="message">日志内容</param>
        public static void LogRequest(string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("Logger");
            if (log.IsErrorEnabled)
            {
                log.Info(message);
            }
            log = null;
        }

        /// <summary>
        /// 回调日志
        /// </summary>
        /// <param name="message"></param>
        public static void LogResopnse(string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("Logger");
            if (log.IsErrorEnabled)
            {
                log.Warn(message);
            }
            log = null;
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="message"></param>
        public static void LogError(string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("Logger");
            if (log.IsErrorEnabled)
            {
                log.Error(message);
            }
            log = null;
        }

        /// <summary>
        /// 生成日志信息——Fatal(致命错误)
        /// </summary>
        /// <param name="message">日志内容</param>
        public static void Fatal(string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("Fatal");
            if (log.IsFatalEnabled)
            {
                log.Fatal(message);
            }
            log = null;
        }


        /// <summary>
        /// 生成日志信息——Error（一般错误）
        /// </summary>
        /// <param name="message">日志内容</param>
        public static void Error(string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("Error");
            if (log.IsErrorEnabled)
            {
                log.Error(message);
            }
            log = null;
        }

        /// <summary>
        /// 生成日志信息——Warn（警告）
        /// </summary>
        /// <param name="message">日志内容</param>
        public static void Warn(string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("Warn");
            if (log.IsWarnEnabled)
            {
                log.Warn(message);
            }
            log = null;
        }

        /// <summary>
        /// 生成日志信息——Info（一般信息）
        /// </summary>
        /// <param name="message">日志内容</param>
        public static void Info(string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("Info");
            if (log.IsInfoEnabled)
            {
                log.Info(message);
            }
            log = null;
        }

        /// <summary>
        /// 生成日志信息——Debug（调试信息）
        /// </summary>
        /// <param name="message">日志内容</param>
        public static void Debug(string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("Debug");
            if (log.IsDebugEnabled)
            {
                log.Debug(message);
            }
            log = null;
        }
    }
}
