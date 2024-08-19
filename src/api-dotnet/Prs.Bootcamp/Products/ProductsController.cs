using Microsoft.AspNetCore.Mvc;
using Prs.Bootcamp.Data;
using Prs.Bootcamp.Data.Models;

namespace Prs.Bootcamp.Products;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    // GET: api/Products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts(
        [FromServices] IQueryHandler<GetProductsQuery, IEnumerable<Product>> queryHandler)
    {
        var products = await queryHandler.HandleAsync(new GetProductsQuery());
        return Ok(products);
    }

    // GET: api/Products/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(
        [FromServices] IQueryHandler<GetProductQuery, Product?> queryHandler,
        int id)
    {
        var query = new GetProductQuery(id);
        var product = await queryHandler.HandleAsync(query);

        return product is null ? NotFound() : Ok(product);
    }

    // PUT: api/Products/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(
        [FromServices] ICommandHandler<UpdateProductCommand> commandHandler,
        int id, Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }

        var command = new UpdateProductCommand(id, product);
        await commandHandler.HandleAsync(command);

        return NoContent();
    }

    // POST: api/Products
    [HttpPost]
    public async Task<ActionResult<Product>> PostProduct(
        [FromServices] ICommandHandler<CreateProductCommand> commandHandler,
        Product product)
    {
        var command = new CreateProductCommand(product);
        await commandHandler.HandleAsync(command);

        return CreatedAtAction("GetProduct", new { id = product.Id }, product);
    }

    // DELETE: api/Products/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(
        [FromServices] ICommandHandler<DeleteProductCommand> commandHandler,
        int id)
    {
        var command = new DeleteProductCommand(id);
        await commandHandler.HandleAsync(command);

        return NoContent();
    }
}
