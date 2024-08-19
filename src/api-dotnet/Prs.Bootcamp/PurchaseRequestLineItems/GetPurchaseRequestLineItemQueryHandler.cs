using Prs.Bootcamp.Data;
using Prs.Bootcamp.Data.Models;

namespace Prs.Bootcamp.PurchaseRequestLineItems;

public class GetPurchaseRequestLineItemQueryHandler(PrsDbContext context) : IQueryHandler<GetPurchaseRequestLineItemQuery, PurchaseRequestLineItem?>
{
    private readonly PrsDbContext _context = context;

    public async Task<PurchaseRequestLineItem?> HandleAsync(GetPurchaseRequestLineItemQuery query)
    {
        return await _context.PurchaseRequestLineItems.FindAsync(query.Id);
    }
}
