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
                new Vendor { Code = "AZN", Name = "Amazon", Address = "address", City = "city", State = "st", Zip = "12345", Phone = "555-555-5555", Email = "email-address" },
                new Vendor { Code = "WAL", Name = "Wal-Mart", Address = "address", City = "city", State = "st", Zip = "12345", Phone = "555-555-5555", Email = "email-address" }
                );

            context.Products.AddOrUpdate(p => p.Name,
                new Product { VendorId = 1, VendorPartNumber = "1", Name = "Part1", Price = 2, Unit = "Ea." },
                new Product { VendorId = 2, VendorPartNumber = "1", Name = "Part2", Price = 2, Unit = "Ea." },
                new Product { VendorId = 2, VendorPartNumber = "2", Name = "Part3", Price = 2, Unit = "Ea." },
                new Product { VendorId = 1, VendorPartNumber = "2", Name = "Part4", Price = 2, Unit = "Ea." }
                );

            context.Status.AddOrUpdate(s => s.Description,
                new Status { Description = "STATUS" }
                );

            context.PurchaseRequests.AddOrUpdate(p => p.Description,
                new PurchaseRequest { UserId = 1, Description = "desc1", Justification = "just", DateNeeded = DateTime.Now.AddDays(7), DeliveryMode = "Santa", StatusId = 1, SubmittedDate = DateTime.Now, Total = 0 }
                );
        }
    }
}
