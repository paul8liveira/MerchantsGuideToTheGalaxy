using Paul8liveira.MerchantsGuideToTheGalaxy.Application.Interface;
using Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Entities;
using Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Interfaces.Services;

namespace Paul8liveira.MerchantsGuideToTheGalaxy.Application
{
    //classe concreta herda metodos da base e implementa (caso necessario) metodos especificos indicados na interface implementada
    public class InputAppService : AppServiceBase<Input>, IInputAppService
    {
        private readonly IInputService _inputService;

        public InputAppService(IInputService inputService): base(inputService)
        {
            _inputService = inputService;
        }
    }
}
