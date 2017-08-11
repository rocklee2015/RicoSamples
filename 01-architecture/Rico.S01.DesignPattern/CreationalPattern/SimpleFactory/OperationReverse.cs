namespace Rico.S01.DesignPattern.CreationalPattern.SimpleFactory
{

    /// <summary>
    /// 相反数类
    /// </summary>
    class OperationReverse : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            result = -NumberB;
            return result;
        }
    }
}
