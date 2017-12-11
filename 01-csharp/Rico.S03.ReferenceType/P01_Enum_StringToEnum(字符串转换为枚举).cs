using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rico.S03.ReferenceType
{
    [TestClass]
    public class EnumStringToEnum
    {
        /// <summary>
        /// 枚举转换为字符串
        /// </summary>
        [TestMethod]
        public void EnumToString()
        {
            var color = EnumColor.Black;
            //方法一
            Console.WriteLine(color.ToString());

            //方法二
            Console.WriteLine(Enum.GetName(color.GetType(), color));

        }

        /// <summary>
        /// 枚举转为数字
        /// </summary>
        [TestMethod]
        public void EnumToInt()
        {
            var color = EnumColor.Black;
            Console.WriteLine((int)color);
        }

        /// <summary>
        /// 字符串转为枚举
        /// </summary>
        [TestMethod]
        public void StringToEnum()
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
