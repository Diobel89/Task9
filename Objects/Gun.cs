namespace Task9.Objects
{
    public class Gun
    {
        public string Name { get; set; }
        public int Caliber { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public int HP { get; set; }
        public bool State { get; set; } // true = nie uszkodzona, false = zniszczona, zniszczona gdy HP = 0
    }
}
