using Task9.InputOutputSystem;
using Task9.InputOutputSystem.Interface;
using Task9.Models;

namespace Task9.Validation
{
    public class Validate
    {
        private bool isParsable;
        private int tempInt;
        private readonly IOutput _output;
        public Validate()
        {
            _output = new Output();
        }
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
                _output.ShowMessage("Najwyższa wartość to: " + tempInt);
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
                _output.ShowMessage("Najwyższa wartość to: " + tempInt);
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
                _output.ShowMessage("Najwyższa wartość to: " + tempInt);
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
                _output.ShowMessage("Najwyższa wartość to: " + tempInt);
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
                _output.ShowMessage("Najwyższa wartość to: " + tempInt);
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
                _output.ShowMessage("Najwyższa wartość to: " + tempInt);
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
                _output.ShowMessage("Najwyższa wartość to: " + tempInt);
                Console.ResetColor();
                return false;
            }
        }
    }
}