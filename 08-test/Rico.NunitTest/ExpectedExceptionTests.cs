using System;
using NUnit.Framework;

namespace Rico.NunitTest
{
    [TestFixture]
    public class ExpectedExceptionTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void HandlesArgumentExceptionAsType()
        {
            throw new ArgumentException();
        }
    }
}