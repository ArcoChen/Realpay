using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Restrict
{
    public partial class Default : System.Web.UI.Page
    {
        static string FilePath = @"C:\YGWeb\js\RealBrand_kh\appversion\realbrandpay.apk";
        static string DesFilePath = @"C:\YGWeb\js\RealBrand_kh\appversion\realbrandpay2.apk";
        //static string FilePath = @"C:\1.txt";
        //static string DesFilePath = @"C:\2.txt";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Restrict_ServerClick(object sender, EventArgs e)
        {
            bool b = ChangeFileName(FilePath, DesFilePath);
            if (b)
            {
                Result.InnerText = "App已暂停下载";
            }
        }

        protected void Recover_ServerClick(object sender, EventArgs e)
        {
            bool b = ChangeFileName(DesFilePath, FilePath);
            if (b)
            {
                Result.InnerText = "已成功恢复下载";
            }
        }

        public bool ChangeFileName(string SrcRelativePath, string DesRealtivePath)
        {
            try
            {
                if (File.Exists(SrcRelativePath))
                {
                    File.Move(SrcRelativePath, DesRealtivePath);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw;
                return false;
            }
        }
    }
}