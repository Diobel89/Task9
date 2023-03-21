using Task9.Factory;
using Task9.InputOutputSystem.Interface;
using Task9.Models;
using Task9.Models.Context;
using Task9.Models.Context.Interfaces;

namespace Task9.Functions.AddingNew
{
    public class AddingShip : Ship
    {
        private readonly IInput input;
        private readonly IOutput output;
        private readonly IShipRepository _shipRepository;
        public AddingShip(IInput input, IOutput output)
        {
            this.input = input;
            this.output = output;
            _shipRepository = new ShipRepository();
        }
        public void Add()
        {
            using (var shipRepo = _shipRepository)
            {
                Ship ship = new ShipFactory(input, output).Create();
                shipRepo.AddShip(ship);
                shipRepo.Save();
            }
        }
    }
}
