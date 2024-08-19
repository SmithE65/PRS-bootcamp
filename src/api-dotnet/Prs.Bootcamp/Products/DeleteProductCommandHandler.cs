using Prs.Bootcamp.Data;

namespace Prs.Bootcamp.Products;

public class DeleteProductCommandHandler(PrsDbContext dbContext) : ICommandHandler<DeleteProductCommand>
{
    public async Task HandleAsync(DeleteProductCommand command)
    {
        var product = await dbContext.Products.FindAsync(command.Id);

        if (product is not null)
        {
            _ = dbContext.Products.Remove(product);
            _ = await dbContext.SaveChangesAsync(); 
        }
    }
}
