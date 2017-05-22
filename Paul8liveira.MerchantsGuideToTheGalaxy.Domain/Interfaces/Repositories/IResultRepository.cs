using Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Entities;
using System.Collections.Generic;

namespace Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Interfaces.Repositories
{
    //Interface de repositorio para adicionar metodos especificos para a entidade fora do contrato base
    public interface IResultRepository : IRepositoryBase<Result>
    {
        IEnumerable<Result> GetAll(int id);
    }
}
