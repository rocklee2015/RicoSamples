using Rico.CQRS.Messaging;
using Rico.CQRS.Reporting;
using Rico.CQRS.Storage;
using Rico.CQRS.Utils;
using StructureMap;

namespace Rico.CQRS.Configuration
{
    public sealed class ServiceLocator
    {
        private static ICommandBus _commandBus;
        private static IReportDatabase _reportDatabase;
        private static bool _isInitialized;
        private static readonly object _lockThis = new object();

        static ServiceLocator()
        {
            if (!_isInitialized)
            {
                lock (_lockThis)
                {
                    ContainerBootstrapper.BootstrapStructureMap();
                    _commandBus = ObjectFactory.GetInstance<ICommandBus>();
                    _reportDatabase = ObjectFactory.GetInstance<IReportDatabase>();
                    _isInitialized = true;
                }
            }


        }



        public static ICommandBus CommandBus
        {
            get { return _commandBus; }
        }

        public static IReportDatabase ReportDatabase
        {
            get { return _reportDatabase; }
        }
    }


    static class ContainerBootstrapper
    {
        public static void BootstrapStructureMap()
        {

            ObjectFactory.Initialize(x =>
            {
                x.For(typeof(IRepository<>)).Singleton().Use(typeof(Repository<>));
                x.For<IEventStorage>().Singleton().Use<InMemoryEventStorage>();
                x.For<IEventBus>().Use<EventBus>();
                x.For<ICommandHandlerFactory>().Use<StructureMapCommandHandlerFactory>();
                x.For<IEventHandlerFactory>().Use<StructureMapEventHandlerFactory>();
                x.For<ICommandBus>().Use<CommandBus>();
                x.For<IEventBus>().Use<EventBus>();
                x.For<IReportDatabase>().Use<ReportDatabase>();
            });
        }
    }
}
