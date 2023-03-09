using Task9.InputOutputSystem.Interface;
using Task9.Models;

namespace Task9.View
{
    public class FactionDisplay
    {
        private readonly IOutput output;
        public FactionDisplay(IOutput output)
        {
            this.output = output;
        }
        public void DisplayAll(List<Faction> factionList)
        {
            foreach (Faction faction in factionList)
            {
                Display(faction);
            }
        }
        private void Display(Faction faction)
        {
            var info = string.Join(" ", "ID: [" + faction.Id
                + "]" + " Name: [" + faction.Name
                + "]" + " Icon: [" + faction.Icon
                + "]");
            output.ShowMessage(info);
        }
    }
}
