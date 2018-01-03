using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rico.S03.ReferenceType
{
    [TestClass]
    public class EnumTest
    {
        /// <summary>
        /// （方式一）枚举转换为字符串
        /// </summary>
        [TestMethod]
        public void ToString_Return_Enum_StringValue()
        {
            var color = EnumColor.Black;

            var colorString = color.ToString();

            Assert.AreEqual("Black", colorString);
        }
        /// <summary>
        /// （方式二）枚举转换为字符串
        /// </summary>
        [TestMethod]
        public void GetName_Return_Enum_StringValue()
        {
            var color = EnumColor.Black;

            var colorString = color.ToString();

            Assert.AreEqual("Black", colorString);
        }

        /// <summary>
        /// 枚举转为数字
        /// </summary>
        [TestMethod]
        public void ToInt_Return_Enum_IntValue()
        {
            var color = EnumColor.Black;

            var colorInt= (int)color;

            Assert.AreEqual(6, colorInt);
        }

        /// <summary>
        /// 字符串转为枚举
        /// </summary>
        [TestMethod]
        public void EnumString_To_Enum()
        {
            var colorString = "Black";

            var color = (EnumColor)Enum.Parse(typeof(EnumColor), colorString);

            Assert.IsTrue(color==EnumColor.Black);
            Assert.IsTrue(color != EnumColor.Red);
        }
    }

    public enum EnumColor
    {
        Red = 1,
        Yellow,
        Green,
        Blue,
        White,
        Black
    }
}
