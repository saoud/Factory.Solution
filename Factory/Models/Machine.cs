using System.Collections.Generic;

namespace Factory.Models
{
  public class Machine
  {
    public Machine()
    {
      MachineEngineers = new HashSet<MachineEngineer>();
    }
    public string Name { get; set; }
    public int MachineId { get; set; }
    public virtual ICollection<MachineEngineer> MachineEngineers { get; set; }
  }
}