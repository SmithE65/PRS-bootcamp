using Prs.Bootcamp.Data;

namespace Prs.Bootcamp.PurchaseRequests;

public class RejectPurchaseRequestCommandHandler(PrsDbContext dbContext) : ICommandHandler<RejectPurchaseRequestCommand>
{
    private readonly PrsDbContext _dbContext = dbContext;

    public async Task HandleAsync(RejectPurchaseRequestCommand command)
    {
        var purchaseRequest = await _dbContext.PurchaseRequests.FindAsync(command.Id);

        if (purchaseRequest is not null)
        {
            purchaseRequest.Status = PurchaseRequestConstants.Rejected;
            purchaseRequest.ReasonForRejection = command.Reason;
            _ = await _dbContext.SaveChangesAsync();
        }
    }
}
