using Prs.Bootcamp.Data;

namespace Prs.Bootcamp.Vendors;

public class GetVendorQueryHandler(PrsDbContext context) : IQueryHandler<GetVendorQuery, VendorDto?>
{
    private readonly PrsDbContext _context = context;
    public async Task<VendorDto?> HandleAsync(GetVendorQuery query)
    {
        var vendor = await _context
            .Vendors
            .FindAsync(query.Id);

        return vendor?.ToDto();
    }
}
