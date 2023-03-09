using Task9.Factory;
using Task9.InputOutputSystem.Interface;
using Task9.Models;
using Task9.Models.Context;

namespace Task9.Functions
{
    public class AddingFaction
    {
        private readonly IInput input;
        public AddingFaction(IInput input)
        {
            this.input = input;
        }
        public void Add()
        {
            using (var factionRepo = new FactionRepository())
            {
                Faction faction = new FactionFactory(input).Create();
                //faction.AddFaction(faction);
                //faction.Save();
            }
        }
    }
}
