using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Rico.Csharp.Samples.CurrentDirectory
{
    [TestClass]
    public class CurrentDirectoryMain
    {
        [TestMethod]
        public void return_a_path()
        {
            var path = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            write("获取模块的完整路径:");
            write(path);

            path = System.Environment.CurrentDirectory;
            write("获取和设置当前目录(该进程从中启动的目录)的完全限定目录:");
            write(path);

            path = System.IO.Directory.GetCurrentDirectory();
            write("获取应用程序的当前工作目录:");
            write(path);

            path = System.AppDomain.CurrentDomain.BaseDirectory;
            write("获取程序的基目录:");
            write(path);

            path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            write("获取和设置包括该应用程序的目录的名称:");
            write(path);

            path = System.IO.Directory.GetParent("../../").FullName;
            write("上一级目录:");
            write(path);

            path = new DirectoryInfo("../../").FullName;
            write("上一级目录:");
            write(path);

            path = System.IO.Directory.GetCurrentDirectory();
            write("当前目录:");
            write(path);

            path = Path.ChangeExtension("File", "html");
            write("File的存放路径:");
            write(path);
            Assert.IsTrue(true);
        }

        private void write(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
