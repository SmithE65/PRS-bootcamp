using Prs.Bootcamp.Data;
using Prs.Bootcamp.Data.Models;

namespace Prs.Bootcamp.Products;

public class GetProductQuery(int id) : IQuery<Product?>
{
    public int Id { get; } = id;
}
