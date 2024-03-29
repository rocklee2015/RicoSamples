﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Rico.S01.LamdaExpression
{
    [TestClass]
    public class AnalyzeLamdaExpression
    {
        /// <summary>
        /// 分析表达式树逻辑
        /// </summary>
        [TestMethod]
        public void AnalyzeLamdaExpression_Return_Success()
        {
            Expression<Func<double, double, double, double, double>> myExp =
             (a, b, m, n) => m * a * a + n * b * b;

            var calc = new BinaryExpressionCalculator(myExp);
            //Console.WriteLine(calc.Calculate(1, 3, 3, 4));
            //Console.WriteLine(calc.Calculate(1, Math.Sin(30), 3, 4));
            Assert.Fail();

        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class BinaryExpressionCalculator
    {
        Dictionary<ParameterExpression, double> _mArgDict;
        LambdaExpression _mExp;

        public BinaryExpressionCalculator(LambdaExpression exp)
        {
            _mExp = exp;
        }

        public double Calculate(params double[] args)
        {
            //从ExpressionExpression中提取参数，和传输的实参对应起来。
            //生成的字典可以方便我们在后面查询参数的值
            _mArgDict = new Dictionary<ParameterExpression, double>();

            for (int i = 0; i < _mExp.Parameters.Count; i++)
            {
                //就不检查数目和类型了，大家理解哈
                _mArgDict[_mExp.Parameters[i]] = args[i];
            }

            //提取树根
            Expression rootExp = _mExp.Body as Expression;

            //计算！
            return InternalCalc(rootExp);
        }

        double InternalCalc(Expression exp)
        {
            ConstantExpression cexp = exp as ConstantExpression;
            if (cexp != null) return (double)cexp.Value;

            ParameterExpression pexp = exp as ParameterExpression;
            if (pexp != null)
            {
                return _mArgDict[pexp];
            }
            #region 支持方法
            var methodExpression = exp as MethodCallExpression;
            if (methodExpression != null)
            {
                object instance = null;
                //实例方法调用
                if (methodExpression.Object != null)
                {
                    var newExpression = methodExpression.Object as NewExpression;
                    var objects = new object[newExpression.Arguments.Count];
                    for (var i = 0; i < newExpression.Arguments.Count; i++)
                    {
                        objects[i] = InternalCalc(newExpression.Arguments[i]);
                    }
                    instance = newExpression.Constructor.Invoke(objects);

                }
                //如果Instance为Null，表明是静态方法调用，如果不为null，表明是实例方法调用
                return (double)methodExpression.Method.Invoke(instance, new object[] { InternalCalc(methodExpression.Arguments[0]) });

            }
            #endregion
            BinaryExpression bexp = exp as BinaryExpression;
            if (bexp == null) throw new ArgumentException("不支持表达式的类型", "exp");

            switch (bexp.NodeType)
            {
                case ExpressionType.Add:
                    return InternalCalc(bexp.Left) + InternalCalc(bexp.Right);
                case ExpressionType.Divide:
                    return InternalCalc(bexp.Left) / InternalCalc(bexp.Right);
                case ExpressionType.Multiply:
                    return InternalCalc(bexp.Left) * InternalCalc(bexp.Right);
                case ExpressionType.Subtract:
                    return InternalCalc(bexp.Left) - InternalCalc(bexp.Right);
                default:
                    throw new ArgumentException("不支持表达式的类型", "exp");
            }
        }
    }
}
