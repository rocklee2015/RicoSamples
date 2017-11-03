using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rico.MVCUnitSample.Models
{
    public interface IFooRepository : IBaseRepository<Foo>
    {
        Foo GetSingle(int fooId);
    }

}