using Prs.Bootcamp.Data;

namespace Prs.Bootcamp.PurchaseRequests;

public class ReadyForReviewCommand(int id) : ICommand
{
    public int Id { get; } = id;
}
