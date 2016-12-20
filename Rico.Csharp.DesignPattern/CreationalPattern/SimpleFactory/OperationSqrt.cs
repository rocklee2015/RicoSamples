using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.Csharp.DesignPattern.CreationalPattern.SimpleFactory
{
    /// <summary>
    /// 平方根类
    /// </summary>
    class OperationSqrt : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            if (NumberB < 0)
                throw new Exception("负数不能开平方根。");
            result = Math.Sqrt(NumberB);
            return result;
        }
    }
}
