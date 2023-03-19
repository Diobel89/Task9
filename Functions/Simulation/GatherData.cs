using Task9.InputOutputSystem.Interface;
using Task9.Models;
using Task9.Models.Context;
using Task9.View;

namespace Task9.Functions.Simulation
{
    public class GatherData : Fleet
    {
        private readonly IInput input;
        private readonly IOutput output;
        public GatherData(IInput input, IOutput output)
        {
            this.input = input;
            this.output = output;
        }
        public void Run()
        {
            SetBattleScal();
            new Start(output, fleet1, fleet2).Run();
            output.ShowMessage("Tsudzuku");
        }
        private void SetBattleScal()
        {
            int scale = input.GetIntValue("1) Mała bitwa (4 vs 4) \n"
                                        + "2 Średnia bitwa (8 vs 8)");
            SelectShip(scale);
        }
        private void SelectShip(int scale)
        {
            int totalValue;
            int availablePoints = SetAvailablePoinstByBattleScal(scale);
            int maxShips = SetMaxShips(scale);
            int fleetNumber = 1;
            int id, index = 0;
            bool exit = false, check = false;
            output.CleanScreen();
            do
            {
            NewShip:
                if (fleetNumber == 3)
                {
                    exit = true;
                }
                else
                {
                    output.ShowMessage("Kolej: Floota " + fleetNumber + "\n" 
                                     + "Pozostałą ilość punktów: " + availablePoints);
                    new ShipDisplay().GetList();

                    id = input.GetId("ship");
                    totalValue = SetTotalValue(id);
                    output.ShowMessage(String.Join(" ", "Koszt totaly to: " + totalValue));
                    int choice = input.GetIntValue("1) Dodaj statek do floty" + fleetNumber + "\n"
                                                 + "2) Wybierz inny\n"
                                                 + "3) Zmień broń");
                    switch (choice)
                    {
                        case 1:
                            {
                                Ship ship = new ShipRepository().GetShip(id);
                                availablePoints -= totalValue; // tutaj wstawić CheckPoints
                                check = CheckPoints(availablePoints);
                                if (check)
                                {
                                    AddShipToFleet(fleetNumber, ship);
                                }
                                else
                                {
                                    fleetNumber++;
                                    availablePoints = SetAvailablePoinstByBattleScal(scale);
                                    index = 0;
                                    goto NewShip;
                                }
                                break;
                            }
                        case 2:
                            {
                                goto NewShip;
                            }
                        case 3:
                            {
                            AskAgain:
                                Ship.GunId = GetNewGun();
                                (int, int) tempTupple = SetShipValue(id);
                                int tempInt = SetGunValue(Ship.GunId);
                                tempInt += tempTupple.Item1;
                                output.ShowMessage(String.Join("", "Nowy koszt totalny to: " + tempInt));
                                Ship shipWithNewGun = SetNewGunToShip(tempTupple.Item1, id);
                                choice = input.GetIntValue("1)Dodaj\n"
                                                         + "2)zmień broń");
                                if (choice == 1 && choice > 0 && choice < 3)
                                {
                                    availablePoints -= tempInt;
                                    check = CheckPoints(availablePoints);
                                    if (check)
                                    {
                                        AddShipToFleet(fleetNumber, shipWithNewGun);
                                    }
                                    else
                                    {
                                        fleetNumber++;
                                        availablePoints = SetAvailablePoinstByBattleScal(scale);
                                        index = 0;
                                        goto NewShip;
                                    }
                                }
                                else
                                {
                                    goto AskAgain;
                                }
                                break;
                            }
                    }
                    output.CleanScreen();
                    if (index < maxShips && fleetNumber < 3)
                    {
                        index++;
                        if (index == maxShips)
                        {
                            fleetNumber++;
                            availablePoints = SetAvailablePoinstByBattleScal(scale);
                            index = 0;
                        }
                    }
                    else
                    {
                        exit = true;
                    }
                }
            }while (!exit);
            // new End(output).Run();
        }
        private Ship SetNewGunToShip(int gunId, int shipId)
        {
            Ship alteredShip = new ShipRepository().GetShip(shipId);
            Gun newGun = new GunRepository().GetGun(gunId);
            alteredShip.GunId = gunId;
            return alteredShip;
        }
        private void AddShipToFleet(int fleetNumber, Ship ship)
        {
            int shipTotalDamage = 0;
            if (fleetNumber == 1)
            {
                //Ship = new ShipRepository().GetShip(id);
                shipTotalDamage = new Fleet().SetTotalDamage(ship); // naprawić :D
                //shipTotalDamage *= ship.Turrets;
                fleet1.Add(new Fleet { Ship = ship, ShipTotalDamage = shipTotalDamage, FleetNumber = fleetNumber });
            }
            if (fleetNumber == 2)
            {
                //Ship = new ShipRepository().GetShip(id);
                shipTotalDamage = new Fleet().SetTotalDamage(ship);
                //shipTotalDamage *= ship.Turrets;
                fleet2.Add(new Fleet { Ship = ship, ShipTotalDamage = shipTotalDamage, FleetNumber = fleetNumber });
            }
        }
        private int SetTotalValue(int id)
        {
            (int, int) shipData = SetShipValue(id);
            return (shipData.Item1) + SetGunValue(shipData.Item2);
        }
        private (int, int) SetShipValue(int id)
        {
            Ship = new ShipRepository().GetShip(id);
            return (Ship.Turrets, Ship.GunId);
        }
        private int SetGunValue(int gunId)
        {
            Gun gun = new GunRepository().GetGun(gunId);
            return gun.Barrels;
        }
        private int SetAvailablePoinstByBattleScal(int scale)
        {
            switch(scale)
            {
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
        private bool CheckPoints(int availablePoints)
        {
            if (availablePoints > 0)
            {
                return true;
            }else
            {
                return false;
            }

        }
    }
}