namespace Task9.Models
{
    public class Gun
    {
        public int Id { get; set; }
        public int IdGunType { get; set; }
        //public int IdAmmo { get; set; } // na przyszłość
        public string Name { get; set; }
        public int Barrels { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public int HP { get; set; }
        public bool State { get; set; } // true = nie uszkodzona, false = zniszczona, zniszczona gdy HP = 0
        public int TypeId { get; set; } // Aircraft (na przyszłość), Main Gun, Secondary Gun (na przyszłość), Torpedo (na przyszłość), Anti-air (na przyszłość)
        //public int Caliber { get; set; } //na przyszłość
        public int Reload { get; set; }
        //public int AircraftId {get; set;} // na przyszłość
        //public int ShellId { get; set; } // na przyszłość
        //public int ReloadTime {get; set;} // na przyszłość
        public int GetMaxArmor()
        {
            return 50;
        }
        public int GetMaxHP()
        {
            return 255;
        }
        public int GetMaxDamage()
        {
            return 255;
        }
        public int GetMaxBarrels()
        {
            return 3;
        }
    }
}
