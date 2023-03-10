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
        //public int MaxSpeed { get; set; }
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
        public int GetMaxId()
        {
            using (var db = new DatabaseContext())
            {
                return db.Ships.Count();
            }
        }
        public Ship GetShip(int id)
        {
            Ship tempShip = new Ship { };
            using (var db = new DatabaseContext())
            {
                foreach (var ship in db.Ships)
                {
                    if (ship.Id == id)
                    {
                        tempShip = ship;
                    }
                }
            }
            return tempShip;
        }
    }
}
