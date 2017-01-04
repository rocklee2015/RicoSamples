
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rico.IOC.AutoFacUnitest.model2;
using Xunit;


namespace Rico.IOC.AutoFacUnitest
{
    /// <summary>
    /// source:http://niuyi.github.io/blog/2012/04/06/autofac-by-unit-test-2/
    /// </summary>
    [TestClass]
    public class AutofacMain2
    {
        [TestMethod]
        public void test_event()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MyEvent>().
                OnActivating(e => e.ReplaceInstance(new MyEvent("input"))).
                OnActivated(e => Console.WriteLine("OnActivated")).
                OnRelease(e => Console.WriteLine("OnRelease"));


            using (IContainer container = builder.Build())
            {
                using (var myEvent = container.Resolve<MyEvent>())
                {
                }
            }
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(true);
        }
        [Fact]
        public void test_event_fact()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MyEvent>().
                OnActivating(e => e.ReplaceInstance(new MyEvent("input"))).
                OnActivated(e => Console.WriteLine("OnActivated")).
                OnRelease(e => Console.WriteLine("OnRelease"));


            using (IContainer container = builder.Build())
            {
                using (var myEvent = container.Resolve<MyEvent>())
                {
                }
            }
        }
        [TestMethod]
        public void call_method_when_init()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MyClassWithMethod>().OnActivating(e => e.Instance.Add(5));
            IContainer container = builder.Build();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(5, container.Resolve<MyClassWithMethod>().Index);
        }
        [TestMethod]
        [ExpectedException(typeof(DependencyResolutionException))]
        public void circular_dependencies_exception()
        {
            var builder = new ContainerBuilder();
            builder.Register(c => new ClassB() { A = c.Resolve<ClassA>() });
            builder.Register(c => new ClassA(c.Resolve<ClassB>()));
            IContainer container = builder.Build();

            var classA = container.Resolve<ClassA>();
        }
        [Fact]
        
        public void circular_dependencies_exception_fact()
        {
            var builder = new ContainerBuilder();
            builder.Register(c => new ClassB() { A = c.Resolve<ClassA>() });
            builder.Register(c => new ClassA(c.Resolve<ClassB>()));
            IContainer container = builder.Build();
            Xunit.Assert.Throws(typeof(DependencyResolutionException), () => container.Resolve<ClassA>());
        }
        [Fact]
        public void circular_dependencies_ok()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ClassB>().
                PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).SingleInstance();
            builder.Register(c => new ClassA(c.Resolve<ClassB>()));
            IContainer container = builder.Build();
            Xunit.Assert.NotNull(container.Resolve<ClassA>());
            Xunit.Assert.NotNull(container.Resolve<ClassB>());
            Xunit.Assert.NotNull(container.Resolve<ClassB>().A);
        }
    }
}
