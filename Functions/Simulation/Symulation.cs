//using Task9.InputOutputSystem.Interface;
//using Task9.Models;
//using Task9.Models.Context;
//using Task9.Validation;
//using Task9.View;

//namespace Task9.Functions.Simulation
//{
//    public class Symulation : Fleet
//    {
//        private readonly IInput input;
//        private readonly IOutput output;
//        public Symulation(IInput input, IOutput output)
//        {
//            this.input = input;
//            this.output = output;
//        }
//        public void Run()
//        {
//            output.ShowMessage("Tsudzuku");
//        }
//        private void GatherData()
//        {
//            output.ShowMessage("In development");
//        }
//        private void SetNumberOfShips()
//        {
//            int numberOfShips;
//            for (FleetNumber = 1; FleetNumber < 3; FleetNumber++)
//            {
//                numberOfShips = input.GetIntValue("Podaj ilość statków dla " + FleetNumber + ":");
//                SetShipType(numberOfShips, FleetNumber);
//            }
//        }
//        private void SetShipType(int numberOfShips, int fleetNumber)
//        {
//            int id;
//            int availablePoints = 100;
//            int shipValue;
//            for (int index = 0; index < numberOfShips; index++)
//            {
//            Again:
//                bool exit = false;
//                do
//                {
//                    new ShipDisplay(output).GetList();
//                    id = input.GetIntValue("Wybierz ID Statku");
//                    //exit = new ShipRepository(input).CheckIdExists(id);
//                } while (!exit);
//                shipValue = GetShipValue(id);
//                availablePoints -= shipValue;
//                if (availablePoints >= 0)
//                {
//                    output.ShowMessage("Brak punktów by dodać statek");
//                    availablePoints += shipValue;
//                    if (availablePoints < 0)
//                    {
//                        goto Again;
//                    }else
//                    {
//                        break;
//                    }
                    
//                }else
//                {
//                    AddShipToFleet(fleetNumber, id);
//                }
//            }
//        }
//        private int GetShipValue(int id)
//        {
//            Ship = new ShipRepository().GetShip(id);
            
//            return Ship.Turrets;
//        }
//        private void AddShipToFleet(int fleetNumber, int id)
//        {
//            //if (fleetNumber == 1)
//            //{
//            //    Ship = new ShipRepository().GetShip(id);
//            //    ShipTotalDamage = new Fleet().SetTotalDamage(id);
//            //    fleet1.Add(new Fleet { Ship = Ship, ShipTotalDamage = ShipTotalDamage, FleetNumber = fleetNumber});
//            //}
//            //if (fleetNumber == 2)
//            //{
//            //    Ship = new ShipRepository().GetShip(id);
//            //    ShipTotalDamage = new Fleet().SetTotalDamage(id);
//            //    fleet2.Add(new Fleet { Ship = Ship, ShipTotalDamage = ShipTotalDamage, FleetNumber = fleetNumber });
//            //}
//        }
//        private void ChooceMap()
//        {
//            output.ShowMessage("In development");
//        }
//        private void Start()
//        {
//            output.ShowMessage("In development");
//        }
//        private void End()
//        {
//            output.ShowMessage("In development");
//        }
//    }
//}
