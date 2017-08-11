using Rico.CQRS.CommandHandlers;
using Rico.CQRS.Commands;

namespace Rico.CQRS.Utils
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<T> GetHandler<T>() where T : Command;
    }
}
