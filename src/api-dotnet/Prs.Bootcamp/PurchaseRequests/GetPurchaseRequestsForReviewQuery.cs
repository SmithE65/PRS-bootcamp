using Prs.Bootcamp.Data;
using Prs.Bootcamp.Data.Models;

namespace Prs.Bootcamp.PurchaseRequests;

public class GetPurchaseRequestsForReviewQuery(int userId) : IQuery<IEnumerable<PurchaseRequest>>
{
    public int UserId { get; } = userId;
}
