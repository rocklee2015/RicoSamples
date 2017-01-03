using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace Rico.IOC.UnitySample.Unity1
{
    public class Unity1Main
    {
        /// <summary>
        /// Unity 入门
        /// source ：http://www.cnblogs.com/kebixisimba/archive/2008/04/08/1142318.html
        /// </summary>
        public static void SimpleTest()
        {
            //Step1. 创建容器
            //在Unity中创建容器实例最简单的方法是直接使用构造函数创建
            IUnityContainer container = new UnityContainer();

            //Step2. 注册接口映射
            //在Unity中提供了一组Register方法供我们在容器中注册接口映射
            //两种写法，一种泛型，一种非泛型
            container.RegisterType<ILogger, ConsoleLogger>();
            //container.RegisterType(typeof (ILogger), typeof (ConsoleLogger));

            //Step3. 获取对象实例
            //在Unity中提供了一组Resolve方法用以获取对象实例
            ILogger logger = container.Resolve<ILogger>();

            logger.Log("Have a  Look!");
        }
        /// <summary>
        /// 使用场景I：建立类型映射
        /// source:http://www.cnblogs.com/kebixisimba/archive/2008/04/19/1161405.html
        /// </summary>
        public static void TypeMapTest()
        {
            //1 直接使用接口（或者基类）作为标识键
            // 同SimpleTest方法

            //2 用接口（或基类）与名称的组合作为标识键
            IUnityContainer container = new UnityContainer();

            //如果需要使用同样的接口（或基类）注册多个映射，可以指定名称来区分每个映射
            //大小写敏感的
            container.RegisterType<ILogger, ConsoleLogger>("Tom");
            container.RegisterType<ILogger, ConsoleLogger>("Jerry");
            container.RegisterType<ILogger, NullLogger>("Snoopy");

            ILogger logger = container.Resolve<ILogger>("Jerry");
            logger.Log("I am Jerry!");

            logger = container.Resolve<ILogger>("Tom");
            logger.Log("I am Tom!");

            logger = container.Resolve<ILogger>("Snoopy");
            logger.Log("I am Snoopy!");


        }
        /// <summary>
        /// 使用场景2：用于单例模式 
        /// source:http://www.cnblogs.com/kebixisimba/archive/2008/04/28/1174474.html
        /// </summary>
        public static void SinglePatternTest()
        {
            //1、将类型注册为单例
            IUnityContainer container = new UnityContainer();
            //当我们指定了ContainerControlledLifetimeManager参数后，容器在第一次调用Resolve方法时会创建一个新对象，此后在每次调用Resolve时，都会返回之前创建的对象
            container.RegisterType<IOrder, CommonOrder>(new ContainerControlledLifetimeManager());

            IOrder order1 = container.Resolve<IOrder>();
            order1.Discount = 0.8;

            IOrder order2 = container.Resolve<IOrder>();
            order2.DumpDiscount();

            //2、将已有对象注册为单例
            VipOrder vipOrder = new VipOrder { Discount = 0.6 };
            container.RegisterInstance<IOrder>(vipOrder);

            IOrder order3 = container.Resolve<IOrder>();
            order3.DumpDiscount();
            order3.Discount -= 0.1;

            IOrder order4 = container.Resolve<IOrder>();
            order4.DumpDiscount();

        }
        /// <summary>
        ///  使用场景3：用于依赖注入-单构造器
        /// </summary>
        public static void DependencyInjectionSingleConstructorTest()
        {
            IUnityContainer container = new UnityContainer()
                .RegisterType<ILogger, ConsoleLogger>()
                .RegisterType<IOrder, CommonOrder>(new ContainerControlledLifetimeManager())
                .RegisterType<IOrderWithLogging, SingleConstructor>();

            IOrder order = container.Resolve<IOrder>();
            order.Discount = 0.8;

            IOrderWithLogging orderWithLogging = container.Resolve<IOrderWithLogging>();
            orderWithLogging.Output();


        }
        /// <summary>
        ///  使用场景3：用于依赖注入-多构造器
        /// </summary>
        public static void DependencyInjectionMultipleConstructorTest()
        {
            IUnityContainer container = new UnityContainer()
                .RegisterType<ILogger, NullLogger>()
                .RegisterType<IOrder, VipOrder>(new ContainerControlledLifetimeManager())
                .RegisterType<IOrderWithLogging, MultipleConstructor>();

            IOrder order = container.Resolve<IOrder>();
            order.Discount = 0.7;

            IOrderWithLogging orderWithLogging = container.Resolve<IOrderWithLogging>();
            orderWithLogging.Output();

        }
        /// <summary>
        ///  使用场景3：用于依赖注入-属性依赖注入
        ///  source:http://www.cnblogs.com/kebixisimba/archive/2008/05/26/1207503.html
        /// </summary>
        public static void DependencyInjectionPropertyInjectionTest()
        {
            IUnityContainer container = new UnityContainer()
                .RegisterType<ILogger, ConsoleLogger>()
                .RegisterType<IOrder, CommonOrder>(new ContainerControlledLifetimeManager())
                .RegisterType<IOrderWithLogging, PropertyInjection>();

            IOrder order = container.Resolve<IOrder>();
            order.Discount = 0.95;

            IOrderWithLogging orderWithLogging = container.Resolve<IOrderWithLogging>();
            orderWithLogging.Output();

        }

        public static void UnityLifeTime()
        {
            //Unity内置了6种生存期管理模型，其中有2种即负责对象实例的创建也负责对象实例的销毁（Disposing）。
            //TransientLifetimeManager - 为每次请求生成新的类型对象实例。 (默认行为)
            //ContainerControlledLifetimeManager - 实现Singleton对象实例。 当容器被Disposed后，对象实例也被Disposed。
            //HierarchicalifetimeManager - 实现Singleton对象实例。但子容器并不共享父容器实例，而是创建针对字容器的Singleton对象实例。当容器被Disposed后，对象实例也被Disposed。
            //ExternallyControlledLifetimeManager - 实现Singleton对象实例，但容器仅持有该对象的弱引用（WeakReference），所以该对象的生存期由外部引用控制。
            //PerThreadLifetimeManager - 为每个线程生成Singleton的对象实例，通过ThreadStatic实现。
            //PerResolveLifetimeManager - 实现与TransientLifetimeManager类似的行为，为每次请求生成新的类型对象实例。不同之处在于对象实例在BuildUp过程中是可被重用的。
        }

    }
}
