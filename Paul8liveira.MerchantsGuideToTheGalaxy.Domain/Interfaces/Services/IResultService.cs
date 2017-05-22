using Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Entities;
using System.Collections.Generic;

namespace Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Interfaces.Services
{
    //Interface de repositorio para adicionar metodos especificos para a entidade fora do contrato base
    public interface IResultService : IServiceBase<Result>
    {
        IEnumerable<Result> GetAll(int id);
    }
}
