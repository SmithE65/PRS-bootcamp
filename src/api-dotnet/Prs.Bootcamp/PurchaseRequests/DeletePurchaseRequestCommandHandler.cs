using Prs.Bootcamp.Data;

namespace Prs.Bootcamp.PurchaseRequests;

public class DeletePurchaseRequestCommandHandler(PrsDbContext dbContext) : ICommandHandler<DeletePurchaseRequestCommand>
{
    private readonly PrsDbContext _dbContext = dbContext;

    public async Task HandleAsync(DeletePurchaseRequestCommand command)
    {
        var purchaseRequest = await _dbContext.PurchaseRequests.FindAsync(command.Id);

        if (purchaseRequest is not null)
        {
            _dbContext.PurchaseRequests.Remove(purchaseRequest);
            await _dbContext.SaveChangesAsync(); 
        }
    }
}
