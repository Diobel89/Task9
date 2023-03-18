using System.Collections;
using Task9.InputOutputSystem.Interface;
using Task9.View;

namespace Task9.Functions.Simulation
{
    public class Start
    {
        private readonly IOutput output;
        private readonly List<Fleet> graveyard = new List<Fleet>();
        public Start(IOutput output)
        {
            this.output = output;
        }
        public void Run(List<Fleet> fleet1, List<Fleet> fleet2)
        {
            StartSimulation(fleet1, fleet2);
            Attack(fleet1, fleet2, graveyard);
            //EndSimulation(fleet1, fleet2, graveyard);
        }
        private void StartSimulation(List<Fleet> fleet1, List<Fleet> fleet2)
        {
            output.CleanScreen();
            new SimulationDisplay(output).Display(fleet1, fleet2);
        }
        private void Attack(List<Fleet> fleet1, List<Fleet> fleet2, List<Fleet> graveyard)
        {
            int index = 0;
            bool exit = false;
            do
            {
                if (fleet1.Count() == 0 ^ fleet2.Count == 0)
                {
                    exit = true;
                }else
                {
                    fleet2[index].Ship.HP -= fleet1[index].ShipTotalDamage;

                    if (fleet2[index].Ship.HP == 0 ^ fleet2[index].Ship.HP < 0)
                    {
                        output.ShowMessage(fleet2[index].Ship.Name + " z floty " + fleet2[index].FleetNumber + " został zatopiony przez " + fleet1[index].Ship.Name + " z floty " + fleet1[index].FleetNumber + ", otrzymał " + fleet1[index].ShipTotalDamage + " punktów obrażeń");
                        graveyard.Add(fleet2[index]);
                        fleet2.Remove(fleet2[index]);
                    }else
                    {
                        output.ShowMessage(fleet2[index].Ship.Name + " z floty " + fleet2[index].FleetNumber + " oberwał za: " + fleet1[index].ShipTotalDamage);
                        fleet1[index].Ship.HP -= fleet2[index].ShipTotalDamage;
                        if (fleet1[index].Ship.HP == 0 ^ fleet1[index].Ship.HP < 0)
                        {
                            output.ShowMessage(fleet1[index].Ship.Name + " z floty " + fleet1[index].FleetNumber + " został zatopiony przez " + fleet2[index].Ship.Name + " z floty " + fleet1[index].FleetNumber + ", otrzymał " + fleet2[index].ShipTotalDamage + " punktów obrażeń");
                            graveyard.Add(fleet1[index]);
                            fleet1.Remove(fleet1[index]);
                        }else
                        {
                            output.ShowMessage(fleet1[index].Ship.Name + " z floty " + fleet1[index].FleetNumber + " oberwał za: " + fleet2[index].ShipTotalDamage);
                        }
                    }
                }
            } while (!exit);
            EndSimulation(fleet1, fleet2, graveyard);
        }
        private void EndSimulation(List<Fleet> fleet1, List<Fleet> fleet2, List<Fleet> graveyard)
        {
            if (fleet1.Count < fleet2.Count)
            {
                output.ShowMessage("Wygrywa: " + fleet2[0].FleetNumber);
            }
            else
            {
                output.ShowMessage("Wygrywa: " + fleet1[0].FleetNumber);
            }
        }
    }
}
