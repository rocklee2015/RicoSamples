using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S14.MaoYanMovie
{
    class Program
    {
        static void Main(string[] args)
        {
            var abot = new AbotMaoyan();
            abot.WriteLog("Begin");
            var crawler = abot.GetManuallyConfiguredWebCrawler();
            var result = crawler.Crawl(abot.FeedUrl);
            System.Console.WriteLine(result.ErrorException);
            abot.SaveMovieToFile();
            abot.WriteLog("end");
        }
    }
}
