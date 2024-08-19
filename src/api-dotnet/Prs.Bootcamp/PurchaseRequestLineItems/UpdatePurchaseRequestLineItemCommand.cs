using Prs.Bootcamp.Data;
using Prs.Bootcamp.Data.Models;

namespace Prs.Bootcamp.PurchaseRequestLineItems;

public class UpdatePurchaseRequestLineItemCommand(PurchaseRequestLineItem purchaseRequestLineItem) : ICommand
{
    public PurchaseRequestLineItem PurchaseRequestLineItem { get; } = purchaseRequestLineItem;
}
