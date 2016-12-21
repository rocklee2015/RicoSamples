using System;

namespace Rico.Csharp.DesignPattern.CreationalPattern.SimpleFactory
{
    /// <summary>
    /// 运算类
    /// </summary>
    public class Operation
    {
        private double _numberA = 0;
        private double _numberB = 0;

        /// <summary>
        /// 数字A
        /// </summary>
        public double NumberA
        {
            get
            {
                return _numberA;
            }
            set
            {
                _numberA = value;
            }
        }

        /// <summary>
        /// 数字B
        /// </summary>
        public double NumberB
        {
            get
            {
                return _numberB;
            }
            set
            {
                _numberB = value;
            }
        }

        /// <summary>
        /// 得到运算结果
        /// </summary>
        /// <returns></returns>
        public virtual double GetResult()
        {
            double result = 0;
            return result;
        }

        /// <summary>
        /// 检查输入的字符串是否准确
        /// </summary>
        /// <param name="currentNumber"></param>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string checkNumberInput(string currentNumber, string inputString)
        {
            string result = "";
            if (inputString == ".")
            {
                if (currentNumber.IndexOf(".") < 0)
                {
                    if (currentNumber.Length == 0)
                        result = "0" + inputString;
                    else
                        result = currentNumber + inputString;
                }
            }
            else if (currentNumber == "0")
            {
                result = inputString;
            }
            else
            {
                result = currentNumber + inputString;
            }

            return result;
        }


    }

}
