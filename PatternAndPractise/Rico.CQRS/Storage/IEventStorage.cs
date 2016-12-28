using System;
using System.Collections.Generic;
using Rico.CQRS.Domain;
using Rico.CQRS.Domain.Mementos;
using Rico.CQRS.Events;

namespace Rico.CQRS.Storage
{
    public interface IEventStorage
    {
        IEnumerable<Event> GetEvents(Guid aggregateId);
        void Save(AggregateRoot aggregate);
        T GetMemento<T>(Guid aggregateId) where T: BaseMemento;
        void SaveMemento(BaseMemento memento);
    }
}
