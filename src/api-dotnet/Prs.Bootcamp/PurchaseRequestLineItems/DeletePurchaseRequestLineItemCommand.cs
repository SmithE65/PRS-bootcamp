using Prs.Bootcamp.Data;

namespace Prs.Bootcamp.PurchaseRequestLineItems;

public class DeletePurchaseRequestLineItemCommand(int id) : ICommand
{
    public int Id { get; } = id;
}
