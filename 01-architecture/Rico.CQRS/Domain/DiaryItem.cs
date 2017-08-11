using System;
using Rico.CQRS.Domain.Mementos;
using Rico.CQRS.Events;
using Rico.CQRS.Storage.Memento;

namespace Rico.CQRS.Domain
{
    public class DiaryItem : AggregateRoot, 
        IHandle<ItemCreatedEvent>,
        IHandle<ItemRenamedEvent>,
        IHandle<ItemFromChangedEvent>, 
        IHandle<ItemToChangedEvent>,
        IHandle<ItemDescriptionChangedEvent>,
        IOriginator
    {
        public string Title { get; set; }

        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Description { get; set; }

        public DiaryItem()
        {
            
        }

        public DiaryItem(Guid id,string title, string description,  DateTime from, DateTime to)
        {
            ApplyChange(new ItemCreatedEvent(id, title,description, from, to));
        }

        public void ChangeTitle(string title)
        {
            ApplyChange(new ItemRenamedEvent(Id, title));
        }

        public void ChangeDescription(string description)
        {
            ApplyChange(new ItemDescriptionChangedEvent(Id, description));
        }

        public void ChangeFrom(DateTime from)
        {
            ApplyChange(new ItemFromChangedEvent(Id, from));
        }

        public void ChangeTo(DateTime to)
        {
            ApplyChange(new ItemToChangedEvent(Id, to));
        }

        public void Delete()
        {
            ApplyChange(new ItemDeletedEvent(Id));
        }

        public void Handle(ItemDeletedEvent e)
        {
            
        }

        public void Handle(ItemCreatedEvent e)
        {
            Title = e.Title;
            From = e.From;
            To = e.To;
            Id = e.AggregateId;
            Description = e.Description;
            Version = e.Version;
        }

        public void Handle(ItemRenamedEvent e)
        {
            Title = e.Title;
        }

        public void Handle(ItemFromChangedEvent e)
        {
            From = e.From;
        }

        public void Handle(ItemToChangedEvent e)
        {
            To = e.To;
        }

        public void Handle(ItemDescriptionChangedEvent e)
        {
            Description = e.Description;
        }
     
        public BaseMemento GetMemento()
        {
            return new DiaryItemMemento(Id,Title, Description,From,To,Version);
        }

        public void SetMemento(BaseMemento memento)
        {
            Title = ((DiaryItemMemento) memento).Title;
            To = ((DiaryItemMemento)memento).To;
            Version= memento.Version;
            From = ((DiaryItemMemento)memento).From;
            Description = ((DiaryItemMemento)memento).Description;
            Id = memento.Id;
        }

        
    }
}
