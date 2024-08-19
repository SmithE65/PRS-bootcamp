using Prs.Bootcamp.Data;

namespace Prs.Bootcamp.PurchaseRequests;

public class RejectPurchaseRequestCommand(int id, string reason) : ICommand
{
    public int Id { get; } = id;
    public string Reason { get; } = reason;
}
