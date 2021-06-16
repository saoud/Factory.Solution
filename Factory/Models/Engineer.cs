using System.Collections.Generic;

namespace Factory.Models
{
  public class Engineer
  {
    public Engineer()
    {
      this.JoinEntities = new HashSet<MachineEngineer>();
    }

    public int EngineerId { get; set; }
    public string EngineerDetails { get; set; }
    public virtual ICollection<MachineEngineer> JoinEntities { get; set; } //unsure if i need a setter here
  }
}