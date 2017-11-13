using System.Web.Mvc;
using ReCommon;
using RedisHelper;
using System;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        Redis redis = new Redis();

        public ActionResult Index()
        {
            try
            {
                redis.StringSet("key2", "{\"name\":\"hoang\",\"gender\":\"male\",\"age\":25}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            string key = redis.StringGet("key1");
            //string ipAddress = HttpHelper.IPAddress();
            string date = ReDateTime.GetDateTimeNow("yyyyMMddHHmmss");
            return Content(key);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}