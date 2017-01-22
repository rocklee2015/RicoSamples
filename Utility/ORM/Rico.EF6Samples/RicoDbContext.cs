using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rico.EF.Common;
using Rico.EFSample.Model;

namespace Rico.EF6Samples
{
    public class RicoDbContext : DbContext
    {
        public RicoDbContext()
            : base("name=RicoDbContext")
        {
            DbInterception.Add(new EfIntercepterLogging());
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //自行注册使用
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
