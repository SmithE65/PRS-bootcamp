using Prs.Bootcamp.Data;
using Prs.Bootcamp.Data.Models;

namespace Prs.Bootcamp.Products;

public class GetProductQueryHandler(PrsDbContext dbContext) : IQueryHandler<GetProductQuery, Product?>
{
    public async Task<Product?> HandleAsync(GetProductQuery query)
    {
        return await dbContext.Products.FindAsync(query.Id);
    }
}
