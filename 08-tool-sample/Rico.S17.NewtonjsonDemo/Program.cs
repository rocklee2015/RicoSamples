using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Rico.S17.NewtonjsonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> Content = new Dictionary<string, string>();
            Content.Add("bulletinContent", "this is bulletinContent");
            Content.Add("topToDay", "this is topToDay");

            //Dictionary转json
            string Contentjson = JsonConvert.SerializeObject(Content);
            Console.WriteLine(Contentjson);
            //json转Dictionary
            Dictionary<string, string> DicContent = (Dictionary<string, string>) JsonConvert.DeserializeObject(Contentjson.ToString());
            Console.WriteLine("Hello World!");
        }
    }
}
