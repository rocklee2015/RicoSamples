using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S11.DateTimeSample
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTimeKind();
           

            Console.ReadKey();
        }

        static void UtcConvertToLocalTime()
        {
            System.DateTime dt = DateTime.Now;//本地时间:2016-8-8 1:47:35
            Console.WriteLine(dt.ToUniversalTime().ToString());//先转化为utc时间又转回北京时间:2016-8-8 1:47:35
            Console.WriteLine(dt.ToString());//本地时间:2016-8-8 1:47:35
            Console.WriteLine(dt.ToUniversalTime().ToString());//UTC时间:2016-8-7 17:47:35
        }

        static void DateTimeKind()
        {
            DateTime time = DateTime.Parse("2013-07-05 00:00:00");
            Console.WriteLine(time.ToUniversalTime()); //2013/7/4 16:00:00
            Console.WriteLine(time.ToLocalTime()); //2013/7/5 8:00:00
            Console.WriteLine(time.Kind);
        }
    }
}
