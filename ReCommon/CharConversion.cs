using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Security.Cryptography;
using System.Drawing;
using System.Web;
using System.IO;

namespace ReCommon
{
    public class CharConversion
    {
        /// <summary>
        /// 字符转ASCII码
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public static int Asc(string character)
        {
            if (character.Length == 1)
            {
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                int intAsciiCode = (int)asciiEncoding.GetBytes(character)[0];
                return (intAsciiCode);
            }
            else
            {
                throw new Exception("Character is not valid.");
            }

        }

        /// <summary>
        /// ASCII码转字符
        /// </summary>
        /// <param name="asciiCode"></param>
        /// <returns></returns>
        public static string Chr(int asciiCode)
        {
            if (asciiCode >= 0 && asciiCode <= 255)
            {
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                byte[] byteArray = new byte[] { (byte)asciiCode };
                string strCharacter = asciiEncoding.GetString(byteArray);
                return (strCharacter);
            }
            else
            {
                throw new Exception("ASCII Code is not valid.");
            }
        }

        /// <summary>
        /// 静态常量读取编号
        /// </summary>
        private static char[] constant =
        {
        '0','1','2','3','4','5','6','7','8','9',
        'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
        'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
        };

        /// <summary>
        /// 生成指定位数随机数
        /// </summary>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string GenerateRandomNumber(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(62);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(62)]);
            }
            return newRandom.ToString();
        }

        public static string GetNum(string str, int Num)
        {
            string Result = "";
            if (string.IsNullOrWhiteSpace(str))
            {
                for (int i = 0; i < Num; i++)
                {
                    Result = Result + "0";
                }
            }
            else
            {
                Char[] strChar = str.ToCharArray();
                bool IsTrue = false;
                for (int y = Num; y > 0; y--)
                {
                    if (!IsTrue)
                    {
                        if (strChar[Num - 1].ToString() == "Z")
                            break;
                        else
                        {
                            for (int z = 0; z < constant.Length - 1; z++)
                            {
                                if (strChar[Num - 1].ToString() == constant[z].ToString())
                                {
                                    strChar[Num - 1] = constant[z + 1];
                                    IsTrue = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                foreach (var ch in strChar)
                {
                    Result = Result + ch.ToString();
                }

            }
            return Result;
        }

        /// <summary>
        /// Md5加密
        /// </summary>
        /// <param name="myString"></param>
        /// <returns></returns>
        public static string GetMD5(string myString)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = System.Text.Encoding.Unicode.GetBytes(myString);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x");
            }

            return byte2String;
        }

        /// <summary>
        /// 32位MD5加密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Md5Hash(string input)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        /// <summary>
        /// Base64保存图片
        /// </summary>
        /// <param name="imgString">base64字符串</param>
        /// <param name="imgName">图片名称</param>
        /// <param name="imgPath">图片存放地址</param>
        public static void Base64ToImg(string imgString, string imgName, string imgPath)
        {
            ///截取图片字符串
            if (imgString != null)
            {
                string[] imgArray = imgString.Split(new char[] { ',' });
                string base64 = imgArray[1];
                string imgType = imgArray[0].Substring(12, 3);
                byte[] bytes = Convert.FromBase64String(base64);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                System.Drawing.Bitmap b = (System.Drawing.Bitmap)System.Drawing.Image.FromStream(ms);

                ///图片保存位置
                //string filePath = "/Img/" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                string filePath = imgPath + imgName + "." + imgType;

                ///保存图片
                //b.Save(HttpContext.Current.Server.MapPath(filePath), System.Drawing.Imaging.ImageFormat.Jpeg);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    b.Save(HttpContext.Current.Server.MapPath(filePath));
                }
                ms.Close();
            }
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="imgString">base64字符串</param>
        /// <param name="imgName">图片名称</param>
        /// <param name="imgPath">图片存放地址</param>
        public static string SaveImg(string imgString, string imgName, string imgPath)
        {
            string filePath = string.Empty;
            ///截取图片字符串
            if (imgString != null)
            {
                imgString = imgString.Replace(" ", "+");
                byte[] bytes = Convert.FromBase64String(imgString);
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes))
                {
                    using (Bitmap b = new Bitmap(ms))
                    {
                        ///图片保存位置
                        filePath = imgPath + imgName + ".jpg";

                        ///判断文件夹是否存在
                        if(Directory.Exists(imgPath)==false)
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath(imgPath));
                        }

                        ///保存图片
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                            b.Save(HttpContext.Current.Server.MapPath(filePath), System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        else
                        {
                            b.Save(HttpContext.Current.Server.MapPath(filePath), System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                    }
                }

            }

            filePath = filePath.Replace("~", "");

            return filePath;
        }

        /// <summary>
        /// 文件流上传图片
        /// </summary>
        /// <param name="imgName">图片名称</param>
        /// <param name="imgString">图片字符串</param>
        public static void FileSteamWrite(string imgName, string imgString)
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(imgString);
                //读入MemoryStream对象
                MemoryStream memoryStream = new MemoryStream(imageBytes, 0, imageBytes.Length);
                memoryStream.Write(imageBytes, 0, imageBytes.Length);
                //转成图片
                Image image = Image.FromStream(memoryStream);

                ///图片保存位置
                string filePath = @"F:/Ip/Img/" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";

                image.Save(HttpContext.Current.Server.MapPath(filePath), System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            //using (FileStream fs = new FileStream(@"F:\IP\Img\"+imgName, FileMode.OpenOrCreate, FileAccess.Write))
            //{
            //    fs.Write(bytes, 0, bytes.Length);
            //}
        }

        /// <summary>  
        /// 二进制流写入文件  
        /// </summary>  
        /// <param name="filepath">文件路径</param>  
        /// <param name="filecontent">文件内容</param>  
        /// <param name="FileName">文件名</param>  
        /// <param name="Errmsg">错误消息</param>  
        /// <returns></returns>  
        public static bool WriteFile(string filepath, byte[] filecontent, string FileName, out string Errmsg)
        {
            DirectoryInfo di = new DirectoryInfo(filepath);
            if (!di.Exists)
            {
                di.Create();
            }
            FileStream fstream = null;
            try
            {
                fstream = File.Create(filepath + "\\" + FileName, filecontent.Length);

                fstream.Write(filecontent, 0, filecontent.Length);   //二进制转换成文件  
            }
            catch (Exception ex)
            {
                Errmsg = ex.Message;
                //抛出异常信息  
                return false;
            }
            finally
            {
                if (fstream != null)
                    fstream.Close();
            }
            Errmsg = "";
            return true;
        }

    }
}
