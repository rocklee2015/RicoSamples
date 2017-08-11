using Rico.CQRS.Events;
using Rico.CQRS.Reporting;

namespace Rico.CQRS.EventHandlers
{
    public class ItemCreatedEventHandler : IEventHandler<ItemCreatedEvent>
    {
        private readonly IReportDatabase _reportDatabase;
        public ItemCreatedEventHandler(IReportDatabase reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }
        public void Handle(ItemCreatedEvent handle)
        {
            DiaryItemDto item = new DiaryItemDto()
                {
                    Id = handle.AggregateId,
                    Description =  handle.Description,
                    From = handle.From,
                    Title = handle.Title,
                    To=handle.To,
                    Version =  handle.Version
                };

            _reportDatabase.Add(item);
        }
    }
}
