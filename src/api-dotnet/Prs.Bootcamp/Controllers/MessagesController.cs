using Microsoft.AspNetCore.Mvc;
using Prs.Bootcamp.Data;
using Prs.Bootcamp.Data.Models;
using Prs.Bootcamp.Models;

namespace Prs.Bootcamp.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class MessagesController : Controller
{
    private readonly PrsDbContext _dbContext;

    public MessagesController(PrsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public ActionResult Add([FromBody] Message message)
    {
        if (ModelState.IsValid)
        {
            _dbContext.Messages.Add(message);
            int numChanges = _dbContext.SaveChanges();
            return Ok(new Msg { Result = "Success", Message = $"{numChanges} record(s) added." });
        }

        return BadRequest(new Msg { Result = "Error", Message = "ModelState invalid." });
    }

    [HttpGet]
    public ActionResult Get(int? id)
    {
        if (id == null || id <= 0)
        {
            return BadRequest(new Msg { Result = "Error", Message = "Get: id invalid or null." });
        }

        Message? message = _dbContext.Messages.Find(id);
        if (message == null)
        {
            return BadRequest(new Msg { Result = "Error", Message = "Get: id invalid." });
        }

        return Ok(message);
    }

    [HttpGet]
    public ActionResult GetByUser(int? id)
    {
        if (id == null || id <= 0)
        {
            return BadRequest(new Msg { Result = "Error", Message = "GetByUser: id invalid or null." });
        }

        User? user = _dbContext.Users.Find(id);
        if (user == null)
        {
            return BadRequest(new Msg { Result = "Error", Message = "GetByUser: id invalid." });
        }

        return Ok(_dbContext.Messages.Where(m => m.ReceiverNavigation!.Id == user.Id));
    }

    [HttpGet]
    public ActionResult List()
    {
        return Ok(_dbContext.Messages.ToList());
    }

    [HttpDelete]
    public ActionResult Remove(int? id)
    {
        if (id == null || id <= 0)
        {
            return BadRequest(new Msg { Result = "Error", Message = "Remove: id invalid or null." });
        }

        Message? message = _dbContext.Messages.Find(id);
        if (message == null)
        {
            return BadRequest(new Msg { Result = "Error", Message = "Remove: id invalid or null." });
        }

        _dbContext.Messages.Remove(message);
        int numChanges = _dbContext.SaveChanges();

        return Ok(new Msg { Result = "Success", Message = $"{numChanges} record(s) removed." });
    }

    [HttpPost]
    public ActionResult Update([FromBody] Message message)
    {
        if (message == null)
        {
            return BadRequest(new Msg { Result = "Error", Message = "Update: null message." });
        }

        Message? dbMessage = _dbContext.Messages.Find(message.Id);
        if (dbMessage == null)
        {
            return BadRequest(new Msg { Result = "Error", Message = "Update: invalid id" });
        }

        dbMessage.Copy(message);

        if (ModelState.IsValid)
        {
            int numChanges = _dbContext.SaveChanges();
            return Ok(new Msg { Result = "Success", Message = $"{numChanges} record(s) updated." });
        }

        return BadRequest(new Msg { Result = "Error", Message = "Update: ModelState invalid." });
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _dbContext.Dispose();
        }
        base.Dispose(disposing);
    }
}
