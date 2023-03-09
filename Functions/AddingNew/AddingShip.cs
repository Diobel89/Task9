using Task9.Factory;
using Task9.InputOutputSystem.Interface;
using Task9.Models;
using Task9.Models.Context;

namespace Task9.Functions
{
    public class AddingShip : Ship
    {
        private readonly IInput input;
        private readonly IOutput output;
        public AddingShip(IInput input)
        {
            this.input = input;
        }
        public void Add()
        {
            using (var shipRepo = new ShipRepository())
            {
                Ship ship = new ShipFactory(input, output).Create();
                shipRepo.AddShip(ship);
                shipRepo.Save();
            }
        }
    }
}
