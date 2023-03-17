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
            int id;
            bool exit = false;
            do
            {
                NewShip:
                new ShipDisplay(output).GetList();

                id = input.GetId("ship"); // zamiast CheckIdExist zrobić funkcje wybierania ID w input? razem z sprawdzaniem czy istnieje
                totalValue = SetTotalValue(id);
                output.ShowMessage(String.Join(" ", "Koszt totaly to: " + totalValue));
                int choice = input.GetIntValue("1) Dodaj statek do floty\n"
                                 + "2) Wybierz inny\n"
                                 + "3) Zmień broń");
                switch (choice)
                {
                    case 1:
                        {
                            Ship ship = new ShipRepository().GetShip(id);
                            AddShipToFleet(fleetNumber, ship);
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
                                AddShipToFleet(fleetNumber, shipWithNewGun);
                            }else
                            {
                                goto AskAgain;
                            }
                            break;
                            //goto AskAgain;
                        }
                }
            }while (!exit);
            //for (int index = 0; index < maxShips; index++)
            //{
            //Again:
            //    output.ShowMessage(String.Join(" ", "Ruch Floty" + fleetNumber));
            //    new ShipDisplay(output).GetList();
            //    int id = input.GetIntValue("Wybierz ID:");
            //    bool isTrue = new Validate().MaxShipId(id);
            //    if (!isTrue)
            //    {
            //        id = input.GetIntValue("Wybierz ID:");
            //    }
            //    totalValue = SetTotalValue(id);
            //    availablePoints -= totalValue;
            //    if (availablePoints > 0 && (availablePoints += totalValue) < 0)
            //    {
            //        output.ShowMessage("Nie stać cię biedaku");
            //        if ((availablePoints += totalValue) < 0)
            //        {
            //            goto Again;
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }
            //    else
            //    {
            //        AddShipToFleet(fleetNumber, id);
            //    }
            //    fleetNumber++;
            //    goto Again;
            //}
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
                shipTotalDamage = new Fleet().SetTotalDamage(ship.GunId); // naprawić :D
                shipTotalDamage *= ship.Turrets;
                fleet1.Add(new Fleet { Ship = ship, ShipTotalDamage = shipTotalDamage, FleetNumber = fleetNumber });
            }
            if (fleetNumber == 2)
            {
                //Ship = new ShipRepository().GetShip(id);
                shipTotalDamage = new Fleet().SetTotalDamage(ship.GunId);
                shipTotalDamage *= ship.Turrets;
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
            //Ship = new ShipRepository().GetShip(id);
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
            new GunDisplay(output).GetList();
            return input.GetId("gun");
            //return new GunRepository().GetGun(id);
        }
    }
}