using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Rico.CsharpGrammarNet461.S05.Serializes
{
    [TestClass]
    public class P04_XmlSerialize
    {
        [TestMethod]
        public void Xml_Serialize_Test()
        {
            Woman w1 = new Woman() { Id = 1, Name = "貂蝉" };
            Woman w2 = new Woman() { Id = 2, Name = "西施" };

            List<Woman> ListWoman = new List<Woman>();
            ListWoman.Add(w1);
            ListWoman.Add(w2);
            XmlPerson p = new XmlPerson();
            p.Id = 1;
            p.Name = "刘备";
            p.ListWoman = ListWoman;

            string str = ObjectToXmlSerializer(p);
            Console.WriteLine(str);

            XmlPerson p1 = ObjectToXmlDESerializer<XmlPerson>(str);
            Console.WriteLine("我的名字是：" + p1.Name + "我的老婆有：");
            foreach (Woman w in p1.ListWoman)
            {
                Console.WriteLine(w.Name);
            }
        }
        //序列化Xml
        public static string ObjectToXmlSerializer(Object Obj)
        {
            string XmlString = "";
            XmlWriterSettings settings = new XmlWriterSettings();
            //去除xml声明
            //settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            settings.Encoding = Encoding.Default;
            using (MemoryStream mem = new MemoryStream())
            {
                using (XmlWriter writer = XmlWriter.Create(mem, settings))
                {
                    //去除默认命名空间xmlns:xsd和xmlns:xsi
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    XmlSerializer formatter = new XmlSerializer(Obj.GetType());
                    formatter.Serialize(writer, Obj, ns);
                }
                XmlString = Encoding.Default.GetString(mem.ToArray());
            }
            return XmlString;
        }

        //反序列化
        public static T ObjectToXmlDESerializer<T>(string str) where T : class
        {
            object obj;
            using (System.IO.MemoryStream mem = new System.IO.MemoryStream(Encoding.Default.GetBytes(str)))
            {
                using (XmlReader reader = XmlReader.Create(mem))
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(T));
                    obj = formatter.Deserialize(reader);
                }
            }
            return obj as T;
        }
      
    }

    public class XmlPerson : IXmlSerializable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Woman> ListWoman { get; set; }


        #region IXmlSerializable 成员

        System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
        {
            throw new NotImplementedException();
        }

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            //一定要特别注意配对问题，否则很容易反序列化集合出现只能够读取第一个的情况
            reader.ReadStartElement("XmlPerson");
            Id = Convert.ToInt32(reader.ReadElementString("Id"));
            Name = reader.ReadElementString("Name");
            //我也不知道为什么，复杂类型只能够另外定义一个，获得值之后再给原来的赋值
            List<Woman> ListWoman2 = new List<Woman>();
            reader.ReadStartElement("ListWoman");
            while (reader.IsStartElement("Woman"))
            {
                Woman w = new Woman();
                reader.ReadStartElement("Woman");
                w.Id = Convert.ToInt32(reader.ReadElementString("Id"));
                w.Name = reader.ReadElementString("Name");
                reader.ReadEndElement();
                reader.MoveToContent();
                ListWoman2.Add(w);
            }
            ListWoman = ListWoman2;
            reader.ReadEndElement();
            reader.ReadEndElement();
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            //这里是不需要WriteStart/End Person的
            writer.WriteElementString("Id", Id.ToString());
            writer.WriteElementString("Name", Name);
            //有重载，想设置命名空间，只需在参数加上
            writer.WriteStartElement("ListWoman");
            foreach (Woman item in ListWoman)
            {
                PropertyInfo[] ProArr = item.GetType().GetProperties();
                writer.WriteStartElement("Woman");
                foreach (PropertyInfo p in ProArr)
                {
                    writer.WriteElementString(p.Name, p.GetValue(item, null).ToString());
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        #endregion
    }

    public class Woman
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
