using Task9.InputOutputSystem.Interface;
using Task9.View;
using Task9.Functions.Simulation;
using Task9.Functions.AddingNew;

namespace Task9
{
    public class Menu
    {
        private readonly IInput input;
        private readonly IOutput output;
        public Menu(IInput input, IOutput output)
        {
            this.input = input;
            this.output = output;
        }
        public void Show()
        {
            Use();
        }
        private void Use()
        {
        Again:
            int choice = ShowOptions();
            bool isParsable = MaxMenuChoice(choice);
                if (isParsable)
                {
                    switch (choice)
                    {
                        case 0:
                            {
                                break;
                            }
                        case 1:
                            {
                                ExecuteCase1();
                                goto Again;
                            }
                        case 2:
                            {
                                ExecuteCase2();
                                goto Again;
                            }
                        case 3:
                            {
                                ExecuteCase3();
                                goto Again;
                            }
                        case 4:
                            {
                                ExecuteCase4();
                                goto Again;
                            }
                        case 5:
                            {
                                ExecuteCase5();
                                goto Again;
                            }
                        case 6:
                            {
                                ExecuteCase6();
                                goto Again;
                            }
                    }
                }
            
        }
        private int ShowOptions()
        {
            Console.ResetColor();
            output.ShowMessage("MENU GŁÓWNE:");
            Console.ResetColor();
            return input.GetIntValue("1) Dodaj Statek\n"
                              + "2) Dodaj Broń\n"
                              + "3) Wyświetl wszystkie statki\n"
                              + "4) Wyświetl wszystkie bronie\n"
                              + "5) Wyświetl wszystkie frakcje\n"
                              + "6) Symulacja\n");
            Console.ResetColor();
        }
        private bool MaxMenuChoice(int choice)
        {
            int menuLimiter = 6;
            if (choice > menuLimiter && choice > -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void ExecuteCase1()
        {
            new AddingShip(input, output).Add();
        }
        private void ExecuteCase2()
        {
            new AddingGun(input).Add();
        }
        private void ExecuteCase3()
        {
            new ShipDisplay().GetList();
        }
        private void ExecuteCase4()
        {
            new GunDisplay().GetList();
        }
        private void ExecuteCase5()
        {
            new FactionDisplay().GetList();
        }
        private void ExecuteCase6()
        {
            //new Symulation(input, output).Run();
            new GatherData(input, output).Run();
        }
    }
}