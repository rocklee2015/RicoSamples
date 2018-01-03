using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    [TestClass]
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
        public static void Lambda_CreateExpressionByApi()
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
        [TestMethod]
        public void Body_ResolveExpression()
        {
            Expression<Func<int, bool>> funcExpression = num => num == 0;

            //开始解析
            ParameterExpression pExpression = funcExpression.Parameters[0]; //lambda 表达式参数
            BinaryExpression body = (BinaryExpression)funcExpression.Body;  //lambda 表达式主体：num == 0

            Assert.AreEqual("num", pExpression.Name);//变量名
            Assert.AreEqual("num", body.Left.ToString());//左边变量
            Assert.AreEqual(ExpressionType.Equal, body.NodeType);//节点类型
            Assert.AreEqual("0", body.Right.ToString());//右边变量

            Console.WriteLine($"解析：{pExpression.Name} => {body.Left} {body.NodeType} {body.Right}");
        }
        /// <summary>
        /// 4.编译表达式树
        /// </summary>
        [TestMethod]
        public  void Compile_Expression()
        {
            //创建表达式树
            Expression<Func<string, int>> funcExpression = msg => msg.Length;

            //表达式树编译成委托
            var lambda = funcExpression.Compile();

            //调用委托
            var actual1=lambda("Hello, World!");

            Assert.AreEqual(13, actual1);

            //语法简化
            var actual2 = funcExpression.Compile()("Hello, World!");
          
            Assert.AreEqual(13, actual2);
        }
        /// <summary>
        /// 5.执行表达式树
        /// </summary>
        [TestMethod]
        public  void Excute_Expression()
        {
            const int constA = 1;
            const int constB = 2;

            //待执行的表达式树
            BinaryExpression bExpression = Expression.Add(Expression.Constant(constA), Expression.Constant(constB));

            //创建 lambda 表达式
            Expression<Func<int>> funcExpression = Expression.Lambda<Func<int>>(bExpression);

            //编译 lambda 表达式
            Func<int> func = funcExpression.Compile();

            //执行 lambda 表达式
            var result = func();

            Assert.AreEqual(3, result);

            Console.WriteLine($"{constA} + {constB} = {func()}");
        }

     

        #endregion
        #region 进阶  http://www.cnblogs.com/Ninputer/archive/2009/08/28/expression_tree1.html

    
        #endregion
    }
 

}

