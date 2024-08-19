using Prs.Bootcamp.Data;

namespace Prs.Bootcamp.Vendors;

public class GetVendorQuery(int id) : IQuery<VendorDto?>
{
    public int Id { get; } = id;
}
