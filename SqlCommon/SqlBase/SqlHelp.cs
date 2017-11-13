using System;
using System.Data.SqlClient;
using Newtonsoft.Json;

using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Transactions;
namespace SqlHelper
{
    public class SqlHelp
    {
        //添加
        public static int Add(string sql, SqlParameter[] sqlparameter)
        {
            int Result = 0;
            using (SqlConnection connection =
               new SqlConnection(SqlHelper.SqlBaseHelper.GetConnSting()))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                if (sqlparameter != null)
                {
                    command.Parameters.AddRange(sqlparameter);
                }
                try
                {
                    connection.Open();
                    Result = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return Result;
        }
        //修改
        public static int Update(string sql, SqlParameter[] sqlparameter)
        {
            int Result = 0;
            using (SqlConnection connection =
               new SqlConnection(SqlHelper.SqlBaseHelper.GetConnSting()))
            {

                SqlCommand command = new SqlCommand(sql, connection);
                if (sqlparameter != null)
                {
                    command.Parameters.AddRange(sqlparameter);
                }
                try
                {
                    connection.Open();
                    Result = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return Result;
        }
        //读取列表
        public static string liststring(string sql, int pageIndex, int Pagesize, SqlParameter[] sqlparameter)
        {
            bool FirstRead = true;
            int intColnum = 0;
            int TotalCount = 0;
            StringBuilder Json = new StringBuilder();
            using (SqlConnection connection =
                  new SqlConnection(SqlHelper.SqlBaseHelper.GetConnSting()))
            {
                SqlCommand command =
                    new SqlCommand(sql, connection);
                if (sqlparameter != null)
                {
                    command.Parameters.AddRange(sqlparameter);
                }
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TotalCount = TotalCount + 1;
                    if (FirstRead)
                    {
                        intColnum = reader.FieldCount;
                        FirstRead = false;
                    }
                    Json.Append("{");
                    for (int i = 0; i < intColnum; i++)
                    {
                        if (i == intColnum - 1)
                        {
                            Json.Append("\"" + reader.GetName(i) + "\":\"" + reader[i].ToString() + "\"");
                            Json.Append("},");
                        }
                        else
                            Json.Append("\"" + reader.GetName(i) + "\":\"" + reader[i].ToString() + "\",");
                    }
                }
                reader.Close();
            }
            int listCount = 0;
            if (TotalCount == Pagesize)
                listCount = (pageIndex + 1) * Pagesize;
            else
                listCount = (pageIndex - 1) * Pagesize + TotalCount;
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"total\":" + listCount + ",\"items\":[");
            if (Json.Length > 0)
                sb.Append(Json.ToString().Substring(0, Json.Length - 1));
            sb.Append("]}");
            return sb.ToString();
        }


        public static string listParameter(string sql, SqlParameter[] sqlparameter)
        {
            bool FirstRead = true;
            int intColnum = 0;
            int TotalCount = 0;
            StringBuilder Json = new StringBuilder();
            using (SqlConnection connection =
                  new SqlConnection(SqlHelper.SqlBaseHelper.GetConnSting()))
            {
                SqlCommand command =
                    new SqlCommand(sql, connection);
                if (sqlparameter != null)
                {
                    command.Parameters.AddRange(sqlparameter);
                }
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TotalCount = TotalCount + 1;
                    if (FirstRead)
                    {
                        intColnum = reader.FieldCount;
                        FirstRead = false;
                    }
                    for (int i = 0; i < intColnum; i++)
                    {
                        if (i == intColnum - 1)
                        {
                            Json.Append(reader[i].ToString());
                            Json.Append("|");
                        }
                        else
                        {
                            Json.Append(reader[i].ToString() + ",");
                        }
                    }
                }
                reader.Close();
            }
            string Sresult = string.Empty;
            if (Json.Length > 0)
                Sresult = Json.ToString().Substring(0, Json.Length - 1);
            return Sresult;
        }

        //检测
        public static bool IsCheck(string sql, SqlParameter[] sqlparameter)
        {
            using (SqlConnection connection =
               new SqlConnection(SqlHelper.SqlBaseHelper.GetConnSting()))
            {
                SqlCommand command =
                    new SqlCommand(sql, connection);
                if (sqlparameter != null)
                    command.Parameters.AddRange(sqlparameter);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                        return true;
                    else
                        return false;
                }
                catch (Exception) { return false; }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 读取单条记录
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="sqlparameter">参数</param>
        /// <returns></returns>
        public static string ReadSingleInfo(string sql, SqlParameter[] sqlparameter)
        {
            int intColnum = 0;
            StringBuilder Json = new StringBuilder();
            using (SqlConnection connection =
                  new SqlConnection(SqlHelper.SqlBaseHelper.GetConnSting()))
            {
                SqlCommand command =
                    new SqlCommand(sql, connection);
                if (sqlparameter != null)
                {
                    command.Parameters.AddRange(sqlparameter);
                }
                connection.Open();
                Json.Append("{");
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    intColnum = reader.FieldCount;
                    for (int i = 0; i < intColnum; i++)
                    {
                        if (i == intColnum - 1)
                        {
                            Json.Append("\"" + reader.GetName(i) + "\":\"" + reader[i].ToString() + "\"");
                        }
                        else
                            Json.Append("\"" + reader.GetName(i) + "\":\"" + reader[i].ToString() + "\",");
                    }
                }
                reader.Close();
            }
            Json.Append("}");
            return Json.ToString();
        }



        /// <summary>
        /// 读取单条记录
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="sqlparameter">参数</param>
        /// <returns></returns>
        public static string ReadSingleParameter(string sql, SqlParameter[] sqlparameter)
        {
            int intColnum = 0;
            string Sresult = string.Empty;
            using (SqlConnection connection =
                  new SqlConnection(SqlHelper.SqlBaseHelper.GetConnSting()))
            {
                SqlCommand command =
                    new SqlCommand(sql, connection);
                if (sqlparameter != null)
                {
                    command.Parameters.AddRange(sqlparameter);
                }
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    intColnum = reader.FieldCount;
                    for (int i = 0; i < intColnum; i++)
                    {
                        if (i == intColnum - 1)
                        {
                            Sresult += reader[i].ToString();
                        }
                        else
                            Sresult += reader[i].ToString() + ",";
                    }
                }
                reader.Close();
            }
            return Sresult;
        }


        #region
        public static int AddUpdateTransaction(List<string> sqlList, List<List<SqlParameter>> Listsqlparameter)
        {
            int Result = 0;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (SqlConnection connection = new SqlConnection(SqlHelper.SqlBaseHelper.GetConnSting()))
                    {
                        try
                        {
                            connection.Open();
                            for (int i = 0; i < sqlList.Count; i++)
                            {
                                SqlCommand command = new SqlCommand(sqlList[i], connection);
                                if (Listsqlparameter.Count > i)
                                {
                                    if (Listsqlparameter[i].Count > 0)
                                    {
                                        SqlParameter[] Params = Listsqlparameter[i].ToArray();
                                        command.Parameters.AddRange(Params);
                                        Result = command.ExecuteNonQuery();
                                    }
                                }
                                else
                                    Result = command.ExecuteNonQuery();

                            }
                            scope.Complete();
                        }
                        catch (Exception ex)
                        {
                            Result = -2;
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            connection.Close();
                        }

                    }
                }
            }
            catch
            {
                Result = -2;
            }

            return Result;
        }
        #endregion
    }
}
