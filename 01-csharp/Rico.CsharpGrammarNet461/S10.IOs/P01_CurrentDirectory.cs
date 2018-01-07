using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rico.S09.IOSample
{
    [TestClass]
    public class CurrentDirectory
    {
        [TestMethod]
        public void Get_Current_Directory()
        {
            var path = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            write("获取模块的完整路径:");
            write(path);
            //C:\PROGRAM FILES (X86)\MICROSOFT VISUAL STUDIO\2017\ENTERPRISE\COMMON7\IDE\COMMONEXTENSIONS\MICROSOFT\TESTWINDOW\vstest.executionengine.x86.exe

            path = System.Environment.CurrentDirectory;
            write("获取和设置当前目录(该进程从中启动的目录)的完全限定目录:");
            write(path);
            //D:\00-github\00-Rocklee2015-old\RicoSamples\01-csharp\Rico.S09.IOSample\bin\Debug

            path = System.IO.Directory.GetCurrentDirectory();
            write("获取应用程序的当前工作目录:");
            write(path);
            //D:\00-github\00-Rocklee2015-old\RicoSamples\01-csharp\Rico.S09.IOSample\bin\Debug

            path = System.AppDomain.CurrentDomain.BaseDirectory;
            write("获取程序的基目录:");
            write(path);
            //D:\00-github\00-Rocklee2015-old\RicoSamples\01-csharp\Rico.S09.IOSample\bin\Debug

            path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            write("获取和设置包括该应用程序的目录的名称:");
            write(path);
            //D:\00-github\00-Rocklee2015-old\RicoSamples\01-csharp\Rico.S09.IOSample\bin\Debug

            path = System.IO.Directory.GetParent("../../").FullName;
            write("上一级目录:");
            write(path);
            //D:\00-github\00-Rocklee2015-old\RicoSamples\01-csharp\Rico.S09.IOSample

            path = new DirectoryInfo("../../").FullName;
            write("上一级目录:");
            write(path);
            //D:\00-github\00-Rocklee2015-old\RicoSamples\01-csharp\Rico.S09.IOSample\

            path = System.IO.Directory.GetCurrentDirectory();
            write("当前目录:");
            write(path);
            //D:\00-github\00-Rocklee2015-old\RicoSamples\01-csharp\Rico.S09.IOSample\bin\Debug

            path = Path.ChangeExtension("File", "html");
            write("File的存放路径:");
            write(path);
            //File.html

            Assert.IsTrue(true);
        }

        private void write(string msg)
        {
            Console.WriteLine(msg);
            Console.WriteLine();
        }
    }
}
