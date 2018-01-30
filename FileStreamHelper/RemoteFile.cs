using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStreamHelper
{
    public class RemoteFile
    {
        /// <summary>  
        /// 连接远程共享文件夹  
        /// </summary>  
        /// <param name="path">远程共享文件夹的路径</param>  
        /// <param name="userName">用户名</param>  
        /// <param name="passWord">密码</param>  
        /// <returns></returns>  
        public static bool ConnectState(string path, string userName, string passWord)
        {
            bool Flag = false;
            Process proc = new Process();
            try
            {
                proc.StartInfo.FileName = "cmd.exe";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardInput = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                string dosLine = "net use " + path + " " + passWord + " /user:" + userName;
                proc.StandardInput.WriteLine(dosLine);
                proc.StandardInput.WriteLine("exit");
                while (!proc.HasExited)
                {
                    proc.WaitForExit(1000);
                }
                string errormsg = proc.StandardError.ReadToEnd();
                proc.StandardError.Close();
                if (string.IsNullOrEmpty(errormsg))
                {
                    Flag = true;
                }
                else
                {
                    throw new Exception(errormsg);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                proc.Close();
                proc.Dispose();
            }
            return Flag;
        }

        public static string TransportRemoteToLocal(string dst)  //src：下载到本地后的文件路径     dst：远程服务器路径    fileName:远程服务器dst路径下的文件名  
        {
            FileStream inFileStream = new FileStream(dst, FileMode.Open);    //远程服务器文件  此处假定远程服务器共享文件夹下确实包含本文件，否则程序报错  

            byte[] buf = new byte[inFileStream.Length];

            string str = System.Text.Encoding.UTF8.GetString(buf);

            inFileStream.Flush();

            inFileStream.Close();

            return str;

        }
    }
}
