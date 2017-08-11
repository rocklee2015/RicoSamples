using Rico.CQRS.Events;

namespace Rico.CQRS.Messaging
{
    public interface IEventBus
    {
        void Publish<T>(T @event) where T : Event;
    }

    //namiesto jedneho Busu budeme mat 2 - command bus a event bus ... event bus sa bude volat z event storage-u
    //ked sa publishne event. zavola sa jeho event handler

    //var bus = new EventBus();
      
    //        var storage = new EventStore(eventBus);
    //        var rep = new Repository<InventoryItem>(storage);
    //        var commands = new InventoryCommandHandlers(rep);
}
