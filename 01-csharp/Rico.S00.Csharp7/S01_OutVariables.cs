using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Console;
namespace Rico.S00.Csharp7
{
    [TestClass]
    public class S01_OutVariables
    {
        [TestMethod]
        public void Csharp7_OutVariables()
        {
            //out 变量（out variables）
            //以前我们使用out变量必须在使用前进行声明，C# 7.0 给我们提供了一种更简洁的语法 “使用时进行内联声明” 。如下所示：
            var input = "2017";
            if (int.TryParse(input, out var result))
            {
                WriteLine("您输入的数字是：{0}", result);
            }
            else
            {
                WriteLine("无法解析输入...");
            }
        }

    }
}
