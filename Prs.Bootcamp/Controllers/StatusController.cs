namespace Prs.Bootcamp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatusController : ControllerBase
{
    private readonly PrsDbContext _dbContext;

    public StatusController(PrsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ActionResult Add(Status status)
    {
        if (ModelState.IsValid)
        {
            _dbContext.Status.Add(status);
            int numChanges = _dbContext.SaveChanges();
            return Ok(new Msg { Result = "Success", Message = $"{numChanges} record(s) added." });
        }

        return BadRequest(new Msg { Result = "Error", Message = "ModelState invalid" });
    }

    public ActionResult Get(int? id)
    {
        if (id == null)
        {
            return BadRequest(new Msg { Result = "Failed", Message = "ID is null" });
        }

        var status = _dbContext.Status.Find(id);

        if (status == null)
        {
            return BadRequest(new Msg { Result = "Failed", Message = $"No user found with id: {id}." });
        }

        return Ok(status);
    }

    public ActionResult GetByDesc(string desc)
    {
        return Ok(_dbContext.Status.Where(s => s.Description == desc).ToList());
    }

    public ActionResult List()
    {
        return Ok(_dbContext.Status.ToList());
    }

    public ActionResult Remove(int? id)
    {
        if (id == null || id <= 0)
        {
            return BadRequest(new Msg { Result = "Error", Message = "id either null or invalid" });
        }

        var status = _dbContext.Status.Find(id);

        if (status == null)
        {
            return BadRequest(new Msg { Result = "Error", Message = "Invalid status id." });
        }

        _dbContext.Status.Remove(status);
        int numChanges = _dbContext.SaveChanges();

        return Ok(new Msg { Result = "Success", Message = $"{numChanges} record(s) removed." });
    }

    public ActionResult Update(Status status)
    {
        if (status == null)
        {
            return BadRequest(new Msg { Result = "Error", Message = "Update: status cannot be null." });
        }

        var dbStatus = _dbContext.Status.Find(status.Id);

        if (dbStatus == null)
        {
            return BadRequest(new Msg { Result = "Error", Message = $"Update: invalid id: {status.Id}" });
        }
        dbStatus.Copy(status);

        int numChanges = 0;
        if (ModelState.IsValid)
        {
            numChanges = _dbContext.SaveChanges();
            return Ok(new Msg { Result = "Success", Message = $"{numChanges} record(s) updated." });
        }

        return BadRequest(new Msg { Result = "Error", Message = $"ModelState invalid; {numChanges} record(s) updated." });
    }
}
