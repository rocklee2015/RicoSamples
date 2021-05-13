using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S00.Csharp7
{
    public class S05_LocalFunction
    {
        static IEnumerable<char> GetCharList(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                throw new ArgumentNullException(nameof(str));

            return GetList();
            /*
              原理解析：局部函数虽然是在其他函数内部声明，但它编译后就是一个被 internal 修饰的静态函数，它是属于类，
            至于它为什么能够使用上级函数中的局部变量和参数呢？
            那是因为编译器会根据其使用的成员生成一个新类型（Class/Struct）然后将其传入函数中。由上可知则局部函数的声

 明跟位置无关，并可无限嵌套。

             */
            IEnumerable<char> GetList()
            {
                for (int i = 0; i < str.Length; i++)
                {
                    yield return str[i];
                }
            }
        }
    }
}
