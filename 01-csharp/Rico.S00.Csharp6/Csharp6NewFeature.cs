using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.String;
/*
 * 来源：http://www.cnblogs.com/vd630/p/4731956.html
 * 来源：http://www.cnblogs.com/henryzhu/p/new-feature-in-csharp-6.html
 */
namespace Rico.S00.Csharp6
{
    [TestClass]
    public class Csharp6NewFeature
    {
        #region 自动属性初始化 (Initializers for auto-properties)

        public bool IsEnabled { get; set; } = true;

        #endregion

        #region 只读属性的初始化(Getter-only auto-properties)

        //public Csharp6NewFeature(int id, int idNew)
        //{
        //    _id = id;
        //    IdNew = idNew;
        //}

        private readonly int _id;
        public int Id
        {
            get { return _id; }
        }

        /// <summary>
        /// 新写法
        /// </summary>
        public int IdNew { get; }

        #endregion

        #region nameof表达式 (nameof expressions)


        [TestMethod]
        public void NameOf()
        {
            string s;
            Console.WriteLine(nameof(s));//s
            s = nameof(s.Length);
            Console.WriteLine(nameof(String)); //String
            Console.WriteLine(nameof(string.Length));//Length
            Console.WriteLine(nameof(string.Substring));//Substring
        }

        #endregion


        #region Using静态类 (Using static)

        public void UsingStatic()
        {
            Console.WriteLine(Concat("a", "b"));
        }

        #endregion
        #region 空值判断 (Null-conditional operators)

        /// <summary>
        /// 2. [.?]空引用判断操作符
        /// </summary>
        [TestMethod]
        public void Nullable()
        {
            string s = null;
            s = s?.Substring(1);
            // string expr_07 = this.s;
            // this.s = ((expr_07 != null) ? expr_07.Substring(0) : null);
            Console.WriteLine(s == null);
        }

        #endregion



        /// <summary>
        /// 3. 字符串嵌入值
        /// </summary>
        [TestMethod]
        public void StringInterpolation()
        {
            int i = 1;
            Console.WriteLine($"{nameof(i)} + 1 = {i + 1}");
            Console.WriteLine($"{i + 1} * {i + 1} = 4");
        }


        #region 用Lambda作为函数体 (Expression bodies on method-like members)
        private void LambdaMethod() => Console.WriteLine(nameof(LambdaMethod));
        private string LambdaProperty => nameof(LambdaProperty);
        [TestMethod]
        public void ExpressionBodiesOnMethodLikeMembers()
        {
            LambdaMethod();
        }
        #endregion

        #region Lambda表达式用作属性 (Expression bodies on property-like function members)


        private string InitedProperty { get; set; } = "InitedProperty";
        #endregion

        #region 带索引的对象初始化器 (Index initializers)

        public void IndexInitializers()
        {
            //现有写法
            var newWrite = new Dictionary<int, string>
            {
                [1] = "a",
                [5] = "e"
            };

            //原写法
            var oldWrite = new Dictionary<int, string>
            {
                {1, "a"},
                {5, "b"}
            };


        }

        #endregion

        #region 异常筛选器 (Exception filters)

        [TestMethod]
        public void ExceptionFilter()
        {
            try
            {
                throw new IOException("Not Throw");
            }
            catch (IOException ex) when (ex.Message != "Need Throw")
            {
                Console.WriteLine(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        #endregion

        #region catch和finally 中的 await (Await in catch and finally blocks)

        //private async void Test()
        //{
        //    try
        //    {
        //        await new Task<int>(() =>
        //        {
        //            return 1;
        //        });
        //    }
        //    catch
        //    {
        //        await new Task<int>(() =>
        //        {
        //            return 1;
        //        });
        //    }
        //    finally
        //    {
        //        await new Task<int>(() =>
        //        {
        //            return 1;
        //        });
        //    }
        //}

        #endregion

        #region 无参数的结构体构造函数 (Parameterless constructors in structs)

        //public struct Point
        //{
        //    public Point()
        //    {
        //        Console.WriteLine("hello from Constructor");
        //        X = 1;
        //        Y = 1;
        //    }

        //    public int X { get; set; }
        //    public int Y { get; set; }
        //}

        #endregion
    }
}
