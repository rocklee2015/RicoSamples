using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rico.NetCore.Web.EFCore
{
    public class RicoDbContext : DbContext
    {
        public RicoDbContext(DbContextOptions<RicoDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
