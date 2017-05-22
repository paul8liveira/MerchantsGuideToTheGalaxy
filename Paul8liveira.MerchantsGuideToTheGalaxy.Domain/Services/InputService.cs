using Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Entities;
using Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Interfaces.Repositories;
using Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Services
{
    //classe concreta herda metodos da base e implementa (caso necessario) metodos especificos indicados na interface implementada
    public class InputService : ServiceBase<Input>, IInputService
    {
        private readonly IInputRepository _inputRepository;

        public InputService(IInputRepository inputRepository) : base(inputRepository)
        {
            _inputRepository = inputRepository;
        }
    }
}
