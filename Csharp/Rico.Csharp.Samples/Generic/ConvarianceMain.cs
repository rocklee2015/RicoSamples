using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.Csharp.Samples.Generic
{
    /// <summary>
    /// http://www.cnblogs.com/zhaopei/p/variability.html
    /// </summary>
    class ConvarianceMain
    {
        /// <summary>
        /// 自带Func 协变
        /// </summary>
        public static void Convariance()
        {
            //string->object （子类到父类的转换）
            Func<string> func1 = () => "协变";
            Func<object> func2 = func1;
        }
        /// <summary>
        /// 自带Action 逆变
        /// </summary>
        public static void Contravariance()
        {
            //object->string （父类到子类的转换）
            Action<object> func3 = t => { };
            Action<string> func4 = func3;
        }
        #region 自定义 Convariance  协变
        private delegate T MyNoOutFun<T>();
        /// <summary>
        /// 自定的泛型委托，子类转换为父类是会出错
        /// </summary>
        public static void ConvarianceError()
        {
            MyNoOutFun<string> func1 = () => "协变";
            //无法将类型 MyNoOutFun<string> 转换为 MyNoOutFun<object>
            //MyNoOutFun<object> func2 = func1;
        }
        /// <summary>
        /// out 关键字指定该类型参数是协变的
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private delegate T MyOutFun<out T>();
        public static void ConvarianceRight()
        {
            MyOutFun<string> func1 = () => "协变";
            MyOutFun<object> func2 = func1;
        }
        #endregion 
        #region 自定义 Contravariance 逆变
        public static void ContravarianceError()
        {
            MyOutFun<object> func1 = () => "逆变";
            //无法将类型  MyNoOutFun<object> 转换为  MyNoOutFun<string> 缺少一个显示转换
            //MyOutFun<string> func2 = func1;
        }
        private delegate void MyInFun<in T>(T obj);
        public static void ContravarianceRight()
        {
            MyInFun<object> func1 = t => { };
            //无法将类型  MyNoOutFun<object> 转换为  MyNoOutFun<string> 缺少一个显示转换
            MyInFun<string> func2 = func1;
        }
        #endregion
        #region 自定义 协变和逆变混合类型
        delegate Tout MyMixFunc<in Tin, out Tout>(Tin obj);
        /// <summary>
        /// 
        /// </summary>
        public static void MixDelegate()
        {
            //in->输入参数->可逆变（父类到子类的转变[如 object->string]）
            //out->返回值->可协变（子类到父类的转变[如 string->object]）
            //如果一个泛型参数是协变的就一定不是逆变的；如果是逆变的就一定不是协变的；泛型参数可以既不是协变的也不是逆变的（也就是不可变的)
            //协变的泛型参数只能作为方法的返回值的类型，逆变的泛型参数只能作为方法的参数的类型

            //所谓的逆变其实只是编译后进行了强制类型转换而已。
            MyMixFunc<object, string> str1 = t => "农码一生";
            MyMixFunc<string, string> str2 = str1;//第一个泛型的逆变（object->string）
            MyMixFunc<object, object> str3 = str1;//第二个泛型的协变（string->object）
            MyMixFunc<string, object> str4 = str1;//第一个泛型的逆变和第二个泛型的协变
        }

        #endregion
    }
}
