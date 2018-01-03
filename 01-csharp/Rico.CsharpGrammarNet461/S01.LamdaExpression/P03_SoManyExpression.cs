using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rico.CsharpGrammarNet461.S01.LamdaExpression
{
    /// <summary>
    /// http://www.cnblogs.com/Ninputer/archive/2009/08/28/expression_tree1.html
    /// </summary>
    [TestClass]
    public class P03_SoManyExpression
    {
        [TestMethod]
        public void Create_Many_Expression()
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
            Assert.AreEqual("-a", g1.ToString());

            //a + b * 2
            var g2 = Expression.Add(expAInt, Expression.Multiply(expBInt, Expression.Constant(2)));
            Assert.AreEqual("(a + (b * 2))", g2.ToString());
            var g2result = Expression.Lambda<Func<int, int, int>>(g2, expAInt, expBInt).Compile();
            Assert.AreEqual(7, g2result(3, 2));

            //Math.Sin(x) + Math.Cos(y)
            var g3 = Expression.Add(Expression.Call(null, typeof(Math).GetMethod("Sin", BindingFlags.Public | BindingFlags.Static), expADouble),
                                    Expression.Call(null, typeof(Math).GetMethod("Cos", BindingFlags.Public | BindingFlags.Static), expBDouble));
            Assert.AreEqual("(Sin(a) + Cos(b))", g3.ToString());

            //new StringBuilder(“Hello”)
            var g4 = Expression.New(typeof(StringBuilder).GetConstructor(new Type[] { typeof(string) }), Expression.Constant("Hello"));
            Assert.AreEqual("new StringBuilder(\"Hello\")", g4.ToString());

            //new int[] { a, b, a + b}
            var g5 = Expression.NewArrayInit(typeof(int), expAInt, expBInt, Expression.Add(expAInt, expBInt));
            Assert.AreEqual("new [] {a, b, (a + b)}", g5.ToString());

            //a[i – 1] * i
            var g6 = Expression.Multiply(Expression.ArrayAccess(expAArray, Expression.Subtract(expIInt, Expression.Constant(1))), expIInt);
            Assert.AreEqual("(a[(i - 1)] * i)", g6.ToString());

            //a.Length > b | b >= 0            
            var g7 = Expression.Or(Expression.GreaterThan(Expression.Property(expAString, "Length"), expBInt), Expression.GreaterThanOrEqual(expBInt, Expression.Constant(0)));
            Assert.AreEqual("((a.Length > b) Or (b >= 0))", g7.ToString());

            var g7Result = Expression.Lambda<Func<string, int, bool>>(g7, expAString, expBInt).Compile();
            Assert.AreEqual(true, g7Result("rico", 2));

            //new System.Windows.Point() { X = Math.Sin(a), Y = Math.Cos(a) }
            var g8 = Expression.MemberInit(
                Expression.New(typeof(Point)), new MemberBinding[]{
                Expression.Bind(typeof(Point).GetProperty("X"),Expression.Call(null, typeof(Math).GetMethod("Sin", BindingFlags.Public | BindingFlags.Static), expADouble)),
                Expression.Bind(typeof(Point).GetProperty("Y"), Expression.Convert(Expression.Call(null, typeof(Math).GetMethod("Cos", BindingFlags.Public | BindingFlags.Static), expADouble),typeof(int)))
                 });

            Assert.AreEqual("new Point() {X = Sin(a), Y = Convert(Cos(a))}", g8.ToString());
        }
    }
    public class Point
    {
        public double X { get; set; }
        public int Y { get; set; }
    }
}
