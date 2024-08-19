using Prs.Bootcamp.Data;
using Prs.Bootcamp.Data.Models;

namespace Prs.Bootcamp.PurchaseRequests;

public class GetPurchaseRequestQueryHandler(PrsDbContext dbContext) : IQueryHandler<GetPurchaseRequestQuery, PurchaseRequest?>
{
    private readonly PrsDbContext _dbContext = dbContext;

    public async Task<PurchaseRequest?> HandleAsync(GetPurchaseRequestQuery query)
    {
        return await _dbContext.PurchaseRequests.FindAsync(query.Id);
    }
}
