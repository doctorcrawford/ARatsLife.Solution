using Microsoft.AspNetCore.Mvc;
using ARatsLife.Models;
using System.Collections.Generic;
using System.Linq;

namespace ARatsLife.Controllers
{
    public class HomeController : Controller
    {
      private readonly ARatsLifeContext _db;

      public HomeController(ARatsLifeContext db)
      {
        _db = db;
      }

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }
    }
}