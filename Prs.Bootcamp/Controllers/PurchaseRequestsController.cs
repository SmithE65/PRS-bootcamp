namespace Prs.Bootcamp.Controllers;

[ApiController]
[Route("api/[controller]")]
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

        decimal total = 0;
        foreach (var item in lineItems)
        {
            total += item.ProductNavigation.Price * item.Quantity;
        }
        purchaseRequest.Total = total;

        int numChanged = 0;
        if (ModelState.IsValid)
        {
            //_dbContext.Entry(purchaseRequest).State = System.Data.Entity.EntityState.Modified;
            numChanged = _dbContext.SaveChanges();
        }

        return Ok(new Msg { Result = "Success", Message = $"{numChanged} record(s) changed with total: {total}" });
    }

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
    public ActionResult GetByStatus(int? id)
    {
        return Ok(_dbContext.PurchaseRequests.Where(pr => pr.StatusId == id).ToList());
    }

    public ActionResult GetByUser(int? id)
    {
        if (id == null || id <= 0)
        {
            return BadRequest(new Msg { Result = "Error", Message = "GetByUser: id either null or invalid" });
        }

        return Ok(_dbContext.PurchaseRequests.Where(r => r.UserId == id).ToList());
    }

    public ActionResult GetItems(int? id)
    {
        if (id == null || id <= 0)
        {
            return BadRequest(new Msg { Result = "Error", Message = "GetItems: id either null or invalid" });
        }

        var items = _dbContext.PurchaseRequestLineItems.Where(li => li.PurchaseRequestId == id).ToList();

        return Ok(items);
    }

    public ActionResult List()
    {
        return Ok(_dbContext.PurchaseRequests.ToList());
    }

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
        pr.StatusNavigation = null;
        pr.UserNavigation = null;

        if (cart.LineItems != null)
        {
            PurchaseRequestLineItem item = null;
            foreach (PurchaseRequestLineItem li in cart.LineItems)
            {
                item = _dbContext.PurchaseRequestLineItems.Find(li.Id);
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

        int numChanges = 0;
        if (ModelState.IsValid)
        {
            numChanges = _dbContext.SaveChanges();
            UpdateTotal(pr.Id);
            return Ok(new Msg { Result = "Success", Message = $"Cart: {numChanges} items updated." });
        }

        return BadRequest(new Msg { Result = "Error", Message = "Cart: ModelState invalid." });
    }
}
