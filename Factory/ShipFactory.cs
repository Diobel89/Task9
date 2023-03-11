using Task9.InputOutputSystem.Interface;
using Task9.Models;
using Task9.Models.Context;
using Task9.Validation;
using Task9.View;

namespace Task9.Factory
{
    public class ShipFactory : Ship
    {
        private readonly IInput input;
        private readonly IOutput output;
        private bool isParsable;
        public ShipFactory(IInput input, IOutput output)
        {
            this.input = input;
            this.output = output;
        }

        public Ship Create()
        {
            Name = GetShipName();
            Armor = GetArmorValue();
            HP = GetHPValue();
            GunId = GetGunID();
            FactionId = GetFactionID();
            Turrets = GetNumberOfTurrets();
            return new Ship { Name = Name, Armor = Armor, HP = HP, Turrets = Turrets, GunId = GunId, FactionId = FactionId };
        }
        private int GetGunID()
        {
            //using (var db = new GunRepository())
            //{
            //    var gunList = db.GetAllGuns();
            //    new GunDisplay(output).DisplayAll((List<Gun>)gunList);
            //}
            new GunDisplay(output).GetList();
            GunId = input.GetIntValue("Wybierz Id broni:");
            return GunId;
        }
        private int GetFactionID()
        {
            using (var db = new FactionRepository())
            {
                var factionList = db.GetAllFactions();
                new FactionDisplay(output).DisplayAll((List<Faction>)factionList);
            }
            FactionId = input.GetIntValue("Wybierz Id frakcji:");
            return FactionId;
        }
        private string GetShipName()
        {

            Name = input.GetStringValue("Podaj nazwę statku:");
            return Name;
        }
        private int GetArmorValue()
        {
            bool exit = false;
            do
            {
                Armor = input.GetIntValue("Podaj wartość panczerza:");
                isParsable = new Validate().MaxShipArmor(Armor);
                if (isParsable)
                {
                    exit = true;
                }
            } while (!exit);
            return Armor;
        }
        private int GetHPValue()
        {
            bool exit = false;
            do
            { 
                HP = input.GetIntValue("Podaj ilość życia:");
                isParsable = new Validate().MaxShipHP(HP);
                if (isParsable)
                {
                    exit = true;
                }
            } while (!exit);
            return HP;
        }
        private int GetNumberOfTurrets()
        {
            bool exit = false;
            do
            { 
                Turrets = input.GetIntValue("Podaj ilość wieżyczek:");
                isParsable = new Validate().MaxShipTurrets(Turrets);
                if (isParsable)
                {
                    exit = true;
                }
            } while (!exit);
            return Turrets;
        }

    }
}
