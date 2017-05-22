using Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Entities;
using Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Interfaces.Repositories;

namespace Paul8liveira.MerchantsGuideToTheGalaxy.Infra.Data.Repositories
{
    //classe concreta herda metodoas da base e implementa (caso necessario) metodos especificos indicados na interface implementada
    public class InputRepository : RepositoryBase<Input>, IInputRepository
    {
    }
}
