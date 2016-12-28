using Rico.CQRS.Events;
using Rico.CQRS.Reporting;

namespace Rico.CQRS.EventHandlers
{
    public class ItemRenamedEventHandler : IEventHandler<ItemRenamedEvent>
    {
        private readonly IReportDatabase _reportDatabase;
        public ItemRenamedEventHandler(IReportDatabase reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }
        public void Handle(ItemRenamedEvent handle)
        {
            var item = _reportDatabase.GetById(handle.AggregateId);
            item.Title = handle.Title;
            item.Version = handle.Version;
        }
    }
}
