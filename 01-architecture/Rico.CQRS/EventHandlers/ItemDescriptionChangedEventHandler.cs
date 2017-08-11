using Rico.CQRS.Events;
using Rico.CQRS.Reporting;

namespace Rico.CQRS.EventHandlers
{
    public class ItemDescriptionChangedEventHandler : IEventHandler<ItemDescriptionChangedEvent>
    {
        private readonly IReportDatabase _reportDatabase;
        public ItemDescriptionChangedEventHandler(IReportDatabase reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }
        public void Handle(ItemDescriptionChangedEvent handle)
        {
            var item = _reportDatabase.GetById(handle.AggregateId);
            item.Description = handle.Description;
            item.Version = handle.Version;
        }
    }
}
