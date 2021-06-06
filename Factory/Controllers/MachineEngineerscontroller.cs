using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Factory.Models;

namespace Factory.Controllers
{
  public class MachineEngineersController : Controller
  {
    private readonly FactoryContext _db;

    public MachineEngineersController(FactoryContext db)
    {
      _db = db;
    }
    public MachineEngineer FindMachineEngineer(int id) => _db.MachineEngineers
      .FirstOrDefault(me => me.MachineEngineerId == id);

    public MachineEngineer CheckEnrollment(int machineId, int engineerId) => _db.MachineEngineers
      .FirstOrDefault(me => (me.EngineerId == engineerId && me.EngineerId == machineId));

    public void CreateNewEngineerMachine(int machineId, int engineerId)
    {
      _db.MachineEngineers.Add(new MachineEngineer() { MachineId = machineId, EngineerId = engineerId });
      _db.SaveChanges();
    }

    [HttpPost]
    public ActionResult Delete(int id, string redirectTo)
    {
      var thisMachineEngineer = FindMachineEngineer(id);
      _db.MachineEngineers.Remove(thisMachineEngineer);
      _db.SaveChanges();
      int entityId = 0;
      if (redirectTo == "Machines") entityId = thisMachineEngineer.MachineId;
      if (redirectTo == "Engineers") entityId = thisMachineEngineer.EngineerId;

      return RedirectToAction("Edit", redirectTo, new { id = entityId });
    }


    [HttpPost]
    public ActionResult Create(int EngineerId, int MachineId, string redirectTo)
    {
      bool engineerCertifiedMachine = CheckEnrollment(MachineId, EngineerId) != null;
      if (MachineId != 0 && !engineerCertifiedMachine)
      {
        CreateNewEngineerMachine(MachineId, EngineerId);
      }
      int entityId = 0;
      if (redirectTo == "Machines") entityId = MachineId;
      if (redirectTo == "Engineers") entityId = EngineerId;
      return RedirectToAction("Edit", redirectTo, new { id = EngineerId });
    }
  }
}
