using Microsoft.EntityFrameworkCore;

namespace Task9.Models
{
    public class Ship
    {
        public int Id { get; set; }
        public int GunId { get; set; }
        public int FactionId { get; set; }
        public string Name { get; set; }
        public int Turrets { get; set; }
        public int Armor { get; set; }
        public int HP { get; set; }
        public int TypeId { get; set; }
        public int GetMaxTurrets()
        {
            return 4;
        }
        public int GetMaxArmor()
        {
            return 50;
        }
        public int GetMaxHP()
        {
            return 255;
        }
    }
}
