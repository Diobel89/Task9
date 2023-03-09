﻿namespace Task9.Models
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
        public int MaxTurrets()
        {
            return 4;
        }
        public int MaxArmor()
        {
            return 50;
        }
        public int MaxHP()
        {
            return 255;
        }
    }
}
