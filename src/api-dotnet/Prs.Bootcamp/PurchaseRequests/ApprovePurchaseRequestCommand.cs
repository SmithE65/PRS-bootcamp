using Prs.Bootcamp.Data;

namespace Prs.Bootcamp.PurchaseRequests;

public class ApprovePurchaseRequestCommand(int id) : ICommand
{
    public int Id { get; } = id;
}
