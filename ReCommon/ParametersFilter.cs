using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace ReCommon
{
    public class ParametersFilter
    {
        #region String length formatter
        public static string FilterSqlHtml(string stringTrim, int MaxLength)
        {
            return ParametersFilter.StripSQLInjection(SubTrim(stringTrim, MaxLength));
        }

        /// <summary>
        /// 对字符串进行裁剪
        /// </summary>
        public static string SubTrim(string stringTrim, int maxLength)
        {
            return Trim(NoHTML(stringTrim), maxLength);
        }

        /// <summary>
        /// 对字符串进行裁剪(区分单字节及双字节字符)
        /// </summary>
        /// <param name="rawString">需要裁剪的字符串</param>
        /// <param name="maxLength">裁剪的长度，按双字节计数</param>
        /// <param name="appendString">如果进行了裁剪需要附加的字符</param>
        public static string Trim(string rawString, int maxLength)
        {
            if (string.IsNullOrEmpty(rawString) || rawString.Length <= maxLength)
            {
                return rawString;
            }
            else
            {
                int rawStringLength = Encoding.UTF8.GetBytes(rawString).Length;
                if (rawStringLength <= maxLength * 2)
                    return rawString;
            }
            StringBuilder checkedStringBuilder = new StringBuilder();
            int appendedLenth = 0;
            for (int i = 0; i < rawString.Length; i++)
            {
                char _char = rawString[i];
                checkedStringBuilder.Append(_char);

                appendedLenth += Encoding.Default.GetBytes(new char[] { _char }).Length;

                if (appendedLenth >= maxLength * 2)
                    break;
            }

            return checkedStringBuilder.ToString();
        }


        #endregion

        #region 特殊字符

        /// <summary>
        /// 检测是否有Sql危险字符
        /// </summary>
        /// <param name="str">要判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsSafeSqlString(string str)
        {
            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }

        /// <summary>
        /// 删除SQL注入特殊字符
        /// </summary>
        public static string StripSQLInjection(string sql)
        {
            if (!string.IsNullOrEmpty(sql))
            {
                //Filter ' -- \ *
                string pattern1 = @"(\%27)|(\')|(\-\-)|(\\)|(\*)";

                //Prevent Execute ' or
                string pattern2 = @"((\%27)|(\'))\s*((\%6F)|o|(\%4F))((\%72)|r|(\%52))";

                //Prevent Execetu sql server Stored procedure or extended stored procedure
                string pattern3 = @"\s+exec(\s|\+)+(s|x)p\w+";

                sql = Regex.Replace(sql, pattern1, string.Empty, RegexOptions.IgnoreCase);
                sql = Regex.Replace(sql, pattern2, string.Empty, RegexOptions.IgnoreCase);
                sql = Regex.Replace(sql, pattern3, string.Empty, RegexOptions.IgnoreCase);
            }
            return sql;
        }

        public static string SQLSafe(string Parameter)
        {
            Parameter = Parameter.ToLower();
            Parameter = Parameter.Replace("'", "");
            Parameter = Parameter.Replace(">", ">");
            Parameter = Parameter.Replace("<", "<");
            Parameter = Parameter.Replace("\n", "<br>");
            Parameter = Parameter.Replace("\0", "·");
            return Parameter;
        }

        /// <summary>
        /// 清除xml中的不合法字符
        /// </summary>
        /// <remarks>
        /// 无效字符：
        /// 0x00 - 0x08
        /// 0x0b - 0x0c
        /// 0x0e - 0x1f
        /// </remarks>
        public static string CleanInvalidCharsForXML(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            else
            {
                StringBuilder checkedStringBuilder = new StringBuilder();
                Char[] chars = input.ToCharArray();
                for (int i = 0; i < chars.Length; i++)
                {
                    int charValue = Convert.ToInt32(chars[i]);

                    if ((charValue >= 0x00 && charValue <= 0x08) || (charValue >= 0x0b && charValue <= 0x0c) || (charValue >= 0x0e && charValue <= 0x1f))
                        continue;
                    else
                        checkedStringBuilder.Append(chars[i]);
                }

                return checkedStringBuilder.ToString();

                //string result = checkedStringBuilder.ToString();
                //result = result.Replace("&#x0;", "");
                //return Regex.Replace(result, @"[\u0000-\u0008\u000B\u000C\u000E-\u001A\uD800-\uDFFF]", delegate(Match m) { int code = (int)m.Value.ToCharArray()[0]; return (code > 9 ? "&#" + code.ToString() : "&#0" + code.ToString()) + ";"; });
            }
        }


        /// <summary>
        /// 改正sql语句中的转义字符
        /// </summary>
        public static string mashSQL(string str)
        {
            return (str == null) ? "" : str.Replace("\'", "'");
        }

        /// <summary>
        /// 替换sql语句中的有问题符号
        /// </summary>
        public static string ChkSQL(string str)
        {
            return (str == null) ? "" : str.Replace("'", "''");
        }

        /// <summary>
        ///  判断是否有非法字符
        /// </summary>
        /// <param name="strString"></param>
        /// <returns>返回TRUE表示有非法字符，返回FALSE表示没有非法字符。</returns>
        public static bool CheckBadStr(string strString)
        {
            bool outValue = false;
            if (strString != null && strString.Length > 0)
            {
                string[] bidStrlist = new string[27];
                bidStrlist[0] = "'";
                bidStrlist[1] = ";";
                bidStrlist[2] = ":";
                bidStrlist[3] = "%";
                bidStrlist[4] = "@@";
                bidStrlist[5] = "&";
                bidStrlist[6] = "#";
                bidStrlist[7] = "\"";
                bidStrlist[8] = "net user";
                bidStrlist[9] = "exec";
                bidStrlist[10] = "net localgroup";
                bidStrlist[11] = "select";
                bidStrlist[12] = "asc";
                bidStrlist[13] = "char";
                bidStrlist[14] = "mid";
                bidStrlist[15] = "insert";
                bidStrlist[16] = "update";
                bidStrlist[17] = "table";
                bidStrlist[18] = "master";
                bidStrlist[19] = "order";
                bidStrlist[20] = "exec";
                bidStrlist[21] = "delete";
                bidStrlist[22] = "drop";
                bidStrlist[23] = "truncate";
                bidStrlist[24] = "xp_cmdshell";
                bidStrlist[25] = "<";
                bidStrlist[26] = ">";
                string tempStr = strString.ToLower();
                for (int i = 0; i < bidStrlist.Length; i++)
                {
                    if (tempStr.IndexOf(bidStrlist[i]) != -1)
                    {
                        outValue = true;
                        break;
                    }
                }
            }
            return outValue;
        }

        #endregion

        #region Tools
        /// <summary>
        /// 去掉最后一个逗号
        /// </summary>
        /// <param name="String">要做处理的字符串</param>
        /// <returns>去掉最后一个逗号的字符串</returns>
        public static string DelLastComma(string String)
        {
            if (String.IndexOf(",") == -1)
            {
                return String;
            }
            return String.Substring(0, String.LastIndexOf(","));
        }

        /// <summary>
        /// 删除最后一个字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ClearLastChar(string str)
        {
            return (str == "") ? "" : str.Substring(0, str.Length - 1);
        }
        /// <summary>
        /// html编码
        /// </summary>
        /// <param name="chr"></param>
        /// <returns></returns>
        public static string html_text(string chr)
        {
            if (chr == null)
                return "";
            chr = chr.Replace("'", "''");
            chr = chr.Replace("<", "<");
            chr = chr.Replace(">", ">");
            return (chr);
        }
        /// <summary>
        /// html解码
        /// </summary>
        /// <param name="chr"></param>
        /// <returns></returns>
        public static string text_html(string chr)
        {
            if (chr == null)
                return "";
            chr = chr.Replace("<", "<");
            chr = chr.Replace(">", ">");
            return (chr);
        }
        public static bool JustifyStr(string strValue)
        {
            bool flag = false;
            char[] str = "^<>'=&*, ".ToCharArray(0, 8);
            for (int i = 0; i < 8; i++)
            {
                if (strValue.IndexOf(str[i]) != -1)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        public static string CheckOutputString(string key)
        {
            string OutputString = string.Empty;
            OutputString = key.Replace("<br>", "\n").Replace("<", "<").Replace(">", ">").Replace("&nbsp;", " ");
            return OutputString;

        }
        #endregion

        #region 转全角
        /// 转全角的函数(SBC case)
        ///
        ///任意字符串
        ///全角字符串
        ///
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///
        public static String ToSBC(String input)
        {
            // 半角转全角：
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new String(c);
        }
        #endregion

        #region 转半角
        ///
        /// 转半角的函数(DBC case)
        ///
        ///任意字符串
        ///半角字符串
        ///
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///
        public static String ToDBC(String input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new String(c);
        }
        #endregion

        #region 去除Html标记
        ///   <summary>
        ///   去除HTML标记
        ///   </summary>
        ///   <param   name="NoHTML">包括HTML的源码   </param>
        ///   <returns>已经去除后的文字</returns>
        public static string NoHTML(string Htmlstring)
        {
            if (string.IsNullOrWhiteSpace(Htmlstring))
                return Htmlstring;
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "",
              RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "",
              RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;
        }

        public static string StripHTML(string strHtml)
        {
            string[] aryReg =
            {
              @"<script[^>]*?>.*?</script>",
              @"<(\/\s*)?!?((\w+:)?\w+)(\w+(\s*=?\s*(([""'])(\\[""'tbnr]|[^\\7])*?\\7|\\w+)|.{0})|\\s)*?(\\/\\s*)?>",
              @"([\r\n])[\s]+",
              @"&(quot|#34);",
              @"&(amp|#38);",
              @"&(lt|#60);",
              @"&(gt|#62);",
              @"&(nbsp|#160);",
              @"&(iexcl|#161);",
              @"&(cent|#162);",
              @"&(pound|#163);",
              @"&(copy|#169);",
              @"&#(\d+);",
              @"-->",
              @"<!--.*\n"
            };
            string[] aryRep =
            {
                "", "", "", "\"", "&", "<", ">", "   ", "\xa1",  //chr(161),
               "\xa2",  //chr(162),
               "\xa3",  //chr(163),
               "\xa9",  //chr(169),
                "",
                "\r\n", ""
            };
            string newReg = aryReg[0];
            string strOutput = strHtml;
            for (int i = 0; i < aryReg.Length; i++)
            {
                Regex regex = new Regex(aryReg[i], RegexOptions.IgnoreCase);
                strOutput = regex.Replace(strOutput, aryRep[i]);
            }
            strOutput.Replace("<", "");
            strOutput.Replace(">", "");
            strOutput.Replace("\r\n", "");
            return strOutput;
        }
        #endregion

        #region 移除HTML标签
        /**/ ///   <summary>
             ///   移除HTML标签
             ///   </summary>
             ///   <param   name="HTMLStr">HTMLStr</param>
        public static string ParseTags(string HTMLStr)
        {
            return System.Text.RegularExpressions.Regex.Replace(HTMLStr, "<[^>]*>", "");
        }
        #endregion

        #region 取出文本中的图片地址
        /**/ ///   <summary>
             ///   取出文本中的图片地址
             ///   </summary>
             ///   <param   name="HTMLStr">HTMLStr</param>
        public static string GetImgUrl(string HTMLStr)
        {
            string str = string.Empty;
            //string sPattern = @"^<img\s+[^>]*>";
            Regex r = new Regex(@"<img\s+[^>]*\s*src\s*=\s*([']?)(?<url>\S+)'?[^>]*>",
              RegexOptions.Compiled);
            Match m = r.Match(HTMLStr.ToLower());
            if (m.Success)
                str = m.Result("${url}");
            return str;
        }

        public static string[] GerImgUrls(string HTMLStr)
        {
            Regex M_hvtRegImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);
            MatchCollection Matches = M_hvtRegImg.Matches(HTMLStr);
            int ImgCount = 0;
            string[] ImgUrlList = new string[Matches.Count];

            foreach (Match match in Matches)
            {
                ImgUrlList[ImgCount++] = match.Groups["imgUrl"].Value;
            }
            return ImgUrlList;
        }
        #endregion
    }
}
