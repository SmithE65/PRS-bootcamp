using Prs.Bootcamp.Data;

namespace Prs.Bootcamp.PurchaseRequests;

public class ReadyForReviewCommandHandler(PrsDbContext dbContext) : ICommandHandler<ReadyForReviewCommand>
{
    private readonly PrsDbContext _dbContext = dbContext;

    public async Task HandleAsync(ReadyForReviewCommand command)
    {
        var purchaseRequest = await _dbContext.PurchaseRequests.FindAsync(command.Id);

        if (purchaseRequest is not null)
        {
            if (purchaseRequest.Total > PurchaseRequestConstants.AutoApproveMax)
            {
                purchaseRequest.Status = PurchaseRequestConstants.Review; 
            }
            else
            {
                purchaseRequest.Status = PurchaseRequestConstants.Approved;
            }

            _ = await _dbContext.SaveChangesAsync();
        }
    }
}
