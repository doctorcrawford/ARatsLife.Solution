using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ARatsLife.Models;
using System.Collections.Generic;
using System.Linq;

namespace ARatsLife.Models;

public class ChoicesController : Controller
{
  public readonly ARatsLifeContext _db;

  public ChoicesController(ARatsLifeContext db)
  {
    _db = db;
  }

  public ActionResult Create(int id)
  {
    ViewBag.Plotpoint = _db.Plotpoints.FirstOrDefault(plotpoint => plotpoint.PlotpointId == id);
    ViewBag.PlotpointId = new SelectList(_db.Plotpoints, "PlotpointId", "Title");
    // ViewBag.PlotpointId = _db.Plotpoints.FirstOrDefault(plotpoint => plotpoint.PlotpointId == id);
    return View();
  }

  [HttpPost]
  public ActionResult Create(Choice choice)
  {
    _db.Choices.Add(choice);
    _db.SaveChanges();
    return RedirectToAction("Index", "PlotPoints");
  }
}