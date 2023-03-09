using Task9.Factory;
using Task9.Models;

namespace Task9.Validation
{
    public class Validate
    {
        private bool isParsable;
        private int tempInt;
        public bool Int(string temp)
        {
            isParsable = CheckInt(temp);
            return isParsable;
        }
        private bool CheckInt(string temp)
        {
            isParsable = int.TryParse(temp, out _);
            return isParsable;
        }
        public bool MaxGunArmor(int armor)
        {
            tempInt = new Gun().MaxArmor();
            if (armor <= tempInt && armor > 0)
            {
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Najwyższa wartość to: " + tempInt);
                Console.ResetColor();
                return false;
            }
        }
        public bool MaxGunHP(int hp)
        {
            tempInt = new Gun().MaxHP();
            if (hp <= tempInt && hp > 0)
            {
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Najwyższa wartość to: " + tempInt);
                Console.ResetColor();
                return false;
            }
        }
        public bool MaxGunBarrels(int barrels)
        {
            tempInt = new Gun().MaxBarrels();
            if (barrels <= tempInt && barrels > 0)
            {
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Najwyższa wartość to: " + tempInt);
                Console.ResetColor();
                return false;
            }
        }
        public bool MaxGunDamage(int damage)
        {
            tempInt = new Gun().MaxDamage();
            if (damage <= tempInt && damage > 0)
            {
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Najwyższa wartość to: " + tempInt);
                Console.ResetColor();
                return false;
            }
        }
        public bool MaxShipTurrets(int turrets)
        {
            tempInt = new Ship().MaxTurrets();
            if (turrets <= tempInt && turrets > 0)
            {
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Najwyższa wartość to: " + tempInt);
                Console.ResetColor();
                return false;
            }
        }
        public bool MaxShipHP(int hp)
        {
            tempInt = new Ship().MaxHP();
            if (hp <= tempInt && hp > 0)
            {
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Najwyższa wartość to: " + tempInt);
                Console.ResetColor();
                return false;
            }
        }
        public bool MaxShipArmor(int armor)
        {
            tempInt = new Ship().MaxArmor();
            if (armor <= tempInt && armor > 0)
            {
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Najwyższa wartość to: " + tempInt);
                Console.ResetColor();
                return false;
            }
        }
    }
}