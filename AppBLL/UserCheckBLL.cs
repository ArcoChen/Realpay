using ReCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBLL
{
    public class UserCheckBLL
    {
        public Dictionary<string,string> UserInfo_Redis(string DATA)
        {
            string jsonData = ApiHelper.DATAToJson(DATA);
            string[] userInfoArray = { "UserAccount" };

            Dictionary<string, string> dic = ApiHelper.SpecificData(userInfoArray, jsonData);
            string imgName = "/Avatar/" + dic["UserAccount"] + ".jpg";
            dic.Add("UserAvatar", imgName);

            return dic;
        }
    }
}
