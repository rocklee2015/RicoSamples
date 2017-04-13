using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Rico.Csharp.Samples
{
    public class SerializeMain
    {
        /// <summary>
        /// 序列化Dictionnary为对象数组
        /// 目的：为BootstrapTable 动态生成列所用，将行结果转换为列结果
        /// </summary>
        public static void SerializeDictionnary()
        {
            //效果：[{name:'Jerry',age:12},{name:'Tom',age:13}]
            var source = new SerializeSource();
            source.Total = 10;

            var random = new Random();
            var row1 = new Dictionary<string, string>();
            for (int i = 1; i < 20; i++)
            {
                row1.Add("西湖" + i, random.Next(1, 100).ToString());
            }
            var row2 = new Dictionary<string, string>();
            for (int i = 1; i < 20; i++)
            {
                row2.Add("西湖" + i, random.Next(1, 100).ToString());
            }

            source.Rows.Add(row1);
            source.Rows.Add(row2);
            JsonSerializer serializer = new JsonSerializer();
            var result = JsonConvert.SerializeObject(source);

        }
    }

    public class SerializeSource
    {
        public SerializeSource()
        {
            Rows = new List<Dictionary<string, string>>();
        }

        public decimal Total { get; set; }
        public List<Dictionary<string, string>> Rows { get; set; }
    }
}
