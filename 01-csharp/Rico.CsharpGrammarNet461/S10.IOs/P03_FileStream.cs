using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.CsharpGrammarNet461.S10.IOs
{
    [TestClass]
    public class P03_FileStream : BaseTest
    {
        [TestCleanup]
        public void TestCleanUp()
        {
            File.Delete(path);
        }

        [TestInitialize]
        public void TestInitialize()
        {

        }

        private string path => $"{BaseDirectory}file.txt";
        [TestMethod]
        public void FileStream_Property()
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                Console.WriteLine(fs.CanRead);  //该属性值指示文件是否可读  True
                Console.WriteLine(fs.CanSeek);  //该属性值指示文件是否支持查找    True
                Console.WriteLine(fs.CanTimeout);    //该属性值指示文件是否支持超时   False
                Console.WriteLine(fs.CanWrite); //该属性值指示文件是否可写  True
                Console.WriteLine(fs.IsAsync);  //该属性值指示文件是否是异步打开,异步打开则返回true，同步打开则返回false False
                Console.WriteLine(fs.Length);   //获取用字节流表示的长度   16    与硬盘中显示的大小一样。
                Console.WriteLine(fs.Name);     //获取传递给构造函数的文件名称  E:\file.txt
                Console.WriteLine(fs.Position); //获取和设置此流的当前位置，注意此方法是可赋值设置的。    0   fs.Position = 100;
                                                //Console.WriteLine(fs.ReadTimeout);  //获取和设置一个值，该值指示尝试读取多长时间后超时，可以赋值超时，如果流上不支持超时(即fs.CanTimeout为false)则引发异常。
                                                //Console.WriteLine(fs.WriteTimeout); //获取和设置一个值，尝试写入多长时间后算超时。如果不支持超时(即fs.CanTimeout为false)则引发异常。
            }

        }

        [TestMethod]
        public void FileStream_Write()
        {
            //写入流
            FileStream fs = new FileStream(path, FileMode.Create);   //打开一个写入流
            string str = "Write Test!";
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            fs.Write(bytes, 0, bytes.Length);
            fs.Flush();     //流会缓冲，此行代码指示流不要缓冲数据，立即写入到文件。
            fs.Close();     //关闭流并释放所有资源，同时将缓冲区的没有写入的数据，写入然后再关闭。
            fs.Dispose();   //释放流所占用的资源，Dispose()会调用Close(),Close()会调用Flush();    也会写入缓冲区内的数据。

            var result = ReadFileString();

            Assert.AreEqual("Write Test!", result);
        }
        [TestMethod]
        public void FileStream_Append()
        {
            CreateFile("old string ");

            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))//追加流，权限设置为可写
            {
                byte[] bytes = Encoding.UTF8.GetBytes("Append Test!");
                fs.Write(bytes, 0, bytes.Length);
            }
            var result = ReadFileString();

            Console.WriteLine(result);

            Assert.AreEqual("old string Append Test!", result);
        }
        [TestMethod]
        public void FileStream_WriteByte()
        {
            using (FileStream fs = new FileStream(path, FileMode.CreateNew, FileAccess.Write))
            {
                byte[] bytes = Encoding.UTF8.GetBytes("WriteByte Test!");
                foreach (byte b in bytes)
                {
                    fs.WriteByte(b);        //逐个字节逐个字节追加入文本
                }
            }
            var result = ReadFileString();

            Assert.AreEqual("WriteByte Test!", result);
        }
        [TestMethod]
        public void FileStream_Read()
        {
            CreateFile("hello word!");

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                byte[] bytes = new byte[fs.Length];

                fs.Read(bytes, 0, (int)fs.Length);

                var result = Encoding.UTF8.GetString(bytes);

                Assert.AreEqual("hello word!", result);
            }

        }

        [TestMethod]
        public void FileStream_ReadByte()
        {
            CreateFile("hello word!");

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                //逐个字符读取
                byte[] bytes = new byte[fs.Length];
                for (int i = 0; i < fs.Length; i++)
                {
                    bytes[i] = (byte)fs.ReadByte();     //逐个字节逐个字节的读取，当读取完之后会自动将当前读取位置移动到下一位
                }
                var result = Encoding.UTF8.GetString(bytes);

                Console.WriteLine(result);

                Assert.AreEqual("hello word!", result);
            }
        }
        private void CreateFile(string content)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(content);
                fs.Write(bytes, 0, bytes.Length);
            }

        }
        private string ReadFileString()
        {
            using (FileStream fs1 = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                //读取内容
                byte[] bytes = new byte[fs1.Length];
                fs1.Read(bytes, 0, (int)fs1.Length);
                return Encoding.UTF8.GetString(bytes);  //将读取到的值获取成字符串输出
            }

        }
        public void TestFile()
        {
            //未明白的东西
            //fs.Handle
            //fs.SafeFileHandle
            //CreateObjRef 
            //GetAccessControl
            //GetLifetimeService
            //InitializeLifetimeService
            //SetAccessControl
            //Synchronized
        }
    }
}
