using Task9.Factory.Interface;
using Task9.InputOutputSystem.Interface;
using Task9.Models;
using Task9.Validation;
using Task9.View;

namespace Task9.Factory
{
    public class ShipFactory : IShipFactory
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
            string name = GetShipName();
            int armor = GetArmorValue();
            int hp = GetHPValue();
            int gunId = GetGunID();
            int factionId = GetFactionID();
            int turrets = GetNumberOfTurrets();
            int typeId = GetShipTypeId();
            return new Ship { Name = name, Armor = armor, HP = hp, Turrets = turrets, GunId = gunId, FactionId = factionId, TypeId = typeId };
        }
        private int GetGunID()
        {
            new GunDisplay(output).GetList();
            return input.GetId("gun");
        }
        private int GetFactionID()
        {
            new FactionDisplay(output).GetList();
            return input.GetId("faction");
        }
        private string GetShipName()
        {
            return input.GetStringValue("Podaj nazwę statku:");
        }
        private int GetArmorValue()
        {
            int armor;
            bool exit = false;
            do
            {
                armor = input.GetIntValue("Podaj wartość panczerza:");
                isParsable = new Validate().MaxShipArmor(armor);
                if (isParsable)
                {
                    exit = true;
                }
            } while (!exit);
            return armor;
        }
        private int GetHPValue()
        {
            int hp;
            bool exit = false;
            do
            { 
                hp = input.GetIntValue("Podaj ilość życia:");
                isParsable = new Validate().MaxShipHP(hp);
                if (isParsable)
                {
                    exit = true;
                }
            } while (!exit);
            return hp;
        }
        private int GetNumberOfTurrets()
        {
            int turrets;
            bool exit = false;
            do
            { 
                turrets = input.GetIntValue("Podaj ilość wieżyczek:");
                isParsable = new Validate().MaxShipTurrets(turrets);
                if (isParsable)
                {
                    exit = true;
                }
            } while (!exit);
            return turrets;
        }
        private int GetShipTypeId()
        {
            //int choice = input.GetIntValue("Wybierz typ:\n"
            //                  + "1) Niszczyciel\n"
            //                  + "2) Krążownik\n"
            //                  + "3) Pancernik"); // hmmm może by to przenieść żeby lepiej wyglądało ?
            //if (choice < 0 && choice > 4)
            //{
            //    switch (choice)
            //    {
            //        case 1:
            //            {
            //                return "Destroyer";
            //            }
            //        case 2:
            //            {
            //                return "Cruiser";
            //            }
            //        case 3: 
            //            {
            //                return "Battleship";
            //            }
            //    }
            //}
            //return "";
            new ShipTypesDisplay(output).GetList();
            return input.GetId("Ship Type:");
        }

    }
}
