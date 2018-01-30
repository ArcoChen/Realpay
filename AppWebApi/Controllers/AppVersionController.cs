using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using FileStreamHelper;

namespace AppWebAPI.Controllers
{
    public class AppVersionController : ApiController
    {
        System.Net.NetworkCredential cred;
        System.Net.WebClient client = new System.Net.WebClient();

        [HttpPost]
        public HttpResponseMessage GetVersion()
        {
            string Result = string.Empty;

            //string path = @"http://www.realbrand.net/appupdate/AppVersion.txt";
            //using (FileStream fsRead = new FileStream(path, FileMode.Open))
            //{
            //    int fsLen = (int)fsRead.Length;
            //    byte[] heByte = new byte[fsLen];
            //    int r = fsRead.Read(heByte, 0, heByte.Length);
            //    Result = System.Text.Encoding.UTF8.GetString(heByte);
            //}

            //HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            //return Respend;

            bool Statu= RemoteFile.ConnectState("http://www.realbrand.net/appupdate", "administrator","yuegang8888888!");
            if(Statu)
            {
                Result= RemoteFile.TransportRemoteToLocal(@"C://YGWeb/js/RealBrand/appupdate/AppVersion.txt");
            }

            HttpResponseMessage Respend = new HttpResponseMessage { Content = new StringContent(Result, Encoding.GetEncoding("UTF-8"), "application/json") };

            return Respend;

        }
    }
}
