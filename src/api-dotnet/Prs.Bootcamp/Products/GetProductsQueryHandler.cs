using Microsoft.EntityFrameworkCore;
using Prs.Bootcamp.Data;
using Prs.Bootcamp.Data.Models;

namespace Prs.Bootcamp.Products;

public class GetProductsQueryHandler(PrsDbContext dbContext) : IQueryHandler<GetProductsQuery, IEnumerable<Product>>
{
    public async Task<IEnumerable<Product>> HandleAsync(GetProductsQuery query)
    {
        return await dbContext.Products.ToListAsync();
    }
}
