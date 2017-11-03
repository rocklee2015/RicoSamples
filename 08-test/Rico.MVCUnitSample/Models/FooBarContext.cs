using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Rico.MVCUnitSample.Models
{
    public class FooBarContext : DbContext
    {
        public DbSet<Foo> Foos { get; set; }
    }

}