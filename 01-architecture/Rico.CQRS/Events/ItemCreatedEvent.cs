using System;

namespace Rico.CQRS.Events
{
    public class ItemCreatedEvent:Event
    {
		public string Title { get; internal set; }
        public DateTime From { get; internal set; }
        public DateTime To { get; internal set; }
        public string Description { get;internal set; }

        public ItemCreatedEvent(Guid aggregateId, string title ,
            string description, DateTime from, DateTime to)
        {
			AggregateId = aggregateId;
            Title = title;
            From = from;
            To = to;
            Description = description;
        }
    }
}
