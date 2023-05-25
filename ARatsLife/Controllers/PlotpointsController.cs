using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ARatsLife.Models;
using System.Collections.Generic;
using System.Linq;
using System;


namespace ARatsLife.Controllers;


public class PlotpointsController : Controller
{
  private readonly ARatsLifeContext _db;
  private readonly ARatsLifeContext _dbQuery;

  public PlotpointsController(ARatsLifeContext db)
  {
    _db = db;
    _dbQuery = db;
  }

  public static void Reorder(ARatsLifeContext db, Plotpoint plotpoint, int num)
  {
    var ppList = db.Plotpoints.ToList();
    if (ppList.Exists(x => x.StoryPosition == plotpoint.StoryPosition))
    {
      var greaterPlotpoints = db.Plotpoints
          .Where(row => row.StoryPosition >= plotpoint.StoryPosition)
          .ToList();

      foreach (var pp in greaterPlotpoints)
      {
        pp.StoryPosition += num;
        db.Plotpoints.Update(pp);
        db.SaveChanges();
      }
    }
  }

  public ActionResult Index()
  {
    List<Plotpoint> model = _db.Plotpoints.OrderBy(pp => pp.StoryPosition).ToList();
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
      Reorder(_db, plotpoint, 1);
      _db.Plotpoints.Add(plotpoint);
      _db.SaveChanges();
      return RedirectToAction("Index");
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
    var ppList = _db.Plotpoints.AsNoTracking().ToList();
    ppList.Remove(plotpoint);
    if (ppList.Exists(x => x.StoryPosition == plotpoint.StoryPosition))
    {
      var greaterPlotpoints = _db.Plotpoints
                                            .Where(row => row.StoryPosition >= plotpoint.StoryPosition)
                                            .ToList();
      greaterPlotpoints.Remove(plotpoint);
      foreach (var pp in greaterPlotpoints)
      {
        if(pp.PlotpointId != plotpoint.PlotpointId)
        {
        pp.StoryPosition += 1;
        _db.Plotpoints.Update(pp);
        }
      }
        _db.SaveChanges();
    }
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
    var plotpoint = _db.Plotpoints.FirstOrDefault(p => p.PlotpointId == id);
    Reorder(_db, plotpoint, -1);
    _db.Plotpoints.Remove(plotpoint);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }
}