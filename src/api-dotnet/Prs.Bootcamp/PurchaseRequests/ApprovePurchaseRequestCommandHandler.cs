using Prs.Bootcamp.Data;

namespace Prs.Bootcamp.PurchaseRequests;

public class ApprovePurchaseRequestCommandHandler(PrsDbContext dbContext) : ICommandHandler<ApprovePurchaseRequestCommand>
{
    private readonly PrsDbContext _dbContext = dbContext;

    public async Task HandleAsync(ApprovePurchaseRequestCommand command)
    {
        var purchaseRequest = await _dbContext.PurchaseRequests.FindAsync(command.Id);

        if (purchaseRequest is not null)
        {
            purchaseRequest.Status = PurchaseRequestConstants.Approved;
            _ = await _dbContext.SaveChangesAsync();
        }
    }
}
