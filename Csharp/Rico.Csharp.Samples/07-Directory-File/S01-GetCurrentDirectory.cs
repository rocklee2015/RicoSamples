using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rico.Csharp.Samples
{
    [TestClass]
    public class CurrentDirectoryMain
    {
        [TestMethod]
        public void return_a_path()
        {
            var path = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            write("��ȡģ�������·��:");
            write(path);

            path = System.Environment.CurrentDirectory;
            write("��ȡ�����õ�ǰĿ¼(�ý��̴���������Ŀ¼)����ȫ�޶�Ŀ¼:");
            write(path);

            path = System.IO.Directory.GetCurrentDirectory();
            write("��ȡӦ�ó���ĵ�ǰ����Ŀ¼:");
            write(path);

            path = System.AppDomain.CurrentDomain.BaseDirectory;
            write("��ȡ����Ļ�Ŀ¼:");
            write(path);

            path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            write("��ȡ�����ð�����Ӧ�ó����Ŀ¼������:");
            write(path);

            path = System.IO.Directory.GetParent("../../").FullName;
            write("��һ��Ŀ¼:");
            write(path);

            path = new DirectoryInfo("../../").FullName;
            write("��һ��Ŀ¼:");
            write(path);

            path = System.IO.Directory.GetCurrentDirectory();
            write("��ǰĿ¼:");
            write(path);

            path = Path.ChangeExtension("File", "html");
            write("File�Ĵ��·��:");
            write(path);
            Assert.IsTrue(true);
        }

        private void write(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
