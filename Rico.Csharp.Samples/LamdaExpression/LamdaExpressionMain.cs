using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Rico.Csharp.Samples.LamdaExpression
{
    public class LamdaExpressionMain
    {
        public static void LamdaExpression_Create()
        {
            //1 要创建表达式树只能使用Expression类提供的静态方法
            //2 用Expression的节点组合 或者 直接从C#、VB的Lambda表达式生成。不管使用的是那种方法，最后我们得到的是一个内存中树状结构的数据
            ParameterExpression expADouble = Expression.Parameter(typeof(double), "a");
            ParameterExpression expBDouble = Expression.Parameter(typeof(double), "b");


            ParameterExpression expAInt = Expression.Parameter(typeof(int), "a");
            ParameterExpression expBInt = Expression.Parameter(typeof(int), "b");


            ParameterExpression expAArray = Expression.Parameter(typeof(int[]), "a");
            ParameterExpression expIInt = Expression.Parameter(typeof(int), "i");

            ParameterExpression expAString = Expression.Parameter(typeof(string), "a");

            //-a            
            var g1 = Expression.Negate(expADouble);
            Console.WriteLine(g1.ToString());

            //a + b * 2
            var g2 = Expression.Add(expAInt, Expression.Multiply(expBInt, Expression.Constant(2)));
            Console.Write(g2.ToString());
            var g2result = Expression.Lambda<Func<int, int, int>>(g2, expAInt, expBInt).Compile();
            Console.WriteLine("=" + g2result(3, 2));
            //Math.Sin(x) + Math.Cos(y)
            var g3 = Expression.Add(Expression.Call(null, typeof(Math).GetMethod("Sin", BindingFlags.Public | BindingFlags.Static), expADouble),
                                    Expression.Call(null, typeof(Math).GetMethod("Cos", BindingFlags.Public | BindingFlags.Static), expBDouble));
            Console.WriteLine(g3.ToString());

            //new StringBuilder(“Hello”)
            var g4 = Expression.New(typeof(StringBuilder).GetConstructor(new Type[] { typeof(string) }), Expression.Constant("Hello"));
            Console.WriteLine(g4.ToString());

            //new int[] { a, b, a + b}
            var g5 = Expression.NewArrayInit(typeof(int), expAInt, expBInt, Expression.Add(expAInt, expBInt));
            Console.WriteLine(g5);

            //a[i – 1] * i
            var g6 = Expression.Multiply(Expression.ArrayAccess(expAArray, Expression.Subtract(expIInt, Expression.Constant(1))), expIInt);
            Console.WriteLine(g6);

            //a.Length > b | b >= 0            
            var g7 = Expression.Or(Expression.GreaterThan(Expression.Property(expAString, "Length"), expBInt), Expression.GreaterThanOrEqual(expBInt, Expression.Constant(0)));

            var g7result = Expression.Lambda<Func<string, int, bool>>(g7, expAString, expBInt).Compile();
            Console.WriteLine("G7：" + g7result("sadf", 2));

            //new System.Windows.Point() { X = Math.Sin(a), Y = Math.Cos(a) }

            var g8 = Expression.MemberInit(
                Expression.New(typeof(Point)), new MemberBinding[]{
                Expression.Bind(typeof(Point).GetProperty("X"),Expression.Call(null, typeof(Math).GetMethod("Sin", BindingFlags.Public | BindingFlags.Static), expADouble)),
                Expression.Bind(typeof(Point).GetProperty("Y"), Expression.Convert(Expression.Call(null, typeof(Math).GetMethod("Cos", BindingFlags.Public | BindingFlags.Static), expADouble),typeof(int)))
                 });

            Console.WriteLine(g8.ToString());
        }
        /// <summary>
        /// 表达式树分析
        /// </summary>
        public void LamdaExpression_Analyze()
        {
            //3 Expression Tree的基本功能：1)分析表达式的逻辑
            Expression<Func<double, double, double, double, double>> myExp =
             (a, b, m, n) => m * a * a + n * b * b;

            var calc = new BinaryExpressionCalculator(myExp);
            Console.WriteLine(calc.Calculate(1, Math.Sin(30), 3, 4));
            Console.ReadKey();
            //3 Expression Tree的基本功能：2)保存和传输表达式 【表达式序列化是大问题】

            //1. 生成表达式的程序与解析表达式的程序不在同一进程内（例如在客户端生成表达式，在服务端解析）。
            //2. 需要储存或缓存表达式，为以后多次使用做准备。
            //3. 需要用其他非.NET技术处理或生成表达式树。

            //3 Expression Tree的基本功能：3)以及重新编译表达式
        }
    }
    public class Point
    {
        public double X { get; set; }
        public int Y { get; set; }
    }
    public class BinaryExpressionCalculator
    {
        Dictionary<ParameterExpression, double> m_argDict;
        LambdaExpression m_exp;


        public BinaryExpressionCalculator(LambdaExpression exp)
        {
            m_exp = exp;
        }

        public double Calculate(params double[] args)
        {
            //从ExpressionExpression中提取参数，和传输的实参对应起来。
            //生成的字典可以方便我们在后面查询参数的值
            m_argDict = new Dictionary<ParameterExpression, double>();

            for (int i = 0; i < m_exp.Parameters.Count; i++)
            {
                //就不检查数目和类型了，大家理解哈
                m_argDict[m_exp.Parameters[i]] = args[i];
            }

            //提取树根
            Expression rootExp = m_exp.Body as Expression;

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
                return m_argDict[pexp];
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

