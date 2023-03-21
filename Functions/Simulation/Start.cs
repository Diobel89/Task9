using Task9.InputOutputSystem.Interface;
using Task9.View;

namespace Task9.Functions.Simulation
{
    public class Start
    {
        private readonly IOutput output;
        private readonly List<Fleet> graveyard = new List<Fleet>();
        private readonly List<Fleet> fleet1 = new List<Fleet>();
        private readonly List<Fleet> fleet2 = new List<Fleet>();
        public Start(IOutput output, List<Fleet> fleet1, List<Fleet> fleet2)
        {
            this.output = output;
            this.fleet1 = fleet1;
            this.fleet2 = fleet2;
        }
        public void Run()
        {
            StartSimulation();
            Attack();
        }
        private void StartSimulation()
        {
            output.CleanScreen();
            new SimulationDisplay(output).Display(fleet1, fleet2);
        }
        private void Attack()
        {
            int index = 0;
            int turn;
            bool exit = false;
            turn = WhosFirst();
            do
            {
                if (fleet1.Count() == 0 ^ fleet2.Count() == 0)
                {
                    exit = true;
                }else
                {
                    output.ShowInt(turn);
                    if (turn == 0 ^ turn == 3 ^ turn == 4)
                    {
                        fleet2[index].Ship.HP -= fleet1[index].ShipTotalDamage;
                        Fleet1Move();
                        turn = 1;
                    }else
                    {
                        fleet1[index].Ship.HP -= fleet2[index].ShipTotalDamage;
                        Fleet2Move();
                        turn = 0;
                    }
                }
            } while (!exit);
            new End(output, fleet1, fleet2, graveyard).Run();
        }
        private void Fleet1Move()
        {
            int index = 0;
            if (fleet2[index].Ship.HP == 0 ^ fleet2[index].Ship.HP < 0)
            {
                output.ShowMessage(fleet2[index].Ship.Name + " z floty " + fleet2[index].FleetNumber + " został zatopiony przez " + fleet1[index].Ship.Name + " z floty " + fleet1[index].FleetNumber + ", otrzymał " + fleet1[index].ShipTotalDamage + " punktów obrażeń");
                graveyard.Add(fleet2[index]);
                fleet2.Remove(fleet2[index]);
            }
            else
            {
                output.ShowMessage(fleet2[index].Ship.Name + " z floty " + fleet2[index].FleetNumber + " oberwał za: " + fleet1[index].ShipTotalDamage);
            }
        }
        private void Fleet2Move()
        {
            int index = 0;
            if (fleet1[index].Ship.HP == 0 ^ fleet1[index].Ship.HP< 0)
            {
                output.ShowMessage(fleet1[index].Ship.Name + " z floty " + fleet1[index].FleetNumber + " został zatopiony przez " + fleet2[index].Ship.Name + " z floty " + fleet2[index].FleetNumber + ", otrzymał " + fleet2[index].ShipTotalDamage + " punktów obrażeń");
                graveyard.Add(fleet1[index]);
                fleet1.Remove(fleet1[index]);
            }else
            {
                output.ShowMessage(fleet1[index].Ship.Name + " z floty " + fleet1[index].FleetNumber + " oberwał za: " + fleet2[index].ShipTotalDamage);
            }
        }
        private int WhosFirst()
        {
            return new Random().Next(6);
        }
    }
}
