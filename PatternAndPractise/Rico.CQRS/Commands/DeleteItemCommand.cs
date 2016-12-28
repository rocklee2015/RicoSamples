using System;

namespace Rico.CQRS.Commands
{
    public class DeleteItemCommand : Command
    {
        public DeleteItemCommand(Guid id, int version) : base(id, version)
        {
        }
    }
}
