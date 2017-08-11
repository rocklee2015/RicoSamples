using Rico.CQRS.Commands;

namespace Rico.CQRS.Storage
{
    public interface ICommandSender
    {
        void Send<T>(T command) where T : Command;
    }
}
