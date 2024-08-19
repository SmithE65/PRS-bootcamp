using Prs.Bootcamp.Data;

namespace Prs.Bootcamp.PurchaseRequests;

public class CreatePurchaseRequestCommandHandler(PrsDbContext dbContext) : ICommandHandler<CreatePurchaseRequestCommand>
{
    private readonly PrsDbContext _dbContext = dbContext;

    public async Task HandleAsync(CreatePurchaseRequestCommand command)
    {
        _dbContext.PurchaseRequests.Add(command.PurchaseRequest);
        await _dbContext.SaveChangesAsync();
    }
}
