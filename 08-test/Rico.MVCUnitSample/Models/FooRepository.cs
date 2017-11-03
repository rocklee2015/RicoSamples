using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rico.MVCUnitSample.Models
{
    public class FooRepository : BaseRepository<FooBarContext, Foo>, IFooRepository

    {
        public Foo GetSingle(int fooId)
        {
            var query = GetAll().FirstOrDefault(x => x.Id == fooId);
            return query;
        }

    }
}