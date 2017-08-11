using System;

namespace Rico.S01.DesignPattern.CreationalPattern.SimpleFactory
{
    /// <summary>
    /// 除法类
    /// </summary>
    class OperationDiv : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            if (NumberB == 0)
                throw new Exception("除数不能为0。");
            result = NumberA / NumberB;
            return result;
        }
    }
}
