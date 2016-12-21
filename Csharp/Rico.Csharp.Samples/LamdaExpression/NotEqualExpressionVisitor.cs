using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rico.Csharp.Samples.LamdaExpression
{
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
