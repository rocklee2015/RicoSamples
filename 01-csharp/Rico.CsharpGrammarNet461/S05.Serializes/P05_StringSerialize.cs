using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.CsharpGrammarNet461.S05.Serializes
{
    [TestClass]
    public class P05_StringSerialize
    {

        [TestMethod]
        [ExpectedException(typeof(Newtonsoft.Json.JsonReaderException))]
        public void String_IdCard_UnSerialize_Throw_Exception()
        {
            string card = "32032419900101123X";
            string serCard = JsonConvert.SerializeObject(card);
            var result = JsonConvert.DeserializeObject(card);
            Console.WriteLine(result);
        }

        [TestMethod]
        public void String_IdCard_Serialize_Success()
        {
            string card = "32032419900101123X";
            string serCard = JsonConvert.SerializeObject(card);
            var result = JsonConvert.DeserializeObject(serCard);
            Console.WriteLine(result);
        }
    }
}
