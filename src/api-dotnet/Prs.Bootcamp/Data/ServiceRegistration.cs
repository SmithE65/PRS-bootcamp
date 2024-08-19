using Microsoft.EntityFrameworkCore;

namespace Prs.Bootcamp.Data;

public static class ServiceRegistration
{
    public static void AddPrsDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<PrsDbContext>(opt =>
        {
            _ = opt.UseNpgsql(connectionString, options =>
            {
                _ = options.EnableRetryOnFailure();
            });
        });
    }
}
