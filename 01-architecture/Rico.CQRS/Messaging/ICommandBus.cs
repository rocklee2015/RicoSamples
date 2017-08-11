using Rico.CQRS.Commands;

namespace Rico.CQRS.Messaging
{
    public interface ICommandBus
    {
        void Send<T>(T command) where T : Command;
    }
}
