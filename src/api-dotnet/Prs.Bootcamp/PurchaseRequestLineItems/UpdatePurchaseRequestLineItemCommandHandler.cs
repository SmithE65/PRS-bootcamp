using Prs.Bootcamp.Data;

namespace Prs.Bootcamp.PurchaseRequestLineItems;

public class UpdatePurchaseRequestLineItemCommandHandler(PrsDbContext context) : ICommandHandler<UpdatePurchaseRequestLineItemCommand>
{
    private readonly PrsDbContext _context = context;
    public async Task HandleAsync(UpdatePurchaseRequestLineItemCommand command)
    {
        _ = _context.PurchaseRequestLineItems.Update(command.PurchaseRequestLineItem);
        _ = await _context.SaveChangesAsync();
    }
}
