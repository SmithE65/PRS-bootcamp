using Prs.Bootcamp.Data;
using Prs.Bootcamp.Data.Models;

namespace Prs.Bootcamp.PurchaseRequests;

public class UpdatePurchaseRequestCommand(int id, PurchaseRequest purchaseRequest) : ICommand
{
    public int Id { get; } = id;
    public PurchaseRequest PurchaseRequest { get; } = purchaseRequest;
}
