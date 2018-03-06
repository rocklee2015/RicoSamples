using Abot.Crawler;
using Abot.Poco;
using CsQuery.HtmlParser;
using System;
using System.Linq;
using System.Text.RegularExpressions;
namespace Rico.S14.AbotTest
{
    public class AbotTest
    {

        /// <summary>
        /// 要跑的网页这里是博客园
        /// </summary>
        public readonly Uri FeedUrl = new Uri(@"https://news.cnblogs.com/");


        /// <summary>
        ///博客园详细页面的正则表达式
        /// </summary>
        public Regex NewsUrlRegex = new Regex("^https://news.cnblogs.com/n/\\d+/$", RegexOptions.Compiled);


        /// <summary>
        /// 博客园分页的正则表达式
        /// </summary>
        public Regex NewsPageRegex = new Regex("^https://news.cnblogs.com/n/page/\\d+/$", RegexOptions.Compiled);




        public IWebCrawler GetManuallyConfiguredWebCrawler()
        {
            //创建配置文件
            CrawlConfiguration config = new CrawlConfiguration();
            //连接超时
            config.CrawlTimeoutSeconds = 0;
            //下载类容格式
            config.DownloadableContentTypes = "text/html, text/plain";
            //是否爬扩展页面
            config.IsExternalPageCrawlingEnabled = false;
            //是否爬扩展连接
            config.IsExternalPageLinksCrawlingEnabled = false;
            //是否爬的检索到rebots.txt文件，可以要个
            config.IsRespectRobotsDotTextEnabled = true;
            //是否多重复爬Uri,一般为false,但我估计太大，内存受不了，应为内存会存是否爬过的数据
            config.IsUriRecrawlingEnabled = false;
            //请求的最大线程，看IIS的支持，太大服务器受不了
            config.MaxConcurrentThreads = System.Environment.ProcessorCount;
            //最大爬的页码连接，如果为0就没有限制，看需求大小
            config.MaxPagesToCrawl = 1000;
            //单页面最大的爬页面量，如果为0就没有限制，基本都为0
            config.MaxPagesToCrawlPerDomain = 0;
            //每爬一个页面等好多毫秒，太快CUP会受不了
            config.MinCrawlDelayPerDomainMilliSeconds = 1000;


            //创建一个爬虫实例
            var crawler = new PoliteWebCrawler(config, null, null, null, null, null, null, null, null);


            //是否爬该网页
            crawler.ShouldCrawlPage(ShouldCrawlPage);
            //是否爬该网页连接
            crawler.ShouldCrawlPageLinks(ShouldCrawlPageLinks);
            //是否下载该页面
            crawler.ShouldDownloadPageContent(ShouldDownloadPageContent);




            //单个页面爬取开始 
            crawler.PageCrawlStartingAsync += crawler_ProcessPageCrawlStarting;
            //单个页面爬取结束 
            crawler.PageCrawlCompletedAsync += crawler_ProcessPageCrawlCompletedAsync;
            //页面不允许爬取事件
            crawler.PageCrawlDisallowedAsync += crawler_PageCrawlDisallowed;
            //页面链接不允许爬取事件
            crawler.PageLinksCrawlDisallowedAsync += crawler_PageLinksCrawlDisallowed;


            return crawler;
        }

        #region 事件
        /// <summary>
        /// 单个页面爬取开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void crawler_ProcessPageCrawlStarting(object sender, PageCrawlStartingArgs e)
        {
            PageToCrawl pageToCrawl = e.PageToCrawl;
            WriteLog("crawler_ProcessPageCrawlStarting:" + pageToCrawl.Uri.AbsoluteUri);
        }

        /// <summary>
        /// 页面不允许爬取事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void crawler_PageCrawlDisallowed(object sender, PageCrawlDisallowedArgs e)
        {
            PageToCrawl pageToCrawl = e.PageToCrawl;
            WriteLog("crawler_PageCrawlDisallowed:" + pageToCrawl.Uri.AbsoluteUri);
        }

