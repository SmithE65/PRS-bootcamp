using Prs.Bootcamp.Data;

namespace Prs.Bootcamp.Vendors;

public static class ServiceRegistration
{
    public static void AddVendorsServices(this IServiceCollection services)
    {
        services.AddScoped<IQueryHandler<GetVendorQuery, VendorDto?>, GetVendorQueryHandler>();
        services.AddScoped<IQueryHandler<GetVendorsQuery, IEnumerable<VendorDto>>, GetVendorsQueryHandler>();
    }
}
