namespace PRS_bootcamp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using PRS_bootcamp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PRS_bootcamp.Models.PRS_bootcampContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PRS_bootcamp.Models.PRS_bootcampContext context)
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

            context.Users.AddOrUpdate(u => u.UserName,
                new User { UserName = "admin", Password = "admin", FirstName = "admin", LastName = "admin", Phone = "555-555-5555", Email = "email-address", IsAdmin = true, IsReviewer = true },
                new User { UserName = "user", Password = "user", FirstName = "user", LastName = "user", Phone = "555-555-5555", Email = "email-address", IsAdmin = true, IsReviewer = true }
                );

            context.Vendors.AddOrUpdate(v => v.Code,
                new Vendor { Code = "AZN", Name = "Amazon", Address = "address", City = "city", State = "st", Zip = "12345", Phone = "555-555-5555", Email = "email-address" }
                );
        }
    }
}
