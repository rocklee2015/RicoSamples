using Rico.CQRS.Events;
using Rico.CQRS.Reporting;

namespace Rico.CQRS.EventHandlers
{
    public class ItemDeletedEventHandler : IEventHandler<ItemDeletedEvent>
    {
        private readonly IReportDatabase _reportDatabase;
        public ItemDeletedEventHandler(IReportDatabase reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }
        public void Handle(ItemDeletedEvent handle)
        {
            _reportDatabase.Delete(handle.AggregateId);
        }
    }
}
