using Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Entities;
using Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Paul8liveira.MerchantsGuideToTheGalaxy.Infra.Data.Repositories
{
    //classe concreta herda metodoas da base e implementa (caso necessario) metodos especificos indicados na interface implementada
    public class ResultRepository : RepositoryBase<Result>, IResultRepository
    {
        public IEnumerable<Result> GetAll(int InputId)
        {
            return Db.Set<Result>().Where(w => w.InputId.Equals(InputId));
        }
    }
}
