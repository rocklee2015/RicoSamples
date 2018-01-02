using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rico.CsharpGrammarNet461.S01.LamdaExpression
{
    [TestClass]
    public class P02_UpdateExpression
    {
        /// <summary>
        /// 6修改表达式树 
        /// </summary>
        [TestMethod]
        public void Expression_Update()
        {
            Expression<Func<int, bool>> oldExpression = num => num == 0;
            Console.WriteLine($"Source: {oldExpression}");

            //ExpressionVisitor 类，通过 Visit 方法间接调用 VisitBinary 方法将 != 替换成 ==。
            var visitor = new NotEqualExpressionVisitor();

            var newExpression = visitor.Visit(oldExpression);

            int param = 0;

            //原表达式结果
            var result = oldExpression.Compile()(param);

            Assert.IsTrue(result);

            //todo: 修改后的如何调用
            //var result1 = Expression.Invoke(newExpression, Expression.Constant(param));
           

            //result = newExpression;

            Assert.AreEqual("num => (num != 0)", newExpression.ToString());

            Console.WriteLine($"Modify: {newExpression}");

        }
    }
    /// <summary>
    /// 不等表达式树访问器
    /// </summary>
    public class NotEqualExpressionVisitor : ExpressionVisitor
    {
        public Expression Visit(BinaryExpression node)
        {
            return VisitBinary(node);
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            return node.NodeType == ExpressionType.Equal
                ? Expression.MakeBinary(ExpressionType.NotEqual, node.Left, node.Right) //重新弄个表达式：用 != 代替 ==
                : base.VisitBinary(node);
        }
    }
}
