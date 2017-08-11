using System;
using Rico.CQRS.Commands;
using Rico.CQRS.Domain;
using Rico.CQRS.Storage;

namespace Rico.CQRS.CommandHandlers
{
    public class CreateItemCommandHandler : ICommandHandler<CreateItemCommand>
    {
        private IRepository<DiaryItem> _repository;

        public CreateItemCommandHandler(IRepository<DiaryItem> repository)
        {
            _repository = repository;
        }

        public void Execute(CreateItemCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }
            if (_repository == null)
            {
                throw new InvalidOperationException("Repository is not initialized.");
            }
            var aggregate = new DiaryItem(command.Id, command.Title, command.Description, command.From, command.To);
            aggregate.Version = -1;
            _repository.Save(aggregate, aggregate.Version);
        }
    }
}
