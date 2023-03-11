using Task9.InputOutputSystem.Interface;
using Task9.Models;

namespace Task9.Factory
{
    public class FactionFactory : Faction
    {
        private readonly IInput input;
        public FactionFactory(IInput input)
        {
            this.input = input;
        }
        public Faction Create()
        {
            Name = GetFactionName();
            Icon = GetFactionIcon();
            return new Faction { Name = Name, Icon = Icon };
        }
        public string GetFactionName()
        {
            Name = input.GetStringValue("Podaj nazwę frakcji:");
            return Name;
        }
        public string GetFactionIcon()
        {
            Icon = input.GetStringValue("Podaj ikonę frakcji:");
            return Icon;
        }
    }
}
