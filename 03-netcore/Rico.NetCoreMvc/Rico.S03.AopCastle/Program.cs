using Castle.DynamicProxy;
using System;

namespace Rico.S03.AopCastle
{
    class Program
    {
        static void Main(string[] args)
        {
            ProxyGenerator generator = new ProxyGenerator();//实例化【代理类生成器】  
            Interceptor interceptor = new Interceptor();//实例化【拦截器】  

            //使用【代理类生成器】创建Person对象，而不是使用new关键字来实例化  
            TestInterceptor test = generator.CreateClassProxy<TestInterceptor>(interceptor);
            Console.WriteLine("当前类型:{0},父类型:{1}", test.GetType(), test.GetType().BaseType);
            Console.WriteLine();
            test.MethodInterceptor();
            Console.WriteLine();
            test.NoInterceptor();
            Console.WriteLine();
            Console.ReadLine();
        }
    }

    public class TestInterceptor
    {
        public virtual void MethodInterceptor()
        {
            Console.WriteLine("走过滤器");
        }

        public void NoInterceptor()
        {
            Console.WriteLine("没有走过滤器");
        }
    }
    public class Interceptor : StandardInterceptor
    {
        /// <summary>
        /// 调用前的拦截器
        /// </summary>
        /// <param name="invocation"></param>
        protected override void PreProceed(IInvocation invocation)
        {
            Console.WriteLine("调用前的拦截器，方法名是：{0}。", invocation.Method.Name);// 方法名   获取当前成员的名称。 
        }
        /// <summary>
        /// 拦截的方法返回时调用的拦截器
        /// </summary>
        /// <param name="invocation"></param>
        protected override void PerformProceed(IInvocation invocation)
        {
            Console.WriteLine("拦截的方法返回时调用的拦截器，方法名是：{0}。", invocation.Method.Name);
            base.PerformProceed(invocation);
        }

        /// <summary>
        /// 调用后的拦截器
        /// </summary>
        /// <param name="invocation"></param>
        protected override void PostProceed(IInvocation invocation)
        {
            Console.WriteLine("调用后的拦截器，方法名是：{0}。", invocation.Method.Name);
        }
    }
}
