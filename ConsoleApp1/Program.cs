using AppBLL;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string jsonData = "[[\"UserAccount\",\"UserPasswd\", \"UserMobile\"," +
                    " \"UserEmail\", \"UserType\", \"UserAvatar\", \"IDNumber\", \"Useraddress\"," +
                    " \"UserName\", \"Verification\"],[\"xu123456\"," +
                    " \"a123456\", \"13527393894\", \"6536163@qq.xom\", \"0\", " +
                    "\"222222\", \"360721199401112816\", \"山西省阳泉市矿区三大发光火大发光火\"," +
                    "\"徐小坤\", \"554949\"]]";

            Console.WriteLine("Hello World!");
            UserCheckBLL B = new UserCheckBLL();
            B.UserInfo_Redis("11", jsonData);
            Console.ReadLine();
        }
    }
}