using Prs.Bootcamp.Data;
using Prs.Bootcamp.Data.Models;

namespace Prs.Bootcamp.Products;

public class UpdateProductCommand(int id, Product product) : ICommand
{
    public int Id { get; } = id;
    public Product Product { get; } = product;
}
