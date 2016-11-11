using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.Consoles.EF
{
    public class BloggingContext : DbContext
    {
        public BloggingContext()
            : base("name=default")
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// 没用的，必须是DbSet
        /// </summary>
        public IQueryable<User> QueryUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .Map(m =>
                {
                    m.Properties(t => new { t.Id, t.Title, t.Url });
                    m.ToTable("Blogs");
                })
                .Map(m =>
                {
                    m.Properties(t => new { t.Id, t.Remark });
                    m.ToTable("BlogDetails");
                });

            base.OnModelCreating(modelBuilder);
        }
    }

    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Remark { get; set; }

    }
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public int Address { get; set; }
        public bool IsDelete { get; set; }

    }
   
}
