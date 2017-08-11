namespace Rico.S01.DesignPattern.CreationalPattern.SimpleFactory
{
    /// <summary>
    /// 乘法类
    /// </summary>
    class OperationMul : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            result = NumberA * NumberB;
            return result;
        }
    }
}
