using System;
using System.Data.SqlClient;
using System.Data;

namespace SqlHelper
{
    public class SqlMsg
    {

        /// <summary>
        /// 添加推送消息
        /// </summary>
        /// <param name="Title">推送的标师</param>
        /// <param name="Msg">推送的消息</param>
        /// <param name="IsRead">是否已读</param>
        /// <param name="Category">推送</param>
        /// <param name="LoginId"></param>
        /// <returns></returns>
        public int AddMsg(string Title,string Msg,int IsRead,int Category,string LoginId)
        {

            int Result = 0;
            try
            {
                string sql = @"insert into (Title, Msg, IsRead, Category, LoginId)
                          values(@Title, @Msg, @IsRead, @Category, @LoginId)";
                SqlParameter[] sqlcommand = new SqlParameter[]
                {
                        new SqlParameter("@Title",Title),
                        new SqlParameter("@Msg",Msg),
                        new SqlParameter("@IsRead",IsRead),
                        new SqlParameter("@Category",Category),
                        new SqlParameter("@LoginId",LoginId)
                };
                Result = SqlHelp.Add(sql, sqlcommand);
                return Result;
            }
            catch { return Result = 0; }
        }
    }
}
