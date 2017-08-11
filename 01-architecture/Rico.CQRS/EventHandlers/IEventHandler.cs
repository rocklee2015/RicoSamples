using Rico.CQRS.Events;

namespace Rico.CQRS.EventHandlers
{
    public interface IEventHandler<TEvent> where TEvent : Event
    {
        void Handle(TEvent handle);
    }
}
