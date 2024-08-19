using Microsoft.EntityFrameworkCore;
using Prs.Bootcamp.Data;

namespace Prs.Bootcamp.Products;

public class UpdateProductCommandHandler(PrsDbContext dbContext) : ICommandHandler<UpdateProductCommand>
{
    public async Task HandleAsync(UpdateProductCommand command)
    {
        dbContext.Entry(command.Product).State = EntityState.Modified;
        _ = await dbContext.SaveChangesAsync();
    }
}
