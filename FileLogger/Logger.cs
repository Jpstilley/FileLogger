using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisKata1
{
    class Logger 
    {
        private readonly string today = DateTime.Today.AddDays(5).ToString("dddd");
        private readonly string weekend = @"weekend.txt";
        private readonly string path = @"log" + DateTime.Today.ToString("yyyyMMdd") + @".txt";
        private readonly IWriter writer;

        public Logger(IWriter writer)
        {
            this.writer = writer;
        }

        public void Log(string message) 
        {
            if (IsWeekend(today))
            {
                WeekendExists(weekend, today);
                
                message = DateTime.Now.ToString("yyyyMMdd") + message;
                writer.Write(message, weekend);
            }
            else
            {


                message = DateTime.Now.ToString("yyyyMMdd") + message;
                writer.Write(message, path);
            }
        }

        private bool IsWeekend(string today)
        {
            
            if (today == DayOfWeek.Saturday.ToString() || today == DayOfWeek.Sunday.ToString())
            {
                return true;
            }

            return false;
        }

        private void WeekendExists(string weekend, string today)
        {
            if(File.Exists(weekend))
            {
                string todayDate = IsSaturday(today);
                string newWeekend = @"weekend-" + todayDate + ".txt";

                //IWriter
                File.AppendText(newWeekend);              
            }
        }

        private string IsSaturday(string today)
        {
            
            if (today == DayOfWeek.Saturday.ToString())
            {
                IsCurrentWeekend(today);
                today = DateTime.Today.ToString("yyyyMMdd");
                return today;
            }
            IsCurrentWeekend(today);
            today = DateTime.Today.AddDays(-1).ToString("yyyyMMdd");
            return today;
        }

        private string IsCurrentWeekend(string today)
        {
            var thisDate = DateTime.ParseExact(today, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            var todaysDate = DateTime.Today;
            if(thisDate <= todaysDate)
            {
                return today;
            }
            return today;

        }
    }
}

//else if (File.Exists(path))
//{
//using (StreamWriter sw = File.AppendText(path))
//{
//    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss ") + message);

//    Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss ") + message);

//}

//}
//else 
//{
//    using (StreamWriter sw = File.CreateText(path))
//    {
//        sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss ") + message);

//        Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss ") + message);

//    }
//}  







//if (File.Exists(weekend) && (today == DayOfWeek.Saturday.ToString() || today == DayOfWeek.Sunday.ToString()))
//{
//    return true;
//}

//else if (!File.Exists(weekend) && (today == DayOfWeek.Saturday.ToString() || today == DayOfWeek.Sunday.ToString()))
//{
//    return false;
//}
//return false;