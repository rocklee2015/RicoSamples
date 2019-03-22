using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Rico.S02.ConsoleSample
{
    public class S01_Configuration
    {
        public static IConfigurationRoot Configuration { get; set; }
        public static void Excute()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            //1.使用Key读取
            var appid = Configuration["AppId"]; // 结果 12345
            var includeScope = Configuration["Logging:IncludeScopes"]; // 结果 false
            var logLevel = Configuration["Logging:LogLevel:Default"]; // 结果 Debug
            var GrantType = Configuration["GrantTypes:0:Name"]; // 结果 authorization_code

            //2.使用GetValue<T>
            //需要安装：Microsoft.Extensions.Configuration.Binder
            var appid2 = Configuration.GetValue<int>("AppId", 12345); // 结果 12345
            var includeScope2 = Configuration.GetValue<bool>("Logging:IncludeScopes", false); // 结果 false
            var logLevel2 = Configuration.GetValue<string>("Logging:LogLevel:Default", "Debug"); // 结果 Debug
            var GrantType2 = Configuration.GetValue<string>("GrantTypes:0:Name", "authorize_code"); // 结果 authorization_code

            //3.Options
            //需要安装：Microsoft.Extensions.Options.ConfigurationExtensions

            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddYamlFile("appsettings.yml")
               .AddYamlFile("array.yml");


            Configuration = builder.Build();

            //Microsoft.Extensions.DependencyInjection
            var services = new ServiceCollection();

            //Microsoft.Extensions.Options
            services.AddOptions();

            services.Configure<MyOptions>(Configuration);
            services.Configure<LoggingOptions>(Configuration.GetSection("Logging"));
            services.Configure<LogLevelOptions>(Configuration.GetSection("Logging:LogLevel"));


            Console.WriteLine(Configuration["AppId"]);//输出 12345
            Console.WriteLine(Configuration["Logging:IncludeScopes"]); //输出 false
            Console.WriteLine(Configuration["Logging:LogLevel:Default"]); //输出 Debug
            Console.WriteLine(Configuration["Logging:LogLevel:System"]); //输出 Information
            Console.WriteLine(Configuration["Logging:LogLevel:Microsoft"]); //输出 Information
            Console.WriteLine(Configuration["GrantTypes:0"]); //输出 authorization
            Console.WriteLine(Configuration["GrantTypes:1"]); //输出 password
            Console.WriteLine(Configuration["GrantTypes:2"]); //输出 client_credentials

            Console.WriteLine(Configuration["0"]);//输出 A
            Console.WriteLine(Configuration["1"]);//输出 B
            Console.WriteLine(Configuration["2"]);//输出 C
            Console.WriteLine(Configuration["3"]);//输出 D


            var serviceProvider = services.BuildServiceProvider();

            var myOptionsAccessor = serviceProvider.GetService<IOptions<MyOptions>>();
            var myOptioins = myOptionsAccessor.Value;

            var loggingOptionsAccessor = serviceProvider.GetService<IOptions<LoggingOptions>>();
            var loggingOptions = loggingOptionsAccessor.Value;

            var logLevelOptionsAccessor = serviceProvider.GetService<IOptions<LogLevelOptions>>();
            var logLevelOptions = logLevelOptionsAccessor.Value;
        }
    }
    public class MyOptions
    {
        public int AppId { get; set; }

        public LoggingOptions Logging { get; set; }

        public List<GrantType> GrantTypes { get; set; }

        public class GrantType
        {
            public string Name { get; set; }
        }
    }

    public class LoggingOptions
    {
        public bool IncludeScopes { get; set; }

        public LogLevelOptions LogLevel { get; set; }
    }

    public class LogLevelOptions
    {
        public string Default { get; set; }

        public string System { get; set; }

        public string Microsoft { get; set; }
    }
}
