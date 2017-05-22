using Paul8liveira.MerchantsGuideToTheGalaxy.Application.Interface;
using Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Entities;
using Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Paul8liveira.MerchantsGuideToTheGalaxy.Application
{
    //classe concreta herda metodos da base e implementa (caso necessario) metodos especificos indicados na interface implementada
    public class ResultAppService : AppServiceBase<Result>, IResultAppService
    {
        private readonly IResultService _resultService;

        public ResultAppService(IResultService resultService): base(resultService)
        {
            _resultService = resultService;
        }

        public IEnumerable<Result> GetAll(int id)
        {
            return _resultService.GetAll(id);
        }
    }
}
