using Prs.Bootcamp.Data;

namespace Prs.Bootcamp.PurchaseRequests;

public class DeletePurchaseRequestCommand(int id) : ICommand
{
    public int Id { get; } = id;
}
