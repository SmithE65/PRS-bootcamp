using Prs.Bootcamp.Data;

namespace Prs.Bootcamp.PurchaseRequestLineItems;

public class DeletePurchaseRequestLineItemCommandHandler(PrsDbContext context) : ICommandHandler<DeletePurchaseRequestLineItemCommand>
{
    private readonly PrsDbContext _context = context;
    public async Task HandleAsync(DeletePurchaseRequestLineItemCommand command)
    {
        var purchaseRequestLineItem = await _context.PurchaseRequestLineItems.FindAsync(command.Id);

        if (purchaseRequestLineItem is not null)
        {
            _ = _context.PurchaseRequestLineItems.Remove(purchaseRequestLineItem);
            _ = await _context.SaveChangesAsync(); 
        }
    }
}
