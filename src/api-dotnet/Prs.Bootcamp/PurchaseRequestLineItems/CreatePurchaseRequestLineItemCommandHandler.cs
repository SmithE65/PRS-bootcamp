using Prs.Bootcamp.Data;

namespace Prs.Bootcamp.PurchaseRequestLineItems;

public class CreatePurchaseRequestLineItemCommandHandler(PrsDbContext context) : ICommandHandler<CreatePurchaseRequestLineItemCommand>
{
    private readonly PrsDbContext _context = context;
    public async Task HandleAsync(CreatePurchaseRequestLineItemCommand command)
    {
        _ = await _context.PurchaseRequestLineItems.AddAsync(command.PurchaseRequestLineItem);
        _ = await _context.SaveChangesAsync();
    }
}
