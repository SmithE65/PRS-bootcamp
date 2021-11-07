﻿namespace Prs.Bootcamp.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class HomeController : Controller
{
    [HttpGet]
    public ActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public ActionResult About()
    {
        ViewBag.Message = "Your application description page.";

        return View();
    }

    [HttpGet]
    public ActionResult Contact()
    {
        ViewBag.Message = "Your contact page.";

        return View();
    }
}
