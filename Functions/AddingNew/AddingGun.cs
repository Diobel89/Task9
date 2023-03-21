using Task9.Factory;
using Task9.InputOutputSystem.Interface;
using Task9.Models;
using Task9.Models.Context;
using Task9.Models.Context.Interfaces;

namespace Task9.Functions.AddingNew
{
    public class AddingGun
    {
        private readonly IInput input;
        private readonly IGunRepository _gunRepository;
        public AddingGun(IInput input)
        {
            this.input = input;
            _gunRepository = new GunRepository();
        }
        public void Add()
        {
            using (var gunRepo = _gunRepository)
            {
                Gun gun = new GunFactory(input).Create();
                gunRepo.AddGun(gun);
                gunRepo.Save();
            }
        }
    }
}
