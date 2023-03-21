using Task9.ErrorCode;
using Task9.InputOutputSystem.Interface;
using Task9.Models.Context;
using Task9.Models.Context.Interfaces;
using Task9.Validation;

namespace Task9.InputOutputSystem
{
    public class Input : IInput
    {
        private readonly IOutput _output;
        private readonly IGunRepository _gunRepository;
        private readonly IShipRepository _shipRepository;
        private readonly IFactionRepository _factionRepository;
        public Input()
        {
            _output = new Output();
            _gunRepository = new GunRepository();
            _shipRepository = new ShipRepository();
            _factionRepository = new FactionRepository();
        }
        public string GetStringValue(string message)
        {
            _output.ShowMessage(message);
            string tempInput = Console.ReadLine();
            return tempInput;
        }
        public int GetIntValue(string message)
        {
            bool isParsable = false;
            int intOut = 0;
            _output.ShowMessage(message);
            string tempInput = Console.ReadLine();
            while (!isParsable)
            {
                isParsable = new Validate().Int(tempInput);
                if (!isParsable)
                {
                    new ErrorCodes(_output).Message(1);
                    _output.ShowMessage(message);
                    tempInput = Console.ReadLine();
                    isParsable = new Validate().Int(tempInput);
                }
                else
                {
                    intOut = int.Parse(tempInput);
                }
            }

            return intOut;
        }
        public int GetId(string fromWhere)
        {
            bool exit = false;
            int id;
            do
            {
                id = GetIntValue("Podaj ID:");
                if (fromWhere == "ship")
                {
                    exit = _shipRepository.CheckIdExists(id);
                    if (exit)
                    {
                        return id;
                    }
                }
                if (fromWhere == "gun")
                {
                    exit = _gunRepository.CheckIdExists(id);
                    if (exit)
                    {
                        return id;
                    }
                }
                if (fromWhere == "faction")
                {
                    exit = _factionRepository.CheckIdExists(id);
                    if (exit)
                    {
                        return id;
                    }
                }
                if (fromWhere == "shiptype")
                {
                    exit = new ShipTypeRepository().CheckIdExists(id);
                    if (exit)
                    {
                        return id;
                    }
                }
                if (fromWhere == "guntype")
                {
                    exit = new GunTypeRepository().CheckIdExists(id);
                    if (exit)
                    {
                        return id;
                    }
                }
            } while (!exit);
            return 0;
        }
    }
}
