using Task9.InputOutputSystem.Interface;
using Task9.Models;

namespace Task9.Validation.OnStart
{
    public class OnStartValidation
    {
        private readonly IOutput output;
        private DatabaseContext context;
        public OnStartValidation(IOutput output)
        {
            this.output = output;
            this.context = new DatabaseContext();
        }
        public void CheckIsDatabaseExistent()
        {

            if (!context.Database.CanConnect())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                output.ShowMessage("Brak bazy danych... tworzenie nowej ... proszę czekać");
                Console.ResetColor();
                CreateDatabase();
                Run();
                Console.ForegroundColor = ConsoleColor.Green;
                output.ShowMessage("Baza została utworzona.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                output.ShowMessage("Database exists!");
                Console.ResetColor();
            }    
        }
        private void CreateDatabase()
        {
            context.Database.EnsureCreated();
        }
        public void Run()
        {
            ValidateGunTypesTable();
            ValidateShipTypesTable();
            ValidateGunTable();
            ValidateFactionTable();
            ValidateShipTable();
            AllChecksPassed();
        }
        private void ValidateGunTypesTable()
        {
            if (context.GunTypes.Any())
            {
            }
            else
            {
                context.GunTypes.Add(new GunType { Type = "Main Gun" });
                context.SaveChanges();
            }
        }
        private void ValidateAmmoTable()
        {
            //not implemented
        }
        private void ValidateGunTable()
        {
                if (context.Guns.Any())
                {
                }else
                {
                    context.Guns.Add(new Gun { Name = "Railgun", Armor = 100, Barrels = 1, Damage = 9999, HP = 9999, State = true, TypeId = 1 }); //1
                    context.Guns.Add(new Gun { Name = "20.3 cm SK C/34", Armor = 50, Barrels = 2, Damage = 200, HP = 255, State = true, TypeId = 1 }); //2 Admiral Hipper-class
                    context.Guns.Add(new Gun { Name = "15 cm TbtsK C/36 ", Armor = 25, Barrels = 1, Damage = 100, HP = 255, State = true, TypeId = 1 }); //3 Z23
                    context.Guns.Add(new Gun { Name = "QF 4.7-inch Mk IX & XII", Armor = 25, Barrels = 2, Damage = 100, HP = 255, State = true, TypeId = 1 }); //4 Javelin
                    context.Guns.Add(new Gun { Name = "5\"/38 caliber gun ", Armor = 25, Barrels = 1, Damage = 100, HP = 100, State = true, TypeId = 1 }); //5 Laffey
                    context.Guns.Add(new Gun { Name = "12.7 cm/50 Type 3", Armor = 25, Barrels = 2, Damage = 100, HP = 100, State = true, TypeId = 1 }); //6 Ayanami?
                    context.Guns.Add(new Gun { Name = "38 cm SK C/34", Armor = 50, Barrels = 2, Damage = 255, HP = 100, State = true, TypeId = 1 }); //7 Bismarck
                    context.Guns.Add(new Gun { Name = "6\"/47 caliber gun", Armor = 40, Barrels = 3, Damage = 200, HP = 100, State = true, TypeId = 1 }); //8 Cleveland
                    context.Guns.Add(new Gun { Name = "16\"/45 caliber", Armor = 50, Barrels = 2, Damage = 255, HP = 100, State = true, TypeId = 1 }); //9 Maryland
                    context.Guns.Add(new Gun { Name = "Ordnance BL 6 inch gun Mk XXIII", Armor = 40, Barrels = 3, Damage = 200, HP = 100, State = true, TypeId = 1 }); //10 Belfast
                    context.Guns.Add(new Gun { Name = "BL 15-inch Mark I naval gun", Armor = 50, Barrels = 2, Damage = 255, HP = 100, State = true, TypeId = 1 }); //11 Warspite
                    context.Guns.Add(new Gun { Name = "20 cm/50 3rd Year Type naval gun", Armor = 40, Barrels = 2, Damage = 200, HP = 100, State = true, TypeId = 1 }); //12 Furutaka
                    context.Guns.Add(new Gun { Name = "46 cm/45 Type 94", Armor = 50, Barrels = 3, Damage = 255, State = true, TypeId = 1 }); // 13 Musashi
                    context.Guns.Add(new Gun { Name = "8 in (203 mm)/55", Armor = 40, Barrels = 3, Damage = 200, State = true, TypeId = 1 }); //14 Indianapolis
                    context.Guns.Add(new Gun { Name = "8 in (200 mm)/55", Armor = 40, Barrels = 3, Damage = 200, State = true, TypeId = 1 }); //15 Portland
                    context.SaveChanges();
                }
        }
        private void ValidateShipTypesTable()
        {
            if (context.ShipTypes.Any())
            {
            }else
            {
                context.ShipTypes.Add(new ShipType { Type = "Destroyer" });
                context.ShipTypes.Add(new ShipType { Type = "Cruiser" });
                context.ShipTypes.Add(new ShipType { Type = "Battleship" });
                context.SaveChanges();
            }
        }
        private void ValidateFactionTable()
        {
                if (context.Factions.Any())
                {
                }else
                {
                    context.Factions.Add(new Faction { Name = "Iron Blood", Icon = "IB" }); //id = 1
                    context.Factions.Add(new Faction { Name = "Eagle Union", Icon = "EU" }); //id = 2
                    context.Factions.Add(new Faction { Name = "Royal Navy", Icon = "RN" }); //id = 3
                    context.Factions.Add(new Faction { Name = "Sakura Empire", Icon = "SE" }); //id = 4
                    context.Factions.Add(new Faction { Name = "Dragon Empery", Icon = "DR" }); //id = 5
                    context.Factions.Add(new Faction { Name = "Northern Parliament", Icon = "NP" }); //id = 6
                    context.Factions.Add(new Faction { Name = "Iris Libre", Icon = "IL" }); //id = 7
                    context.Factions.Add(new Faction { Name = "Vichya Dominion", Icon = "VD" }); //id = 8
                    context.Factions.Add(new Faction { Name = "Sardegna Empire", Icon = "SaE" }); //id = 9
                    context.SaveChanges();
                }
        }
        private void ValidateShipTable()
        {
                if (context.Ships.Any())
                {
                }else
                {
                    //Iron Blood Destroyers
                    context.Ships.Add(new Ship { Name = "Z23", Armor = 100, HP = 1000, GunId = 3, FactionId = 1, Turrets = 3, TypeId = 1 });
                    //Iron Blood Cruisers
                    context.Ships.Add(new Ship { Name = "Prinz Eugen", Armor = 9999, HP = 9999, GunId = 1, FactionId = 1, Turrets = 4, TypeId = 2 });
                    context.Ships.Add(new Ship { Name = "Admiral Hipper", Armor = 2000, HP = 200, GunId = 2, FactionId = 1, Turrets = 4, TypeId = 2});
                    context.Ships.Add(new Ship { Name = "Blücher", Armor = 200, HP = 2000, GunId = 2, FactionId = 1, Turrets = 4, TypeId = 2 });
                    //Iron Blood BattleShips
                    context.Ships.Add(new Ship { Name = "Bismarck", Armor = 300, HP = 3000, GunId = 7, FactionId = 1, Turrets = 4, TypeId = 3});
                    //Eagle Union Destroyers
                    context.Ships.Add(new Ship { Name = "Laffey", Armor = 100, HP = 1000, GunId = 5, FactionId = 2, Turrets = 4, TypeId = 1 });
                    //Eagle Union Cruisers
                    context.Ships.Add(new Ship { Name = "Cleveland", Armor = 200, HP = 2000, GunId = 8, FactionId = 2, Turrets = 4, TypeId = 2 });
                    context.Ships.Add(new Ship { Name = "Indianapolis", Armor = 200, HP = 2000, GunId = 14, FactionId = 2, Turrets = 3, TypeId = 2});
                    context.Ships.Add(new Ship { Name = "Portland", Armor = 200, HP = 2000, GunId = 15, FactionId = 2, Turrets = 3, TypeId = 2 });
                    //Eagle Union BattleShips
                    context.Ships.Add(new Ship { Name = "Maryland", Armor = 300, HP = 3000, GunId = 9, FactionId = 2, Turrets = 4, TypeId = 3});
                    //Royal Navy Destroyers
                    context.Ships.Add(new Ship { Name = "Javelin", Armor = 100, HP = 1000, GunId = 4, FactionId = 3, Turrets = 3, TypeId = 1 });
                    //Royal Navy Cruisers
                    context.Ships.Add(new Ship { Name = "Belfast", Armor = 200, HP = 2000, GunId = 10, FactionId = 3, Turrets = 4, TypeId = 2});
                    //Royal Navy BattleShips
                    context.Ships.Add(new Ship { Name = "Warspite", Armor = 300, HP = 3000, GunId = 11, FactionId = 3, Turrets = 4, TypeId = 3 });
                    //Sakura Empire Destroyers
                    context.Ships.Add(new Ship { Name = "Ayanami", Armor = 100, HP = 1000, GunId = 6, FactionId = 4, Turrets = 3, TypeId = 1 });
                    //Sakura Empire Cruisers
                    context.Ships.Add(new Ship { Name = "Furutaka", Armor = 200, HP = 2000, GunId = 12, FactionId = 4, Turrets = 3, TypeId = 2});
                    //Sakura Empire BattleShips
                    context.Ships.Add(new Ship { Name = "Musashi", Armor = 300, HP = 3000, GunId = 13, FactionId = 4, Turrets = 3, TypeId = 3});
                    context.SaveChanges();
                }
        }
        private void AllChecksPassed()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            output.ShowMessage("All Green!");
            Console.ResetColor();
        }
        private void CheckFail()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            output.ShowMessage("Upss coś poszło nie tak");
            Console.ResetColor();
        }
    }
}
