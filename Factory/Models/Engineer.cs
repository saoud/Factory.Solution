using System;
using System.Collections.Generic;

namespace Factory.Models
{
  public class Engineer
  {
    public Engineer()
    {
      MachineEngineers = new HashSet<MachineEngineer>();
    }
    public string Name { get; set; }
    public int EngineerId { get; set; }
    public DateTime DateHired { get; set; }

    public virtual ICollection<MachineEngineer> MachineEngineers { get; set; }
  }
}