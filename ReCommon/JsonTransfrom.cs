
using System.Data;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Reflection;
using System;
using System.Text;

namespace ReCommon
{
    public class JsonTransfrom
    {
        /// <summary>
        /// 返回结果拼接为JSON字符串
        /// </summary>
        /// <param name="ReturnCode">请求状态</param>
        /// <param name="Source">请求源</param>
        /// <param name="Credentials">用户凭证，缺省为0</param>
        /// <param name="Index">时间戳</param>
        /// <param name="Method">方法名</param>
        /// <returns></returns>
        public static string ResultToJson(string ReturnCode, string Source, string Credentials, string Index, string Method, Dictionary<string, string> data)
        {
            StringBuilder Json = new StringBuilder();
            Json.Append("{\"RETURNCODE\":\"" + ReturnCode + "\"");
            Json.Append(",\"SOURCE\":\"" + Source + "\"");
            Json.Append(",\"CREDENTIALS\":\"" + Credentials + "\"");
            Json.Append(",\"INDEX\":\"" + Index + "\"");
            Json.Append(",\"METHOD\":\"" + Method + "\"");
            Json.Append(",");

            if (data != null)
            {
                int i = 0;

                //循环打印dictionary数据
                foreach (var item in data)
                {
                    i++;
                    if (i < data.Count)
                    {
                        Json.Append("\"" + item.Key + "\":\"" + item.Value + "\",");
                    }
                    else
                    {
                        Json.Append("\"" + item.Key + "\":\"" + item.Value + "\"");
                    }
                }
            }

            Json.Append("}");
            return Json.ToString();
        }

        /// <summary>
        /// 请求参数转换为JSON字符串（查询）
        /// </summary>
        /// <param name="Source">请求来源</param>
        /// <param name="Credentials">用户凭证</param>
        /// <param name="Address">IP地址</param>
        /// <param name="Terminal">设备标识， 0-PC，1-Android，2-iOS</param>
        /// <param name="Index">数据包序列</param>
        /// <param name="Method">请求方法</param>
        /// <param name="data">实体数据</param>
        /// <returns></returns>
        public static string SeaRequsetToJson(string Source, string Credentials, string Address, string Terminal, string Index, string Method, Dictionary<string, string> data)
        {
            StringBuilder Json = new StringBuilder();
            Json.Append("{\"SOURCE\":\"" + Source + "\"");
            Json.Append(",\"CREDENTIALS\":\"" + Credentials + "\"");
            Json.Append(",\"ADDRESS\":\"" + Address + "\"");
            Json.Append(",\"TERMINAL\":\"" + Terminal + "\"");
            Json.Append(",\"INDEX\":\"" + Index + "\"");
            Json.Append(",\"METHOD\":\"" + Method + "\"");
            Json.Append(",");

            if (data != null)
            {
                int i = 0;

                //循环打印dictionary数据
                foreach (var item in data)
                {
                    i++;
                    if (i < data.Count)
                    {
                        Json.Append("\"" + item.Key + "\":\"" + item.Value + "\",");
                    }
                    else
                    {
                        Json.Append("\"" + item.Key + "\":\"" + item.Value + "\"");
                    }
                }
            }

            Json.Append("}");
            return Json.ToString();
        }

        /// <summary>
        /// 请求参数转换为JSON字符串（插入）
        /// </summary>
        /// <param name="Source">请求来源</param>
        /// <param name="Credentials">用户凭证</param>
        /// <param name="Address">IP地址</param>
        /// <param name="Terminal">设备标识， 0-PC，1-Android，2-iOS</param>
        /// <param name="Index">数据包序列</param>
        /// <param name="Method">请求方法</param>
        /// <param name="data">实体数据</param>
        /// <returns></returns>
        public static string InsRequsetToJson(string Source, string Credentials, string Address, string Terminal, string Index, string Method, Dictionary<string, string> data)
        {
            StringBuilder Json = new StringBuilder();
            Json.Append("{\"SOURCE\":\"" + Source + "\"");
            Json.Append(",\"CREDENTIALS\":\"" + Credentials + "\"");
            Json.Append(",\"ADDRESS\":\"" + Address + "\"");
            Json.Append(",\"TERMINAL\":\"" + Terminal + "\"");
            Json.Append(",\"INDEX\":\"" + Index + "\"");
            Json.Append(",\"METHOD\":\"" + Method + "\"");
            Json.Append(",\"DATA\":\"");
            string str = string.Empty;
            if (data != null)
            {
                int i = 0;

                //循环打印dictionary数据
                foreach (var item in data)
                {
                    i++;
                    if (i < data.Count)
                    {
                        str+="[[\"" + item.Key + "\",";
                    }
                    else
                    {
                        str+="\"" + item.Key + "\"";
                    }
                }
                str+="],[";

                i = 0;
                //循环打印dictionary数据
                foreach (var item in data)
                {
                    i++;
                    if (i < data.Count)
                    {
                        str += "\"" + item.Value + "\",";
                    }
                    else
                    {
                        str += "\"" + item.Value + "\"";
                    }
                }
                str += "]]";

                str = System.Web.HttpUtility.UrlEncode(str);
                Json.Append(str);
                Json.Append("\"}");
            }
            return Json.ToString();
        }

        /// <summary>
        /// 返回Json格式错误信息
        /// </summary>
        /// <param name="ErrorName">错误名</param>
        /// <param name="ErrorMessage">错误信息</param>
        /// <returns></returns>
        public static string ErrorToJson(string ErrorName, string ErrorMessage)
        {
            StringBuilder Json = new StringBuilder();
            Json.Append("{\"" + ErrorName + "\":\"" + ErrorMessage + "\"}");
            return Json.ToString();
        }

