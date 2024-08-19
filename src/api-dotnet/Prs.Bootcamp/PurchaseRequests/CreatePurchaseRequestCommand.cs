using Prs.Bootcamp.Data;
using Prs.Bootcamp.Data.Models;

namespace Prs.Bootcamp.PurchaseRequests;

public class CreatePurchaseRequestCommand(PurchaseRequest purchaseRequest) : ICommand
{
    public PurchaseRequest PurchaseRequest { get; } = purchaseRequest;
}
