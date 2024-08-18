using Microsoft.AspNetCore.Mvc;
using Prs.Bootcamp.Data;
using Prs.Bootcamp.Data.Models;
using Prs.Bootcamp.Models;

namespace Prs.Bootcamp.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class PurchaseRequestsController : ControllerBase
{
    private readonly PrsDbContext _dbContext;

    public PurchaseRequestsController(PrsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public class Cart
    {
        public PurchaseRequest? Request { get; set; }
        public List<PurchaseRequestLineItem>? LineItems { get; set; }
    }

    /// <summary>
    /// Sums all LineItems where PurchaseRequestId matches id
    /// </summary>
    /// <param name="id">PurchaseRequest Id</param>
    /// <returns>JSON formatted success or error messages.</returns>
    [HttpPost]
    public ActionResult UpdateTotal(int? id)
    {
        if (id == null || id <= 0)
        {
            return BadRequest(new Msg { Result = "Error", Message = "Invalid id." });
        }

        var purchaseRequest = _dbContext.PurchaseRequests.Find(id);

        if (purchaseRequest == null)
        {
            return BadRequest(new Msg { Result = "Error", Message = $"No PurchaseRequest found for id: {id}" });
        }

        var lineItems = _dbContext.PurchaseRequestLineItems.Where(p => p.PurchaseRequestId == purchaseRequest.Id).ToList();
        purchaseRequest.Total = lineItems.Sum(x => x.ProductNavigation?.Price * x.Quantity ?? -1);

        int numChanged = 0;
        if (ModelState.IsValid)
        {
            //_dbContext.Entry(purchaseRequest).State = System.Data.Entity.EntityState.Modified;
            numChanged = _dbContext.SaveChanges();
        }

        return Ok(new Msg { Result = "Success", Message = $"{numChanged} record(s) changed with total: {purchaseRequest.Total}" });
    }

    [HttpPost]
    public ActionResult Add(PurchaseRequest purchaseRequest)
    {
        if (ModelState.IsValid)
        {
            _dbContext.PurchaseRequests.Add(purchaseRequest);
            int numChanges = _dbContext.SaveChanges();
            return Ok(new Msg { Result = "Success", Message = $"{numChanges} record(s) added." });
        }

        return BadRequest(new Msg { Result = "Error", Message = "ModelState invalid" });
    }

    [HttpGet]
    public ActionResult Get(int? id)
    {
        if (id == null || id <= 0)
        {
            return BadRequest(new Msg { Result = "Error", Message = "Get: id either null or invalid" });
        }

        var purchaseRequest = _dbContext.PurchaseRequests.Find(id);

        if (purchaseRequest == null)
        {
            return BadRequest(new Msg { Result = "Error", Message = $"No user found with id: {id}." });
        }

        return Ok(purchaseRequest);
    }

    [HttpGet]
    public ActionResult GetCart(int? id)
    {
        if (id == null || id <= 0)
        {
            return BadRequest(new Msg { Result = "Error", Message = "GetCart: id either null or invalid" });
        }

        var pr = _dbContext.PurchaseRequests.Find(id);
        if (pr == null)
        {
            return BadRequest(new Msg { Result = "Error", Message = "GetCart: invalid request id." });
        }

        var lineitems = _dbContext.PurchaseRequestLineItems.Where(i => i.PurchaseRequestId == pr.Id).ToList();

        return Ok(new Cart { Request = pr, LineItems = lineitems });
    }

    /// <summary>
    /// Returns all purchase requests with the provided status ID
    /// </summary>
    /// <param name="id">Status ID</param>
    /// <returns>List of PurchaseRequest objects</returns>
    [HttpGet]
    public ActionResult GetByStatus(string? id)
    {
        return Ok(_dbContext.PurchaseRequests.Where(pr => pr.Status == id).ToList());
    }

    [HttpGet]
    public ActionResult GetByUser(int? id)
    {
        if (id == null || id <= 0)
        {
            return BadRequest(new Msg { Result = "Error", Message = "GetByUser: id either null or invalid" });
        }

        return Ok(_dbContext.PurchaseRequests.Where(r => r.UserId == id).ToList());
    }

    [HttpGet]
    public ActionResult GetItems(int? id)
    {
        if (id == null || id <= 0)
        {
            return BadRequest(new Msg { Result = "Error", Message = "GetItems: id either null or invalid" });
        }

        var items = _dbContext.PurchaseRequestLineItems.Where(li => li.PurchaseRequestId == id).ToList();

        return Ok(items);
    }

    [HttpGet]
    public ActionResult List()
    {
        return Ok(_dbContext.PurchaseRequests.ToList());
    }

    [HttpDelete]
    public ActionResult Remove(int? id)
    {
        if (id == null || id <= 0)
        {
            return BadRequest(new Msg { Result = "Error", Message = "id either null or invalid" });
        }

        var purchaseRequest = _dbContext.PurchaseRequests.Find(id);

        if (purchaseRequest == null)
        {
            return BadRequest(new Msg { Result = "Error", Message = "Invalid request id." });
        }

        _dbContext.PurchaseRequests.Remove(purchaseRequest);
        int numChanges = _dbContext.SaveChanges();

        return Ok(new Msg { Result = "Success", Message = $"{numChanges} record(s) removed." });
    }

    [HttpPost]
    public ActionResult Update(PurchaseRequest purchaseRequest)
    {
        if (purchaseRequest == null)
        {
            return BadRequest(new Msg { Result = "Error", Message = "Update: purchase req cannot be null." });
        }

        var dbPurchaseRequest = _dbContext.PurchaseRequests.Find(purchaseRequest.Id);

        if (dbPurchaseRequest == null)
        {
            return BadRequest(new Msg { Result = "Error", Message = $"Update: invalid id: {purchaseRequest.Id}" });
        }
        dbPurchaseRequest.Copy(purchaseRequest);

        int numChanges = 0;
        if (ModelState.IsValid)
        {
            numChanges = _dbContext.SaveChanges();
            return Ok(new Msg { Result = "Success", Message = $"{numChanges} record(s) updated." });
        }

        return BadRequest(new Msg { Result = "Error", Message = $"ModelState invalid; {numChanges} record(s) updated." });
    }

    [HttpPost]
    public ActionResult UpdateCart([FromBody] Cart cart)
    {
        if (cart.Request == null)
        {
            return BadRequest(new Msg { Result = "Error", Message = "Cart: null request." });
        }

        var pr = _dbContext.PurchaseRequests.Find(cart.Request.Id);
        if (pr == null)
        {
            return BadRequest(new Msg { Result = "Error", Message = "Cart: invalid Id." });
        }
        pr.Copy(cart.Request);
        pr.UserNavigation = null;

        if (cart.LineItems != null)
        {
            foreach (PurchaseRequestLineItem li in cart.LineItems)
            {
                var item = _dbContext.PurchaseRequestLineItems.Find(li.Id);
                if (item == null)
                {
                    _dbContext.PurchaseRequestLineItems.Add(li);
                }
                else
                {
                    item.Copy(li);
                }
            }
        }

        if (ModelState.IsValid)
        {
            var numChanges = _dbContext.SaveChanges();
            UpdateTotal(pr.Id);
            return Ok(new Msg { Result = "Success", Message = $"Cart: {numChanges} items updated." });
        }

        return BadRequest(new Msg { Result = "Error", Message = "Cart: ModelState invalid." });
    }
}
