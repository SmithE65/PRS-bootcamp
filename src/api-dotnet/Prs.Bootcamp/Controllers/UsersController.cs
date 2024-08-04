using Microsoft.AspNetCore.Mvc;
using Prs.Bootcamp.Data;
using Prs.Bootcamp.Data.Models;
using Prs.Bootcamp.Models;

namespace Prs.Bootcamp.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UsersController : ControllerBase
{
    private readonly PrsDbContext _dbContext;

    public UsersController(PrsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public ActionResult Add(User user)
    {
        if (ModelState.IsValid)
        {
            _dbContext.Users.Add(user);
            int numChanges = _dbContext.SaveChanges();
            return Ok(new Msg { Result = "Success", Message = $"{numChanges} record(s) added." });
        }

        return BadRequest(new Msg { Result = "Error", Message = "Add: ModelState invalid" });
    }

    [HttpGet]
    public ActionResult Get(int? id)
    {
        if (id == null || id <= 0)
        {
            return BadRequest(new Msg { Result = "Error", Message = "Get: id either null or invalid" });
        }

        var user = _dbContext.Users.Find(id);

        if (user == null)
        {
            return BadRequest(new Msg { Result = "Error", Message = $"Get: invalid user id: {id}." });
        }

        return Ok(user);
    }

    [HttpGet]
    public ActionResult List()
    {
        return Ok(_dbContext.Users.ToList());
    }

    [HttpPost]
    public ActionResult Login(string UserName, string Password)
    {
        return Ok(_dbContext.Users.Where(u => u.UserName == UserName && u.Password == Password).ToList());
    }

    [HttpDelete]
    public ActionResult Remove(int? id)
    {
        if (id == null || id <= 0)
        {
            return BadRequest(new Msg { Result = "Error", Message = "Remove: id either null or invalid" });
        }

        var user = _dbContext.Users.Find(id);

        if (user == null)
        {
            return BadRequest(new Msg { Result = "Error", Message = "Remove: invalid user id." });
        }

        _dbContext.Users.Remove(user);
        int numChanges = _dbContext.SaveChanges();

        return Ok(new Msg { Result = "Success", Message = $"{numChanges} record(s) removed." });
    }

    [HttpPost]
    public ActionResult Update(User user)
    {
        if (user == null)
        {
            return BadRequest(new Msg { Result = "Error", Message = "Update: cannot be null." });
        }

        var dbUser = _dbContext.Users.Find(user.Id);

        if (dbUser == null)
        {
            return BadRequest(new Msg { Result = "Error", Message = $"Update: invalid id: {user.Id}" });
        }
        dbUser.Copy(user);

        int numChanges = 0;
        if (ModelState.IsValid)
        {
            numChanges = _dbContext.SaveChanges();
            return Ok(new Msg { Result = "Success", Message = $"{numChanges} record(s) updated." });
        }

        return BadRequest(new Msg { Result = "Error", Message = $"ModelState invalid; {numChanges} record(s) updated." });
    }
}
