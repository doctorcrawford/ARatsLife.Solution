using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ARatsLife.Models;
using System.Collections.Generic;
using System.Linq;


namespace ARatsLife.Controllers;

public class PlotpointsController : Controller
{
  private readonly ARatsLifeContext _db;

  public PlotpointsController(ARatsLifeContext db)
  {
    _db = db;
  }

  public ActionResult Index()
  {
    List<Plotpoint> model = _db.Plotpoints.ToList();
    return View(model);
  }
  public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public ActionResult Create(Plotpoint plotpoint)
  {
    if (!ModelState.IsValid)
    {
      return View(plotpoint);
    }
    else
    {
      _db.Plotpoints.Add(plotpoint);
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }
  }

  public ActionResult Edit(int id)
  {
    Plotpoint thisPlotpoint = _db.Plotpoints.FirstOrDefault(plotpoint => plotpoint.PlotpointId == id);
    return View(thisPlotpoint);
  }

  [HttpPost]
  public ActionResult Edit(Plotpoint plotpoint)
  {
    _db.Plotpoints.Update(plotpoint);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }

  public ActionResult Details(int id)
  {
    Plotpoint plotpoint = _db.Plotpoints
                                        .Include(plotpoint => plotpoint.Choices)
                                        .FirstOrDefault(plotpoint => plotpoint.PlotpointId == id);
    return View(plotpoint);
  }

  public ActionResult Delete(int id)
  {
    Plotpoint plotpoint = _db.Plotpoints.FirstOrDefault(plotpoint => plotpoint.PlotpointId == id);
    return View(plotpoint);
  }

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    Plotpoint plotpoint = _db.Plotpoints.FirstOrDefault(plotpoint => plotpoint.PlotpointId == id);
    _db.Plotpoints.Remove(plotpoint);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }
}