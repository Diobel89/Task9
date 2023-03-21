using Task9.Factory.Interface;
using Task9.InputOutputSystem.Interface;
using Task9.Models;
using Task9.Validation;

namespace Task9.Factory
{
    public class GunFactory : IGunFactory
    {
        private readonly IInput input;
        private bool isParsable;
        public GunFactory(IInput input)
        {
            this.input = input;
        }

        public Gun Create()
        {
            string name = GetGunName();
            int hp = GetHPValue();
            int armor = GetArmorValue();
            int damage = GetDMGValue();
            int barrels = GetNumberOfBarrels();
            bool state = true;
            int typeId = GetGunTypeId();
            return new Gun { Name = name, HP = hp, Armor = armor, Damage = damage, State = state, Barrels = barrels , TypeId = typeId};
        }
        private string GetGunName()
        {
            return input.GetStringValue("Podaj nazwę broni:");
        }
        private int GetHPValue()
        {
            int hp;
            bool exit = false;
            do
            {
                hp = input.GetIntValue("Podaj ilość życia:");
                isParsable = new Validate().MaxGunHP(hp);
                if (isParsable)
                {
                    exit = true;
                }
            } while (!exit);
            return hp;
        }
        private int GetArmorValue()
        {
            int armor;
            bool exit = false;
            do
            {
                armor = input.GetIntValue("Podaj wartość panczerza:");
                isParsable = new Validate().MaxGunArmor(armor);
                if (isParsable)
                {
                    exit = true;
                }
            } while (!exit);
            return armor;
        }
        private int GetDMGValue()
        {
            int damage;
            bool exit = false;
            do
            {
                damage = input.GetIntValue("Podaj wartość zadawanych obrażeń (dla 1 lufy):");
                isParsable = new Validate().MaxGunDamage(damage);
                if (isParsable)
                {
                    exit = true;
                }
            }while (!exit);
            return damage;
        }
        private int GetNumberOfBarrels()
        {
            int barrels;
            bool exit = false;
            do
            {
                barrels = input.GetIntValue("Podaj ilość luf:");
                isParsable = new Validate().MaxGunBarrels(barrels);
                if (isParsable)
                {
                    exit = true;
                }
            }while (!exit);
            return barrels;
        }
        private int GetGunTypeId()
        {
            return 1;
        }
    }
}
