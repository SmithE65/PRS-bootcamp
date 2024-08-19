using Prs.Bootcamp.Data;

namespace Prs.Bootcamp.Products;

public class CreateProductCommandHandler(PrsDbContext dbContext) : ICommandHandler<CreateProductCommand>
{
    public async Task HandleAsync(CreateProductCommand command)
    {
        _ = dbContext.Products.Add(command.Product);
        _ = await dbContext.SaveChangesAsync();
    }
}
