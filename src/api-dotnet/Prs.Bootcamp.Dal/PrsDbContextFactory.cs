using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Prs.Bootcamp.Dal;

public class PrsDbContextFactory : IDesignTimeDbContextFactory<PrsDbContext>
{
    public PrsDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PrsDbContext>();
        var connectionString = @"server=(localdb)\MSSQLLocalDB;Database=PRS;Integrated Security=true;Encrypt=False;";
        optionsBuilder.UseSqlServer(connectionString);

        return new PrsDbContext(optionsBuilder.Options);
    }
}