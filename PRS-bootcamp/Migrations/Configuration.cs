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
                new User { UserName = "admin", Password = "admin", FirstName = "admin", LastName = "admin", Phone = "5555555555", Email = "email-address", IsAdmin = true, IsReviewer = true },
                new User { UserName = "user", Password = "user", FirstName = "user", LastName = "user", Phone = "5555555555", Email = "email-address", IsAdmin = false, IsReviewer = true }
                );

            context.Vendors.AddOrUpdate(v => v.Code,
                new Vendor { Code = "AZN", Name = "Amazon", Address = "address", City = "city", State = "st", Zip = "12345", Phone = "5555555555", Email = "email-address" },
                new Vendor { Code = "WAL", Name = "Wal-Mart", Address = "address", City = "city", State = "st", Zip = "12345", Phone = "5555555555", Email = "email-address" }
                );

            context.Products.AddOrUpdate(p => p.Name,
                new Product { VendorId = 1, VendorPartNumber = "1", Name = "Part1", Description = "This is one part of a whole.", Price = 1, Unit = "Ea." },
                new Product { VendorId = 2, VendorPartNumber = "1", Name = "Part2", Description = "This is two parts of a whole.", Price = 2, Unit = "Ea." },
                new Product { VendorId = 2, VendorPartNumber = "2", Name = "Part3", Description = "This is three parts of a whole.", Price = 3, Unit = "Ea." },
                new Product { VendorId = 1, VendorPartNumber = "2", Name = "Part4", Description = "This is four parts of a whole.", Price = 4, Unit = "Ea." }
                );

            context.Status.AddOrUpdate(s => s.Description,
                new Status { Description = "IP" },
                new Status { Description = "REVIEW" },
                new Status { Description = "ACCEPTED" },
                new Status { Description = "REJECTED" },
                new Status { Description = "FULFILLED" }
                );

            //context.PurchaseRequests.AddOrUpdate(p => p.Description,
            //    new PurchaseRequest { UserId = 1, Description = "desc1", Justification = "just", DateNeeded = DateTime.Now.AddDays(7), DeliveryMode = "Santa", StatusId = 1, SubmittedDate = DateTime.Now, Total = 0 }
            //    );
        }
    }
}
