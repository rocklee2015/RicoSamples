using Rico.CQRS.Events;

namespace Rico.CQRS.Storage

{
    public interface IEventPublisher
    {
        void Publish(Event @event);
    }
}
