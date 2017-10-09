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
            //设置绝对过期时间，却不过期
            var person = new Person { CacheKey = "key_1", Name = "ricolee" };
            Cache cache = HttpRuntime.Cache;
            //cache.Insert(person.CacheKey, person, null, DateTime.Now.AddSeconds(10), TimeSpan.Zero);
            cache.Insert(person.CacheKey, person, null, DateTime.UtcNow.AddSeconds(10), Cache.NoSlidingExpiration);
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
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }
    }

    public class Person
    {
        public string CacheKey { get; set; }

        public string Name { get; set; }
    }
}
