using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ReCommon
{
    public class CleanTask
    {

        public static string ROOT_PATH = @"C://imgData/";

        public CleanTask()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(aTimer_Elapsed);
            timer.Interval = 1000 * 60;
            timer.Enabled = true;
        }


        public static void aTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            int intHour = e.SignalTime.Hour;
            int intMinute = e.SignalTime.Minute;

            int iHour = 02;
            int iMinute = 00;
            if (iHour == intHour && iMinute == intMinute)
            {
                string date = DateTime.Today.AddDays(-2).ToString("yyyyMMdd");
                string dirPath = ROOT_PATH + date+"/";
                if (Directory.Exists(dirPath))
                {
                    Directory.Delete(dirPath, true);
                }
            }
        }
    }
}
