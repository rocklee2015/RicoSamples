using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Baitu.Consoles.SocialInsurance
{
    [TestClass]
    public class EnumTest
    {
        /// <summary>
        /// 将字符串转换为枚举
        /// source:http://www.cnblogs.com/pato/archive/2011/08/15/2139705.html
        /// </summary>
        [TestMethod]
        public void Convert_String_To_Enum()
        {
            var a = (Platform)Enum.Parse(typeof (Platform), "Alipay");
            Assert.IsTrue(a==Platform.Alipay);
        }
        [TestMethod]
        public void Convert_Enum_To_String()
        {
            Assert.IsTrue(Platform.Alipay.ToString()== "Alipay");
            Assert.IsTrue(((int)Platform.Alipay).ToString() == "0");
        }
    }

    public enum Platform
    {
        [System.ComponentModel.Description("支付宝")]
        Alipay=0,
        [System.ComponentModel.Description("微信")]
        Webchat
    }
}
