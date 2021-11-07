namespace Prs.Bootcamp.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class VendorsController : ControllerBase
{
    private readonly PrsDbContext _dbContext;

    public VendorsController(PrsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public ActionResult Add(Vendor vendor)
    {
        if (ModelState.IsValid)
        {
            _dbContext.Vendors.Add(vendor);
            int numChanges = _dbContext.SaveChanges();
            return Ok(new Msg { Result = "Success", Message = $"{numChanges} record(s) added." });
        }

        return BadRequest(new Msg { Result = "Error", Message = "ModelState invalid" });
    }

    [HttpGet]
    public ActionResult Get(int? id)
    {
        if (id == null)
        {
            return BadRequest(new Msg { Result = "Failed", Message = "ID is null" });
        }

        var vendor = _dbContext.Vendors.Find(id);

        if (vendor == null)
        {
            return BadRequest(new Msg { Result = "Failed", Message = $"No user found with id: {id}." });
        }

        return Ok(vendor);
    }

    [HttpGet]
    public ActionResult List()
    {
        return Ok(_dbContext.Vendors.ToList());
    }

    [HttpDelete]
    public ActionResult Remove(int? id)
    {
        if (id == null || id <= 0)
        {
            return BadRequest(new Msg { Result = "Error", Message = "id either null or invalid" });
        }

        var vendor = _dbContext.Vendors.Find(id);

        if (vendor == null)
        {
            return BadRequest(new Msg { Result = "Error", Message = "Invalid user id." });
        }

        _dbContext.Vendors.Remove(vendor);
        int numChanges = _dbContext.SaveChanges();

        return Ok(new Msg { Result = "Success", Message = $"{numChanges} record(s) removed." });
    }

    [HttpPost]
    public ActionResult Update(Vendor vendor)
    {
        if (vendor == null)
        {
            return BadRequest(new Msg { Result = "Error", Message = "Update: vendor cannot be null." });
        }

        var dbVendor = _dbContext.Vendors.Find(vendor.Id);

        if (dbVendor == null)
        {
            return BadRequest(new Msg { Result = "Error", Message = $"Update: invalid id: {vendor.Id}" });
        }
        dbVendor.Copy(vendor);

        int numChanges = 0;
        if (ModelState.IsValid)
        {
            numChanges = _dbContext.SaveChanges();
            return Ok(new Msg { Result = "Success", Message = $"{numChanges} record(s) updated." });
        }

        return BadRequest(new Msg { Result = "Error", Message = $"ModelState invalid; {numChanges} record(s) updated." });
    }
}
