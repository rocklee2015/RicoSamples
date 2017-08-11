using System;

namespace Rico.CQRS.Exceptions
{
    public class UnregisteredDomainCommandException : Exception
    {
        public UnregisteredDomainCommandException(string message) : base(message) { }
    }
}
