using Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Entities;
using Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Interfaces.Repositories;
using Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Services
{
    //classe concreta herda metodos da base e implementa (caso necessario) metodos especificos indicados na interface implementada
    public class ResultService : ServiceBase<Result>, IResultService
    {
        private readonly IResultRepository _resultRepository;

        public ResultService(IResultRepository resultRepository) : base(resultRepository)
        {
            _resultRepository = resultRepository;
        }

        public IEnumerable<Result> GetAll(int id)
        {
            return _resultRepository.GetAll(id);
        }
    }
}
