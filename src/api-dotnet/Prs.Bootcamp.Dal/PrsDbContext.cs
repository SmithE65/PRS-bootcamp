using Microsoft.EntityFrameworkCore;
using Prs.Bootcamp.Dal.Models;

namespace Prs.Bootcamp.Dal;

public class PrsDbContext : DbContext
{
    public PrsDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Message> Messages => Set<Message>();
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
