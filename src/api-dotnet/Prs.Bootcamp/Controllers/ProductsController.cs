using Microsoft.AspNetCore.Mvc;
using Prs.Bootcamp.Data;
using Prs.Bootcamp.Data.Models;
using Prs.Bootcamp.Models;

namespace Prs.Bootcamp.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ProductsController : ControllerBase
{
    private readonly PrsDbContext _dbContext;

    public ProductsController(PrsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public ActionResult Add([FromBody] Product product)
    {
        if (ModelState.IsValid)
        {
            _dbContext.Products.Add(product);
            int numChanges = _dbContext.SaveChanges();
            return Ok(new Msg { Result = "Success", Message = $"{numChanges} record(s) added." });
        }

        return BadRequest("ModelState invalid");
    }

    [HttpGet]
    public ActionResult Get(int? id)
    {
        if (id == null)
        {
            return BadRequest(new Msg { Result = "Failed", Message = "ID is null" });
        }

        Product? product = _dbContext.Products.Find(id);

        if (product == null)
        {
            return BadRequest(new Msg { Result = "Failed", Message = $"No user found with id: {id}." });
        }

        return Ok(product);
    }

    [HttpGet]
    public ActionResult List()
    {
        return Ok(_dbContext.Products.ToList());
    }

    [HttpDelete]
    public ActionResult Remove(int? id)
    {
        if (id == null || id <= 0)
        {
            return BadRequest("id either null or invalid");
        }

        Product? product = _dbContext.Products.Find(id);

        if (product == null)
        {
            return BadRequest("Invalid user id.");
        }

        _dbContext.Products.Remove(product);
        int numChanges = _dbContext.SaveChanges();

        return Ok(new Msg { Result = "Success", Message = $"{numChanges} record(s) removed." });
    }

    [HttpPost]
    public ActionResult Update(Product product)
    {
        if (product == null)
        {
            return BadRequest("Update: product cannot be null.");
        }

        Product? dbProduct = _dbContext.Products.Find(product.Id);

        if (dbProduct == null)
        {
            return BadRequest($"Update: invalid id: {product.Id}");
        }
        dbProduct.Copy(product);

        int numChanges = 0;
        if (ModelState.IsValid)
        {
            numChanges = _dbContext.SaveChanges();
            return Ok(new Msg { Result = "Success", Message = $"{numChanges} record(s) updated." });
        }

        return BadRequest($"ModelState invalid; {numChanges} record(s) updated.");
    }
}
