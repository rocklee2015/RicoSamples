using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.CsharpGrammarNet461.S04.ReferenceTypes
{
    [TestClass]
    public class P03_ClassInherit
    {
        [TestMethod]
        public void Inherit_Test()
        {
            P02_Father father = new P02_Son() { Name = "儿子", Age = 12, Money = 10 };
           
        }
    }

    public class P02_Father
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    public class P02_Son : P02_Father
    {
        public double Money { get; set; }
    }
}
