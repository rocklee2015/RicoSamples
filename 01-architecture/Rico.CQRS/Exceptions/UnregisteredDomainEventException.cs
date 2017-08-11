using System;

namespace Rico.CQRS.Exceptions
{
    public class UnregisteredDomainEventException : Exception
    {
        public UnregisteredDomainEventException(string message) : base(message) { }
    }
}
