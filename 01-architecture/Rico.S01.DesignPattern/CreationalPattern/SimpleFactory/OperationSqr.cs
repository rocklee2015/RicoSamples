namespace Rico.S01.DesignPattern.CreationalPattern.SimpleFactory
{

    /// <summary>
    /// 平方类
    /// </summary>
    class OperationSqr : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            result = NumberB * NumberB;
            return result;
        }
    }
}
