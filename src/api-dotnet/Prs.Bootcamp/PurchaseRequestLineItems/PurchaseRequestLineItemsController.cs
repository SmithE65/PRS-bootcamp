using Microsoft.AspNetCore.Mvc;
using Prs.Bootcamp.Data;
using Prs.Bootcamp.Data.Models;

namespace Prs.Bootcamp.PurchaseRequestLineItems;

[Route("api/[controller]")]
[ApiController]
public class PurchaseRequestLineItemsController : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<PurchaseRequestLineItem>> GetPurchaseRequestLineItemAsync(
        [FromServices] IQueryHandler<GetPurchaseRequestLineItemQuery, PurchaseRequestLineItem?> handler, 
        int id)
    {
        var purchaseRequestLineItem = await handler.HandleAsync(new GetPurchaseRequestLineItemQuery(id));
        return purchaseRequestLineItem is null ? NotFound() : Ok(purchaseRequestLineItem);
    }

    [HttpPost]
    public async Task<ActionResult<PurchaseRequestLineItem>> CreatePurchaseRequestLineItemAsync(
        [FromServices] ICommandHandler<CreatePurchaseRequestLineItemCommand> handler,
        PurchaseRequestLineItem purchaseRequestLineItem)
    {
        await handler.HandleAsync(new CreatePurchaseRequestLineItemCommand(purchaseRequestLineItem));
        return CreatedAtAction(nameof(GetPurchaseRequestLineItemAsync), new { id = purchaseRequestLineItem.Id }, purchaseRequestLineItem);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PurchaseRequestLineItem>> UpdatePurchaseRequestLineItemAsync(
        [FromServices] ICommandHandler<UpdatePurchaseRequestLineItemCommand> handler,
        int id, PurchaseRequestLineItem purchaseRequestLineItem)
    {
        if (id != purchaseRequestLineItem.Id)
        {
            return BadRequest();
        }
        await handler.HandleAsync(new UpdatePurchaseRequestLineItemCommand(purchaseRequestLineItem));
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<PurchaseRequestLineItem>> DeletePurchaseRequestLineItemAsync(
        [FromServices] ICommandHandler<DeletePurchaseRequestLineItemCommand> handler,
        int id)
    {
        await handler.HandleAsync(new DeletePurchaseRequestLineItemCommand(id));
        return NoContent();
    }
}
