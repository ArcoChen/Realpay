using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Web;
namespace ReCommon
{
    public class ReToHtml
    {
        #region 解析模板的html中匹配的标签，进行替换（暂时只能用于没有分页的页面）
        /// <summary>
        /// 解析模板的html中匹配的标签，进行替换（暂时只能用于没有分页的页面）
        /// </summary>
        /// <param name="html">HTML</param>
        /// <returns>返回替换后的HTML</returns>
        public static string ReturnHtml(string html)
        {
            string newhtml = html;
            newhtml = newhtml.Replace("<#Title#>", "这个是标题替换");//替换标题
            return newhtml;
        }
        #endregion

        #region 读取HTML文件
        /// <summary>
        /// 读取HTML文件
        /// </summary>
        /// <param name="temp">html文件的相对路径</param>
        /// <returns>返回html</returns>
        public static string ReadHtmlFile(string temp)
        {
            StreamReader sr = null;
            string str = "";
            try
            {
                sr = new StreamReader(HttpContext.Current.Server.MapPath(temp));
                str = sr.ReadToEnd(); // 读取文件 
            }
            catch (Exception exp)
            {
                HttpContext.Current.Response.Write(exp.Message);
                HttpContext.Current.Response.End();
            }
            finally
            {
                sr.Dispose();
                sr.Close();

            }
            return str;
        }
        #endregion

        #region 生成html文件
        /// <summary>
        /// 生成html文件
        /// </summary>
        /// <param name="filmname">文件名（带相对路径路径,如：../a.html）</param>
        /// <param name="html">html内容（整个）</param>
        public static void writeHtml(string filmname, string html)
        {
            System.Text.Encoding code = System.Text.Encoding.GetEncoding("utf-8");
            string htmlfilename = HttpContext.Current.Server.MapPath(filmname);
            string str = html;
            StreamWriter sw = null;
            // 写文件
            try
            {
                sw = new StreamWriter(htmlfilename, false, code);
                sw.Write(str);
                sw.Flush();
            }

            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
                HttpContext.Current.Response.End();
            }

            finally
            {
                sw.Close();
            }
        } 
        #endregion

    }
}