        /// <summary>
        /// 单个页面爬取结束 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void crawler_ProcessPageCrawlCompletedAsync(object sender, PageCrawlCompletedArgs e)
        {


            WriteLog("crawler_ProcessPageCrawlCompletedAsync:" + e.CrawledPage.Uri.AbsoluteUri);
            //判断是否是新闻详细页面
            if (NewsUrlRegex.IsMatch(e.CrawledPage.Uri.AbsoluteUri))
            {
                var htmlDoc = e.CrawledPage.Content.Text;

                var jquery = CsQuery.CQ.CreateDocument(htmlDoc);
                var news = jquery["#news_title"].FirstElement();

                var newsTitle = news.FirstChild.InnerText;

                //var csTitle = e.CrawledPage.CsQueryDocument.Select("#news_title");
                //var linkDom = csTitle.FirstElement().FirstChild;


                //var newsInfo = e.CrawledPage.CsQueryDocument.Select("#news_info");
                //var dateString = newsInfo.Select(".time", newsInfo);  


                //var str = (e.CrawledPage.Uri.AbsoluteUri + "\t" + HtmlData.HtmlDecode(linkDom.InnerText)) + "\r\n";
                var str = (e.CrawledPage.Uri.AbsoluteUri + "\t" + HtmlData.HtmlDecode(newsTitle)) + "\r\n";

                System.IO.File.AppendAllText("fake.txt", str);
                WriteLog(str);
            }
        }



        #endregion
        /// <summary>
        /// 页面链接不允许爬取事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void crawler_PageLinksCrawlDisallowed(object sender, PageLinksCrawlDisallowedArgs e)
        {
            CrawledPage pageToCrawl = e.CrawledPage;
            WriteLog("crawler_PageLinksCrawlDisallowed:" + pageToCrawl.Uri.AbsoluteUri);
        }




     

        /// <summary>
        /// 如果是Feed页面或者分页或者详细页面才需要爬取
        /// </summary>
        private CrawlDecision ShouldCrawlPage(PageToCrawl pageToCrawl, CrawlContext context)
        {


            if (pageToCrawl.IsRoot || pageToCrawl.IsRetry || FeedUrl == pageToCrawl.Uri
                || NewsPageRegex.IsMatch(pageToCrawl.Uri.AbsoluteUri)
                || NewsUrlRegex.IsMatch(pageToCrawl.Uri.AbsoluteUri))
            {
                WriteLog("ShouldCrawlPage true:" + pageToCrawl.Uri.AbsoluteUri);
                return new CrawlDecision { Allow = true };
            }
            else
            {
                WriteLog("ShouldCrawlPage false:" + pageToCrawl.Uri.AbsoluteUri);
                return new CrawlDecision { Allow = false, Reason = "Not match uri" };
            }
        }


        /// <summary>
        /// 如果是Feed页面或者分页或者详细页面才需要爬取
        /// </summary>
        private CrawlDecision ShouldDownloadPageContent(PageToCrawl pageToCrawl, CrawlContext crawlContext)
        {
            if (pageToCrawl.IsRoot || pageToCrawl.IsRetry || FeedUrl == pageToCrawl.Uri
                || NewsPageRegex.IsMatch(pageToCrawl.Uri.AbsoluteUri)
                || NewsUrlRegex.IsMatch(pageToCrawl.Uri.AbsoluteUri))
            {
                WriteLog("ShouldDownloadPageContent true:" + pageToCrawl.Uri.AbsoluteUri);
                return new CrawlDecision
                {
                    Allow = true
                };
            }
            WriteLog("ShouldDownloadPageContent false:" + pageToCrawl.Uri.AbsoluteUri);

            return new CrawlDecision { Allow = false, Reason = "Not match uri" };
        }


        /// <summary>
        /// 是否爬去网页连接
        /// </summary>
        /// <param name="crawledPage"></param>
        /// <param name="crawlContext"></param>
        /// <returns></returns>
        private CrawlDecision ShouldCrawlPageLinks(CrawledPage crawledPage, CrawlContext crawlContext)
        {


            if (!crawledPage.IsInternal)
                return new CrawlDecision { Allow = false, Reason = "We dont crawl links of external pages" };


            if (crawledPage.IsRoot || crawledPage.IsRetry || crawledPage.Uri == FeedUrl
                || NewsPageRegex.IsMatch(crawledPage.Uri.AbsoluteUri))
            {
                WriteLog("ShouldCrawlPageLinks true:" + crawledPage.Uri.AbsoluteUri);


                return new CrawlDecision { Allow = true };
            }
            else
            {
                WriteLog("ShouldCrawlPageLinks false:" + crawledPage.Uri.AbsoluteUri);


                return new CrawlDecision { Allow = false, Reason = "We only crawl links of pagination pages" };
            }
        }

        private static object lockObj = new object();
        public void WriteLog(string log)
        {
            lock (lockObj)
            {
                System.IO.File.AppendAllText("log.txt", log);
                System.IO.File.AppendAllText("log.txt", "\r\n==================\r\n");
            }

            Console.WriteLine(log);
        }
    }
}
