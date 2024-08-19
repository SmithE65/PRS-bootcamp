using Prs.Bootcamp.Data;
using Prs.Bootcamp.Data.Models;

namespace Prs.Bootcamp.PurchaseRequestLineItems;

public class GetPurchaseRequestLineItemQuery(int id) : IQuery<PurchaseRequestLineItem?>
{
    public int Id { get; } = id;
}
