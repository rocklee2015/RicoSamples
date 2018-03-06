using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Web;
using System.Web.Caching;

namespace Rico.S10.CacheSample
{
    /// <summary>
    /// 需要引用system.web
    /// </summary>
    [TestClass]
    public class P01_CacheDemo
    {
        public P01_CacheDemo()
        {
            cache1 = new Cache();
        }

        private Cache cache1 { get; }

        [TestMethod]
        public void Cache_New()
        {
            Cache cache = new Cache();
            Assert.IsNotNull(cache);
        }

        [TestMethod]
        public void Cache_Poperty_New()
        {
            
            Assert.IsNotNull(cache1);
        }

        /// <summary>
        /// 绝对 和 滑动过期时间
        /// </summary>
        [TestMethod]
        public void AbsoluteTime_Expire()
        {
            //设置绝对过期时间，却不过期
            var person = new Person { CacheKey = "key_1", Name = "ricolee" };
            Cache cache = new Cache();
            //绝对过期 使用本地时间
            cache.Insert(person.CacheKey, person, null, DateTime.Now.AddSeconds(3), TimeSpan.Zero);

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
                    Assert.IsNull(cachePerson);
                    break;
                }
                else
                {
                    Console.WriteLine($"{DateTime.Now:HH:mm:sss} Name:{cachePerson.Name}");
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));
                if (count++ > 5)
                {
                    Assert.Fail();
                    break;
                }
            }
        }
        private bool _isCallBackSuccess = false;
        [TestMethod]
        public void CacheUpdateCallback_Return_Success()
        {
            Cache cache = HttpRuntime.Cache;
            //文件权重级别
            cache.Insert("ricolee", "缓冲移除通知", null, DateTime.UtcNow.AddSeconds(5), Cache.NoSlidingExpiration, CacheItemPriority.Low, Show);
            cache.Insert("ricolee", "hhe");
            int count = 0;
            while (true)
            {
                if (_isCallBackSuccess)
                {
                    Assert.IsTrue(_isCallBackSuccess);
                    break;
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));
                if (count++ > 5)
                {
                    Assert.Fail();
                    break;
                }
            }
            
        }
        void Show(string key, object value, CacheItemRemovedReason reason)
        {
            Cache cache = HttpRuntime.Cache;
            var nowValue = cache[key];
            Console.WriteLine($"key 为 {key} 的缓存变动，理由：{reason}; 消息：{value},现值：{nowValue}");
            _isCallBackSuccess = true;
        }

    }

    public class Person
    {
        public string CacheKey { get; set; }

        public string Name { get; set; }
    }
}
