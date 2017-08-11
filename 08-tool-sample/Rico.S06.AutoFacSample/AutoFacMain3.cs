using Autofac;
using Autofac.Util;
using Rico.S06.AutoFacSample.model;
using Xunit;

namespace Rico.IOC.AutoFacUnitest
{
    /// <summary>
    /// source:http://niuyi.github.io/blog/2012/04/06/autofact-by-unit-test3/
    /// </summary>
    public class AutoFacMain3
    {
        /// <summary>
        /// Per Dependency为默认的生命周期，也被称为’transient’或’factory’，其实就是每次请求都创建一个新的对象
        /// </summary>
        [Fact]
        public void per_dependency()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MyClass>().InstancePerDependency();
            IContainer container = builder.Build();
            var myClass1 = container.Resolve<MyClass>();
            var myClass2 = container.Resolve<MyClass>();
            Assert.NotEqual(myClass1, myClass2);
        }
        /// <summary>
        /// Single Instance也很好理解，就是每次都用同一个对象
        /// </summary>
        [Fact]
        public void single_instance()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MyClass>().SingleInstance();

            IContainer container = builder.Build();
            var myClass1 = container.Resolve<MyClass>();
            var myClass2 = container.Resolve<MyClass>();

            Assert.Equal(myClass1, myClass2);
        }
        /// <summary>
        /// Per Lifetime Scope，同一个Lifetime生成的对象是同一个实例
        /// </summary>
        [Fact]
        public void per_lifetime_scope()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MyClass>().InstancePerLifetimeScope();

            IContainer container = builder.Build();
            var myClass1 = container.Resolve<MyClass>();
            var myClass2 = container.Resolve<MyClass>();

            ILifetimeScope inner = container.BeginLifetimeScope();
            var myClass3 = inner.Resolve<MyClass>();
            var myClass4 = inner.Resolve<MyClass>();

            Assert.Equal(myClass1, myClass2);
            Assert.NotEqual(myClass2, myClass3);
            Assert.Equal(myClass3, myClass4);
        }
        [Fact]
        public void life_time_and_dispose()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Disposable>();

            using (IContainer container = builder.Build())
            {
                var outInstance = container.Resolve<Disposable>(new NamedParameter("name", "out"));

                using (var inner = container.BeginLifetimeScope())
                {
                    var inInstance = container.Resolve<Disposable>(new NamedParameter("name", "in"));
                }//inInstance dispose here
            }//out dispose here
        }
    }
}
