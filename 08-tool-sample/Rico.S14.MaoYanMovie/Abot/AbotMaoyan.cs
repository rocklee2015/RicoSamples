using Abot.Crawler;
using Abot.Poco;
using CsQuery.HtmlParser;
using Newtonsoft.Json;
using Rico.S14.MaoYanMovie.WdMovie;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Rico.S14.MaoYanMovie
{
    public class AbotMaoyan
    {
        private Queue MovieQueues = new Queue();

        /// <summary>
        /// 猫眼主页
        /// </summary>
        public Uri FeedUri = new Uri(@"http://maoyan.com/films?ci=50");


        private bool IsStart { get; set; }


        private static List<MaoyanMovieScore> MovieScores = new List<MaoyanMovieScore>();

        /// <summary>
        /// 猫眼主页分页的正则表达式，showType(1正在热映,2 即将上映),前两页。ci=50匹配的杭州地区
        /// </summary>
        public Regex MoviePageRegex = new Regex("^http://maoyan.com/films\\?showType=[1|2][&ci=50]*[&offset=0|&offset=30]*$", RegexOptions.Compiled);

        /// <summary>
        /// 猫眼电影详细
        /// </summary>
        public Regex MovieDetailRegex = new Regex("^http://maoyan.com/films/\\d+$", RegexOptions.Compiled);



        public AbotMaoyan()
        {
            ThreadPool.SetMaxThreads(10, 3);
        }

        public void StartDownMovie()
        {
            var thread = new Thread(StartDownMovieThread);
            thread.Start();
        }
        private void StartDownMovieThread()
        {
            IsStart = true;
            while (IsStart || MovieQueues.Count > 0)
            {
                if (MovieQueues.Count > 0)
                {
                    var movie = (MaoyanMovie)MovieQueues.Dequeue();
                    //匹配评分
                    var movieScore = MovieScores.FirstOrDefault(a => a.MoiveName == movie.MovieName);
                    if (movieScore != null)
                    {
                        movie.MovieScore = movieScore.Score;
                    }

                    //同步到数据库
                    var result = CinemaManager.AddFilm(movie);
                    if (result == false)
                    {
                        Console.WriteLine($"【{movie.MovieName}】 失败！");
                    }
                    else
                    {
                        Console.WriteLine($"【{movie.MovieName}】 完成！");
                    }
                }
                else
                {
                    Console.WriteLine($"休息10秒");
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                }
            }
            Console.WriteLine($"退出循环！");
        }
        public void EndDownMovie()
        {
            IsStart = false;
        }



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
        }

        /// <summary>
        /// 页面不允许爬取事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void crawler_PageCrawlDisallowed(object sender, PageCrawlDisallowedArgs e)
        {
            PageToCrawl pageToCrawl = e.PageToCrawl;
        }


        /// <summary>
        /// 页面链接不允许爬取事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void crawler_PageLinksCrawlDisallowed(object sender, PageLinksCrawlDisallowedArgs e)
        {
            CrawledPage pageToCrawl = e.CrawledPage;
        }

        /// <summary>
        /// 单个页面爬取结束 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void crawler_ProcessPageCrawlCompletedAsync(object sender, PageCrawlCompletedArgs e)
        {
            var uri = e.CrawledPage.Uri.AbsoluteUri;

            ThreadPool.QueueUserWorkItem(new WaitCallback(CrawlCompleted), new CrawlParam { Url = uri, Text = e.CrawledPage.Content.Text });


        }

        private void CrawlCompleted(object state)
        {
            var param = state as CrawlParam;
            var uri = param.Url;
            var text = param.Text;

            //抓取影片详细的数据
            if (MovieDetailRegex.IsMatch(uri))
            {
                var htmlText = text;
                var movie = MaoyanManager.FindMovieInfoFromHtml(htmlText);
                if (movie == null)
                    return;
                movie.Url = uri;

                MovieQueues.Enqueue(movie);
            }

            //抓取主页中影片的评分
            if (MoviePageRegex.IsMatch(uri)
                || FeedUri.AbsoluteUri == uri)
            {
                var htmlText = text;
                var movieScores = MaoyanManager.FindMovieScoreFormHtml(htmlText);
                if (movieScores.Count <= 0)
                    return;
                foreach (var item in movieScores)
                {
                    if (MovieScores.Count(a => a.MoiveName == item.MoiveName) <= 0)
                    {
                        MovieScores.Add(item);
                    }
                    else
                    {
                        var movieScore = MovieScores.FirstOrDefault(a => a.MoiveName == item.MoiveName);
                        if (movieScore != null)
                            MovieScores.Remove(movieScore);
                        MovieScores.Add(item);
                    }
                }
            }
        }
        public string GetQueryString(string name, string url)
        {
            Regex re = new Regex(@"(^|&)?(\w+)=([^&]+)(&|$)?", System.Text.RegularExpressions.RegexOptions.Compiled);
            MatchCollection mc = re.Matches(url);
            foreach (Match m in mc)
            {
                if (m.Result("$2").Equals(name))
                {
                    return m.Result("$3");
                }
            }
            return "";
        }



        #endregion



        /// <summary>
        /// 如果是Feed页面或者分页或者详细页面才需要爬取
        /// </summary>
        private CrawlDecision ShouldCrawlPage(PageToCrawl pageToCrawl, CrawlContext context)
        {
            var uri = pageToCrawl.Uri.AbsoluteUri;
            if (pageToCrawl.IsRoot
                || pageToCrawl.IsRetry
                || FeedUri == pageToCrawl.Uri
                || MoviePageRegex.IsMatch(uri)
                || MovieDetailRegex.IsMatch(uri))
            {
                if (MoviePageRegex.IsMatch(uri) || FeedUri == pageToCrawl.Uri)
                {
                    Console.WriteLine(uri);
                }
                return new CrawlDecision { Allow = true };
            }
            return new CrawlDecision { Allow = false, Reason = "Not match uri" };
        }


        /// <summary>
        /// 如果是Feed页面或者分页或者详细页面才需要爬取
        /// </summary>
        private CrawlDecision ShouldDownloadPageContent(PageToCrawl pageToCrawl, CrawlContext crawlContext)
        {
            if (pageToCrawl.IsRoot
                || pageToCrawl.IsRetry
                || FeedUri == pageToCrawl.Uri
                || MoviePageRegex.IsMatch(pageToCrawl.Uri.AbsoluteUri)
                || MovieDetailRegex.IsMatch(pageToCrawl.Uri.AbsoluteUri))
            {

                return new CrawlDecision { Allow = true };
            }

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


            if (crawledPage.IsRoot
                || crawledPage.IsRetry
                || crawledPage.Uri == FeedUri
                || MoviePageRegex.IsMatch(crawledPage.Uri.AbsoluteUri))
            {
                return new CrawlDecision { Allow = true };
            }
            return new CrawlDecision { Allow = false, Reason = "We only crawl links of pagination pages" };
        }



    }
    public class CrawlParam
    {
        public string Url { get; set; }

        public string Text { get; set; }
    }
}
