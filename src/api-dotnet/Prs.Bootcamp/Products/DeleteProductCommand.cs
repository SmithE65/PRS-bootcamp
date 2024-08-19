using Prs.Bootcamp.Data;

namespace Prs.Bootcamp.Products;

public class DeleteProductCommand(int id) : ICommand
{
    public int Id { get; } = id;
}
