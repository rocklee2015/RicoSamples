using System;
using System.Threading;
using System.Web;
using System.Web.Caching;

namespace Rico.S10.CacheSample
{
    class Program
    {
        static void Main(string[] args)
        {
            CacheUpdateCallback();
            Console.ReadKey();
        }

        /// <summary>
        /// 绝对 和 滑动过期时间
        /// </summary>
        static void AbsoluteAndSlidingExiprationCache()
        {
            //设置绝对过期时间，却不过期
            var person = new Person { CacheKey = "key_1", Name = "ricolee" };
            Cache cache = HttpRuntime.Cache;
            //绝对过期 使用本地时间
            cache.Insert(person.CacheKey, person, null, DateTime.Now.AddSeconds(10), TimeSpan.Zero);

            //绝对过期 UTC时间，Cache.NoSlidingExpiration和TimeSpan.Zero 一样表示不使用平滑过期策略
            //cache.Insert(person.CacheKey, person, null, DateTime.UtcNow.AddSeconds(10), Cache.NoSlidingExpiration);
            //cache.Insert(person.CacheKey, person, null, DateTime.UtcNow.AddSeconds(10), TimeSpan.Zero); 

            //滑动过期 UTC时间
            //cache.Insert(person.CacheKey, person, null, Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(5));
            int count = 0;
            while (true)
            {
                var cacheobj = cache[person.CacheKey];
                var cachePerson = cacheobj as Person;
                if (cachePerson == null)
                {
                    Console.WriteLine("缓存过期");
                }
                else
                {
                    Console.WriteLine($"{DateTime.Now:HH:mm:sss} Name:{cachePerson.Name}");
                }
                if (count++ > 20)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(6));
                    count = 0;
                }
                else
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
            }
        }

        static void CacheUpdateCallback()
        {
            Cache cache = HttpRuntime.Cache;
            //文件权重级别
            cache.Add("ricolee", "缓冲移除通知", null, DateTime.UtcNow.AddSeconds(5), Cache.NoSlidingExpiration, CacheItemPriority.Low, Show);
        }
        static void Show(string key, object value, CacheItemRemovedReason reason)
        {
            Cache cache = HttpRuntime.Cache;
            var nowValue = cache[key];
            Console.WriteLine($"key 为 {key} 的缓存变动，理由：{reason}; 消息：{value},现值：{nowValue}");

        }

    }

    public class Person
    {
        public string CacheKey { get; set; }

        public string Name { get; set; }
    }
}
