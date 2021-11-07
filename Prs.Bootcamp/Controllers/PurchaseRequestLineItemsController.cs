namespace Prs.Bootcamp.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class PurchaseRequestLineItemsController : ControllerBase
{
    private readonly PrsDbContext _dbContext;

    public PurchaseRequestLineItemsController(PrsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Updates the total column in a purchase request with given id
    /// </summary>
    /// <param name="id">PurchaseRequest.Id</param>
    /// <returns>JSON indicating success or failure</returns>
    [HttpPost]
    public ActionResult UpdateTotal(int? id)
    {
        // check for valid id
        if (id == null || id <= 0)
        {
            return BadRequest(new Msg { Result = "Error", Message = "Invalid id." });
        }

        // try to find a request
        var purchaseRequest = _dbContext.PurchaseRequests.Find(id);

        // check and see if we got a request
        if (purchaseRequest == null)
        {
            return BadRequest(new Msg { Result = "Error", Message = $"No PurchaseRequest found for id: {id}" });
        }

        // get all lineitems attached to the purchase request
        var lineItems = _dbContext.PurchaseRequestLineItems.Where(p => p.PurchaseRequestId == purchaseRequest.Id).ToList();

        // sum the subtotals for each lineitem
        decimal total = 0;
        foreach (var item in lineItems)
        {
            // entity framework has been returning inconsistent results and this is my workaround
            if (item.ProductNavigation == null)
            {
                item.ProductNavigation = _dbContext.Products.Find(item.ProductId);
            }

            // if we still don't have a product
            if (item.ProductNavigation == null)
            {
                return BadRequest(new Msg { Result = "Error", Message = "UpdateTotal: invalid ProductId." });
            }

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

    [HttpPost]
    public ActionResult Add(PurchaseRequestLineItem purchaseRequestLineItem)
    {
        if (purchaseRequestLineItem.PurchaseRequestId <= 0 || purchaseRequestLineItem.ProductId <= 0)
        {
            return BadRequest(new Msg { Result = "Error", Message = "LineItem Add: invalid foreign key." });
        }
        if (ModelState.IsValid)
        {
            _dbContext.PurchaseRequestLineItems.Add(purchaseRequestLineItem);
            int numChanges = _dbContext.SaveChanges();
            UpdateTotal(purchaseRequestLineItem.PurchaseRequestId);
            return Ok(new Msg { Result = "Success", Message = $"{numChanges} record(s) added." });
        }

        return BadRequest(new Msg { Result = "Error", Message = "ModelState invalid" });
    }

    [HttpGet]
    public ActionResult Get(int? id)
    {
        if (id == null)
        {
            return BadRequest(new Msg { Result = "Failed", Message = "ID is null" }); // Why is this 'Failed' instead of 'Error'?
        }

        PurchaseRequestLineItem? purchaseRequestLine = _dbContext.PurchaseRequestLineItems.Find(id);

        if (purchaseRequestLine == null)
        {
            return BadRequest(new Msg { Result = "Failed", Message = $"No user found with id: {id}." });
        }

        return Ok(purchaseRequestLine);
    }

    [HttpGet]
    public ActionResult List()
    {
        return Ok(_dbContext.PurchaseRequestLineItems.ToList());
    }

    [HttpDelete]
    public ActionResult Remove(int? id)
    {
        if (id == null || id <= 0)
        {
            return BadRequest(new Msg { Result = "Error", Message = "id either null or invalid" });
        }

        PurchaseRequestLineItem? purchaseRequestLine = _dbContext.PurchaseRequestLineItems.Find(id);

        if (purchaseRequestLine == null)
        {
            return BadRequest(new Msg { Result = "Error", Message = "Invalid prli id." });
        }

        int prid = purchaseRequestLine.PurchaseRequestId;
        _dbContext.PurchaseRequestLineItems.Remove(purchaseRequestLine);
        int numChanges = _dbContext.SaveChanges();
        UpdateTotal(prid);

        return Ok(new Msg { Result = "Success", Message = $"{numChanges} record(s) removed." });
    }

    [HttpPost]
    public ActionResult Update(PurchaseRequestLineItem purchaseRequestLineItem)
    {
        if (purchaseRequestLineItem == null)
        {
            return BadRequest(new Msg { Result = "Error", Message = "Update: prli cannot be null." });
        }

        PurchaseRequestLineItem? dbPurchaseRequest = _dbContext.PurchaseRequestLineItems.Find(purchaseRequestLineItem.Id);

        if (dbPurchaseRequest == null)
        {
            return BadRequest(new Msg { Result = "Error", Message = $"Update: invalid id: {purchaseRequestLineItem.Id}" });
        }
        dbPurchaseRequest.Copy(purchaseRequestLineItem);

        int numChanges = 0;
        if (ModelState.IsValid)
        {
            numChanges = _dbContext.SaveChanges();
            UpdateTotal(purchaseRequestLineItem.PurchaseRequestId);
            return Ok(new Msg { Result = "Success", Message = $"{numChanges} record(s) updated." });
        }

        return BadRequest(new Msg { Result = "Error", Message = $"ModelState invalid; {numChanges} record(s) updated." });
    }
}
