using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Factory.Models;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;
    public MachinesController(FactoryContext db)
    {
      _db = db;
    }

    public List<Machine> AllMachines() => _db.Machines.ToList();
    public Machine FindMachine(int id) => _db.Machines
    .Include(machine => machine.MachineEngineers)
      .ThenInclude(join => join.Engineer)
      .FirstOrDefault(machine => machine.MachineId == id);

    public ActionResult Index() => View(AllMachines());
    public ActionResult Create() => View();

    [HttpPost]
    public ActionResult Create(Machine m)
    {
      _db.Machines.Add(m);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id) => View(FindMachine(id));

    public ActionResult Edit(int id) => View(FindMachine(id));
    [HttpPost]
    public ActionResult Edit(Machine m)
    {
      _db.Entry(m).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id) => View(FindMachine(id));

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}