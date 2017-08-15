using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Console;
namespace Rico.S00.Csharp7
{
    [TestClass]
    public class Csharp7NewFeature
    {
        #region out 变量（out variables）
        [TestMethod]
        public void OutVariables()
        {
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

        #endregion

    }
}
