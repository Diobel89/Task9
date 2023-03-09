using Task9.Parse;
using Task9.InputOutputSystem.Interface;
using Task9.Validation;
using Task9.Models.Context;
using Task9.Models;
using Task9.View;
using Task9.Factory;
using Task9.Functions;

namespace Task9
{
    public class Menu
    {
        private readonly IInput input;
        private readonly IOutput output;
        private string temp;
        private int choice;
        private bool isParsable;
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

            ShowOptions();

            temp = Console.ReadLine();
            isParsable = new Validate().Int(temp);
            if (isParsable)
            {
                choice = new StringParseTo().Int(temp);
                isParsable = MaxMenuChoice(choice);
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
        }
        private void ShowOptions()
        {
            Console.ResetColor();
            Console.WriteLine("MENU GŁÓWNE:");
            Console.ResetColor();
            Console.WriteLine("1) Dodaj Statek\n"
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
            using (var db = new ShipRepository())
            {
                var shipList = db.GetAllShips();
                new ShipDisplay(output).DisplayAll((List<Ship>) shipList);
            }
        }
        private void ExecuteCase4()
        {
            //using (var db = new GunRepository())
            //{
            //    var gunList = db.GetAllGuns();
            //    new GunDisplay(output).DisplayAll((List<Gun>)gunList);
            //}
            new GunDisplay(output).GetList();
        }
        private void ExecuteCase5()
        {
            using (var db = new FactionRepository())
            {
                var factionList = db.GetAllFactions();
                new FactionDisplay(output).DisplayAll((List<Faction>)factionList);
            }
        }
        private void ExecuteCase6()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            output.ShowMessage("In Development");
            Console.ResetColor();
        }
    }
}