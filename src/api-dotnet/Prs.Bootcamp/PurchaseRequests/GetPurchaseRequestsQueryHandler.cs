using Microsoft.EntityFrameworkCore;
using Prs.Bootcamp.Data;
using Prs.Bootcamp.Data.Models;

namespace Prs.Bootcamp.PurchaseRequests;

public class GetPurchaseRequestsQueryHandler(PrsDbContext dbContext) : IQueryHandler<GetPurchaseRequestsQuery, IEnumerable<PurchaseRequest>>
{
    private readonly PrsDbContext _dbContext = dbContext;

    public async Task<IEnumerable<PurchaseRequest>> HandleAsync(GetPurchaseRequestsQuery query)
    {
        return await _dbContext.PurchaseRequests.ToListAsync();
    }
}
