using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.CsharpGrammarNet461.S10.IOs
{
    class P02_File
    {
        public void File_Method_Property()
        {
            File.AppendText(@"E:\file1.txt");   //创建file1.txt文本并写入内容，如果文件不存在则创建。固定是UTF-8编码，不可改变。
            File.AppendAllText(@"E:\file.txt", "你在他乡还好吗？");  //在E盘创建了一个file.txt文件，并在里面写入了 你在他乡还好吗？
            File.Copy(@"E:\file.txt", @"F:\file.txt", false);
            File.Create(@"F:\kk.txt");      //在F盘创建文件，重载中可以设置安全权限等信息。
            Console.Write(File.Exists(@"E:\file.txt"));   //文件存在则True否则False
            Console.Write(File.GetCreationTime(@"E:\file.txt"));    //输出2013/1/13 23:03:02
            Console.Write(File.GetCreationTimeUtc(@"E:\file.txt"));    //输出2013/1/13 15:03:02   全球标准时间
            Console.Write(File.GetLastAccessTime(@"E:\file.txt"));      //2013/1/13 23:03:!2    上次访问时间  
            Console.Write(File.GetLastAccessTimeUtc(@"E:\file.txt"));   //2013/1/13 15:03:12    上次访问时间 全球标准时间
            Console.Write(File.GetLastWriteTime(@"E:\file.txt"));       //2013/1/13 12:53:10    上次写入时间
            Console.Write(File.GetLastWriteTimeUtc(@"E:\file.txt"));    //2013/1/13 15:53:10    上次写入时间 全球标准时间
            File.Move(@"E:\file.txt", @"F:\file.txt");         //将E盘的file.txt移动到了F盘
            byte[] byteArr = File.ReadAllBytes(@"E:\file.txt");
            foreach (byte b in byteArr)
            {
                Console.Write(b);       //输出内容的每个字节，一串数字
            }

            string[] strArr1 = File.ReadAllLines(@"E:\file.txt", Encoding.GetEncoding("gb2312"));    //对于中文，应该设置读取的变啊为gb2312或utf8，否则中文都是问号
            foreach (var str in strArr1)
            {
                Console.WriteLine(str);     //一行就是一个字符串，所有行组成的字符串数组
            }
            Console.Write(File.ReadAllText(@"E:\file.txt", Encoding.GetEncoding("gb2312"))); //有中文要注意加上编码，否则依然是乱码。

            File.SetCreationTime(@"E:\file.txt", DateTime.Now.AddDays(-1));
            Console.Write(File.GetCreationTime(@"E:\file.txt"));    //输出 2013/1/14 23:30:02
            File.SetCreationTime(@"E:\file.txt", DateTime.Now.AddDays(-1)); //国际标准时间
            Console.Write(File.GetCreationTimeUtc(@"E:\file.txt"));     //输出 2013/1/14 15:30:36
            File.SetLastAccessTime(@"E:\file.txt", DateTime.Now.AddDays(-1));
            Console.Write(File.GetLastAccessTime(@"E:\file.txt"));    //输出 2013/1/14 23:32:46
            File.SetLastAccessTimeUtc(@"E:\file.txt", DateTime.Now.AddDays(-1)); //国际标准时间
            Console.Write(File.GetLastAccessTimeUtc(@"E:\file.txt"));     //输出 2013/1/14 15:32:56

            File.SetLastWriteTime(@"E:\file.txt", DateTime.Now.AddDays(-1));
            Console.Write(File.GetLastWriteTime(@"E:\file.txt"));    //输出 2013/1/14 23:33:42
            File.SetLastWriteTimeUtc(@"E:\file.txt", DateTime.Now.AddDays(-1)); //国际标准时间
            Console.Write(File.GetLastWriteTimeUtc(@"E:\file.txt"));     //输出 2013/1/14 15:33:56
            File.WriteAllText(@"E:\file.txt", "真的爱你");   //提示 访问被拒绝，先改掉只读属性吧。然后文件里面的文本变成了"真的爱你"，注意会替换原有内容
            string[] strArr2 = { "你", "好", "吗", "?" };
            File.WriteAllLines(@"E:\file.txt", strArr2);  //此方法同样会替换原有文本，参数为字符串数组，一个字符串一行
            FileAttributes f = File.GetAttributes(@"E:\file.txt");    //获取到的是一个标志枚举的实例
            if ((f & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)   //此处实现了判断文件是否只读，其它信息要通过位运算得到
            {
                Console.Write("此文件是只读的");
            }
            else
            {
                Console.Write("此文件不是只读的");
            }
            //设置文件属性，用标志枚举设置
            File.SetAttributes(@"E:\file.txt", FileAttributes.ReadOnly);   //将此文件设置为只读之后真的修改不了了，手动也修改不了。   
            File.SetAttributes(@"E:\file.txt", FileAttributes.Hidden | FileAttributes.ReadOnly);  //位运算，同时设置隐藏与只读

            string str2 = "你在他乡还好吗？";
            byte[] bytes = Encoding.UTF8.GetBytes(str2);
            File.WriteAllBytes(@"E:\file.txt", bytes);   //没有文件会自动创建此段代码已经运行，E:\file.txt文件的内容就变成了  你在他乡还好吗？


            //Open  已重载。 打开指定路径上的 FileStream。  方便了点，帮助new了FileStream而已，跟自己new FileStream一样
            FileStream fs1 = File.Open(@"E:\file.txt", FileMode.Open, FileAccess.Read);
            byte[] bytes1 = new byte[fs1.Length];
            fs1.Read(bytes, 0, (int)fs1.Length);
            Console.WriteLine(Encoding.UTF8.GetString(bytes1));  //输出E:\file.txt里的文件内容。

            FileStream fs2 = File.OpenRead(@"E:\file.txt");
            byte[] bytes2 = new byte[fs2.Length];
            fs2.Read(bytes, 0, (int)fs2.Length);
            Console.WriteLine(Encoding.UTF8.GetString(bytes2));    //输出E：file.txt里的文件内容

            FileStream fs3 = File.OpenWrite(@"E:\file.txt");     //此方法是内容是写在原有内容的前面。
            byte[] bytes3 = Encoding.UTF8.GetBytes("真的爱你");
            fs3.Write(bytes3, 0, bytes.Length);
            fs3.Flush();

            StreamWriter sw = File.CreateText(@"E:\kk.txt");
            sw.Write("测试CreateText方法");         //在E盘下生成一个kk.txt文件，其实File.CreateText内部还是new了个StreamWriter，方便点而已。
            sw.Flush();

            StreamReader sr = File.OpenText(@"E:\kk.txt");
            string str3 = sr.ReadToEnd();
            Console.WriteLine(str3);     //输出E:\kk.txt   的内容

            //以下未了解的方法，有时间要研究下
            //File.Encrypt(@"E:\file.txt");
            //File.Decrypt(@"E:file.txt");
            //File.GetAccessControl();

            //SetAccessControl  对指定的文件应用由 FileSecurity 对象描述的访问控制列表 (ACL) 项。  
            //  创建一个新文件，在其中写入指定的字节数组，然后关闭该文件。如果目标文件已存在，则改写该文件。   
            //File.Replace(@"E:\file.txt", @"E:\file.txt", @"F:\123.txt");

        }
    }
}
