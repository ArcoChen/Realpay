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
        public string UserInfo_Redis(string UserAvatar,string DATA)
        {
            string jsonData = ApiHelper.DATAToJson(DATA);
            string[] userInfoArray = { "UserAccount"};
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("UserAvatar", UserAvatar);
            Dictionary<string, string> data = ApiHelper.SpecificData(userInfoArray, jsonData);
            dic = dic.Concat(data) as Dictionary<string,string>;
            string Result = ApiHelper.DictionaryToStr<string>(dic);
            return Result;
        }
    }
}
