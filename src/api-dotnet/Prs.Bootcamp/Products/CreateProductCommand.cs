using Prs.Bootcamp.Data;
using Prs.Bootcamp.Data.Models;

namespace Prs.Bootcamp.Products;

public class CreateProductCommand(Product product) : ICommand
{
    public Product Product { get; } = product;
}
