using System;

namespace Rico.CQRS.Events
{
    public class ItemToChangedEvent : Event
    {
        public DateTime To { get; internal set; }
        public ItemToChangedEvent(Guid aggregateId, DateTime to)
        {
			AggregateId = aggregateId;
            To = to;
        }
    }
}
