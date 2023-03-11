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
            ValidateGunDatabase();
            ValidateFactionDatabase();
            ValidateShipDatabase();
            AllChecksPassed();
        }
        private void ValidateGunDatabase()
        {
            using (var db = new DatabaseContext())
            {
                if (db.Guns.Any())
                {
                }else
                {
                    db.Guns.Add(new Gun { Name = "Railgun", Armor = 100, Barrels = 1, Damage = 9999, HP = 9999, State = true });
                    db.SaveChanges();
                }
            }
        }
        private void ValidateFactionDatabase()
        {
            using (var db = new DatabaseContext())
            {
                if (db.Factions.Any())
                {
                }else
                {
                    db.Factions.Add(new Faction { Name = "Iron Blood", Icon = "IB" });
                    db.Factions.Add(new Faction { Name = "Eagle Union", Icon = "EU" });
                    db.Factions.Add(new Faction { Name = "Royal Navy", Icon = "RN" });
                    db.Factions.Add(new Faction { Name = "Sakura Empire", Icon = "SE" });
                    db.Factions.Add(new Faction { Name = "Dragon Empery", Icon = "DR" });
                    db.Factions.Add(new Faction { Name = "Northern Parliament", Icon = "NP" });
                    db.Factions.Add(new Faction { Name = "Iris Orthodoxy", Icon = "IO" });
                    db.Factions.Add(new Faction { Name = "Iris Libre", Icon = "IL" });
                    db.Factions.Add(new Faction { Name = "Vichya Dominion", Icon = "VD" });
                    db.Factions.Add(new Faction { Name = "Sardegna Empire", Icon = "SaE" });
                    db.SaveChanges();
                }
            }
        }
        private void ValidateShipDatabase()
        {
            using (var db = new DatabaseContext())
            {
                if (db.Ships.Any())
                {
                }else
                {
                    db.Ships.Add(new Ship { Name = "Prinz Eugen", Armor = 9999, HP = 9999, GunId = 1, FactionId = 1, Turrets = 4});
                    db.SaveChanges();
                    //return true;
                }
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
