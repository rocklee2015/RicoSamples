using Abot.Crawler;
using Abot.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CsQuery.HtmlParser;
namespace Rico.S14.AbotTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var abot = new AbotTest();
            abot.WriteLog("Begin");
            var crawler = abot.GetManuallyConfiguredWebCrawler();
            var result = crawler.Crawl(abot.FeedUrl);
            System.Console.WriteLine(result.ErrorException);
            abot.WriteLog("end");
        }


    }
}
