using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core.Registration;
using Xunit;
using Rico.IOC.AutoFacUnitest.model;

namespace Rico.IOC.AutoFacUnitest
{
    /// <summary>
    /// source:http://niuyi.github.io/blog/2012/04/06/autofac-by-unit-test/
    /// </summary>
    public class AutoFacMain1
    {
        [Fact]
        public void can_resolve_myclass()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MyClass>();
            IContainer container = builder.Build();
            var myClass = container.Resolve<MyClass>();
            Assert.NotNull(myClass);
        }
        [Fact]
        public void register_as_interface()
        {
            var builder = new ContainerBuilder();
            builder.Register(c => new MyClass()).As<IMyInterface>();

            IContainer container = builder.Build();
            Assert.NotNull(container.Resolve<IMyInterface>());
            Assert.Throws(typeof(ComponentNotRegisteredException), () => container.Resolve<MyClass>());
        }
        [Fact]
        public void can_register_with_lambda()
        {
            var builder = new ContainerBuilder();
            builder.Register(c => new MyClass());

            IContainer container = builder.Build();
            var myClass = container.Resolve<MyClass>();
            Assert.NotNull(myClass);
        }
        [Fact]
        public void register_with_parameter()
        {
            var builder = new ContainerBuilder();
            builder.Register(c => new MyParameter());
            builder.Register(c => new MyClass(c.Resolve<MyParameter>()));
            IContainer container = builder.Build();
            Assert.NotNull(container.Resolve<MyClass>());
        }
        [Fact]
        public void register_with_property()
        {
            var builder = new ContainerBuilder();
            builder.Register(c => new MyProperty());
            builder.Register(
                c => new MyClass()
                {
                    Property = c.Resolve<MyProperty>()
                });
            IContainer container = builder.Build();
            var myClass = container.Resolve<MyClass>();
            Assert.NotNull(myClass);
            Assert.NotNull(myClass.Property);
        }
        [Fact]
        public void select_an_implementer_based_on_parameter_value()
        {
            var builder = new ContainerBuilder();
            builder.Register<IRepository>((c, p) =>
            {
                var type = p.Named<string>("type");
                if (type == "test")
                {
                    return new TestRepository();
                }
                else
                {
                    return new DbRepository();
                }
            }).As<IRepository>();

            IContainer container = builder.Build();
            var repository = container.Resolve<IRepository>(new NamedParameter("type", "test"));
            Assert.Equal(typeof(TestRepository), repository.GetType());
        }
        [Fact]
        public void register_with_instance()
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance(MyInstance.Instance).ExternallyOwned();
            IContainer container = builder.Build();
            var myInstance1 = container.Resolve<MyInstance>();
            var myInstance2 = container.Resolve<MyInstance>();
            Assert.Equal(myInstance1, myInstance2);
        }
        [Fact]
        public void register_open_generic()
        {
            var builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof(MyList<>));
            IContainer container = builder.Build();
            var myIntList = container.Resolve<MyList<int>>();
            Assert.NotNull(myIntList);
            var myStringList = container.Resolve<MyList<string>>();
            Assert.NotNull(myStringList);
        }
        [Fact]
        public void register_order()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<DbRepository>().As<IRepository>();
            containerBuilder.RegisterType<TestRepository>().As<IRepository>();

            IContainer container = containerBuilder.Build();
            var repository = container.Resolve<IRepository>();
            Assert.Equal(typeof(TestRepository), repository.GetType());
        }
        [Fact]
        public void register_order_defaults()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<DbRepository>().As<IRepository>();
            containerBuilder.RegisterType<TestRepository>().As<IRepository>().PreserveExistingDefaults();

            IContainer container = containerBuilder.Build();
            var repository = container.Resolve<IRepository>();
            Assert.Equal(typeof(DbRepository), repository.GetType());
        }
        [Fact]
        public void register_with_name()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<DbRepository>().Named<IRepository>("DB");
            containerBuilder.RegisterType<TestRepository>().Named<IRepository>("Test");

            IContainer container = containerBuilder.Build();
            var dbRepository = container.ResolveNamed<IRepository>("DB");
            var testRepository = container.ResolveNamed<IRepository>("Test");
            Assert.Equal(typeof(DbRepository), dbRepository.GetType());
            Assert.Equal(typeof(TestRepository), testRepository.GetType());
        }
        [Fact]
        public void choose_constructors()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MyParameter>();
            builder.RegisterType<MyClass>().UsingConstructor(typeof(MyParameter));
            IContainer container = builder.Build();
            var myClass = container.Resolve<MyClass>();
            Assert.NotNull(myClass);
        }
        [Fact]
        public void register_assembly()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).
                Where(t => t.Name.EndsWith("Repository")).
                AsImplementedInterfaces();

            IContainer container = builder.Build();
            var repository = container.Resolve<IRepository>();
            Assert.NotNull(repository);
        }
    }
}
