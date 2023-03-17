using System.Runtime.CompilerServices;
using Task9.InputOutputSystem.Interface;
using Task9.Models;
using Task9.Models.Context;

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
            tempInt = new Gun().GetMaxArmor();
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
            tempInt = new Gun().GetMaxHP();
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
            tempInt = new Gun().GetMaxBarrels();
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
            tempInt = new Gun().GetMaxDamage();
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
            tempInt = new Ship().GetMaxTurrets();
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
            tempInt = new Ship().GetMaxHP();
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
            tempInt = new Ship().GetMaxArmor();
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
        public bool MaxShipId(int userInput)
        {
            tempInt = new ShipRepository().GetMaxId(); // zmienić całkowicie z bool na int z GetMaxId na CheckIdExist
            if (userInput <= tempInt && userInput >= 0)
            {
                return true;
            }else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Brak ID");
                Console.ResetColor();
                return false;
            }
        }
        public bool MaxGunId(int userInput)
        {
            tempInt = new GunRepository().GetMaxId();
            if (userInput <= tempInt && userInput >= 0)
            {
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Brak ID");
                Console.ResetColor();
                return false;
            }
        }
        public bool MaxFactionId(int userInput)
        {
            tempInt = new Faction().GetMaxId();
            if (userInput <= tempInt && userInput >= 0)
            {
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Brak ID");
                Console.ResetColor();
                return false;
            }
        }
    }
}