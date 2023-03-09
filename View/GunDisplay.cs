using Task9.InputOutputSystem.Interface;
using Task9.View.Interface;
using Task9.Models;

namespace Task9.View
{
    public class GunDisplay : IGunDisplay
    {
        private readonly IOutput output;
        public GunDisplay(IOutput output)
        {
            this.output = output;
        }
        public void DisplayAll(List<Gun> gunList)
        {
            foreach (Gun gun in gunList)
            {
                Display(gun);
            }
        }
        private void Display(Gun gun)
        {
            var info = string.Join(" ", "ID: [" + gun.Id 
                + "]" + "Name: [" + gun.Name
                + "]" + "Barrels: [" + gun.Barrels
                + "]" + "Damage: [" + gun.Damage
                + "]" + "Armor: [" + gun.Armor
                + "]" + "HP: [" + gun.HP);
            output.ShowMessage(info);
        }
    }
}
