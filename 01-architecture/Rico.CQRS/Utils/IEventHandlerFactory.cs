using System.Collections.Generic;
using Rico.CQRS.EventHandlers;
using Rico.CQRS.Events;

namespace Rico.CQRS.Utils
{
    public interface IEventHandlerFactory
    {
        IEnumerable<IEventHandler<T>> GetHandlers<T>() where T : Event;
    }
}
