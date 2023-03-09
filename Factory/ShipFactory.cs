using Task9.InputOutputSystem.Interface;
using Task9.Models;
using Task9.Models.Context;
using Task9.View;

namespace Task9.Factory
{
    public class ShipFactory : Ship
    {
        private readonly IInput input;
        private readonly IOutput output;
        public ShipFactory(IInput input, IOutput output)
        {
            this.input = input;
            this.output = output;
        }

        public Ship Create()
        {
            GunId = GetGunID();
            FactionId = GetFactionID();
            Name = GetShipName();
            Armor = GetArmorValue();
            HP = GetHPValue();
            Turrets = GetNumberOfTurrets();
            return new Ship { Name = Name, Armor = Armor, HP = HP, Turrets = Turrets, GunId = GunId, FactionId = FactionId };
        }
        private int GetGunID()
        {
            using (var db = new GunRepository())
            {
                var gunList = db.GetAllGuns();
                new GunDisplay(output).DisplayAll((List<Gun>)gunList);
            }
            GunId = input.GetIntValue("Wybierz Id broni:");
            return GunId;
        }
        private int GetFactionID()
        {
            return FactionId;
        }
        private string GetShipName()
        {
            Name = input.GetStringValue("Podaj nazwę statku:");
            return Name;
        }
        private int GetArmorValue()
        {
            Armor = input.GetIntValue("Podaj wartość panczerza:");
            return Armor;
        }
        private int GetHPValue()
        {
            HP = input.GetIntValue("Podaj ilość życia:");
            return HP;
        }
        private int GetNumberOfTurrets()
        {
            Turrets = input.GetIntValue("Podaj ilość wieżyczek:");
            return Turrets;
        }

    }
}
