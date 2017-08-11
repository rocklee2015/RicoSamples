using System;

namespace Rico.CQRS.Events
{
    public interface IEvent
    {
        Guid Id { get; }
    }
}
