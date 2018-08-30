using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rico.S14.MaoYanMovie
{
    class Program
    {
        private static AbotMaoyan abot = new AbotMaoyan();
        private static int Count = 1;
        static void Main(string[] args)
        {
            DownMovie(null, null);
            //方法二：使用System.Timers.Timer类
            System.Timers.Timer t = new System.Timers.Timer(TimeSpan.FromHours(24).TotalMilliseconds);//实例化Timer类，设置时间间隔
            t.Elapsed += new System.Timers.ElapsedEventHandler(DownMovie);//到达时间的时候执行事件
            t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)
            t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件

            t.Start();
         
            Console.ReadKey();
        }
   
        
        
        public static void DownMovie(object source, System.Timers.ElapsedEventArgs e)
        {
            Console.Clear();
            abot.StartDownMovie();
            Console.Title = $"=======第 {Count++} 次爬取 正在进行  {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}=======";


            var crawler = abot.GetManuallyConfiguredWebCrawler();
          
            crawler.Crawl(abot.FeedUri);

            abot.EndDownMovie();


            Console.Title = $"=======第 {Count} 次爬取  已经结束 {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}========";


        }

    }
}
