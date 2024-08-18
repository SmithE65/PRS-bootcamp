using Microsoft.EntityFrameworkCore;
using Prs.Bootcamp.Data.Models;

namespace Prs.Bootcamp.Data;

public class PrsDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<PurchaseRequest> PurchaseRequests => Set<PurchaseRequest>();
    public DbSet<PurchaseRequestLineItem> PurchaseRequestLineItems => Set<PurchaseRequestLineItem>();
    public DbSet<Status> Status => Set<Status>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Vendor> Vendors => Set<Vendor>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
