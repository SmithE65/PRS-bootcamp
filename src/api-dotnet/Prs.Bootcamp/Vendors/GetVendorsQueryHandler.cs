using Microsoft.EntityFrameworkCore;
using Prs.Bootcamp.Data;

namespace Prs.Bootcamp.Vendors;

public class GetVendorsQueryHandler(PrsDbContext context) : IQueryHandler<GetVendorsQuery, IEnumerable<VendorDto>>
{
    private readonly PrsDbContext _context = context;

    public async Task<IEnumerable<VendorDto>> HandleAsync(GetVendorsQuery query)
    {
        return await _context
            .Vendors
            .Select(v => new VendorDto(
                v.Id,
                v.Code,
                v.Name,
                v.Address,
                v.City,
                v.State,
                v.Zip,
                v.Phone,
                v.Email))
            .ToListAsync();
    }
}
