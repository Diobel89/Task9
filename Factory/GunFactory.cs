using Task9.InputOutputSystem.Interface;
using Task9.Models;
using Task9.Validation;

namespace Task9.Factory
{
    public class GunFactory : Gun
    {
        private readonly IInput input;
        private bool isParsable;
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
            bool exit = false;
            do
            {
                HP = input.GetIntValue("Podaj ilość życia:");
                isParsable = new Validate().MaxGunHP(HP);
                if (isParsable)
                {
                    exit = true;
                }
            } while (!exit);
            return HP;
        }
        private int GetArmorValue()
        {
            bool exit = false;
            do
            {
                Armor = input.GetIntValue("Podaj wartość panczerza:");
                isParsable = new Validate().MaxGunArmor(Armor);
                if (isParsable)
                {
                    exit = true;
                }
            } while (!exit);
            return Armor;
        }
        private int GetDMGValue()
        {
            bool exit = false;
            do
            {
                Damage = input.GetIntValue("Podaj wartość zadawanych obrażeń (dla 1 lufy):");
                isParsable = new Validate().MaxGunDamage(Damage);
                if (isParsable)
                {
                    exit = true;
                }
            }while (!exit);
            return Damage;
        }
        private int GetNumberOfBarrels()
        {
            bool exit = false;
            do
            {
                Barrels = input.GetIntValue("Podaj ilość luf:");
                isParsable = new Validate().MaxGunBarrels(Barrels);
                if (isParsable)
                {
                    exit = true;
                }
            }while (!exit);
            return Barrels;
        }
    }
}
