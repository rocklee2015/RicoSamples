using Rico.CQRS.Events;
using Rico.CQRS.Reporting;

namespace Rico.CQRS.EventHandlers
{
    public class ItemFromChangedEventHandler : IEventHandler<ItemFromChangedEvent>
    {
        private readonly IReportDatabase _reportDatabase;
        public ItemFromChangedEventHandler(IReportDatabase reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }
        public void Handle(ItemFromChangedEvent handle)
        {
            var item = _reportDatabase.GetById(handle.AggregateId);
            item.From = handle.From;
            item.Version = handle.Version;
        }
    }
}
