using Task9.InputOutputSystem.Interface;
using Task9.Models;

namespace Task9.Factory
{
    public class GunFactory : Gun
    {
        private readonly IInput input;
        public GunFactory(IInput input)
        {
            this.input = input;
        }

        public Gun Create()
        {
            Name = GetGunName();
            HP = GetHPValue();
            Armor = GetArmorValue();
            Damage = GetDMGValue();
            Barrels = GetNumberOfBarrels();
            State = true;
            return new Gun { Name = Name, HP = HP, Armor = Armor, Damage = Damage, State = State, Barrels = Barrels };
        }
        private string GetGunName()
        {
            Name = input.GetStringValue("Podaj nazwę broni:");
            return Name;
        }
        private int GetHPValue()
        {
            HP = input.GetIntValue("Podaj ilość życia:");
            return HP;
        }
        private int GetArmorValue()
        {
            Armor = input.GetIntValue("Podaj wartość panczerza:");
            return Armor;
        }
        private int GetDMGValue()
        {
            Damage = input.GetIntValue("Podaj wartość zadawanych obrażeń (dla 1 lufy):");
            return Damage;
        }
        private int GetNumberOfBarrels()
        {
            Barrels = input.GetIntValue("Podaj ilość luf:");
            return Barrels;
        }
    }
}
