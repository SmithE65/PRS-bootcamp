using Microsoft.AspNetCore.Mvc;
using Prs.Bootcamp.Data;
using Prs.Bootcamp.Data.Models;

namespace Prs.Bootcamp.PurchaseRequests;

[Route("api/[controller]")]
[ApiController]
public class PurchaseRequestsController : ControllerBase
{
    // GET: api/PurchaseRequests
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PurchaseRequest>>> GetPurchaseRequests(
        [FromServices] IQueryHandler<GetPurchaseRequestsQuery, IEnumerable<PurchaseRequest>> queryHandler)
    {
        var purchaseRequests = await queryHandler.HandleAsync(new GetPurchaseRequestsQuery());
        return Ok(purchaseRequests);
    }

    // GET: api/PurchaseRequests/5
    [HttpGet("{id}")]
    public async Task<ActionResult<PurchaseRequest>> GetPurchaseRequest(
        [FromServices] IQueryHandler<GetPurchaseRequestQuery, PurchaseRequest?> queryHandler,
        int id)
    {
        var query = new GetPurchaseRequestQuery(id);
        var purchaseRequest = await queryHandler.HandleAsync(query);
        return purchaseRequest is null ? NotFound() : Ok(purchaseRequest);
    }

    // PUT: api/PurchaseRequests/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPurchaseRequest(
        [FromServices] ICommandHandler<UpdatePurchaseRequestCommand> commandHandler,
        int id, PurchaseRequest purchaseRequest)
    {
        if (id != purchaseRequest.Id)
        {
            return BadRequest();
        }

        var command = new UpdatePurchaseRequestCommand(id, purchaseRequest);
        await commandHandler.HandleAsync(command);
        return NoContent();
    }

    // POST: api/PurchaseRequests
    [HttpPost]
    public async Task<ActionResult<PurchaseRequest>> PostPurchaseRequest(
        [FromServices] ICommandHandler<CreatePurchaseRequestCommand> commandHandler,
        PurchaseRequest purchaseRequest)
    {
        var command = new CreatePurchaseRequestCommand(purchaseRequest);
        await commandHandler.HandleAsync(command);
        return CreatedAtAction("GetPurchaseRequest", new { id = purchaseRequest.Id }, purchaseRequest);
    }

    // DELETE: api/PurchaseRequests/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePurchaseRequest(
        [FromServices] ICommandHandler<DeletePurchaseRequestCommand> commandHandler,
        int id)
    {
        var command = new DeletePurchaseRequestCommand(id);
        await commandHandler.HandleAsync(command);
        return NoContent();
    }

    [HttpGet("review/{userId}")]
    public async Task<ActionResult<IEnumerable<PurchaseRequest>>> GetPurchaseRequestsForReview(
        [FromServices] IQueryHandler<GetPurchaseRequestsForReviewQuery, IEnumerable<PurchaseRequest>> queryHandler,
        int userId)
    {
        var query = new GetPurchaseRequestsForReviewQuery(userId);
        var purchaseRequests = await queryHandler.HandleAsync(query);
        return Ok(purchaseRequests);
    }

    [HttpPut("review/{id}")]
    public async Task<IActionResult> ReviewPurchaseRequest(
        [FromServices] ICommandHandler<ReadyForReviewCommand> commandHandler,
        int id)
    {
        var command = new ReadyForReviewCommand(id);
        await commandHandler.HandleAsync(command);

        return NoContent();
    }

    [HttpPut("approve/{id}")]
    public async Task<IActionResult> ApprovePurchaseRequest(
        [FromServices] ICommandHandler<ApprovePurchaseRequestCommand> commandHandler,
        int id)
    {
        var command = new ApprovePurchaseRequestCommand(id);
        await commandHandler.HandleAsync(command);
        return NoContent();
    }

    [HttpPut("reject/{id}")]
    public async Task<IActionResult> RejectPurchaseRequest(
        [FromServices] ICommandHandler<RejectPurchaseRequestCommand> commandHandler,
        int id, string reason)
    {
        var command = new RejectPurchaseRequestCommand(id, reason);
        await commandHandler.HandleAsync(command);
        return NoContent();
    }
}
