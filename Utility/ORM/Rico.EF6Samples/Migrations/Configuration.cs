using Rico.EFSample.Model;

namespace Rico.EF6Samples.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Rico.EF6Samples.RicoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Rico.EF6Samples.RicoDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Students.Add(new Student() { Name = "Rico", Age = 20 });
            context.Students.Add(new Student() { Name = "Tom", Age = 20 });
            context.Students.Add(new Student() { Name = "Jerry", Age = 20 });

        }
    }
}
