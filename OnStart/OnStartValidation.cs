using Task9.InputOutputSystem.Interface;
using Task9.Models;

namespace Task9.OnStart
{
    public class OnStartValidation
    {
        private readonly IOutput output;
        public OnStartValidation(IOutput output)
        {
            this.output = output;
        }

        public bool Run()
        {
            return true;
        }
        private bool ValidateGunDatabase()
        {
            using (var db = new DatabaseContext())
            {
                if (db.Guns != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    output.ShowMessage("All Green!");
                    Console.ResetColor();
                    return true;
                }else
                {
                    db.Guns.Add(new Gun { Name = "Railgun", Armor = 100, Barrels = 1, Damage = 9999, HP = 9999, State = true, Id = 0 });
                    db.SaveChanges();
                    return true;
                }
            }
        }
        private bool ValidateShipDatabase()
        {
            using (var db = new DatabaseContext())
            {
                if (db.Ships != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    output.ShowMessage("All Green!");
                    Console.ResetColor();
                    return true;
                }else
                {
                    db.Ships.Add(new Ship { Name = "Prinz Eugen", Armor = 9999, HP = 9999, GunId = 0, FactionId = 0});
                    return true;
                }
            }
        }
    }
}
