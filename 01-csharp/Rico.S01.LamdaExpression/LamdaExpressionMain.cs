using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Rico.S01.LamdaExpression
{
    /// <summary>
    /// 
    /// source:http://www.cnblogs.com/Ninputer/archive/2009/08/28/expression_tree1.html
    /// </summary>
    public class LamdaExpressionMain
    {
        #region 入门  http://www.cnblogs.com/liqingwen/archive/2016/09/18/5868688.html

        /// <summary>
        /// 1.Lambda 表达式创建表达式树
        /// </summary>
        public static void CreateExpressionByLamda()
        {
            Expression<Action<int>> actionExpression = n => Console.WriteLine(n);
            Expression<Func<int, bool>> funcExpression1 = (n) => n < 0;
            Expression<Func<int, int, bool>> funcExpression2 = (n, m) => n - m == 0;
        }
        /// <summary>
        /// 2.API 创建表达式树
        /// </summary>
        public static void CreateExpressionByApi()
        {
            //通过 Expression 类创建表达式树
            //lambda：num => num == 0
            ParameterExpression pExpression = Expression.Parameter(typeof(int));    //参数：num
            ConstantExpression cExpression = Expression.Constant(0);    //常量：0
            BinaryExpression bExpression = Expression.MakeBinary(ExpressionType.Equal, pExpression, cExpression);   //表达式：num == 0
            Expression<Func<int, bool>> lambda = Expression.Lambda<Func<int, bool>>(bExpression, pExpression);  //lambda 表达式：num => num == 0
        }
        /// <summary>
        /// 3.解析表达式树
        /// </summary>
        public static void ResolveExpression()
        {
            Expression<Func<int, bool>> funcExpression = num => num == 0;

            //开始解析
            ParameterExpression pExpression = funcExpression.Parameters[0]; //lambda 表达式参数
            BinaryExpression body = (BinaryExpression)funcExpression.Body;  //lambda 表达式主体：num == 0

            Console.WriteLine($"解析：{pExpression.Name} => {body.Left} {body.NodeType} {body.Right}");
        }
        /// <summary>
        /// 4.编译表达式树
        /// </summary>
        public static void CompileExpression()
        {
            //创建表达式树
            Expression<Func<string, int>> funcExpression = msg => msg.Length;
            //表达式树编译成委托
            var lambda = funcExpression.Compile();
            //调用委托
            Console.WriteLine(lambda("Hello, World!"));

            //语法简化
            Console.WriteLine(funcExpression.Compile()("Hello, World!"));
        }
        /// <summary>
        /// 5.执行表达式树
        /// </summary>
        public static void ExcuteExpression()
        {
            const int n = 1;
            const int m = 2;

            //待执行的表达式树
            BinaryExpression bExpression = Expression.Add(Expression.Constant(n), Expression.Constant(m));
            //创建 lambda 表达式
            Expression<Func<int>> funcExpression = Expression.Lambda<Func<int>>(bExpression);
            //编译 lambda 表达式
            Func<int> func = funcExpression.Compile();

            //执行 lambda 表达式
            Console.WriteLine($"{n} + {m} = {func()}");
        }
        /// <summary>
        /// 6.修改表达式树 
        /// </summary>
        public static void UpdateExpression()
        {
            Expression<Func<int, bool>> funcExpression = num => num == 0;
            Console.WriteLine($"Source: {funcExpression}");

            //ExpressionVisitor 类，通过 Visit 方法间接调用 VisitBinary 方法将 != 替换成 ==。
            var visitor = new NotEqualExpressionVisitor();
            var expression = visitor.Visit(funcExpression);

            Console.WriteLine($"Modify: {expression}");

        }

        #endregion
        #region 进阶  http://www.cnblogs.com/Ninputer/archive/2009/08/28/expression_tree1.html

        /// <summary>
        /// 构建复杂的表达式树
        /// </summary>
        public static void CreateComplexLamdaExpression()
        {
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
            Console.WriteLine(g7);

            var g7Result = Expression.Lambda<Func<string, int, bool>>(g7, expAString, expBInt).Compile();
            Console.WriteLine("G7：" + g7Result("sadf", 2));

            //new System.Windows.Point() { X = Math.Sin(a), Y = Math.Cos(a) }
            var g8 = Expression.MemberInit(
                Expression.New(typeof(Point)), new MemberBinding[]{
                Expression.Bind(typeof(Point).GetProperty("X"),Expression.Call(null, typeof(Math).GetMethod("Sin", BindingFlags.Public | BindingFlags.Static), expADouble)),
                Expression.Bind(typeof(Point).GetProperty("Y"), Expression.Convert(Expression.Call(null, typeof(Math).GetMethod("Cos", BindingFlags.Public | BindingFlags.Static), expADouble),typeof(int)))
                 });

            Console.WriteLine(g8.ToString());
        }
        /// <summary>
        /// 分析表达式树逻辑
        /// </summary>
        public static void AnalyzeLamdaExpression()
        {
            Expression<Func<double, double, double, double, double>> myExp =
             (a, b, m, n) => m * a * a + n * b * b;

            var calc = new BinaryExpressionCalculator(myExp);
            Console.WriteLine(calc.Calculate(1, Math.Sin(30), 3, 4));
            Console.ReadKey();

        }
        #endregion
    }
    public class Point
    {
        public double X { get; set; }
        public int Y { get; set; }
    }

}

