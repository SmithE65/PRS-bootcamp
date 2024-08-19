using Microsoft.EntityFrameworkCore;
using Prs.Bootcamp.Data;

namespace Prs.Bootcamp.PurchaseRequests;

public class UpdatePurchaseRequestCommandHandler(PrsDbContext dbContext) : ICommandHandler<UpdatePurchaseRequestCommand>
{
    private readonly PrsDbContext _dbContext = dbContext;

    public async Task HandleAsync(UpdatePurchaseRequestCommand command)
    {
        _dbContext.Entry(command.PurchaseRequest).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}