        #region 将json转换为DataTable
        /// <summary>
        /// 将json转换为DataTable
        /// </summary>
        /// <param name="strJson">得到的json</param>
        /// <returns></returns>
        public static DataTable JsonToDataTable(string strJson)
        {
            //转换json格式
            strJson = strJson.Replace(",\"", "*\"").Replace("\":", "\"#").ToString();
            //取出表名   
            var rg = new Regex(@"(?<={)[^:]+(?=:\[)", RegexOptions.IgnoreCase);
            string strName = rg.Match(strJson).Value;
            DataTable tb = null;
            //去除表名   
            strJson = strJson.Substring(strJson.IndexOf("[") + 1);
            strJson = strJson.Substring(0, strJson.IndexOf("]"));

            //获取数据   
            rg = new Regex(@"(?<={)[^}]+(?=})");
            MatchCollection mc = rg.Matches(strJson);
            for (int i = 0; i < mc.Count; i++)
            {
                string strRow = mc[i].Value;
                string[] strRows = strRow.Split('*');

                //创建表   
                if (tb == null)
                {
                    tb = new DataTable();
                    tb.TableName = strName;
                    foreach (string str in strRows)
                    {
                        var dc = new DataColumn();
                        string[] strCell = str.Split('#');

                        if (strCell[0].Substring(0, 1) == "\"")
                        {
                            int a = strCell[0].Length;
                            dc.ColumnName = strCell[0].Substring(1, a - 2);
                        }
                        else
                        {
                            dc.ColumnName = strCell[0];
                        }
                        tb.Columns.Add(dc);
                    }
                    tb.AcceptChanges();
                }

                //增加内容   
                DataRow dr = tb.NewRow();
                for (int r = 0; r < strRows.Length; r++)
                {
                    dr[r] = strRows[r].Split('#')[1].Trim().Replace("，", ",").Replace("：", ":").Replace("\"", "");
                }
                tb.Rows.Add(dr);
                tb.AcceptChanges();
            }

            return tb;
        }
        #endregion
    }

    #region DATATable与实体类相互转换
    /// <summary>
    /// DataTable与实体类互相转换
    /// </summary>
    /// <typeparam name="T">实体类</typeparam>
    public class ModelHandler<T> where T : new()
    {
        #region DataTable转换成实体类

        /// <summary>
        /// 填充对象列表：用DataSet的第一个表填充实体类
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns></returns>
        public List<T> FillModel(DataSet ds)
        {
            if (ds == null || ds.Tables[0] == null || ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return FillModel(ds.Tables[0]);
            }
        }

        /// <summary> 
        /// 填充对象列表：用DataSet的第index个表填充实体类
        /// </summary> 
        public List<T> FillModel(DataSet ds, int index)
        {
            if (ds == null || ds.Tables.Count <= index || ds.Tables[index].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return FillModel(ds.Tables[index]);
            }
        }

        /// <summary> 
        /// 填充对象列表：用DataTable填充实体类
        /// </summary> 
        public List<T> FillModel(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            List<T> modelList = new List<T>();
            foreach (DataRow dr in dt.Rows)
            {
                //T model = (T)Activator.CreateInstance(typeof(T)); 
                T model = new T();
                for (int i = 0; i < dr.Table.Columns.Count; i++)
                {
                    PropertyInfo propertyInfo = model.GetType().GetProperty(dr.Table.Columns[i].ColumnName);
                    if (propertyInfo != null && dr[i] != DBNull.Value)
                        propertyInfo.SetValue(model, dr[i], null);
                }

                modelList.Add(model);
            }
            return modelList;
        }

        /// <summary> 
        /// 填充对象：用DataRow填充实体类
        /// </summary> 
        public T FillModel(DataRow dr)
        {
            if (dr == null)
            {
                return default(T);
            }

            //T model = (T)Activator.CreateInstance(typeof(T)); 
            T model = new T();

            for (int i = 0; i < dr.Table.Columns.Count; i++)
            {
                PropertyInfo propertyInfo = model.GetType().GetProperty(dr.Table.Columns[i].ColumnName);
                if (propertyInfo != null && dr[i] != DBNull.Value)
                    propertyInfo.SetValue(model, dr[i], null);
            }
            return model;
        }

        #endregion

        #region 实体类转换成DataTable

        /// <summary>
        /// 实体类转换成DataSet
        /// </summary>
        /// <param name="modelList">实体类列表</param>
        /// <returns></returns>
        public DataSet FillDataSet(List<T> modelList)
        {
            if (modelList == null || modelList.Count == 0)
            {
                return null;
            }
            else
            {
                DataSet ds = new DataSet();
                ds.Tables.Add(FillDataTable(modelList));
                return ds;
            }
        }

        /// <summary>
        /// 实体类转换成DataTable
        /// </summary>
        /// <param name="modelList">实体类列表</param>
        /// <returns></returns>
        public static DataTable FillDataTable(List<T> modelList)
        {
            if (modelList == null || modelList.Count == 0)
            {
                return null;
            }
            DataTable dt = CreateData(modelList[0]);

            foreach (T model in modelList)
            {
                DataRow dataRow = dt.NewRow();
                foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
                {
                    dataRow[propertyInfo.Name] = propertyInfo.GetValue(model, null);
                }
                dt.Rows.Add(dataRow);
            }
            return dt;
        }

        /// <summary>
        /// 根据实体类得到表结构
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns></returns>
        private static DataTable CreateData(T model)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                dataTable.Columns.Add(new DataColumn(propertyInfo.Name, propertyInfo.PropertyType));
            }
            return dataTable;
        }

        #endregion
    }
    #endregion
}
