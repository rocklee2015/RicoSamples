using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.CsharpGrammarNet461.S10.IOs
{
    /// <summary>
    /// MemoryStream 是一个特例，MemoryStream中没有任何非托管资源，所以它的Dispose不调用也没关系。托管资源.Net会自动回收
    /// </summary>
    [TestClass]
    public class P05_MemoryStream
    {
        [TestInitialize]
        public void TestInitialize()
        {
            MemoryStream ms = new MemoryStream();
            byte[] bytes = Encoding.UTF8.GetBytes("MemoryStream Content");

            ms.Write(bytes, 0, bytes.Length);   //已将一段文本写入内存
        }

        [TestMethod]
        public void MemoryStream_Property()
        {
            //属性测试
            MemoryStream ms = new MemoryStream();
            Console.WriteLine(ms.CanRead);      //True  内存流可读
            Console.WriteLine(ms.CanSeek);      //True  内存流支持查找，指针移来移去的查找
            Console.WriteLine(ms.CanTimeout);   //False 内存流不支持超时
            Console.WriteLine(ms.CanWrite);     //True  内存流可写
            Console.WriteLine(ms.Capacity);     //0     分配给该流的字节数

            byte[] bytes = Encoding.UTF8.GetBytes("MemoryStream Content");

            ms.Write(bytes, 0, bytes.Length);   //已将一段文本写入内存

            Console.WriteLine("分配字节：" + ms.Capacity);     //256   再次读取为文本流分配的字节数已经变成了256，看来内存流是根据需要的多少来分配的
            Console.WriteLine("长度：" + ms.Length);       //9    这个是流长度，通常与英文的字符数一样，真正占用的字节数。

            Console.WriteLine("位置：" + ms.Position);     //9    流当前的位置，该属性可读可设置
        }
        [TestMethod]
        public void MemoryStream_GetBuffer()
        {
            MemoryStream ms = new MemoryStream();
            WriteContent(ms);
            byte[] byte1 = ms.GetBuffer();          //返回无符号字节数组 差点被忽悠了，无符号字节数组 其实就是byte(0~255),有符号字节sbyte(-128~127)
            string str1 = Encoding.UTF8.GetString(byte1);
            Console.WriteLine(str1);    //输出    abcdedcba
        }
        [TestMethod]
        public void MemoryStream_Seek()
        {
            MemoryStream ms = new MemoryStream();
            WriteContent(ms);
            //Seek
            ms.Seek(2, SeekOrigin.Current);    //设置当前流正在读取的位置 为开始位置即从0开始
            //从内存中读取一个字节
            int i = ms.ReadByte();
            Console.WriteLine(i);                   //输出99
            byte[] bytes3 = ms.ToArray();
            foreach (byte b in bytes3)
            {
                Console.Write(b + "-");//用于对比   输出 97-98-99-100-101-100-99-98-97-   可以看到    0,1,2第二位刚好是99
            }
        }
        [TestMethod]
        public void MemoryStream_Position()
        {
            MemoryStream ms2 = new MemoryStream();
            byte[] bytes6 = Encoding.UTF8.GetBytes("abcde");
            ms2.Write(bytes6, 0, bytes6.Length);
            Console.WriteLine(ms2.Position);    //输出5 写完之后流的位置就到了最后，因此想用read读取必须加下面这一行代码。 

            //ms2.Seek(0, SeekOrigin.Begin);    //想要用Read方法读取完整的流，必须设置当前位置,Read是从Position的位置开始读。
            ms2.Position = 0;                   //Read是从当前位置开始读，这行代码和上面一行意义一样。
            byte[] byteArray = new byte[5] { 110, 110, 110, 110, 110 }; //99是经过YTF8解码之后是 n
            ms2.Read(byteArray, 2, 1);   //读取一个字节，byteArray的第一个元素中，(注意从0开始)
            Console.WriteLine(Encoding.UTF8.GetString(byteArray)); //nnann

        }
        private void WriteContent(MemoryStream ms)
        {
            if (ms != null)
            {
                byte[] bytes = Encoding.UTF8.GetBytes("MemoryStream Content");

                ms.Write(bytes, 0, bytes.Length);   //已将一段文本写入内存
            }
        }
    }
}
