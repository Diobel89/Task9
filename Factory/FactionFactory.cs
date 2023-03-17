using Task9.InputOutputSystem.Interface;
using Task9.Factory.Interface;
using Task9.Models;

namespace Task9.Factory
{
    public class FactionFactory : IFactionFactory
    {
        private readonly IInput input;
        public FactionFactory(IInput input)
        {
            this.input = input;
        }
        public Faction Create()
        {
            string name = GetFactionName();
            string icon = GetFactionIcon();
            return new Faction { Name = name, Icon = icon };
        }
        public string GetFactionName()
        {
            return input.GetStringValue("Podaj nazwę frakcji:");
        }
        public string GetFactionIcon()
        {
            return input.GetStringValue("Podaj ikonę frakcji:");
        }
    }
}
