using System;

namespace Rico.CQRS.Commands
{
    public interface ICommand
    {
        Guid Id { get; }
    }
}
