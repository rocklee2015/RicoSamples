using System;

namespace Rico.CQRS.Exceptions
{
    public class ConcurrencyException : Exception
    {
        public ConcurrencyException(string message) : base(message) { }
    }
}
