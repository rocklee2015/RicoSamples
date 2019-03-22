using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Rico.S02.ConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            S01_Configuration.Excute();
            //var task = Baidu();
            //task.Wait();
            Console.ReadKey();
        }
        public static async Task<string> Baidu()
        {
            Console.WriteLine("Starting connections");
            for (int i = 0; i < 2; i++)
            {
                using (var client = new HttpClient())
                {
                    var result = await client.GetAsync("http://www.baidu.com");
                    Console.WriteLine(result.StatusCode);
                    var body = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                }
            }
            Console.WriteLine("Connections done");
            return await Task.FromResult("result");
        }
    }
}
