using Task9.Factory;
using Task9.InputOutputSystem.Interface;
using Task9.Models;
using Task9.Models.Context;
using Task9.Models.Context.Interfaces;

namespace Task9.Functions.AddingNew
{
    public class AddingFaction
    {
        private readonly IInput input;
        private readonly IFactionRepository _factionRepository;
        public AddingFaction(IInput input)
        {
            this.input = input;
            _factionRepository = new FactionRepository();
        }
        public void Add()
        {
            using (var factionRepo = _factionRepository)
            {
                Faction faction = new FactionFactory(input).Create();
                //faction.AddFaction(faction);
                //faction.Save();
            }
        }
    }
}
