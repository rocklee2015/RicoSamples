using System;
using System.Globalization;

namespace Rico.Csharp.DesignPattern.CreationalPattern.SimpleFactory
{
    public class SimpleFactoryPattern
    {
        /// <summary>
        /// 简单工厂实现计算器
        /// </summary>
        public static void Calculator()
        {
            try
            {
                Console.Write("请输入数字A：");
                string strNumberA = Console.ReadLine();
                Console.Write("请选择运算符号(+、-、*、/)：");
                string strOperate = Console.ReadLine();
                Console.Write("请输入数字B：");
                string strNumberB = Console.ReadLine();
                string strResult = "";

                Operation oper;
                oper = OperationFactory.createOperate(strOperate);
                oper.NumberA = Convert.ToDouble(strNumberA);
                oper.NumberB = Convert.ToDouble(strNumberB);
                strResult = oper.GetResult().ToString(CultureInfo.InvariantCulture);

                Console.WriteLine("结果是：" + strResult);

            }
            catch (Exception ex)
            {
                Console.WriteLine("您的输入有错：" + ex.Message);
            }
        }
    }
}
