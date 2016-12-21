using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.Csharp.DesignPattern.CreationalPattern.SimpleFactory
{
    /// <summary>
    /// 运算类工厂
    /// </summary>
    public class OperationFactory
    {
        public static Operation createOperate(string operate)
        {
            Operation oper = null;
            switch (operate)
            {
                case "+":
                    {
                        oper = new OperationAdd();
                        break;
                    }
                case "-":
                    {
                        oper = new OperationSub();
                        break;
                    }
                case "*":
                    {
                        oper = new OperationMul();
                        break;
                    }
                case "/":
                    {
                        oper = new OperationDiv();
                        break;
                    }
                case "sqr":
                    {
                        oper = new OperationSqr();
                        break;
                    }
                case "sqrt":
                    {
                        oper = new OperationSqrt();
                        break;
                    }
                case "+/-":
                    {
                        oper = new OperationReverse();
                        break;
                    }
            }

            return oper;
        }
    }
}
