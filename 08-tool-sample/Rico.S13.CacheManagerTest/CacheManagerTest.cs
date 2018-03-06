using System;
using CacheManager.Core;
using CacheManager.Core.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rico.S13.CacheManagerTest
{
    [TestClass]
    public class CacheManagerTest
    {
        [TestMethod]
        public void Build_AddPutUpdate()
        {
            var cache = CacheFactory.Build("getStartedCache", settings =>
             {
                 settings.WithSystemRuntimeCacheHandle("handleName");
             });
            cache.Add("keyA", "valueA");
            cache.Put("keyB", 23);
            cache.Update("keyB", v => 42);

            Console.WriteLine("KeyA is " + cache.Get("keyA"));      // should be valueA
            Console.WriteLine("KeyB is " + cache.Get("keyB"));      // should be 42

            cache.Remove("keyA");

            Console.WriteLine("KeyA removed? " + (cache.Get("keyA") == null).ToString());
            Console.WriteLine("We are done...");
        }

        [TestMethod]
        public void Redis_分级缓存()
        {
            var cache = CacheFactory.Build<int>("myCache", settings =>
            {
                settings
                    .WithSystemRuntimeCacheHandle("inProcessCache")//内存缓存Handle
                    .EnableStatistics()
                    .EnablePerformanceCounters()
               
                    .And
                    .WithRedisConfiguration("redis", config =>//Redis缓存配置
                        {
                          config.WithAllowAdmin()
                                .WithDatabase(0)
                                .WithEndpoint("localhost", 6379);
                        })
                    .WithMaxRetries(1000)//尝试次数
                    .WithRetryTimeout(100)//尝试超时时间
                    .WithRedisBackplane("redis")//redis使用Back Plate
                    .WithRedisCacheHandle("redis", true);//redis缓存handle
            });
            cache.Add("keyA",20);
            cache.Add("keyB", 21);
            cache.Add("keyC", 22);
            cache.Put("keyD", 23);
            cache.Update("keyB", v => 42); //更新

            Console.WriteLine("KeyA is " + cache.Get("keyA"));      // should be valueA
            Console.WriteLine("KeyB is " + cache.Get("keyB"));
            for (var i = 0;  i < 50; i++)
            {
                cache.Get("keyA");
            }


            foreach (var handle in cache.CacheHandles)
            {
                var stats = handle.Stats;
                Console.WriteLine(string.Format(
                        "Items: {0}, Hits: {1}, Miss: {2}, Remove: {3}, ClearRegion: {4}, Clear: {5}, Adds: {6}, Puts: {7}, Gets: {8}",
                            stats.GetStatistic(CacheStatsCounterType.Items),
                            stats.GetStatistic(CacheStatsCounterType.Hits),
                            stats.GetStatistic(CacheStatsCounterType.Misses),
                            stats.GetStatistic(CacheStatsCounterType.RemoveCalls),
                            stats.GetStatistic(CacheStatsCounterType.ClearRegionCalls),
                            stats.GetStatistic(CacheStatsCounterType.ClearCalls),
                            stats.GetStatistic(CacheStatsCounterType.AddCalls),
                            stats.GetStatistic(CacheStatsCounterType.PutCalls),
                            stats.GetStatistic(CacheStatsCounterType.GetCalls)
                        ));
            }
        }
        public void Redis_2()
        {
            var cache = CacheFactory.Build<int>("myCache", settings =>
            {
                settings.WithUpdateMode(CacheUpdateMode.Up)
                        .WithSystemRuntimeCacheHandle("")
                        .WithExpiration(ExpirationMode.Sliding, TimeSpan.FromSeconds(60))
                        .And
                        .WithRedisConfiguration("redis", config =>
                        {
                            config.WithAllowAdmin()
                                  .WithDatabase(0)
                                  .WithEndpoint("localhost", 6379);
                        })
                         .WithMaxRetries(1000)//尝试次数
                         .WithRetryTimeout(100)//尝试超时时间
                         .WithRedisBackplane("redis")//redis使用Back Plate
                         .WithRedisCacheHandle("redis", true);//redis缓存handle
            });

        }
    }
}
