namespace Task9.Models
{
    public class Gun
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public int Caliber { get; set; }
        public int Barrels { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public int HP { get; set; }
        public bool State { get; set; } // true = nie uszkodzona, false = zniszczona, zniszczona gdy HP = 0
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
        public int GetMaxId()
        {
            using (var db = new DatabaseContext())
            {
                return db.Guns.Count();
            }
        }
    }
}
