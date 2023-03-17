using Task9.Factory;
using Task9.InputOutputSystem.Interface;
using Task9.Models;
using Task9.Models.Context;

namespace Task9.Functions.AddingNew
{
    public class AddingGun
    {
        private readonly IInput input;
        public AddingGun(IInput input)
        {
            this.input = input;
        }
        public void Add()
        {
            using (var gunRepo = new GunRepository())
            {
                Gun gun = new GunFactory(input).Create();
                gunRepo.AddGun(gun);
                gunRepo.Save();
            }
        }
    }
}
