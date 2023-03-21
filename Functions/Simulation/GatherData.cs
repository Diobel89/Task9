using Task9.InputOutputSystem.Interface;
using Task9.Models;
using Task9.Models.Context;
using Task9.Models.Context.Interfaces;
using Task9.View;

namespace Task9.Functions.Simulation
{
    public class GatherData : Fleet
    {
        private readonly IInput input;
        private readonly IOutput output;
        private readonly IGunRepository _gunRepository;
        private readonly IShipRepository _shipRepository;
        private int availablePoints, totalValue;
        private int fleetNumber = 1;
        private int scale, maxShips, index;
        public GatherData(IInput input, IOutput output)
        {
            this.input = input;
            this.output = output;
            _gunRepository = new GunRepository();
            _shipRepository = new ShipRepository();
        }
        public void Run()
        {
            bool exit = false;
            bool check, check2;
            scale = SetBattleScal();
            maxShips = SetMaxShips(scale);
            availablePoints = SetAvailablePoinstByBattleScal(scale);
            do
            {
                output.CleanScreen();
                check = CheckPointsLimit();
                check2 = CheckForEndOfTurnByIndex();
                if (check && !check2)
                {
                    ShowTurnInfo();
                    Ship ship = SelectShip();
                    int choice = ShowOptionsAndGetChoice(ship);
                    RunChoice(choice, ship);
                }else
                {
                    if (fleetNumber == 1)
                    {
                        SetVariablesForNextFleet();
                    }else
                    {
                        exit = true;
                    }
                }
            }while (!exit);
            new Start(output, fleet1, fleet2).Run(); 
            output.ShowMessage("Tsudzuku");
        }
        private int SetBattleScal()
        {
            bool exit = false;
            int choice;
            do
            {
                choice = input.GetIntValue("1) Mała bitwa (4 vs 4) \n"
                                       + "2 Średnia bitwa (8 vs 8)");
                if (choice > 0 && choice <= 2)
                {
                    exit = true;
                    return choice;
                }
            } while (!exit);
            return choice;
        }
        private void ShowTurnInfo()
        {
            output.ShowMessage("Teraz okręty dodaje flota " + fleetNumber);
            output.ShowMessage("index: " + index);
            output.ShowMessage("Pozostałe punkty: " + availablePoints);
        }
        private Ship SelectShip()
        {
            new ShipDisplay().GetList();
            int id = input.GetId("ship");
            return _shipRepository.GetShip(id);
        }

        private int ShowOptionsAndGetChoice(Ship ship)
        {
            totalValue = SetTotalValue(ship.Id);
            output.ShowMessage(String.Join(" ", "Koszt totaly to: " + totalValue));
            return input.GetIntValue("1) Dodaj statek do floty" + fleetNumber + "\n"
                                         + "2) Wybierz inny\n"
                                         + "3) Zmień broń");
        }
        private bool CheckForEndOfTurnByIndex()
        {
            if (index >= maxShips)
            {
                return true;
            }else
            {
                return false;
            }
        }
        private void RunChoice(int choice, Ship ship)
        {
            switch (choice)
            {
                case 0:
                    {
                        output.ShowMessage("zła opcja");
                        break;
                    }
                case 1:
                    {
                        ExecuteCase1(ship);
                        break;
                    }
                case 2:
                    {
                        break;
                    }
                case 3:
                    {
                        ExecuteCase3(ship);
                        break;
                    }
            }
        }
        private Ship SetNewGunToShip(Ship ship)
        {
            ship.GunId = GetNewGun();
            return ship;
        }
        private void AddShipToFleet(Ship ship)
        {
            int shipTotalDamage;
            if (fleetNumber == 1)
            {
                shipTotalDamage = new Fleet().SetTotalDamage(ship);
                fleet1.Add(new Fleet { Ship = ship, ShipTotalDamage = shipTotalDamage, FleetNumber = fleetNumber });
            }
            if (fleetNumber == 2)
            {
                shipTotalDamage = new Fleet().SetTotalDamage(ship);
                fleet2.Add(new Fleet { Ship = ship, ShipTotalDamage = shipTotalDamage, FleetNumber = fleetNumber });
            }
        }
        private int SetAvailablePointsAfterSelectingShip(Ship ship)
        {
            return availablePoints -= SetTotalValue(ship.Id);
        }
        private int SetTotalValue(int id)
        {
            (int, int) shipData = SetShipValue(id);
            return (shipData.Item1) + SetGunValue(shipData.Item2);
        }
        private (int, int) SetShipValue(int id)
        {
            Ship = _shipRepository.GetShip(id);
            return (Ship.Turrets, Ship.GunId);
        }
        private int SetGunValue(int gunId)
        {
            Gun gun = _gunRepository.GetGun(gunId);
            return gun.Barrels;
        }
        private int SetAvailablePoinstByBattleScal(int scale)
        {
            switch (scale)
            {
                case 0:
                    {
                        break;
                    }
                case 1:
                    {
                        return 25; // 4 vs 4
                    }
                case 2:
                    {
                        return 45; // 8 vs 8
                    }
            }
            return 0;
        }
        private int SetMaxShips(int scale)
        {
            switch (scale)
            {
                case 0:
                    {
                        break;
                    }
                case 1:
                    {
                        return 4; // 4 vs 4
                    }
                case 2:
                    {
                        return 8; // 8 vs 8
                    }
            }
            return 0;
        }
        private int GetNewGun()
        {
            new GunDisplay().GetList();
            return input.GetId("gun");
        }
        private bool CheckPointsLimit()
        {
            if (availablePoints > 0)
            {
                return true;
            } else
            {
                return false;
            }

        }
        private void ExecuteCase1(Ship ship)
        {
            bool check;
            availablePoints = SetAvailablePointsAfterSelectingShip(ship);
            check = CheckPointsLimit();
            if (check)
            {
                AddShipToFleet(ship);
                index++;
            }
        }
        private void SetVariablesForNextFleet()
        {
            fleetNumber = 2;
            availablePoints = SetAvailablePoinstByBattleScal(scale);
            index = 0;
        }
        private void ExecuteCase2()
        {
            output.ShowMessage("not implemented");
        }
        private void ExecuteCase3(Ship ship)
        {
            int choice;
            ship = SetNewGunToShip(ship);
            choice = ShowGunOptionsAndGetChoice(ship);
        }
        private int ShowGunOptionsAndGetChoice(Ship ship)
        {
            totalValue = SetTotalValue(ship.Id);
            output.ShowMessage(String.Join(" ", "Koszt totaly z nową bronią: " + totalValue));
            return input.GetIntValue("1) Dodaj broń" + fleetNumber + "\n"
                                         + "2) Wybierz inną");
            RunExecuteCase3Choice(ship);
        }
        private void RunExecuteCase3Choice(Ship ship)
        {
            bool check;
            availablePoints = SetAvailablePointsAfterSelectingShip(ship);
            check = CheckPointsLimit();
            if (check)
            {
                AddShipToFleet(ship);
                index++;
            }
        }
    }
}