using Task9.Models;

namespace Task9.Functions.Simulation
{
    public class Fleet 
    {
        public List<Fleet> fleet1 = new List<Fleet>();
        public List<Fleet> fleet2 = new List<Fleet>();
        public Ship Ship { get; set; }
        public int TotalDamage { get; set; }
    }
}
