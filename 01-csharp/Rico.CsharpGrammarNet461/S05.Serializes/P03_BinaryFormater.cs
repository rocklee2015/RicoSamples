using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Rico.CsharpGrammarNet461.S05.Serializes
{
    [TestClass]
    public class P03_BinaryFormater
    {
        [TestMethod]
        public void BinaryFormater_Serialize_Object()
        {
            ArrayList favourites = new ArrayList();
            favourites.Add("看电视");
            favourites.Add("看电影");

            Person person = new Person() { Height = "180 cm", Birsthday = "2017-01-01" };
            person.SetWeight(60.8);

            var path = AppDomain.CurrentDomain.BaseDirectory + "\\person.dat";
            Console.WriteLine(path);
            person.Seiralize(path);

            var desPerson = person.Deserialize(path);

            Assert.IsNotNull(desPerson);
            Assert.AreEqual("180 cm", desPerson.Height);
            Console.WriteLine(desPerson.ToString());

            File.Delete(path);
        }
    }

    [Serializable]
    public class Person
    {
        private string _Name = "张三";

        private ArrayList _Favourittes = new ArrayList();

        private double _Weight;



        public string Height { get; set; }

        public string Birsthday { get; set; }

        public double Weight { get; set; }

        public void SetWeight(double weight)
        {
            Weight = weight;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Name:"+_Name);
            builder.AppendLine("Height:" + Height);
            return builder.ToString();
        }

        public void Seiralize(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fs, this);
            }
        }

        public Person Deserialize(string fileName)
        {
            Person person;
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                person = (Person)binaryFormatter.Deserialize(fs);
            }
            return person;
        }
    }
}
