using Prs.Bootcamp.Data;
using Prs.Bootcamp.Data.Models;

namespace Prs.Bootcamp.PurchaseRequests;

public class GetPurchaseRequestQuery(int id) : IQuery<PurchaseRequest?>
{
    public int Id { get; } = id;
}
