namespace Rico.CQRS.Events
{
    public interface IHandle<TEvent> where TEvent:Event
    {
        void Handle(TEvent e);
    }
}
