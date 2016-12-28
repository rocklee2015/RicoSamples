using System;

namespace Rico.CQRS.Events
{
    public class ItemDeletedEvent:Event
    {
        public ItemDeletedEvent(Guid aggregateId)
        {
			AggregateId = aggregateId;
        }
    }
}
