using Microsoft.EntityFrameworkCore;
using Prs.Bootcamp.Data;
using Prs.Bootcamp.Data.Models;

namespace Prs.Bootcamp.PurchaseRequests;

public class GetPurchaseRequestsForReviewQueryHandler(PrsDbContext dbContext) : IQueryHandler<GetPurchaseRequestsForReviewQuery, IEnumerable<PurchaseRequest>>
{
    private readonly PrsDbContext _dbContext = dbContext;

    public async Task<IEnumerable<PurchaseRequest>> HandleAsync(GetPurchaseRequestsForReviewQuery query)
    {
        return await _dbContext.PurchaseRequests
            .Where(pr => pr.UserId != query.UserId && pr.Status == PurchaseRequestConstants.Review)
            .ToListAsync();
    }
}
