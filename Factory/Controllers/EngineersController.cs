using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Factory.Models;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;

    public EngineersController(FactoryContext db)
    {
      _db = db;
    }

    public List<Engineer> AllEngineers() => _db.Engineers.ToList();
    public Engineer FindEngineer(int id) => _db.Engineers
      .Include(engineer => engineer.MachineEngineers)
      .ThenInclude(join => join.Machine)
      .FirstOrDefault(engineer => engineer.EngineerId == id);

    public void CreateNewEngineerMachine(int machineId, int engineerId) => _db.MachineEngineers.Add(new MachineEngineer() { MachineId = machineId, EngineerId = engineerId });

    public ActionResult Index() => View(AllEngineers());
    public ActionResult Create()
    {
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer e, int MachineId)
    {
      _db.Engineers.Add(e);
      _db.SaveChanges();
      if (MachineId != 0)
      {
        CreateNewEngineerMachine(MachineId, e.EngineerId);
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id) => View(FindEngineer(id));
    public ActionResult Edit(int id)
    {
      var thisEngineer = FindEngineer(id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(thisEngineer);
    }
    [HttpPost]
    public ActionResult Edit(Engineer e)
    {
      _db.Entry(e).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id) => View(FindEngineer(id));
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      _db.Engineers.Remove(thisEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}